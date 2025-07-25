import { createContext, useContext, useEffect, useState } from "react";
import type { User } from "../interfaces/User"
import { jwtDecode } from "jwt-decode"
import axios from "axios";

interface DecodedToken {
  exp: number
}

interface AuthContextType {
  user: User | null
  isAuthenticated: boolean;
  login: (token: string) => void;
  logout: () => void;
  isAdmin: () => boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

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

        const userData = response.data.data

        const user: User = {
          id: userData.id,
          firstName: userData.firstname,
          lastName: userData.lastname,
          email: userData.email,
          tcnumber: userData.tcnumber,
          companyId: userData.companyId,
          roles: userData.roles,
        };

        setUser(user)
        setIsAuthenticated(true)
      } catch (error) {
        console.error("Invalid token")
        logout()
      }
    }
  }

  useEffect(() => {
    fetchUser()
  }, []);

  const login = async (token: string) => {
    localStorage.setItem("token", token)
    await fetchUser()
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
