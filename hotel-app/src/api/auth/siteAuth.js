import { ADMIN_LOGIN, SITE_LOGIN } from "../urls"
import axios from "axios";

const siteLogin = (email, password) => {
    const url = SITE_LOGIN;
    return axios.post(url, {
        email: email,
        password: password
    });
}

export default siteLogin;