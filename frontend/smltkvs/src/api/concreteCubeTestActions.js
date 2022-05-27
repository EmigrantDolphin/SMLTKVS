import { setConcreteCubeTest } from "../reducers/concreteCubeTest";
import { setConcreteCubeTestCrushForces } from "../reducers/concreteCubeTestCrushForces";
import { setConcreteCubeTests } from "../reducers/concreteCubeTests";
import { apiPaths } from "./constants/apiPaths";
import { roles } from "./constants/roles";
import { requestApi, restMethod } from "./requestApi";
import { getLoggedInUser } from "./userActions";

export const createConcreteCubeTest = async (
    data
) => {
    return requestApi(apiPaths.postConcreteCubeTest, data, restMethod.POST);
};

export const getConcreteCubeTestList = async (dispatch) => {
    const loggedInUserRole = getLoggedInUser().role;

    let apiPath = '';
    if (loggedInUserRole === roles.admin || loggedInUserRole === roles.employee)
        apiPath = apiPaths.getConcreteCubeTestList.employee;
    else
        apiPath = apiPaths.getConcreteCubeTestList.client;

    var result = await requestApi(apiPath);
    if (!result.isOk) return;
    var json = await result.response.json();
    dispatch(setConcreteCubeTests(json));
};

export const getConcreteCubeTest = async (dispatch, testId) => {
    const loggedInUserRole = getLoggedInUser().role;

    let apiPath = '';
    if (loggedInUserRole === roles.admin || loggedInUserRole === roles.employee)
        apiPath = apiPaths.getConcreteCubeTest.employee;
    else
        apiPath = apiPaths.getConcreteCubeTest.client;
    
    apiPath = apiPath + testId;

    var result = await requestApi(apiPath);
    if (!result.isOk) return;
    var json = await result.response.json();
    dispatch(setConcreteCubeTest(json));
};

export const getConcreteCubeTestCrushForces = async (dispatch, constructionSiteId) => {
    const loggedInUserRole = getLoggedInUser().role;

    let apiPath = apiPaths.postConcreteCubeTestCrushForces.replace('{constructionSiteId}', constructionSiteId);

    var result = await requestApi(apiPath);
    if (!result.isOk) return;
    var arrayOfForces = await result.response.json();
    dispatch(setConcreteCubeTestCrushForces(arrayOfForces));
};

export const getConcreteCubeTestProtocol = async (testId) => {
    const loggedInUserRole = getLoggedInUser().role;

    let apiPath = '';
    if (loggedInUserRole === roles.admin || loggedInUserRole === roles.employee)
        apiPath = apiPaths.getConcreteCubeTestProtocol.employee;
    else
        apiPath = apiPaths.getConcreteCubeTestProtocol.client;
    
    apiPath = apiPath.replace('{testId}', testId);

    var result = await requestApi(apiPath);
    if (!result.isOk) return;

    result.response.blob().then(blob => {
        const fileUrl = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = fileUrl;
        a.target = '_blank';
        a.click();
    });
};