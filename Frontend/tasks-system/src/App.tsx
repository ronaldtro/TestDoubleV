import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

// Importar las páginas
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import DashboardPage from './pages/DashboardPage';
import UserManagementPage from './pages/UserManagementPage';
import TaskManagementPage from './pages/TaskManagementPage';
import UsersManagement from './pages/UsersManagement';



const App: React.FC = () => {
  return (
    <Router>
      <Routes>
        {/* Ruta para la página de inicio de sesión */}
        <Route path="/login" element={<LoginPage />} />

        {/* Ruta para la página de registro */}
        <Route path="/register" element={<RegisterPage />} />

        {/* Ruta para la página de dashboard */}
        <Route path="/dashboard" element={<DashboardPage />} />

        {/* Ruta para administrar usuarios */}
        <Route path="/users-management" element={<UsersManagement />} />

        {/* Rutas protegidas para el dashboard y la gestión de usuarios/tareas */}
        <Route>
          <Route path="/" element={<LoginPage />} />
          <Route path="/users" element={<UserManagementPage />} />
          <Route path="/tasks" element={<TaskManagementPage />} />
        </Route>

        {/* Ruta para manejar 404 - Página no encontrada */}
        <Route path="*" element={<div>Page Not Found</div>} />
      </Routes>
    </Router>
  );
};

export default App;
