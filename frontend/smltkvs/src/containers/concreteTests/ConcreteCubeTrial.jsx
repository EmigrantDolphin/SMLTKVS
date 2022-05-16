import { useState } from 'react';
import { Form, DatePicker, Button, Input, notification, Select, InputNumber } from 'antd';
import CompanyAutoComplete from '../../components/CompanyAutoComplete';
import moment from 'moment';
import { getLoggedInUser } from '../../api/userActions';
import ConcreteTrialTable from '../../components/ConcreteTrialTable';
import { createConcreteCubeTest } from '../../api/concreteCubeTestActions';
import { testTypes } from '../../api/constants/testTypes';
import { concreteTypes } from '../../api/constants/concreteTypes';
import { routes } from '../../routes';
import { useNavigate } from 'react-router-dom';
const { Option } = Select;

const calculateAverageStrength = (data) => {
    const strengths = data.map(x => Number(x.strength));
    const sumOfStrengths = strengths.reduce((a, b) => a + b, 0);
    const average = sumOfStrengths / data.length;

    return average;
}

const calculateStandardDeviation = (data, averageStrength) => {
    const strengths = data.map(x => Number(x.strength));
    let sq = strengths.reduce((sum, strength) => sum + ((strength - averageStrength) * (strength - averageStrength)));
    sq = sq / (data.length /*- 1*/); // todo: if 1 test, this will divide by 0?????

    const s = Math.sqrt(sq);
    return s;
}

const ConcreteCubeTrial = () => {
    const [isSendingRequest, setIsSendingRequest] = useState(false);
    const [acceptedSampleCount, setAcceptedSampleCount] = useState(1);
    const [selectedCompany, setSelectedCompany] = useState(null);
    const [form] = Form.useForm();
    const navigate = useNavigate();
    const currentUser = getLoggedInUser();

    const onFinish = (values) => {
        const averageStrength = calculateAverageStrength(values.testData);
        const standardDeviation = calculateStandardDeviation(values.testData, averageStrength);
        console.log(standardDeviation);

        console.log('Success:', values);
        const postObject = {
            clientCompanyId: values.companyid,
            clientConstructionSiteId: values.clientConstructionSiteId,
            employeeCompanyId: currentUser.CompanyId,
            testExecutionDate: values.testExecutionDate,
            testSamplesReceivedDate: values.testSamplesReceivedDate,
            testSamplesDeliveredBy: values.testSamplesDeliveredBy,
            testSamplesReceivedComment: values.testSamplesReceivedComment,
            testSamplesReceivedCount: values.testSamplesReceivedCount,
            testExecutedByUserId: currentUser.userId,
            protocolCreatedByUserId: currentUser.userId,
            testType: values.testType,
            concreteType: values.concreteType,
            acceptedSampleCount: values.acceptedSampleCount,
            rejectedSampleCount: values.rejectedSampleCount,
            averageCrushForce: averageStrength,
            standardUncertainty: 1, //ask Zabulionis
            extendedUncertainty: 1, //ask Zabulionis
            standardDeviation: standardDeviation,
            characteristicStrength: 3, //calculation present but ask Zabulionis which one to use
            concreteRating: 'C30/30', // explanation in .tex
            testData: values.testData.map(x => {
                return {
                    comment: x.comment,
                    destructivePower: x.destructivePower,
                    crushingStrength: x.strength,
                    valueA: x.valueA.values,
                    valueB: x.valueB.values
                }
            })
        };
        console.log('post object:', postObject);
        
        setIsSendingRequest(true);
        createConcreteCubeTest(postObject)
            .then(response => {
                setIsSendingRequest(false);
                if (response.isOk) {
                    notification.success({
                        message: 'Sėkmė!',
                        description: 'Bandymas atliktas sėkmingai'
                    });
                    navigate(routes.home);
                }
            });
    };

    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    const changeAcceptedSampleCount = (selectedTestType, form) => {
        if (selectedTestType === testTypes.INITIAL) {
            form.setFieldsValue({acceptedSampleCount: 3, testData: undefined})
            setAcceptedSampleCount(3);
        }
        else {
            form.setFieldsValue({'acceptedSampleCount': 1, testData: undefined})
            setAcceptedSampleCount(1);
        }
    }

    const changeSelectedCompany = (company) => {
        form.setFieldsValue({clientConstructionSiteId: null});
        setSelectedCompany(company);
    };

    return (
        <Form
            name='basic'
            style={{marginTop:100}}
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 4 }}
            form={form}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete='off'
        >
            <Form.Item
                label='Užsakovas'
                name='companyid'
                rules={[{ required: true, message: 'Prašome pasirinkti kliento įmonę iš sąrašo' }]}
            >
                <CompanyAutoComplete onCompanySelect={(company) => changeSelectedCompany(company)}/>
            </Form.Item>

            <Form.Item
                label='Užsakovo statybos objektas'
                name='clientConstructionSiteId'
                rules={[{ required: true }]}
            >
                <Select disabled={!selectedCompany} >
                    {selectedCompany && selectedCompany.constructionSites?.map((site, index) => 
                        <Option key={index} value={site.constructionSiteId}>{site.name}</Option>
                    )}
                </Select>
            </Form.Item>

            <Form.Item
                label='Bandinių gavimo/pristatymo data'
                name='testSamplesReceivedDate'
                rules={[{ required: true, message: 'Pasirinkite bandinių gavimo datą' }]}
            >
                <DatePicker showTime />
            </Form.Item>

            <Form.Item
                label='Bandinius pristatė'
                name='testSamplesDeliveredBy'
                rules={[{ required: true }]}
            >
                <Select>
                    <Option value='Užsakovas'></Option>
                    <Option value='Užsakovo įgaliotas atstovas'></Option>
                    <Option value='Vykdytojas'></Option>
                </Select>
            </Form.Item>

            <Form.Item
                label='Bandinių pristatymo komentaras'
                name='testSamplesReceivedComment'
                rules={[{ required: true }]}
                initialValue='Bandiniai atvežti tinkamai supakuoti, apsaugota nuo drėgmės išgaravimo, bandinių geometrija ir matmenys vizualiai atitinka reikalavimus.'
            >
                <Input.TextArea />
            </Form.Item>

            <Form.Item
                label='Pristatytų bandinių kiekis'
                name='testSamplesReceivedCount'
                rules={[{ required: true }]}
            >
                <InputNumber />
            </Form.Item>

            <Form.Item
                label='Bandymo tipas'
                name='testType'
                rules={[{ required: true }]}
                initialValue={1}
            >
                <Select onChange={(selectedType) => changeAcceptedSampleCount(selectedType, form)}>
                    <Option value={testTypes.INITIAL}>Pradinis</Option>
                    <Option value={testTypes.PERMANENT}>Nuolatinis</Option>
                </Select>
            </Form.Item>

            <Form.Item
                label='Išbandytos imties dydis'
                name='acceptedSampleCount'
                initialValue={1}
                rules={[{ required: true }]}
            >
                <InputNumber disabled style={{color:'black'}} />
            </Form.Item>

            <Form.Item
                label='Išbrokuotų kubelių kiekis'
                name='rejectedSampleCount'
            >
                <InputNumber />
            </Form.Item>

            <Form.Item
                label='Betono tipas'
                name='concreteType'
                rules={[{ required: true }]}
                initialValue={0}
            >
                <Select>
                    <Option value={concreteTypes.HEAVYANDNORMAL}>Sunkusis/normalusis</Option>
                    <Option value={concreteTypes.LIGHT}>Lengvasis</Option>
                </Select>
            </Form.Item>

            <Form.Item
                label='Bandymo data'
                name='testExecutionDate'
                initialValue={moment()}
                rules={[{ required: true, message: 'Pasirinkite bandymo atlikimo datą' }]}
            >
                <DatePicker showTime />
            </Form.Item>

            <Form.Item
                label='Bandytojas'
                name='testUserName'
                initialValue={currentUser.username}
                rules={[{ required: true, message: 'Įveskite bandytojo vardą' }]}
            >
                <Input disabled style={{color: 'black'}}/>
            </Form.Item>

            <Form.Item
                name='testData'
                style={{
                    width: '700px',
                    margin: '10px auto'
                }}
                >
                <ConcreteTrialTable acceptedSampleCount={acceptedSampleCount} />
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 10, span: 4 }}>
                <Button
                    type='primary'
                    htmlType='submit'
                    loading={isSendingRequest}
                >
                    Submit
                </Button>
            </Form.Item>
        </Form>
    );
};

export default ConcreteCubeTrial;