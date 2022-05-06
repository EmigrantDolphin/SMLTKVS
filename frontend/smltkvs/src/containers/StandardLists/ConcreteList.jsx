import { Card } from 'antd';
import NavigateButton from '../../components/NavigateButton';

const selectButtonText = 'Atlikti bandymą';

const ConcreteList = () => {
    return (
        <Card title="Betonas ir gelžbetonis">
            <Card
                type="inner"
                title="Standartas LST 2010"
                extra={<NavigateButton text={selectButtonText} navigateUrl='/concreteTrial' />} // move to urls file
            >
            SStandarto trumpas aprašas ............Standarto trumpas aprašas ............Standarto trumpas aprašas ............tandarto trumpas aprašas ............
            </Card>
            <Card
            style={{ marginTop: 16 }}
            type="inner"
            title="Standartas LST 2044"
            extra={<NavigateButton text={selectButtonText} navigateUrl='/concreteTrial' />}
            >
            Standarto trumpas aprašymas.............
            </Card>
        </Card>
    )
};

export default ConcreteList;