import { ADMIN_LOGIN } from "../urls"
import axios from "axios";

const adminLogin = (email, password) => {
    const url = ADMIN_LOGIN;
    return axios.post(url, {
        email: email,
        password: password
    });
}

export default adminLogin;