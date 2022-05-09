import { notification } from 'antd';
import { localStorageKeys } from './constants/localStorageKeys';
import { logoutUser } from './userActions';
export const restMethod = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    PATCH: 'PATCH',
    DELETE: 'DELETE'
};

export const requestApi = async (api, data = undefined, requestMethod = restMethod.GET) => {
    const auth = JSON.parse(localStorage.getItem(localStorageKeys.authToken));

    var response = await fetch(`https://localhost:7062/api${api}`, {
        method: requestMethod,
        body: data && JSON.stringify(data),
        headers: {
            "Content-Type": "application/json",
            "Authorization": auth &&
                `Bearer ${auth.token}`
        }
    });

    if (response.status === 400) {
        var text = await response.text();
        notification.error({
            message: 'Klaida',
            description: text || 'Netikėta klaida.'
        });

        return {
            isOk: false
        };
    }

    if (response.status === 401 || response.status === 403) {
        logoutUser();
    }

    return {
        isOk: true,
        response: response
    }
}