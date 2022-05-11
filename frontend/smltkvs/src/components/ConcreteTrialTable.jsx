import React from 'react';
import { Table, InputNumber, Button } from 'antd';
import { isArrayFilled } from '../utilities/isArrayFilled';

const initialData = [{
    key: 0,
    testNumber: 0,
    valueA: {
        values: new Array(6)
    },
    valueB: {
        values: new Array(6)
    },
    destructivePower: null,
    strength: null,
    comments: null,
    pictures: null
}];

const calculateStrength = (newData, testIndex) => {
    const aValues = newData[testIndex].valueA.values;
    const bValues = newData[testIndex].valueB.values;
    const destructivePower = newData[testIndex].destructivePower;
    
    if (
        isArrayFilled(aValues) &&
        isArrayFilled(bValues) &&
        destructivePower
    ) {
        const am = aValues.reduce((a, b) => a + b, 0) / 6;
        const bm = bValues.reduce((a, b) => a + b, 0) / 6;
        const f = destructivePower / (am * bm);

        newData[testIndex].strength = f.toFixed(3);
    }
    else {
        newData[testIndex].strength = null;
    }

    return newData;
}

const ConcreteTrialTable = ({ onChange, value }) => {
    const [, updateState] = React.useState();
    const forceUpdate = React.useCallback(() => updateState({}), []);

    const onValueAChange = (inputValue, testIndex, valueIndex) => {
        let newData = value || initialData;

        const valueAValues = [...newData[testIndex].valueA.values];
        valueAValues[valueIndex] = inputValue;
        newData[testIndex] = {...newData[testIndex], valueA: { values: valueAValues } }

        onDataChange(newData, testIndex);
    }

    const onValueBChange = (inputValue, testIndex, valueIndex) => {
        let newData = value || initialData;;

        const valueBValues = [...newData[testIndex].valueB.values];
        valueBValues[valueIndex] = inputValue;
        newData[testIndex] = {...newData[testIndex], valueB: { values: valueBValues } }

        onDataChange(newData, testIndex);
    }

    const onDestructivePowerChange = (inputValue, testIndex) => {
        let newData = value || initialData;;
        newData[testIndex] = {...newData[testIndex], destructivePower: inputValue};
        onDataChange(newData, testIndex);
    }

    const onDataChange = (newData, testIndex) => {
        newData = calculateStrength(newData, testIndex);
        onChange(newData);
        //TODO: Figure out why table doesn't update when 'value' changes. For now, forcing update.
        forceUpdate();
    }

    const addTest = () => {
        const data = value || initialData;

        let newRow = {...initialData[0]};
        newRow.key = data.length;
        newRow.testNumber = data.length;

        data.push(newRow);

        onChange([...data]);
        forceUpdate();
    }

    const removeTest = () => {
        value.pop();

        onChange([...value]);
        forceUpdate();
    }

    const columns = [
        {
            title: 'Bandinio Nr.',
            dataIndex: 'testNumber',
            key: 'testNumber',
            width: 100,
            fixed: 'left',
        },
        {
            title: 'Skerspjūvio matmenys',
            children: [
            {
                title: 'a',
                dataIndex: 'valueA',
                key: 'valueA',
                width: 150,
                render: (_, rowData, index) => {
                    return (
                        <>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[0]} onChange={(val) => onValueAChange(val, index, 0)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[1]} onChange={(val) => onValueAChange(val, index, 1)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[2]} onChange={(val) => onValueAChange(val, index, 2)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[3]} onChange={(val) => onValueAChange(val, index, 3)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[4]} onChange={(val) => onValueAChange(val, index, 4)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueA.values[5]} onChange={(val) => onValueAChange(val, index, 5)}/>
                        </>
                    );
                }
            },
            {
                title: 'b',
                dataIndex: 'valueB',
                key: 'valueB',
                width: 150,
                render: (_, rowData, index) => {
                    return (
                        <>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[0]} onChange={(val) => onValueBChange(val, index, 0)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[1]} onChange={(val) => onValueBChange(val, index, 1)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[2]} onChange={(val) => onValueBChange(val, index, 2)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[3]} onChange={(val) => onValueBChange(val, index, 3)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[4]} onChange={(val) => onValueBChange(val, index, 4)}/>
                            <InputNumber size='small' required controls={false} value={rowData.valueB.values[5]} onChange={(val) => onValueBChange(val, index, 5)}/>
                        </>
                    );
                }
            },
            ],
        },
        {
            title: 'Ardančioji jėga F, kN',
            dataIndex: 'destructivePower',
            key: 'destructivePower',
            width: 200,
            render: (_, rowData, index) => {
                return (
                    <>
                        <InputNumber
                            required
                            controls={false}
                            value={rowData.destructivePower}
                            onChange={(val) => onDestructivePowerChange(val, index)}
                        />
                    </>
                );
            }
        },
        {
            title: 'Stipris gniuždant fc, MPa',
            dataIndex: 'strength',
            key: 'strength',
            width: 80,
        },
        {
            title: 'Pastabos',
            dataIndex: 'comments',
            key: 'comments',
            width: 80,
        },
        {
            title: 'Nuotraukos',
            dataIndex: 'pictures',
            key: 'pictures',
            width: 80,
        },
    ];

    return (
        <div style={{width: '700px'}}>
            <Table
                columns={columns}
                dataSource={value ? [...value] : initialData}
                bordered
                pagination={false}
            />
            <div style={{display: 'flex'}}>
                <Button
                    type='primary'
                    style={{marginTop: '5px'}}
                    onClick={() => addTest()}
                >
                    Pridėti bandinį
                </Button>

                {value && value.length > 1 && (
                    <Button
                        style={{marginTop: '5px', marginLeft: '20px'}}
                        onClick={() => removeTest()}
                    >
                        Ištrinti bandinį
                    </Button>
                )}
            </div>
        </div>
    );
}

export default ConcreteTrialTable;