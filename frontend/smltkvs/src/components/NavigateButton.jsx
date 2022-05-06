import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';

const NavigateButton = (props) => {
    const navigate = useNavigate();

    return (
        <Button
            onClick={() => navigate(props.navigateUrl)}
        >
            {props.text}
        </Button>
    )
}

export default NavigateButton;