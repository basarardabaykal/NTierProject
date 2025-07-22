import { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import { useAuth } from "../context/AuthContext"

export default function Navbar() {
  const navigate = useNavigate()
  const { isAuthenticated, logout } = useAuth()

  useEffect(() => {
    const handleStorageChange = (e: StorageEvent) => {
      if (e.key === "token") {
        window.location.reload()
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
            (<button
              onClick={() => {
                logout()
                navigate("/login")
              }}
            >Logout</button>) :
            (<Link to={"/login"}>Login</Link>)}
        </div>
      </div>
    </>
  )
}