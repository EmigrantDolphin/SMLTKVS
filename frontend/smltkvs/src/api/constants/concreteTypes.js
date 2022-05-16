export const concreteTypes = {
    HEAVYANDNORMAL: 0,
    LIGHT: 1
};

export const getConcreteTypeTranslation = (type) => {
    switch (type) {
        case concreteTypes.HEAVYANDNORMAL:
            return 'Sunkusis arba normalusis';
        case concreteTypes.LIGHT:
            return 'lengvasis';
        default: return '';
    }
}