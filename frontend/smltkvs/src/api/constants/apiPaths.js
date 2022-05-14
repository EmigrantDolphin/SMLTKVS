export const apiPaths = {
    postRegisterUser: {
        admin: '/admin/user',
        clientAdmin: '/client-admin/user'
    },
    postLogin: '/auth/user/login',
    getUsers: {
        admin: '/admin/users',
        employee: '/employee/users',
        client: '/client/users',
        clientAdmin: '/client-admin/users'
    },
    postConcreteCubeTest: '/concrete/cube/test',
    postCompany: '/company',
    getCompanies: '/companies',
    putCompany: '/company/' // :todo figure out a better way to add variables
};