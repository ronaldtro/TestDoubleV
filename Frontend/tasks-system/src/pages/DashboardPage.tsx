import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const DashboardPage: React.FC = () => {

  const [role, setRole] = useState("");

  useEffect(() => {
    const role = localStorage.getItem("role");
    if (role) {
      setRole(role == "1" ? "administrador" : role == "2" ? "Supervidor" : "Empleado");
    };
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Dashboard - {role}</h1>
      {/* Administrador */}
      <div className="space-y-4">
        {/* <Link to="/tasks" className="block p-4 bg-blue-500 text-white rounded text-center">Manage Tasks</Link>
        <Link to="/users" className="block p-4 bg-green-500 text-white rounded text-center">Manage Users</Link> */}
        {role == "administrador" ? <div className="">
          <Link to="/register" className="block p-4 bg-green-500 text-white rounded text-center">
            Crear usuarios
          </Link>
          <Link to="/users-management" className="block p-4 bg-blue-500 text-white rounded text-center">
            Administrar usuarios
          </Link>
        </div> : ""}
      </div>

    </div>
  );
};

export default DashboardPage;
