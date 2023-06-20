import './style.css'
import { openSideMenu } from '../../../../store/site/siteLayout-slice';
import { useDispatch } from 'react-redux';
import logo from '../../../../img/logo.png'
import { setPage } from '../../../../store/admin/adminLayout-slice';
const Menu = () => {
    const dispatch = useDispatch();

    const handleUserClick = () => {
        dispatch(openSideMenu());
    }

    const handleMenuClick = (page) => {
        dispatch(setPage(page));
    }

    return(
        <div className="navbar">
            <div className='menu'>
                <img src={logo} className="logo"></img>
                <div className='menu-item'>
                    <button onClick={() => handleMenuClick("dashboard")} className='menu-button'>
                        Ana Menü
                    </button>
                </div>
                <div className='menu-item'>
                    <button onClick={() => handleMenuClick("floors")} className='menu-button'>
                        Katlar
                    </button>
                </div>
                <div className='menu-item'>
                    <button onClick={() => handleMenuClick("rooms")} className='menu-button'>
                        Odalar
                    </button>
                </div>
                <div className='menu-item'>
                    <button onClick={() => handleMenuClick("rezervations")} className='menu-button'>
                        Rezervasyonlar
                    </button>
                </div>
            </div>
            <div className='end-menu'>
                <div className='end-menu-item'>
                    <button className='menu-button' onClick={handleUserClick}>
                        <i className='fa fa-lg fa-user'></i>
                    </button>
                </div>
            </div>
        </div>
    )
} 

export default Menu;
