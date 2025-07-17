import './App.css'
import { Routes, Route } from "react-router-dom"
import HomePage from './Pages/HomePage'
import Login from './Pages/Login'
import Register from './Pages/Register'
import UsersPanel from './Pages/UsersPanel'
function App() {

  return (
    <>
      <div className='w-3/4 m-auto'>
        <Routes>
          <Route path="/" element={<UsersPanel />} />
          <Route path="/login" element={<Login />} />
        </Routes>

      </div>

    </>
  )
}

export default App
