import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AutoComplete } from 'antd';
import { getCompanies } from '../api/companyActions';

const getOptions = (companies) => {
    return companies.map((company, index) => {
        return {
            value: `${index}. ${company.name}`,
            companyid: company.companyId
        };
    });
}


const CompanyAutoComplete = (props) => {
    const dispatch = useDispatch();
    var companies = useSelector(state => state.companies.value);
    const [options, setOptions] = useState(getOptions(companies));

    const onSelect = (data) => {
        if (props.onCompanySelect) {
            const companyData = companies.find(x => x.companyId === data.companyid);
            props.onCompanySelect(companyData);
        }
        props.onChange(data.companyid);
    };

    const onSearch = (companies, searchText) => {
        const filteredCompanies = companies.filter(company => {
            return company.name.includes(searchText);
        })
        .slice(0, 10);

        setOptions(getOptions(filteredCompanies));
    }

    useEffect(() => {
        getCompanies(dispatch);
    }, [dispatch])

    return (
        <>
            <AutoComplete
                options={options}
                onSearch={(searchText) => onSearch(companies, searchText)}
                style={{
                    width: 200,
                }}
                onSelect={(_, data) => onSelect(data)}
            />
        </>
    );
};

export default CompanyAutoComplete;