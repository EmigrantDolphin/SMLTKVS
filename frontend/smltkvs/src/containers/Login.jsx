import React, { useState } from 'react';
import { Form, Input, Button, Checkbox } from 'antd';
import { loginUser } from '../api/userActions';
import { useNavigate } from 'react-router-dom';
import { routes } from '../routes';

const Login = () => {
    const navigate = useNavigate();
    const [isLoading, setIsLoading] = useState(false);

    const onFinish = (values) => {
        setIsLoading(true);
        loginUser(values.username, values.password)
            .then(loggedIn => {
                setIsLoading(false);
                if (loggedIn)
                    navigate(routes.home);
            });
    };

    return (
        <Form
            style={{marginTop:100}}
            name="basic"
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 4 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            autoComplete="off"
        >
            <Form.Item
                label="Prisijungimo vardas"
                name="username"
                rules={[{ required: true, message: 'Prašome įvesti prisijungimo vardą!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item
                label="Slaptažodis"
                name="password"
                rules={[{ required: true, message: 'Prašome įvesti prisijungimo slaptažodį!' }]}
            >
                <Input.Password />
            </Form.Item>

            <Form.Item name="remember" valuePropName="checked" wrapperCol={{ offset: 8, span: 8 }}>
                <Checkbox>Prisiminti mane</Checkbox>
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 8, span: 8 }}>
                <Button
                    type="primary"
                    htmlType="submit"
                    loading={isLoading}
                >
                    Prisijungti
                </Button>
            </Form.Item>
        </Form>
    );
}

export default Login;