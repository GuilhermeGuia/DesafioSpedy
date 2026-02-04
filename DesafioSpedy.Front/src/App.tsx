import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import { AuthLayout } from './layouts/AuthLayout'
import { AppLayout } from './layouts/AppLayout'
import { PublicRoute } from './auth/PublicRoute'
import { PrivateRoute } from './auth/PrivateRoute'
import { Login } from './pages/Login/Login'
import { TicketListPage } from './pages/Tickets/TicketListPage'

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route element={<PublicRoute />}>
          <Route element={<AuthLayout />}>
            <Route path="/login" element={<Login />} />
          </Route>
        </Route>

        <Route element={<PrivateRoute />}>
          <Route element={<AppLayout />}>
            <Route path="/tickets" element={<TicketListPage />} />
          </Route>
        </Route>

        <Route path="*" element={<Navigate to="/tickets" />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
