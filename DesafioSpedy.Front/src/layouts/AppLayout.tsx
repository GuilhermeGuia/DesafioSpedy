
import { Outlet } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";

export function AppLayout() {
  const { logout } = useContext(AuthContext);

  return (
    <div>
      <header style={{ padding: 16, borderBottom: "1px solid #ccc" }}>
        <strong>Support Tickets</strong>
        <button onClick={logout} style={{ float: "right" }}>
          Sair
        </button>
      </header>

      <main style={{ padding: 16 }}>
        <Outlet />
      </main>
    </div>
  );
}
