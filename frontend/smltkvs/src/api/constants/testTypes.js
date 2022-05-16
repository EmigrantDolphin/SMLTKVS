export const testTypes = {
    INITIAL: 0,
    PERMANENT: 1
};

export const getTestTypeTranslation = (type) => {
    switch (type) {
        case testTypes.INITIAL:
            return 'Pradinis';
        case testTypes.PERMANENT:
            return 'Nuolatinis';
        default: return '';
    }
}