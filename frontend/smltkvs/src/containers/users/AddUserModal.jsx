import { useState } from 'react';
import { Modal, Button, Form, Input, notification, Select } from 'antd';
import { getLoggedInUser, registerUser } from '../../api/userActions';
import { roles } from '../../api/constants/roles';
import CompanyAutoComplete from '../../components/CompanyAutoComplete';
const { Option } = Select;


const getOptionsByCurrentUserRole = (currentUserRole) => {
  if (currentUserRole === roles.admin)
    return (
      <>
        <Option value={roles.admin}>Administorius</Option>
        <Option value={roles.employee}>Darbuotojas</Option>
        <Option value={roles.client}>Klientas</Option>
        <Option value={roles.clientAdmin}>Klientas administratorius</Option>
      </>
    );

  if (currentUserRole === roles.employee || currentUserRole === roles.clientAdmin)
    return (
      <>
        <Option value={roles.client}>Klientas</Option>
        <Option value={roles.clientAdmin}>Klientas administratorius</Option>
      </>
    );
}

const AddUserModal = ({ currentUserRole, onSuccess }) => {
    const [visible, setVisible] = useState(false);
    const [isCompanySelectionRequired, setIsCompanyRequired] = useState(false);
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
        const companyId = isCompanySelectionRequired ? values.companyid : getLoggedInUser().companyId;

        registerUser(
            values.username,
            values.password,
            values.role,
            companyId,
            values.email,
            values.name
        )
        .then(result => {
            if (result.isOk){
                setVisible(false);
                notification.success({
                    message: 'Sėkmė!',
                    description: 'Naudotojas pridėtas sėkmingai'
                });
                onSuccess();
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

    const onRoleSelected = (role) => {
        if ((currentUserRole === roles.admin || currentUserRole === roles.employee) && (role === roles.client || role === roles.clientAdmin)) {
            setIsCompanyRequired(true);
        }
        else {
            setIsCompanyRequired(false);
        }
    }

    return (
    <>
        <Button
            style={{float: 'right', marginBottom: '5px'}}
            onClick={showModal}
        >
            Pridėti naudotoją
        </Button>
        <Modal
            title='Sukurti naudotoją'
            visible={visible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}
            okText='Pridėti'
            cancelText='Atšaukti'
            destroyOnClose={true}
        >
            <Form
                name='basic'
                form={form}
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete='off'
            >
                <Form.Item
                    label='Prisijungimo vardas'
                    name='username'
                    rules={[{ required: true, message: 'Prisijungimo vardas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label='Rolė'
                    name='role'
                    rules={[{required: true, message: 'Privalote pasirinkti rolę'}]}
                >
                    <Select onChange={onRoleSelected}>
                        {getOptionsByCurrentUserRole(currentUserRole)}
                    </Select>
                </Form.Item>

                {isCompanySelectionRequired && (
                    <Form.Item
                        label='Įmonė'
                        name='companyid'
                        rules={[{required: true, message: 'Privalote pasirinkti įmonę'}]}
                    >
                        <CompanyAutoComplete />
                    </Form.Item>
                )}

                <Form.Item
                    label='Slaptažodis'
                    name='password'
                    rules={[{ required: true, message: 'Slaptažodis yra būtinas' }]}
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

                <Form.Item
                    label='Pavadinimas'
                    name='name'
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label='El. Paštas'
                    name='email'
                >
                    <Input />
                </Form.Item>
            </Form>
        </Modal>
    </>
    );
};

export default AddUserModal;