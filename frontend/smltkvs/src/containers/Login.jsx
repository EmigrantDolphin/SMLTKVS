import React from 'react';
import { Form, Input, Button, Checkbox } from 'antd';

const Login = () => {
    const onFinish = (values) => {
        console.log('Success:', values);
    };

    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <Form
            style={{marginTop:100}}
            name="basic"
            labelCol={{ span: 10 }}
            wrapperCol={{ span: 4 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
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
                <Button type="primary" htmlType="submit">
                    Prisijungti
                </Button>
            </Form.Item>
        </Form>
    )
}

export default Login;