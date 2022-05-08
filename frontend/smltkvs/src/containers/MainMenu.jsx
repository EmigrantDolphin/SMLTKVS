import React, { useState } from 'react';
import { Menu } from 'antd';
import { AppstoreOutlined, MailOutlined } from '@ant-design/icons';
import ConcreteList from './StandardLists/ConcreteList';
import Clients from './Clients';

function getItem(label, key, icon, children, type) {
  return { key, icon, children, label, type };
}

const concreteKey = 'concrete';
const employeesKey = 'somethingElse'
const clientsKey = 'clientsElse'
const items = [
  getItem('Betonas ir gelžbetonis', concreteKey, <MailOutlined />),
  getItem('Darbuotojai', employeesKey, <AppstoreOutlined />),
  getItem('Klientai', clientsKey, <AppstoreOutlined />)
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
        </div>
    </div>
  );
};

export default MainMenu;