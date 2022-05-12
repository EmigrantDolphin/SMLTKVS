import { apiPaths } from "./constants/apiPaths";
import { requestApi, restMethod } from "./requestApi";

export const createConcreteCubeTest = async (
    data
) => {
    return requestApi(apiPaths.postConcreteCubeTest, data, restMethod.POST);
};