import { useEffect, useState } from "react"
import { href, Link, useNavigate } from "react-router-dom"
import { useAuth } from "../context/AuthContext"
import { useTheme } from "../context/ThemeContext"
import { FloatingDock } from "./ui/floating-dock"
import { IconHome, IconUser, IconLogin2, IconLogout2, IconTable, IconBrightnessDownFilled, IconBrightnessDown } from "@tabler/icons-react";
import Profile from "./Profile";


export default function Navbar() {
  const navigate = useNavigate()
  const { isAuthenticated, logout } = useAuth()
  const { darkMode, toggleDarkMode } = useTheme()
  const [showProfile, setShowProfile] = useState<boolean>(false)

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
      <div className="fixed left-1/2 -translate-x-1/2 bottom-8 z-50">
        <FloatingDock
          items={[
            {
              title: "Home",
              icon: <IconHome className="w-full h-full" />,
              onClick: () => {
                navigate("/")
              }
            },
            {
              title: "IconTable",
              icon: <IconTable className="w-full h-full" />,
              onClick: () => {
                navigate("/panel")
              }
            },
            {
              title: "Profile",
              icon: <IconUser className="w-full h-full" />,
              onClick: () => {
                setShowProfile(true)
              }
            },
            isAuthenticated ?
              {
                title: "Logout",
                icon: <IconLogout2 className="w-full h-full" />,
                onClick: () => {
                  logout()
                  navigate("/login")
                }
              } :

              {
                title: "Login",
                icon: <IconLogin2 className="w-full h-full" />,
                onClick: () => {
                  navigate("/login")
                }
              },

            darkMode ?
              {
                title: "Bright Mode",
                icon: <IconBrightnessDownFilled className="w-full h-full" />,
                onClick: () => {
                  toggleDarkMode()
                }
              } :
              {
                title: "Dark Mode",
                icon: <IconBrightnessDown className="w-full h-full" />,
                onClick: () => {
                  toggleDarkMode()
                }
              },

          ]}
        ></FloatingDock >
      </div>
      <Profile isOpen={showProfile} onClose={() => setShowProfile(false)}></Profile>
    </>
  )
}