import { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom"

export default function Navbar() {
  const navigate = useNavigate()
  const [isAuthenticated, setIsAuthenticated] = useState(false)

  const checkAuth = () => {
    const token = localStorage.getItem("token")
    if (token) {
      setIsAuthenticated(!!token)
    }
  }

  const logout = () => {
    localStorage.removeItem("token")
    setIsAuthenticated(false)
    navigate("/login")
  }

  useEffect(() => {
    checkAuth()

    const handleStorageChange = (e: any) => {
      if (e.key === "token") {
        checkAuth()
      }
    }

    window.addEventListener("storage", handleStorageChange)

    return () => {
      window.removeEventListener("storage", handleStorageChange)
    }

  }, [])

  return (
    <>
      <div className="absolute top-0 w-full h-16 border-b-2 bg-black border-gray-400 flex items-center justify-center">
        <div className="w-3/4 flex flex-row justify-between items-center text-white text-xl">
          <Link to={"/"}>Home</Link>
          {isAuthenticated ?
            (<button onClick={logout}>Logout</button>) :
            (<Link to={"/login"}>Login</Link>)}
        </div>
      </div>
    </>
  )
}