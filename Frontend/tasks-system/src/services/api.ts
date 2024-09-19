import axios from 'axios';

// Configura la URL base de la API
const api = axios.create({
  baseURL: 'https://localhost:7107/api', // Cambia esto por la URL base de tu API
  headers: {
    'Content-Type': 'application/json',
  },
});

// Interceptor para agregar el token JWT a cada solicitud
api.interceptors.request.use(
  config => {
    const token = localStorage.getItem('token'); // O usa el método que prefieras para obtener el token
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => Promise.reject(error)
);

export default api;
