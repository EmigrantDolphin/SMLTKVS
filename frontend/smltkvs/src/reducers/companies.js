import { createSlice } from '@reduxjs/toolkit';

export const companiesSlice = createSlice({
    name: "companies",
    initialState: { value: [] },
    reducers: {
        setCompanies: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { setCompanies } = companiesSlice.actions;

export default companiesSlice.reducer;