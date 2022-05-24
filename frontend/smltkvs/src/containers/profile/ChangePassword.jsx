import React, { useState } from 'react';
import { Form, Input, Button, notification } from 'antd';
import { changePassword } from '../../api/userActions';
import { useNavigate } from 'react-router-dom';
import { routes } from '../../routes';

const ChangePassword = () => {
    const navigate = useNavigate();
    const [isLoading, setIsLoading] = useState(false);

    const onFinish = (values) => {
        setIsLoading(true);
        changePassword(values.password)
            .then(resp => {
                setIsLoading(false);
                if (resp.isOk) {
                    navigate(routes.home);
                    notification({
                        message: 'Sėkmė',
                        description: 'Slaptažodis pakeistas sėkmingai'
                    });
                }
            });
    };

    return (
        <Form
            style={{marginTop:100}}
            name="basic"
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 6 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            autoComplete="off"
        >
            <Form.Item
                label="Slaptažodis"
                name="password"
                rules={[{ required: true, message: 'Prašome įvesti prisijungimo slaptažodį!' }]}
            >
                <Input.Password />
            </Form.Item>

            <Form.Item
                name='confirm'
                label='Patvirtinkite slaptažodį'
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

            <Form.Item wrapperCol={{ offset: 8, span: 8 }}>
                <Button
                    type="primary"
                    htmlType="submit"
                    loading={isLoading}
                >
                    Pakeisti
                </Button>
            </Form.Item>
        </Form>
    );
}

export default ChangePassword;