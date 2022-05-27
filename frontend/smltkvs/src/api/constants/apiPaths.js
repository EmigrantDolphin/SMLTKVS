export const apiPaths = {
    postRegisterUser: {
        admin: '/admin/user',
        employee: '/employee/user',
        clientAdmin: '/client-admin/user'
    },
    postLogin: '/auth/user/login',
    postChangePassword: '/auth/user/change-password',
    getUsers: {
        admin: '/admin/users',
        employee: '/employee/users',
        client: '/client/users',
        clientAdmin: '/client-admin/users'
    },
    postConcreteCubeTest: '/employee/concrete/cube/test',
    postConcreteCubeTestCrushForces: '/employee/concrete/cube/tests/strengths/{constructionSiteId}',
    getConcreteCubeTestList: {
        employee:  '/employee/concrete/cube/tests',
        client:  '/client/concrete/cube/tests'
    },
    getConcreteCubeTest: {
        employee: '/employee/concrete/cube/tests/',
        client: '/client/concrete/cube/tests/',
    },
    getConcreteCubeTestProtocol: {
        employee: '/employee/concrete/cube/tests/{testId}/protocol',
        client: '/client/concrete/cube/tests/{testId}/protocol'
    },
    postCompany: '/company',
    getCompanies: '/companies',
    putCompany: '/company/'
};