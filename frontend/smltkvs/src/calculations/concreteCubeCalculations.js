export const concreteCubeCalculateAverageStrength = (crushForces) => {
    const sumOfCrushForces = crushForces.reduce((a, b) => a + b, 0);
    const average = sumOfCrushForces / crushForces.length;

    return average;
}

export const concreteCubeCalculateStandardDeviation = (crushForces, averageStrength) => {
    let sq = crushForces.reduce((sum, crushForce) => sum + ((crushForce - averageStrength) * (crushForce - averageStrength)));
    sq = sq / (crushForces.length - 1);

    const s = Math.sqrt(sq);
    return s;
}

export const concreteCubeCalculatePermanentTestCharacteristicStrength = ( crushForces, averageStrength, standardDeviation ) => {
    const minimumCubeCrushForce = Math.min(...crushForces);
    const minimumStrengthCubeCharacteristic = minimumCubeCrushForce + 4;

    const averageStrengthCubeCharacteristic = averageStrength - (1.48 * standardDeviation);

    return Math.min(minimumStrengthCubeCharacteristic, averageStrengthCubeCharacteristic);
}

export const concreteCubeCalculateInitialTestCharacteristicStrength = ( cubeCrushForces, averageStrength ) => {
    const minimumCubeCrushForce = Math.min(...cubeCrushForces);
    const minimumStrengthCubeCharacteristic = minimumCubeCrushForce + 4;

    const averageStrengthCubeCharacteristic = averageStrength - 4;

    return Math.min(minimumStrengthCubeCharacteristic, averageStrengthCubeCharacteristic);
}

export const concreteCubeCalculateConcreteClass = (characteristicStrength) => {
    const classSet = [
    {
        value: 10,
        name: 'C8/10'
    },
    {
        value: 15,
        name: 'C12/15'
    },
    {
        value: 20,
        name: 'C16/20'
    },
    {
        value: 25,
        name: 'C20/25'
    },
    {
        value: 30,
        name: 'C25/30'
    },
    {
        value: 37,
        name: 'C30/37'
    },
    {
        value: 45,
        name: 'C35/45'
    },
    {
        value: 50,
        name: 'C40/50'
    },
    {
        value: 55,
        name: 'C45/55'
    },
    {
        value: 60,
        name: 'C50/60'
    },
    {
        value: 67,
        name: 'C55/67'
    },
    {
        value: 75,
        name: 'C60/75'
    },
    {
        value: 85,
        name: 'C70/85'
    },
    {
        value: 95,
        name: 'C80/95'
    },
    {
        value: 105,
        name: 'C90/105'
    },
    {
        value: 115,
        name: 'C100/115'
    },
    ];

    let previousClass = classSet[0];
    for (const concreteClass of classSet) {
        if (concreteClass.value > characteristicStrength){
            return previousClass.name;
        }
        else {
            previousClass = concreteClass;
        }
    }
}