import { useSelector, useDispatch} from "react-redux";
import './style.css'
import {Link} from 'react-router-dom'
import {closeSideMenu} from '../../../../store/site/siteLayout-slice'
import {logout} from '../../../../store/auth-slice'
const SideMenu = () => {

    const dispatch = useDispatch();

    const isLoggedIn = useSelector(state => state.auth.isLoggedIn);
    const isSideMenuOpen = useSelector(state => state.siteLayout.isSideMenuOpen);

    const handleSiteMenuClose = () => {
        dispatch(closeSideMenu());	
    }
	const handleLogoutClick = () => {
		dispatch(logout());
	}

    const userMenu = <div class={isSideMenuOpen ? "side-menu" : "side-menu-closed"}>
     <div className="side-menu-close">
         <button className="side-menu-button-close" onClick={handleSiteMenuClose}>
             <i className="fa fa-close"></i>
         </button>
     </div>
	<div className="side-menu-item">
            <button className="side-menu-button">Profilim</button>
        </div>
        <div className="side-menu-item">
            <button className="side-menu-button" onClick={handleLogoutClick}> Çıkış Yap</button>
        </div>
    </div>

    const guestMenu = <div class={isSideMenuOpen ? "side-menu" : "side-menu-closed"}>
        <div className="side-menu-close">
         <button className="side-menu-button-close" onClick={handleSiteMenuClose} >
                <i className="fa fa-close"></i>
            </button>
        </div>
        <div className="side-menu-item">
            <Link to="login" className="side-menu-button"> Giriş Yap </Link>
        </div>
    </div>

    if(isLoggedIn)
        return userMenu
    else
        return guestMenu

}

export default SideMenu;
