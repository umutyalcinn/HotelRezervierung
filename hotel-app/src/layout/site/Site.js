import Banner from "../../components/site/layout/Banner";
import Menu from "../../components/site/layout/Menu";
import SideMenu from "../../components/site/layout/SideMenu";
import BannerImg from "../../img/home-page-background.jpg";

const Site = () => {
    return (
        <div className="site">
            <Menu></Menu>
            <SideMenu></SideMenu>
            <Banner banner={BannerImg} width="70%"/> 
        </div>
        
    )
}

export default Site;
