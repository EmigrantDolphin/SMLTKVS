import { Card } from 'antd';
import NavigateButton from '../../components/NavigateButton';
import { routes } from '../../routes';

const selectButtonText = 'Atlikti bandymą';

const ConcreteList = () => {
    return (
        <Card title="Betonas ir gelžbetonis">
            <Card
                type="inner"
                title="LST EN 12390-3"
                extra={<NavigateButton text={selectButtonText} navigateUrl={routes.concreteCubeTrial} />}
            >
                Betono kubelinio stiprio nustatymas pagal LST EN 12390-3
            </Card>
        </Card>
    )
};

export default ConcreteList;