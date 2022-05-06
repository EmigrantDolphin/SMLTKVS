import React, { useState } from 'react';
import { Menu } from 'antd';
import { AppstoreOutlined, MailOutlined } from '@ant-design/icons';
import ConcreteList from './StandardLists/ConcreteList';

function getItem(label, key, icon, children, type) {
  return { key, icon, children, label, type };
}

const concreteKey = 'concrete';
const somethingElseKey = 'somethingElse'
const items = [
  getItem('Betonas ir gelžbetonis', concreteKey, <MailOutlined />),
  getItem('Kazkas dar', somethingElseKey, <AppstoreOutlined />)
];

const StandardSelection = () => {
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
        </div>
    </div>
  );
};

export default StandardSelection;