import { useState } from 'react';
import { Modal, Form, Input, notification, Button } from 'antd';
import { createCompany } from '../../api/companyActions';


const AddCompanyModal = () => {
    const [form] = Form.useForm();
    const [confirmLoading, setConfirmLoading] = useState(false);
    const [visible, setVisible] = useState(false);
    const [addedConstructionSitesCount, setAddedConstructionSitesCount] = useState(0);

    const handleOk = () => {
        setConfirmLoading(true);
        form.submit();
    };

    const onFinish = (values) => {
        createCompany(values)
            .then(res => {
                if (res.isOk) {
                    notification.success({
                        message: 'Sėkmė!',
                        description: 'Įmonė išsaugota sėkmingai'
                    });
                }
                setConfirmLoading(false);
            })
    }

    const onFinishFailed = () => {
        setConfirmLoading(false);
    }

    const handleCancel = () => {
        setAddedConstructionSitesCount(0);
        setVisible(false);
    }

    const getConstructionSiteFields = (siteCount) => {
        return Array(siteCount).fill().map((_, index) => {
            return (
                <>
                    <Form.Item
                        key={`constructionSiteName_${index}`}
                        label='Pavadinimas'
                        name={['constructionSites', index, 'name']}
                        rules={[{ required: true, message: 'Pavadinimas yra būtinas' }]}
                        style={{marginBottom:'0px'}}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        key={`constructionSiteAddress_${index}`}
                        label='Adresas'
                        rules={[{ required: true, message: 'Adresas yra būtinas' }]}
                        name={['constructionSites', index, 'address']}
                    >
                        <Input />
                    </Form.Item>
                </>
            )
        });
    }

    return (
    <>
        <Button
            style={{float: 'right', marginBottom: '5px'}}
            onClick={() => setVisible(true)}
        >
            Pridėti
        </Button>
        <Modal
            title='Įmonės pridėjimas'
            visible={visible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}
            okText='Išsaugoti'
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
                    label='Pavadinimas'
                    name='name'
                    rules={[{ required: true, message: 'Pavadinimas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label='Adresas'
                    name='address'
                    rules={[{ required: true, message: 'Adresas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label='Įmonės kodas'
                    name='companyCode'
                    rules={[{ required: true, message: 'Įmonės kodas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>
                Imones objektai
                {getConstructionSiteFields(addedConstructionSitesCount)}

                <Button
                    onClick={() => setAddedConstructionSitesCount(addedConstructionSitesCount + 1)}
                    style={{marginLeft: '5px'}}
                >
                    Pridėti objektą
                </Button>

                {addedConstructionSitesCount > 0 && (
                    <Button
                        onClick={() => setAddedConstructionSitesCount(addedConstructionSitesCount - 1)}
                        style={{marginLeft: '5px'}}
                    >
                        Pašalinti objektą
                    </Button>
                )}

            </Form>
        </Modal>
    </>
    );
};

export default AddCompanyModal;