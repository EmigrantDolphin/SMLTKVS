import { createSlice } from '@reduxjs/toolkit';

export const userSlice = createSlice({
    name: "user",
    initialState: { value: { name: "", age: 1, email: "" } },
    reducers: {
        login: (state, action) => {
            state.value = action.payload;
        }
    }
});

export const { login } = userSlice.actions;

// use it like this
// import { useDispatch } from 'react-redux';
// import { login } from '../reducers/user'
//dispatch(login({name: '', age: 1, email: ''})); //Pretty much call the action 

export default userSlice.reducer;