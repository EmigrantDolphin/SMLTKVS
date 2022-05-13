import { apiPaths } from "./constants/apiPaths";
import { requestApi, restMethod } from "./requestApi";
import { setUsers } from "../reducers/users";
import { localStorageKeys } from "./constants/localStorageKeys";
import { routes } from "../routes";

export const loginUser = async (username, password) => {
    var result = await requestApi(apiPaths.postLogin, {
        username, password
    }, restMethod.POST);

    if (!result.isOk)
        return false;

    var json = await result.response.json();

    localStorage.setItem(localStorageKeys.authToken, JSON.stringify(json));
    return true;
};

export const getLoggedInUser = () => {
    var auth = localStorage.getItem(localStorageKeys.authToken);
    if (!auth)
        logoutUser();

    return JSON.parse(auth);
}

export const logoutUser = () => {
    localStorage.removeItem(localStorageKeys.authToken);
    window.location.href = routes.login;
};

export const registerUser = async (username, password, role, email, name) => {
    return requestApi(apiPaths.postRegisterUser, {
        username,
        password,
        role,
        email,
        name
    }, restMethod.POST);
};

export const getUsers = async (dispatch) => {
    var result = await requestApi(apiPaths.getUsers);
    if (!result.isOk) return;
    var json = await result.response.json();
    dispatch(setUsers(json));
};