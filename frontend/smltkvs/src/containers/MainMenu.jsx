import React, { useState } from 'react';
import { Menu } from 'antd';
import { AppstoreOutlined, MailOutlined } from '@ant-design/icons';
import ConcreteList from './concreteTests/ConcreteList';
import Users from './users/Users';
import Companies from './companies/Companies';
import { getLoggedInUser, logoutUser } from '../api/userActions';
import { roles } from '../api/constants/roles';
import { useEffect } from 'react';

function getItem(label, key, icon, children, type) {
  return { key, icon, children, label, type };
}

const concreteKey = 'concreteKey';
const usersKey = 'usersKey';
const companiesKey = 'companiesKey'
const logoutKey = 'logoutKey';

const MainMenu = () => {
  const currentUserRole = getLoggedInUser().role;
  const [selectedItem, setSelectedItem] = useState(concreteKey);

  const items = [
    getItem('Betonas ir gelžbetonis', concreteKey, <MailOutlined />),
    getItem('Naudotojai', usersKey, <AppstoreOutlined />)
  ];

  if (currentUserRole === roles.admin || currentUserRole === roles.employee) {
    items.push(getItem('Įmonės', companiesKey, <AppstoreOutlined />));
  }

  items.push(getItem('Atsijungti', logoutKey, <AppstoreOutlined />));

  const onClick = (e) => {
    setSelectedItem(e.key);
  };

  useEffect(() => {
    if (selectedItem === logoutKey) {
      logoutUser();
    }
  }, [selectedItem]);

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
            {selectedItem === usersKey && <Users />}
            {selectedItem === companiesKey && <Companies />}
        </div>
    </div>
  );
};

export default MainMenu;