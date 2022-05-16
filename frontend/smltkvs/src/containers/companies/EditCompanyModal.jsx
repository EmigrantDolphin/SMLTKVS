import { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Modal, Form, Input, notification, Button } from 'antd';
import { getCompanies, updateCompany } from '../../api/companyActions';


const EditCompanyModal = ({values, isVisible, onModalCancel}) => {
    const [confirmLoading, setConfirmLoading] = useState(false);
    const [form] = Form.useForm();
    const [addedConstructionSitesCount, setAddedConstructionSitesCount] = useState(0);
    const dispatch = useDispatch();

    const handleOk = () => {
        setConfirmLoading(true);
        form.submit();
    };

    const onFinish = (values) => {
        updateCompany(values)
            .then(res => {
                if (res.isOk) {
                    notification.success({
                        message: 'Sekmė!',
                        description: 'Įmonės duomenys atnaujinti sėkmingai'
                    });
                    getCompanies(dispatch).then(() => handleCancel());
                }
                setConfirmLoading(false);
            })
    }

    const onFinishFailed = () => {
        setConfirmLoading(false);
    }

    const handleCancel = () => {
        setAddedConstructionSitesCount(0);
        onModalCancel();
    }

    const getConstructionSiteFields = (siteCount) => {
        return Array(siteCount).fill().map((_, index) => {
            return (
                <div key={index}>
                    <Form.Item
                        name={['constructionSites', index, 'constructionSiteId']}
                        style={{display: 'none'}}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        key={`constructionSiteName_${index}`}
                        label="Pavadinimas"
                        name={['constructionSites', index, 'name']}
                        rules={[{ required: true, message: 'Pavadinimas yra būtinas' }]}
                        style={{marginBottom:'0px'}}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        key={`constructionSiteAddress_${index}`}
                        label="Adresas"
                        rules={[{ required: true, message: 'Adresas yra būtinas' }]}
                        name={['constructionSites', index, 'address']}
                    >
                        <Input />
                    </Form.Item>
                </div>
            )
        });
    }

    useEffect(() => {
        form.setFieldsValue(values);
    }, [form, values])

    const presentConstructionSites = values?.constructionSites?.length ? values.constructionSites.length : 0;
    return (
    <>
        <Modal
            title='Įmonės duomenų atnaujinimas'
            visible={isVisible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}
            okText='Atnaujinti'
            cancelText='Atšaukti'
            destroyOnClose={true}
        >
            <Form
                name="basic"
                form={form}
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                initialValues={values}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    name="companyId"
                    style={{display:'none'}}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Pavadinimas"
                    name="name"
                    rules={[{ required: true, message: 'Pavadinimas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Adresas"
                    name="address"
                    rules={[{ required: true, message: 'Adresas yra būtinas' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Įmonės kodas"
                    name="companyCode"
                >
                    <Input />
                </Form.Item>
                Imones objektai
                {getConstructionSiteFields(presentConstructionSites + addedConstructionSitesCount)}

                <Button onClick={() => setAddedConstructionSitesCount(addedConstructionSitesCount + 1)}>
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

export default EditCompanyModal;