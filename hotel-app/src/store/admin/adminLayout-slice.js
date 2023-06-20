import { createSlice } from "@reduxjs/toolkit";

const adminLayoutSlice = createSlice({
    name: "adminLayout",
    initialState: {
        page: "dashboard"
    },
    reducers: {
        setPage : (state, action) => {
            state.page = action.payload
        }
    }
})

export const { setPage } = adminLayoutSlice.actions
export default adminLayoutSlice.reducer;
