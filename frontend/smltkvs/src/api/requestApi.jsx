export const restMethod = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    PATCH: 'PATCH',
    DELETE: 'DELETE'
};

export const requestApi = (api, data = undefined, requestMethod = restMethod.GET) => {
    return fetch(`https://localhost:7062/api${api}`, {
        method: requestMethod,
        body: data && JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    });
}