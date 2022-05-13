import React, { useState } from 'react';
import { Menu } from 'antd';
import { AppstoreOutlined, MailOutlined } from '@ant-design/icons';
import ConcreteList from './concreteTests/ConcreteList';
import Clients from './clients/Clients';
import Companies from './companies/Companies';

function getItem(label, key, icon, children, type) {
  return { key, icon, children, label, type };
}

const concreteKey = 'concreteKey';
const employeesKey = 'employeesKey';
const clientsKey = 'clientsKey';
const companiesKey = 'companiesKey'
const items = [
  getItem('Betonas ir gelžbetonis', concreteKey, <MailOutlined />),
  getItem('Darbuotojai', employeesKey, <AppstoreOutlined />),
  getItem('Klientai', clientsKey, <AppstoreOutlined />),
  getItem('Įmonės', companiesKey, <AppstoreOutlined />)
];

const MainMenu = () => {
    const [selectedItem, setSelectedItem] = useState(concreteKey);

  const onClick = (e) => {
    setSelectedItem(e.key);
  };

  return (
    <div
        style={{
            display: 'flex',
            justifyContent: 'center',
            columnGap: '20px',
            marginTop: '2%'
        }}
    >
        <Menu
            onClick={onClick}
            style={{
                width: 256
            }}
            defaultSelectedKeys={[concreteKey]}
            defaultOpenKeys={[concreteKey]}
            mode="inline"
            items={items}
        />
        <div
            style={{
                width: '40%',
            }}
        >
            {selectedItem === concreteKey && <ConcreteList />}
            {selectedItem === clientsKey && <Clients />}
            {selectedItem === companiesKey && <Companies />}
        </div>
    </div>
  );
};

export default MainMenu;