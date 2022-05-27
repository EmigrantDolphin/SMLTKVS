import { useState } from 'react';
import { Form, DatePicker, Button, Input, notification, Select, InputNumber } from 'antd';
import CompanyAutoComplete from '../../components/CompanyAutoComplete';
import moment from 'moment';
import { getLoggedInUser } from '../../api/userActions';
import ConcreteTrialTable from '../../components/ConcreteTrialTable';
import { createConcreteCubeTest, getConcreteCubeTestCrushForces } from '../../api/concreteCubeTestActions';
import { testTypes } from '../../api/constants/testTypes';
import { concreteTypes } from '../../api/constants/concreteTypes';
import { routes } from '../../routes';
import { useNavigate } from 'react-router-dom';
import {
    concreteCubeCalculateAverageStrength,
    concreteCubeCalculateStandardDeviation,
    concreteCubeCalculateInitialTestCharacteristicStrength,
    concreteCubeCalculatePermanentTestCharacteristicStrength,
    concreteCubeCalculateConcreteClass
} from '../../calculations/concreteCubeCalculations';
import { useDispatch, useSelector } from 'react-redux';
import { useEffect } from 'react';
const { Option } = Select;

const ConcreteCubeTrial = () => {
    const dispatch = useDispatch();
    const constructionSiteTestCrushForces = useSelector(state => state.concreteCubeTestCrushForces.value);
    const [isSendingRequest, setIsSendingRequest] = useState(false);
    const [acceptedSampleCount, setAcceptedSampleCount] = useState(1);
    const [selectedCompany, setSelectedCompany] = useState(null);
    const [form] = Form.useForm();
    const navigate = useNavigate();
    const currentUser = getLoggedInUser();

    const onFinish = (values) => {
        let crushForces = null
        let standardDeviation = null;
        let characteristicStrength = null;

        if (values.testType === testTypes.INITIAL) {
            crushForces = values.testData.map(x => Number(x.strength));
        } else {
            crushForces = [...constructionSiteTestCrushForces];
            values.testData.forEach(x => crushForces.push(Number(x.strength)));
        }

        const averageStrength = concreteCubeCalculateAverageStrength(crushForces);

        if (values.testType === testTypes.INITIAL) {
            characteristicStrength = concreteCubeCalculateInitialTestCharacteristicStrength(crushForces, averageStrength);
        }
        else {
            standardDeviation = concreteCubeCalculateStandardDeviation(crushForces, averageStrength);
            characteristicStrength = concreteCubeCalculatePermanentTestCharacteristicStrength(crushForces, averageStrength, standardDeviation);
        }
        const concreteRating = concreteCubeCalculateConcreteClass(characteristicStrength);

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
            standardUncertainty: null, // not implemented
            extendedUncertainty: null, // not implemented
            standardDeviation: standardDeviation,
            characteristicStrength: characteristicStrength,
            concreteRating: concreteRating,
            testData: values.testData.map(x => {
                console.log(x);
                return {
                    comment: x.comments,
                    destructivePower: x.destructivePower,
                    crushingStrength: x.strength,
                    valueA: x.valueA.values,
                    valueB: x.valueB.values
                }
            })
        };
        
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

    const changeSelectedCompany = (company) => {
        form.setFieldsValue({clientConstructionSiteId: null});
        setSelectedCompany(company);
    };

    const onConstructionSiteSelect = (constructionSiteId) => {
        getConcreteCubeTestCrushForces(dispatch, constructionSiteId);
    };

    useEffect(() => {
        if (constructionSiteTestCrushForces.length >= 35) {
            form.setFieldsValue({acceptedSampleCount: 1, testType: testTypes.PERMANENT, testData: undefined})
            setAcceptedSampleCount(1);
        }
        else {
            form.setFieldsValue({acceptedSampleCount: 3, testType: testTypes.INITIAL, testData: undefined})
            setAcceptedSampleCount(3);
        }
    }, [constructionSiteTestCrushForces, form, setAcceptedSampleCount]);

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
                <Select
                    disabled={!selectedCompany}
                    onSelect={(id) => onConstructionSiteSelect(id)}
                >
                    {selectedCompany && selectedCompany.constructionSites?.map((site, index) => 
                        <Option
                            key={index}
                            value={site.constructionSiteId}
                        >
                            {site.name}
                        </Option>
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
                <InputNumber min={0} />
            </Form.Item>

            <Form.Item
                label='Bandymo tipas'
                name='testType'
                rules={[{ required: true }]}
            >
                <Select
                    disabled
                    showArrow={false}
                >
                    <Option value={testTypes.INITIAL}><span style={{color:'black'}}>Pradinis</span></Option>
                    <Option value={testTypes.PERMANENT}><span style={{color:'black'}}>Nuolatinis</span></Option>
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
                <InputNumber min={0} />
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
                    Saugoti
                </Button>
            </Form.Item>
        </Form>
    );
};

export default ConcreteCubeTrial;