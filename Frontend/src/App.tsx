import './App.css'
import HomePage from './assets/Pages/HomePage'
import Login from './assets/Pages/Login'
import Register from './assets/Pages/Register'

function App() {

  return (
    <>
      <div className='w-3/4 m-auto'>
        <Login />
        <div className='mb-20'></div>
        <HomePage />
      </div>
    </>
  )
}

export default App
