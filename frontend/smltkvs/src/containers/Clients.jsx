import { Table } from 'antd';
import AddClientModal from './AddClientModal';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getUsers } from '../api/userActions';

const columns = [
  {
    title: 'Pavadinimas',
    dataIndex: 'name',
    width: '30%',
  },
  {
    title: 'El. Paštas',
    dataIndex: 'email',
  },
  {
    title: 'Prisijungimo vardas',
    dataIndex: 'username',
    sorter: (a, b) => a.username.localeCompare(b.username),
    width: '40%',
  },
];

function onChange(pagination, filters, sorter, extra) {
  console.log('params', pagination, filters, sorter, extra);
}

const getUserColumnData = (users) => {
  if (!users) return [];

  return users.map(user => {
    return {
      key: user.userId,
      name: user.name,
      email: user.email,
      username: user.username
    };
  });
}

const Clients = () => {
  const dispatch = useDispatch();
  const users = useSelector((state) => {console.log(state); return state.users.value});

  useEffect(() => {
    getUsers(dispatch);
  }, [dispatch]);

  return (
      <>
          <AddClientModal />
          <Table columns={columns} dataSource={getUserColumnData(users)} onChange={onChange} />
      </>
  );
}

export default Clients;