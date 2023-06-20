import './style.css'
import logo from '../../../../img/logo.png'
import {openSideMenu} from '../../../../store/site/siteLayout-slice'
import {useDispatch} from 'react-redux'

const Menu = () => {
    
    const dispatch = useDispatch();

    const handleUserClick = () => {
        dispatch(openSideMenu());
    }
    

    return (
        <div className="navbar" src={logo}>
            <div className='menu'>
                <img src={logo} className='logo'></img>
                <div className='menu-item'>
                    <button className='menu-button'>
                        Ana Sayfa
                    </button>
                </div>
                <div className='menu-item'>
                    <button className='menu-button'>
                        Rezervasyon
                    </button>
                </div>
                <div className='menu-item'>
                    <button className='menu-button'>
                        İletişim
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
