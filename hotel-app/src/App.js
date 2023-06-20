import './App.css';
import 'font-awesome/css/font-awesome.css'
import Admin from './layout/admin/Admin';
import Site from './layout/site/Site';
import Login from './pages/site/login/Login'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';

function App() {
  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn)
  const user = useSelector((state) => state.auth.user)
  const dispatch = useDispatch();

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Navigate to={isLoggedIn && user.userType == 1 ? "/admin" : '/site'}/>}></Route>
        <Route path='/site/login' element={<Login></Login>}></Route>
        <Route path='/site' element={<Site></Site>}></Route>
        <Route path='/site/signup'></Route>
        <Route path='/admin' element={isLoggedIn && user.userType == 1 ? <Admin></Admin> : <Navigate to='/site/login'></Navigate>} ></Route>
      </Routes>
    </BrowserRouter>
  )
  
}

export default App;
