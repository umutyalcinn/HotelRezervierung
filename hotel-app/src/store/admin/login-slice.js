import { createSlice } from "@reduxjs/toolkit";

const adminLoginSlice = createSlice({
        name: "adminLogin",
        initialState: {
            email: "",
            password: ""
        },
        reducers: {
            setPassword: (state, action) => {
                state.password = action.payload;
            },
            setEmail: (state, action) => {
                state.email = action.payload;
            }
        }
    }
);

export const { setPassword, setEmail } = adminLoginSlice.actions;
export default adminLoginSlice.reducer;