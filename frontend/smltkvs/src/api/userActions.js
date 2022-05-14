import { apiPaths } from "./constants/apiPaths";
import { requestApi, restMethod } from "./requestApi";
import { setUsers } from "../reducers/users";
import { localStorageKeys } from "./constants/localStorageKeys";
import { routes } from "../routes";
import { roles } from "./constants/roles";

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
    const loggedInUserRole = getLoggedInUser().role;

    let apiPath = '';
    if (loggedInUserRole === roles.admin)
        apiPath = apiPaths.postRegisterUser.admin
    if (loggedInUserRole === roles.clientAdmin)
        apiPath = apiPaths.postRegisterUser.clientAdmin

    return requestApi(apiPath, {
        username,
        password,
        role,
        email,
        name
    }, restMethod.POST);
};

export const getUsers = async (dispatch) => {
    const loggedInUserRole = getLoggedInUser().role;
console.log(getLoggedInUser());
console.log(loggedInUserRole);

    let apiPath = '';
    if (loggedInUserRole === roles.admin)
        apiPath = apiPaths.getUsers.admin
    if (loggedInUserRole === roles.clientAdmin)
        apiPath = apiPaths.getUsers.clientAdmin
    if (loggedInUserRole === roles.client)
        apiPath = apiPaths.getUsers.client
    if (loggedInUserRole === roles.employee)
        apiPath = apiPaths.getUsers.employee

    var result = await requestApi(apiPath);
    if (!result.isOk) return;
    var json = await result.response.json();
    dispatch(setUsers(json));
};