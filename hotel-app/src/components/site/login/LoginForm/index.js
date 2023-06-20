import { useSelector, useDispatch } from "react-redux";
import { setEmail, setPassword } from "../../../../store/admin/login-slice";
import adminLogin from "../../../../api/auth/adminAuth";
import './style.css'
import { useState } from "react";
import siteLogin from "../../../../api/auth/siteAuth";
import {login} from "../../../../store/auth-slice";
import {useNavigate} from "react-router-dom";
const LoginForm = () => {

    const navigate = useNavigate();
    const user = useSelector(state => state.auth.user);
    const isLoggedIn = useSelector(state => state.auth.isLoggedIn);
    if(isLoggedIn){
	    if(user.userType === 0)
		    navigate("/site");
	    else if(user.userType === 1)
		    navigate("/admin");
    }
    
    const [isEmployee, setIsEmployee] = useState(false);

    const email = useSelector(state => state.adminLogin.email);
    const password = useSelector(state => state.adminLogin.password);

    const dispatch = useDispatch();

    const handlePassword = (event) => {
        dispatch(setPassword(event.target.value));
    }

    const handleEmail = (event) => {
        dispatch(setEmail(event.target.value));
    }

    const handleLogin = () => {
        if(isEmployee){
            adminLogin(email, password).then(res => {
                if(res.status == 200)
		    dispatch(login({
			...res.data,
			userType: 1
		    }));
                else if(res.status == 401)
                    alert("Geçersiz Kullanıcı Adı veya Şifre!");
            }).catch(error => {
                alert("Geçersiz Kullanıcı Adı veya Şifre!");
            });
        }
        else{
            siteLogin(email, password).then(res => {
                if(res.status == 200){
		    dispatch(login({
			    ...res.data,
			    userType: 0
		    }));
	    	}
                else if(res.status == 401)
                    alert("Geçersiz Kullanıcı Adı veya Şifre!");
            }).catch(error => {
                alert("Geçersiz Kullanıcı Adı veya Şifre!");
            });
        }
        
    }

    const handleCustomer = () => {
        setIsEmployee(false);
    }

    const handleEmployee = () => {
        setIsEmployee(true);
    }


    return (
        <div className="container">
            <div className='login-form'>
                <div className="tab">
                    <button className={'tab-item ' + (isEmployee ? '' : 'selected')} onClick={handleCustomer}>
                        Müşteri
                    </button>
                    <button className={'tab-item ' + (isEmployee ? 'selected' : '')} onClick={handleEmployee}>
                        Personel
                    </button>
                </div>
                <div className='body'>
                    <div className="header">
                        {isEmployee ? "Personel " : "Müşteri "} Giriş
                    </div>
                    <div className='email input'>
                        <span className="icon"><i className="fa fa-user" aria-hidden="true"></i></span>
                        <input id='username' placeholder='E-Mail' type='text' onChange={handleEmail}></input>
                    </div>
                    
                    <div className='password input'>                    
                        <span className="icon"><i className="fa fa-xl fa-lock"></i></span>               
                        <input id='password' placeholder='Şifre' type='password' onChange={handlePassword}></input>
                    </div>

                    <div>                  
                        <input id='rememberMe' className="input" type='checkbox'/>                        
                        <label for='rememberMe'>Beni Hatırla</label>
                    </div>

                    <div className='sign-in input'>
                        <button className='button' onClick={handleLogin} id='submit' type='button'>Giriş Yap</button>
                    </div>
                </div>
            </div>
        </div>
        
        
    );
}

export default LoginForm;
