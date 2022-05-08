import { apiPaths } from "./constants/apiPaths";
import { requestApi, restMethod } from "./requestApi";


export const registerUser = async (username, password, role, email, name) => {
    return requestApi(apiPaths.postRegisterUser, {
        username,
        password,
        role,
        email,
        name
    }, restMethod.POST);
}