import { Table } from 'antd';
import AddClientModal from './AddClientModal';

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

const data = [
  {
    key: '1',
    name: 'John Brown',
    email: 32,
    username: 'New York No. 1 Lake Park',
  },
  {
    key: '2',
    name: 'Jim Green',
    email: 42,
    username: 'London No. 1 Lake Park',
  },
  {
    key: '3',
    name: 'Joe Black',
    email: 32,
    username: 'Sidney No. 1 Lake Park',
  },
  {
    key: '4',
    name: 'Jim Red',
    email: 32,
    username: 'London No. 2 Lake Park',
  },
];

function onChange(pagination, filters, sorter, extra) {
  console.log('params', pagination, filters, sorter, extra);
}

const Clients = () => {
    return (
        <>
            <AddClientModal />
            <Table columns={columns} dataSource={data} onChange={onChange} />
        </>
    );
}

export default Clients;