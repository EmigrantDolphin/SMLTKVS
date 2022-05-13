import { useState } from 'react';
import { Form, DatePicker, Button, Input, notification } from 'antd';
import ClientAutoComplete from '../../components/ClientAutoComplete';
import moment from 'moment';
import { getLoggedInUser } from '../../api/userActions';
import ConcreteTrialTable from '../../components/ConcreteTrialTable';
import { createConcreteCubeTest } from '../../api/concreteCubeTestActions';
import { testTypes } from '../../api/constants/testTypes';
import { concreteTypes } from '../../api/constants/concreteTypes';

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

const ConcreteTrial = () => {
    const [isSendingRequest, setIsSendingRequest] = useState(false);

    const onFinish = (values) => {
        const averageStrength = calculateAverageStrength(values.testData);
        const standardDeviation = calculateStandardDeviation(values.testData, averageStrength);
        console.log(standardDeviation);

        console.log('Success:', values);
        const postObject = {
            clientCompanyId: '543c1d38-5f3d-473f-b73b-87f9bcc02041', // select from available companies
            employeeCompanyId: '543c1d38-5f3d-473f-b73b-87f9bcc02042', // select current employee company
            testExecutionDate: values.testExecutionDate,
            testSamplesReceivedDate: values.testSamplesReceivedDate,
            testSamplesReceivedBy: 'Vykdytojas', // ['Uzsakovas', 'Uzsakovo igaliotas atstovas', 'Vykdytojas']
            testSamplesReceivedComment: 'Bandiniai atvezti yara yara from .tex', // move to input field
            testSamplesReceivedCount: 6, // from input
            testExecutedByUserId: '543c1d38-5f3d-473f-b73b-87f9bcc02043', // get from localhost
            protocolCreatedByUserId: '543c1d38-5f3d-473f-b73b-87f9bcc02043', // get from localhost
            testType: testTypes.INITIAL, // from dropdown select
            concreteType: concreteTypes.LIGHT, // from dropdown select
            acceptedSampleCount: 3, // based on testType selection
            rejectedSampleCount: 3, // input
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
        
        setIsSendingRequest(true);
        createConcreteCubeTest(postObject)
            .then(response => {
                setIsSendingRequest(false);
                if (response.isOk) {
                    notification.success({
                        message: 'Sėkmė!',
                        description: 'Bandymas atliktas sėkmingai'
                    });
                }
            });
    };

    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <Form
            name='basic'
            style={{marginTop:100}}
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 4 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete='off'
        >
            <Form.Item
                label='Užsakovas'
                name='clientId'
                rules={[{ required: true, message: 'Prašome pasirinkti klientą iš sąrašo' }]}
            >
                <ClientAutoComplete />
            </Form.Item>

            <Form.Item
                label='Bandinių gavimo/pristatymo data'
                name='testSamplesReceivedDate'
                rules={[{ required: true, message: 'Pasirinkite bandinių gavimo datą' }]}
            >
                <DatePicker showTime />
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
                initialValue={getLoggedInUser().username}
                rules={[{ required: true, message: 'Įveskite bandytojo vardą' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item
                name='testData'
                style={{
                    width: '700px',
                    margin: '10px auto'
                }}
                >
                <ConcreteTrialTable />
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

export default ConcreteTrial;