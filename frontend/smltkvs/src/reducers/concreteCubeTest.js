import { createSlice } from '@reduxjs/toolkit';

export const concreteCubeTestSlice = createSlice({
    name: "concreteCubeTest",
    initialState: { value: [] },
    reducers: {
        setConcreteCubeTest: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { setConcreteCubeTest } = concreteCubeTestSlice.actions;

export default concreteCubeTestSlice.reducer;