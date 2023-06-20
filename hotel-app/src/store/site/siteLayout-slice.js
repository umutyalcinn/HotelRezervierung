import { createSlice } from "@reduxjs/toolkit";

const siteLayoutSlice = createSlice({
    name: "siteLayout",
    initialState: {
        isSideMenuOpen: false
    },

    reducers: {
        openSideMenu: (state, action) => {
            state.isSideMenuOpen = true;
        },
        closeSideMenu: (state, action) => {
            state.isSideMenuOpen = false;
        }
    }
})

export const { openSideMenu, closeSideMenu} = siteLayoutSlice.actions;
export default siteLayoutSlice.reducer;
