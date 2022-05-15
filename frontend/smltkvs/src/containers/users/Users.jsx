import { Table, Select } from 'antd';
import AddUserModal from './AddUserModal';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getLoggedInUser, getUsers } from '../../api/userActions';
import { roles } from '../../api/constants/roles';
import { getCompanies } from '../../api/companyActions';
const { Option } = Select;

const getColumns = (currentUserRole) => {
  const items =
  [
    {
      title: 'Pavadinimas',
      dataIndex: 'name'
    },
    {
      title: 'El. Paštas',
      dataIndex: 'email',
    },
    {
      title: 'Prisijungimo vardas',
      dataIndex: 'username',
      sorter: (a, b) => a.username.localeCompare(b.username)
    }
  ];

  if (currentUserRole === roles.employee || currentUserRole === roles.admin) {
    items.push({
        title: 'Įmonė',
        dataIndex: 'companyName'
    });
  }

  return items;
}

const getUserColumnData = (users, companies) => {
  if (!users || !companies) return [];

  return users.map(user => {
    return {
      key: user.userId,
      name: user.name,
      email: user.email,
      username: user.username,
      companyName: companies.find(x => x.companyId === user.companyId)?.name
    };
  });
}

const getDefaultSelectedRole = (currentUserRole) => {
  if (currentUserRole === roles.admin || currentUserRole === roles.employee)
    return roles.employee

  return roles.client;
}

const getOptionsByCurrentUserRole = (currentUserRole) => {
  if (currentUserRole === roles.admin || currentUserRole === roles.employee)
    return (
      <>
        <Option value={roles.admin}>Administratoriai</Option>
        <Option value={roles.employee}>Darbuotojai</Option>
        <Option value={roles.client}>Klientai</Option>
        <Option value={roles.clientAdmin}>Klientai administratoriai</Option>
      </>
    );

  return (
    <>
      <Option value={roles.client}>Klientai</Option>
      <Option value={roles.clientAdmin}>Klientai administratoriai</Option>
    </>
  );
}

const Users = () => {
  const currentUserRole = getLoggedInUser().role;
  const defaultSelectedRole = getDefaultSelectedRole(currentUserRole);

  const dispatch = useDispatch();
  const [selectedRole, setSelectedRole] = useState(defaultSelectedRole);
  const users = useSelector((state) => state.users.value);
  const companies = useSelector((state) => state.companies.value);

  const roleChanged = (selectedRole) => {
    setSelectedRole(selectedRole);
  }

  useEffect(() => {
    getUsers(dispatch, selectedRole);
    if (currentUserRole === roles.admin || currentUserRole === roles.employee) {
      getCompanies(dispatch);
    }
  }, [dispatch, selectedRole, currentUserRole]);

  return (
    <>
      <Select
        style={{width:200, float: 'left'}}
        onChange={roleChanged}
        defaultValue={defaultSelectedRole}
      >
        {getOptionsByCurrentUserRole(currentUserRole)}
      </Select>
        {currentUserRole !== roles.client && (
          <AddUserModal currentUserRole={currentUserRole} onSuccess={() => getUsers(dispatch, selectedRole)} />
        )}
        <Table columns={getColumns(currentUserRole)} dataSource={getUserColumnData(users, companies)} />
    </>
  );
}

export default Users;