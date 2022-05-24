import { testTypes } from "../api/constants/testTypes";

export const isArrayFilled = (array) => {
    return array.reduce((a, b) => a + (b === null ? 0 : 1), 0) === array.length;
}


export const concreteCubeCalculateAverageStrength = (data) => {
    const strengths = data.map(x => Number(x.strength));
    const sumOfStrengths = strengths.reduce((a, b) => a + b, 0);
    const average = sumOfStrengths / data.length;

    return average;
}

export const concreteCubeCalculateStandardDeviation = (data, averageStrength) => {
    const strengths = data.map(x => Number(x.strength));
    let sq = strengths.reduce((sum, strength) => sum + ((strength - averageStrength) * (strength - averageStrength)));
    sq = sq / (data.length /*- 1*/); // todo: if 1 test, this will divide by 0?????

    const s = Math.sqrt(sq);
    return s;
}

export const concreteCubeCalculateCharacteristicStrength = ( data, averageStrength ) => {

    if (data.testType === testTypes.INITIAL) {
        return concreteCubeCalculateInitialTestCharacteristicStrength(data, averageStrength);
    }
    else {

    }
}

//TODO: get all strengths from BE by constructionSiteID
const concreteCubeCalculatePermanentTestCharacteristicStrength = ( strengths, averageStrength, standardDeviation ) => {
    // calculate cube strength average from this + 35 from DB
    // substract 1.48 times standardDeviation calculated from DB data?

    //get minimum strength from DB + 4
}

const concreteCubeCalculateInitialTestCharacteristicStrength = ( data, averageStrength ) => {
    const cubeStrengths = data.map(x => Number(x.strength))
    const minimumCubeStrength = Math.min(...cubeStrengths);
    const minimumStrengthCubeCharacteristic = minimumCubeStrength + 4;

    const averageStrengthCubeCharacteristic = averageStrength - 4;

    return Math.min(minimumStrengthCubeCharacteristic, averageStrengthCubeCharacteristic);
}