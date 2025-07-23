import './App.css'
import { Routes, Route } from "react-router-dom"
import Navbar from './components/Navbar'
import HomePage from './Pages/HomePage'
import Login from './Pages/Login'
import Signup from './Pages/Signup'
import UsersPanel from './Pages/UsersPanel'
function App() {

  return (
    <>



      <div className='m-auto'>
        <Routes>
          <Route path="/panel" element={<UsersPanel />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Signup />} />
          <Route path="/" element={<HomePage />} />
        </Routes>
      </div>

    </>
  )
}

export default App
