import { createSlice } from '@reduxjs/toolkit';

export const usersSlice = createSlice({
    name: "users",
    initialState: { value: [] },
    reducers: {
        setUsers: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { setUsers } = usersSlice.actions;

export default usersSlice.reducer;