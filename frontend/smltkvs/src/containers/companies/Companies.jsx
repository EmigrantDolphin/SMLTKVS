import { Card, Button } from 'antd';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getCompanies } from '../../api/companyActions';
import AddCompanyModal from './AddCompanyModal';
import EditCompanyModal from './EditCompanyModal';

const getCompanyInfoRow = (paramName, param, withColon = true, index = undefined) => {
    return (
        <tr key={index}>
            <td style={{textAlign:'left'}}>{paramName}</td>
            <td style={{textAlign:'left'}}>{withColon && ': '}{param}</td>
        </tr>
    );
}


const Companies = () => {
    const [editedCompanyData, setEditedCompanyData] = useState(null);
    const dispatch = useDispatch();
    const companies = useSelector((state) => state.companies.value);

    useEffect(() => {
        getCompanies(dispatch);
    }, [dispatch]);

    const getViewCard = (values, index) => {
        return (
            <Card
                type="inner"
                key={index}
                style={{marginBottom: '5px'}}
                extra={
                    <Button
                        onClick={() => setEditedCompanyData({...values})}
                        size='small'
                    >
                        Redaguoti
                    </Button>}
            >
                <table>
                    <tbody>
                        {getCompanyInfoRow('Pavadinimas', values.name)}
                        {getCompanyInfoRow('Adresas', values.address)}
                        {getCompanyInfoRow('Imonės kodas', values.companyCode)}
                        {getCompanyInfoRow('Statybų objektai', '')}
                        {values.constructionSites.map((site, index) => {
                            return getCompanyInfoRow('', `* ${site.name}, ${site.address}`, false, index);
                        })}

                    </tbody>
                </table>
            </Card>
        )
    }

    return (
        <Card
            title={
                <>
                    Įmonės
                    <AddCompanyModal />
                </>
            }
        >
            <EditCompanyModal
                isVisible={editedCompanyData !== null}
                onModalCancel={() => setEditedCompanyData(null)}
                values={editedCompanyData}
            />
            {companies.map((item, index) => getViewCard(item, index))}
        </Card>
    )
};

export default Companies;