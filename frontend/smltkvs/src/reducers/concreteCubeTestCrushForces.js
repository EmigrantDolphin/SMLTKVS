import { createSlice } from '@reduxjs/toolkit';

export const concreteCubeTestCrushForcesSlice = createSlice({
    name: 'concreteCubeTestCrushForces',
    initialState: { value: [] },
    reducers: {
        setConcreteCubeTestCrushForces: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { setConcreteCubeTestCrushForces } = concreteCubeTestCrushForcesSlice.actions;

export default concreteCubeTestCrushForcesSlice.reducer;