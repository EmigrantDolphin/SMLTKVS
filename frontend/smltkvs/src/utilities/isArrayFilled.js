export const isArrayFilled = (array) => {
    return array.reduce((a, b) => a + (b === null ? 0 : 1), 0) === array.length;
}