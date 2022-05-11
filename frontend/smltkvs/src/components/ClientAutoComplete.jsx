import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AutoComplete } from 'antd';
import { getUsers } from '../api/userActions';

const getOptions = (users) => {
    return users.map(user => {
        return {
            value: user.name || user.username,
            clientid: user.userId
        }
    });
}

const onSelect = (_, data, onChange) => {
    onChange(data.clientid);
};

const ClientAutoComplete = (props) => {
    const dispatch = useDispatch();
    var clients = useSelector(state => state.users.value);
    const [options, setOptions] = useState(getOptions(clients));

    const onSearch = (users, searchText) => {
        const filteredUsers = users.filter(user => {
            const userName = user.name || user.username;
            return userName.includes(searchText);
        })
        .slice(0, 10);

        setOptions(getOptions(filteredUsers));
    }

    useEffect(() => {
        getUsers(dispatch);
    }, [dispatch])

    return (
        <>
            <AutoComplete
                options={options}
                onSearch={(searchText) => onSearch(clients, searchText)}
                style={{
                    width: 200,
                }}
                onSelect={(_, data) => onSelect(_, data, props.onChange)}
            />
        </>
    );
};

export default ClientAutoComplete;