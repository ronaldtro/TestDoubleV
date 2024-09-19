import React, { useState } from 'react';
import AuthForm from '../components/AuthForm';
import { login } from '../services/authService';
import { useNavigate } from 'react-router-dom';
import { setToken } from '../utilities/auth';
import Swal from 'sweetalert2';

const LoginPage: React.FC = () => {
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  const handleLogin = async (data: { email: string; password: string }) => {
    try {
      const response = await login(data.email, data.password);
      if (response.success) {
        localStorage.setItem("user", response.data.user);
        localStorage.setItem("role", response.data.role);
        setToken(response.data.token);
        navigate('/dashboard');
        
        Swal.fire({
          icon: 'success',
          text: "Bienvenid@!",
          toast: true,
          position: 'top-end',
          timer: 3000,
          timerProgressBar: true,
      });

      } else {
        setError('Invalid credentials');
      }
    } catch (err) {
      setError('An error occurred');
    }
  };

  return (
    <div className="flex items-center justify-center h-screen">
      <div className="w-full max-w-md p-6 bg-white rounded shadow-md">
        <h1 className="text-2xl font-bold mb-4">Login</h1>
        <AuthForm onSubmit={handleLogin} mode="login" />
        {error && <p className="text-red-500 mt-4">{error}</p>}
      </div>
    </div>
  );
};

export default LoginPage;
