import { createContext, useContext, useEffect, useState } from "react";
import type { User } from "../interfaces/User"
import { jwtDecode } from "jwt-decode"
import axios from "axios";

interface DecodedToken {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name": string
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress": string
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string | string[]
  exp: number
}

interface AuthContextType {
  user: User | null
  isAuthenticated: boolean;
  login: (token: string, user: User) => void;
  logout: () => void;
  isAdmin: () => boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const fetchUser = async () => {
      const token = localStorage.getItem("token")
      if (token) {
        try {
          const decoded: DecodedToken = jwtDecode(token)

          if (decoded.exp * 1000 < Date.now()) {
            logout()
            return
          }

          const response = await axios.post("https://localhost:7297/api/auth/get",
            JSON.stringify(token), // send raw string
            {
              headers: {
                "Content-Type": "application/json",
              },
            })

          if (!response.data.success) {
            localStorage.removeItem("token")
          }

          const user = response.data.data

          setUser(user)
          setIsAuthenticated(true)
        } catch (error) {
          console.error("Invalid token")
          logout()
        }
      }
    }

    fetchUser()
  }, []);

  const login = (token: string, user: User) => {
    localStorage.setItem("token", token)
    setUser(user)
    setIsAuthenticated(true)
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
    setIsAuthenticated(false);
  };

  const isAdmin = () => {
    return user?.roles.includes("Admin") ?? false;
  }

  return (
    <AuthContext.Provider value={{ user, isAuthenticated, login, logout, isAdmin }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within AuthProvider");
  return context;
};
