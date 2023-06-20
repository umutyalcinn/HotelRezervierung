import { createSlice } from "@reduxjs/toolkit";

const authSlice = createSlice({
	name: 'auth',
	initialState: {
		isLoggedIn: false,
		user: null,
	},
	reducers: {
		login: (state, action) => {
			state.user = action.payload;
			state.isLoggedIn = true;
		},
		logout: (state, action) => {
			state.user = null;
			state.isLoggedIn = false;
	    	}
	}
});

export const {login, logout} = authSlice.actions;
export default authSlice.reducer; 
