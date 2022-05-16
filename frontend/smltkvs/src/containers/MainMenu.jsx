import React, { useState } from 'react';
import { Menu } from 'antd';
import { BorderOutlined, UserOutlined, LogoutOutlined, BankOutlined } from '@ant-design/icons';
import ConcreteList from './concreteTests/ConcreteList';
import ConcreteCubeTrialList from './concreteTests/ConcreteCubeTrialList';
import Users from './users/Users';
import Companies from './companies/Companies';
import { getLoggedInUser, logoutUser } from '../api/userActions';
import { roles } from '../api/constants/roles';
import { useEffect } from 'react';

function getItem(label, key, icon, children, type) {
  return { key, icon, children, label, type };
}

const concreteKey = 'concreteKey';
const createConcreteTestKey = 'createConcreteTestKey';
const viewConcreteTestsKey = 'viewConcreteTestsKey';
const usersKey = 'usersKey';
const companiesKey = 'companiesKey'
const logoutKey = 'logoutKey';

const MainMenu = () => {
  const currentUserRole = getLoggedInUser().role;
  const [selectedItem, setSelectedItem] = useState(viewConcreteTestsKey);

  const concreteSubMenu = [];

  if (currentUserRole === roles.admin || currentUserRole === roles.employee) {
    concreteSubMenu.push(getItem('Sukurti', createConcreteTestKey));
  }
  concreteSubMenu.push(getItem('Kubelinio stiprio bandymai', viewConcreteTestsKey));

  const mainMenuItems = [
    getItem('Betonas ir gelžbetonis', concreteKey, <BorderOutlined />, concreteSubMenu),
    getItem('Naudotojai', usersKey, <UserOutlined />)
  ];

  if (currentUserRole === roles.admin || currentUserRole === roles.employee) {
    mainMenuItems.push(getItem('Įmonės', companiesKey, <BankOutlined />));
  }

  mainMenuItems.push(getItem('Atsijungti', logoutKey, <LogoutOutlined />));

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
            defaultSelectedKeys={[viewConcreteTestsKey]}
            defaultOpenKeys={[concreteKey]}
            mode="inline"
            items={mainMenuItems}
        />
        <div
            style={{
                width: '40%',
            }}
        >
            {selectedItem === createConcreteTestKey  && <ConcreteList />}
            {selectedItem === viewConcreteTestsKey  && <ConcreteCubeTrialList />}
            {selectedItem === usersKey && <Users />}
            {selectedItem === companiesKey && <Companies />}
        </div>
    </div>
  );
};

export default MainMenu;