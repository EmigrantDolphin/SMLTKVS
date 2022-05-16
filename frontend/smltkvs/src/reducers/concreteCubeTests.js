import { createSlice } from '@reduxjs/toolkit';

export const concreteCubeTestsSlice = createSlice({
    name: "concreteCubeTests",
    initialState: { value: [] },
    reducers: {
        setConcreteCubeTests: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { setConcreteCubeTests } = concreteCubeTestsSlice.actions;

export default concreteCubeTestsSlice.reducer;