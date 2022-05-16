import { Table, Button } from 'antd';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getConcreteCubeTestList, getConcreteCubeTestProtocol } from '../../api/concreteCubeTestActions';
import { FilePdfOutlined } from '@ant-design/icons';
import { testTypes } from '../../api/constants/testTypes';


const getConcreteCubeTestData = (concreteCubeTests) => {
    return concreteCubeTests.map(test => {return {...test, key: test.concreteCubeTestId}});
}

const ConcreteCubeTrialList = () => {
    const [downloadingPdfId, setDownloadingPdfId] = useState(null);
    const dispatch = useDispatch();
    const concreteCubeTests = useSelector((state) => state.concreteCubeTests.value);

    const getProtocol = (testId) => {
        setDownloadingPdfId(testId);
        getConcreteCubeTestProtocol(testId)
            .then(_ => {
                setDownloadingPdfId(null);
            });
    }

    const getColumns = () => {
        const items =
        [
            {
                title: 'Protokolo numeris',
                dataIndex: 'protocolNumber'
            },
            {
                title: 'Įmonė',
                dataIndex: 'companyName',
            },
            {
                title: 'Objekto adresas',
                dataIndex: 'constructionSiteAddress',
                sorter: (a, b) => a.username.localeCompare(b.username)
            },
            {
                title: 'Testo tipas',
                dataIndex: 'testType',
                render: (type) => {
                    switch (type) {
                        case testTypes.INITIAL : return <span>Pradinis</span>;
                        case testTypes.PERMANENT : return <span>Nuolatinis</span>;
                        default: return <span></span>
                    };
                }
            },
            {
                title: 'Atlikimo data',
                dataIndex: 'testExecutionDate',
                render: (date) => <span>{new Date(date).toLocaleString()}</span>
            },
            {
                title: 'Bandytojo vardas',
                dataIndex: 'testExecutingUserName',
            },
            {
                title: '',
                render: (_, item) => 
                    <Button
                        icon={<FilePdfOutlined />}
                        size='small'
                        disabled={item.concreteCubeTestId === downloadingPdfId}
                        // onClick={() => navigate(routes.concreteCubeTrialView, {state: {concreteCubeTestId: item.concreteCubeTestId}})}
                        onClick={() => getProtocol(item.concreteCubeTestId)}
                    />
            }
        ];

        return items;
    }

  useEffect(() => {
    getConcreteCubeTestList(dispatch);
  }, [dispatch]);

  return (
    <>
        <Table columns={getColumns()} dataSource={getConcreteCubeTestData(concreteCubeTests)} />
    </>
  );
}

export default ConcreteCubeTrialList;