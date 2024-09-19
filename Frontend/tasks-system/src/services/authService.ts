import api from './api';

interface LoginResponse {
  success: boolean;
  status: number;
  data: {
    user: any; // Puedes reemplazar `any` con un modelo de usuario específico
    token: string;
    role: string;
  };
}

interface RegisterResponse {
  status: number;
  success: boolean;
  data: any; // Puedes reemplazar `any` con un modelo de usuario específico
}

export const login = async (email: string, password: string) => {
  try {
    const response = await api.post<LoginResponse>('/Authentication/login', { email, password });
    return response.data;
  } catch (error) {
    throw new Error('Login failed');
  }
};

export const register = async (email: string, username: string, password: string, names: string, lastNames: string, dateOfBirth: string) => {
  try {
    const response = await api.post<RegisterResponse>('/Authentication/register', { email, username, password, names, lastNames, dateOfBirth });
    return response.data;
  } catch (error) {
    throw new Error('Registration failed');
  }
};
