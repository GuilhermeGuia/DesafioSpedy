import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "./useAuth";

export function PublicRoute() {
  const { isAuthenticated } = useAuth();

  if (isAuthenticated) {
    return <Navigate to="/tickets" replace />;
  }

  return <Outlet />;
}
