import { Form, DatePicker, Button, Input } from 'antd';
import ClientAutoComplete from '../../../components/ClientAutoComplete';
import moment from 'moment';
import { getLoggedInUser } from '../../../api/userActions';

const ConcreteTrial = () => {
    const [form] = Form.useForm();
    const onFinish = (values) => {
        console.log('Success:', values);
    };

    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <Form
            name="basic"
            style={{marginTop:100}}
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 4 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
            form={form}
        >
            <Form.Item
                label="Užsakovas"
                name="clientId"
                rules={[{ required: true, message: 'Prašome pasirinkti klientą iš sąrašo' }]}
            >
                <ClientAutoComplete form={form} />
            </Form.Item>

            <Form.Item
                label="Bandinių gavimo/pristatymo data"
                name="sampleArrivalDate"
                rules={[{ required: true, message: 'Pasirinkite bandinių gavimo datą' }]}
            >
                <DatePicker showTime />
            </Form.Item>

            <Form.Item
                label="Bandymo data"
                name="testDate"
                initialValue={moment()}
                rules={[{ required: true, message: 'Pasirinkite bandymo atlikimo datą' }]}
            >
                <DatePicker showTime />
            </Form.Item>

            <Form.Item
                label="Bandytojas"
                name="testUserName"
                initialValue={getLoggedInUser().username}
                rules={[{ required: true, message: 'Įveskite bandytojo vardą' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 10, span: 4 }}>
                <Button type="primary" htmlType="submit">
                    Submit
                </Button>
            </Form.Item>
        </Form>
    );
};

export default ConcreteTrial;