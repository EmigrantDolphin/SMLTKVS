import { Table } from 'antd';
import AddClientModal from './AddClientModal';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getUsers } from '../../api/userActions';

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
  const users = useSelector((state) => state.users.value);

  useEffect(() => {
    getUsers(dispatch);
  }, [dispatch]);

  return (
    <>
        <AddClientModal />
        <Table columns={columns} dataSource={getUserColumnData(users)} />
    </>
  );
}

export default Clients;