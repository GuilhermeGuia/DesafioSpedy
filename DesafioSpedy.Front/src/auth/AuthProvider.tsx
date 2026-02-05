import { useState } from "react";
import { AuthContext } from "./AuthContext";
import { storage } from '../utils/storage';


export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [isAuthenticated, setIsAuthenticated] = useState(
    !!storage.getToken()
  );

  function login(token: string) {
    storage.setToken(token)
    setIsAuthenticated(true);
  }

  function logout() {
    storage.clear();
    setIsAuthenticated(false);
  }

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}
