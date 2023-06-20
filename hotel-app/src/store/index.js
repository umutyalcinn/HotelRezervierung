import { configureStore } from "@reduxjs/toolkit";
import adminLoginSlice from "./admin/login-slice";
import authSlice from "./auth-slice";
import siteLayoutSlice from "./site/siteLayout-slice";
import adminLayoutSlice from "./admin/adminLayout-slice";
 const store = configureStore({
    reducer: {
        auth: authSlice,
        adminLogin: adminLoginSlice,
        siteLayout: siteLayoutSlice,
        adminLayout: adminLayoutSlice,
    }
 });

 export default store;
