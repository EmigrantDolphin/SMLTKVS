import { setCompanies } from "../reducers/companies";
import { apiPaths } from "./constants/apiPaths";
import { requestApi, restMethod } from "./requestApi";

export const createCompany = async (data) => {
    return requestApi(apiPaths.postCompany, data, restMethod.POST);
};

export const getCompanies = async (dispatch) => {
    var result = await requestApi(apiPaths.getCompanies);
    if (!result.isOk) return;
    var json = await result.response.json();
    dispatch(setCompanies(json));
};

export const updateCompany = async (data) => {
    return await requestApi(`${apiPaths.putCompany}${data.companyId}`, data, restMethod.PUT);
};