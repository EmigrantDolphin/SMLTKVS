import { Button } from 'antd';
import { useLocation } from 'react-router-dom';
import { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { getConcreteCubeTest, getConcreteCubeTestProtocol } from '../../api/concreteCubeTestActions';
import { getConcreteTypeTranslation } from '../../api/constants/concreteTypes';
import { getTestTypeTranslation } from '../../api/constants/testTypes';

const ConcreteCubeTrialView = () => {
    const testId = useLocation().state.concreteCubeTestId;
    const dispatch = useDispatch();
    const concreteCubeTest = useSelector((state) => state.concreteCubeTest.value);

    useEffect(() => {
        console.log('test');
        getConcreteCubeTest(dispatch, testId);
    }, [dispatch, testId]);

    return (
        <div>
            <h2>Betono kubelinio stiprio nustatymas pagal LST EN 12390-3</h2>
            <h2>Bandymų protokolas {concreteCubeTest?.testProtocolNumber}</h2>
            <div>
                <p>
                    <b>Užsakovas: </b>{concreteCubeTest?.clientCompany?.name}, {concreteCubeTest?.clientCompany?.address}, {concreteCubeTest?.clientCompany?.companyCode}<br/>
                    <b>Statybos objektas: </b>{concreteCubeTest?.clientConstructionSite?.name}, {concreteCubeTest?.clientConstructionSite?.address}<br/>
                    <b>Vykdytojas: </b>TODO:<br/>
                </p>
                <br/>
                <p>
                    <b>Bandymai atlikti: </b> {concreteCubeTest && new Date(concreteCubeTest.testExecutionDate).toLocaleString()}<br/>
                    <b>Bandiniai gauti: </b> {concreteCubeTest && new Date(concreteCubeTest.testSamplesReceivedDate).toLocaleString()}
                </p>
                <br />
                <p>
                    <b>Bandinius pristatė: </b> {concreteCubeTest?.testSamplesDeliveredBy}<br/>
                    <b>Bandymus atliko: </b> {concreteCubeTest?.testExecutedByUserName}
                </p>
            </div>
            <h1>1. Bandinių imties apibūdinimas</h1>
            <div style={{textAlign:'left', marginLeft:'25%', marginRight: '25%'}}>
                <p>
                    <b>Bandymo tipas pagal LST EN 206-1 8.2.1.2 ir/arba 8.2.1.3 pastraipas: </b>{getTestTypeTranslation(concreteCubeTest?.testType)}<br/>
                    <b>Betono tipas pagal tankį: </b> {getConcreteTypeTranslation(concreteCubeTest?.concreteType)}<br />
                    <b>Gautos arba paimtos imties dydis: </b> {concreteCubeTest?.testSamplesReceivedCount} betoniniai kubeliai.<br/>
                    <b>Bandinių matmenys: </b> betono kubai (TODO:) cm.<br/>
                    <b>Bendras bandinių išvaizdos apibūdinimas bandinių priėmimo metu: </b> {concreteCubeTest?.testSamplesReceivedComment}
                </p>
            </div>
            <h1>2. Bandymo rezultatai</h1>
            <div div style={{textAlign:'left', marginLeft:'25%', marginRight: '25%'}}>
                <p>
                    <b>Išbandytos imties dydis:</b> išbandytas {concreteCubeTest?.acceptedSampleCount} betoninis kubelis. Po pirminės apžiūros bandymui
                       atrinktas {concreteCubeTest?.acceptedSampleCount} kubelis, {concreteCubeTest?.rejectedSampleCount} kubelis (kubeliai) išbrokuotas.
                       Bandymo rezultatai surasyti į 3 lentelę.
                </p>
            </div>
            <h1>3. Skaičiavimo rezultatai</h1>
            <div div style={{textAlign:'left', marginLeft:'25%', marginRight: '25%'}}>
                <ol>
                    <li>Vidutinio gniuždomojo stiprio įvertis fcm,cube = {concreteCubeTest?.averageCrushForce} MPa</li>
                    <li>Vidutinio gniuždomojo stiprio įverčio neapibrėžtys:</li>
                        <dd>(a) Standartinė neapibrėžtis: u = {concreteCubeTest?.standardUncertainty} MPa</dd>
                        <dd>(b) Išplėstinė neapibrėžtis U = k*u = {concreteCubeTest?.extendedUncertainty} MPa, kai išplėstinės neapibrėžties koeficientas k = 2 ????</dd>
                    <li>Standartinio nuokrypio įvertis s = {concreteCubeTest?.standardDeviation} MPa</li>
                    <li>Charakteristinio stiprio įvertis fck,cube = {concreteCubeTest?.characteristicStrength} MPa</li>
                    <li>Artimiausia mažesnė betono klasė nustatyta pagal kubelinį stiprį fck,cube: {concreteCubeTest?.concreteRating}</li>
                </ol>
            </div>
            TODO: Add test data table
            <Button onClick={() => getConcreteCubeTestProtocol(testId)}>Generuoti protokola</Button>
        </div>
    );
};

export default ConcreteCubeTrialView;