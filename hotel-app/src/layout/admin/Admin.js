import SideMenu from "../../components/site/layout/SideMenu";
import Menu from "../../components/admin/layout/Menu";
import { useSelector } from "react-redux";
import Dashboard from "../../pages/admin/Dashboard";
import Floors from "../../pages/admin/Floors";
import Rooms from "../../pages/admin/Rooms";
import Rezervations from "../../pages/admin/Rezervations";
const Admin = () => {

    const currentPage = useSelector(state => state.adminLayout.page)

    return(
        <div className="admin">
            <Menu/>
            <SideMenu/>
            {currentPage === "dashboard" && <Dashboard/>}
            {currentPage === "floors" && <Floors/>}
            {currentPage === "rooms" && <Rooms/>}
            {currentPage === "rezervations" && <Rezervations/>}
        </div>
    )
}

export default Admin; 
