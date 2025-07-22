import { createContext, useContext, useEffect, useState } from "react";
import type { User } from "../interfaces/User"
import { jwtDecode } from "jwt-decode"

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
  login: (token: string) => void;
  logout: () => void;
  isAdmin: () => boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("token")
    if (token) {
      try {
        const decoded: DecodedToken = jwtDecode(token)

        if (decoded.exp * 1000 < Date.now()) {
          logout()
          return
        }

        const userData: User = {
          id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
          email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
          name: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
          roles: Array.isArray(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
            ? decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
            : [decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]],
          tcnumber: "", // not in token
          companyId: "" // not in token
        }

        setUser(userData)
        setIsAuthenticated(true)
      } catch (error) {
        console.error("Invalid token")
        logout()
      }
    }
  }, []);

  const login = (token: string) => {
    localStorage.setItem("token", token)
    const decoded: DecodedToken = jwtDecode(token)

    const userData: User = {
      id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
      email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
      name: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
      roles: Array.isArray(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
        ? decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
        : [decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]],
      tcnumber: "",
      companyId: ""
    }

    setUser(userData)
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
