import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { Modal, Button, Form, Input, notification } from 'antd';
import { registerUser } from '../api/userActions';
import { getUsers } from '../api/userActions';
import { roles } from '../api/constants/roles';


const AddClientModal = () => {
    const dispatch = useDispatch();
    const [visible, setVisible] = useState(false);
    const [confirmLoading, setConfirmLoading] = useState(false);
    const [form] = Form.useForm();

    const showModal = () => {
        setVisible(true);
    };

    const handleOk = () => {
        setConfirmLoading(true);
        form.submit();
    };

    const onFinish = (values) => {
        registerUser(
            values.username,
            values.password,
            roles.client,
            values.email,
            values.name
        )
        .then(result => {
            if (result.isOk){
                setVisible(false);
                notification.success({
                    message: 'Sėkmė!',
                    description: 'Klientas pridėtas sėkmingai'
                });
                getUsers(dispatch);
            }
            setConfirmLoading(false);
        });
    }

    const onFinishFailed = () => {
        setConfirmLoading(false);
    }

    const handleCancel = () => {
        setVisible(false);
    };

    return (
    <>
        <Button
            style={{float: 'right', marginBottom: '5px'}}
            onClick={showModal}
        >
            Pridėti klientą
        </Button>
        <Modal
            title='Pridėti klientą'
            visible={visible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}
            okText='Pridėti'
            cancelText='Atšaukti'
            destroyOnClose={true}
        >
            <Form
                name="basic"
                form={form}
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    label="Prisijungimo vardas"
                    name="username"
                    rules={[{ required: true, message: 'Prisijungimo vardas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Slaptažodis"
                    name="password"
                    rules={[{ required: true, message: 'Slaptažodis yra būtinas' }]}
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    name="confirm"
                    label="Patvirtinkite slaptažodį"
                    dependencies={['password']}
                    hasFeedback
                    rules={[
                        {
                        required: true,
                        message: 'Prašome patvirtinti slaptažodį!',
                        },
                        ({ getFieldValue }) => ({
                        validator(_, value) {
                            if (!value || getFieldValue('password') === value) {
                            return Promise.resolve();
                            }
                            return Promise.reject(new Error('Įvesti slaptažodžiai nesutampa!'));
                        },
                        }),
                    ]}
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    label="Pavadinimas"
                    name="name"
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="El. Paštas"
                    name="email"
                >
                    <Input />
                </Form.Item>
            </Form>
        </Modal>
    </>
    );
};

export default AddClientModal;