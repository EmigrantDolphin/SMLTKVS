import { Form, DatePicker, Button, Input } from 'antd';
import ClientAutoComplete from '../../../components/ClientAutoComplete';
import moment from 'moment';
import { getLoggedInUser } from '../../../api/userActions';
import ConcreteTrialTable from '../../../components/ConcreteTrialTable';

const calculateAverageStrength = (data) => {
    const strengths = data.map(x => Number(x.strength));
    const sumOfStrengths = strengths.reduce((a, b) => a + b, 0);
    const average = sumOfStrengths / data.length;

    return average;
}

const calculateStandardDeviation = (data, averageStrength) => {
    const strengths = data.map(x => Number(x.strength));
    let sq = strengths.reduce((sum, strength) => sum + ((strength - averageStrength) * (strength - averageStrength)));
    sq = sq / (data.length - 1); // todo: if 1 test, this will divide by 0?????

    const s = Math.sqrt(sq);
    return s;
}

const ConcreteTrial = () => {
    const onFinish = (values) => {
        const averageStrength = calculateAverageStrength(values.testData);
        const standardDeviation = calculateStandardDeviation(values.testData, averageStrength);
        console.log(standardDeviation);

        console.log('Success:', values);
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
                name='sampleArrivalDate'
                rules={[{ required: true, message: 'Pasirinkite bandinių gavimo datą' }]}
            >
                <DatePicker showTime />
            </Form.Item>

            <Form.Item
                label='Bandymo data'
                name='testDate'
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
                <Button type='primary' htmlType='submit'>
                    Submit
                </Button>
            </Form.Item>
        </Form>
    );
};

export default ConcreteTrial;