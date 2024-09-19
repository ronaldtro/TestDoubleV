// auth.ts
import * as jwtDecode from 'jwt-decode';


// Función para guardar el token en el almacenamiento local
export const setToken = (token: string) => {
  localStorage.setItem('token', token);
};

// Función para obtener el token del almacenamiento local
export const getToken = () => {
  return localStorage.getItem('token');
};

// Función para eliminar el token del almacenamiento local (logout)
export const removeToken = () => {
  localStorage.removeItem('token');
};

// Función para verificar si el usuario está autenticado
export const isAuthenticated = () => {
  return !!getToken();
};

interface DecodedToken {
  userId: string;
  exp: number;
  // Añadir otros campos según el contenido del token
}

// export const getDecodedToken = () => {
//   const token = getToken();
//   if (token) {
//     try {
//       return jwtDecode(token) as DecodedToken;
//     } catch (e) {
//       console.error('Failed to decode token', e);
//     }
//   }
//   return null;
// };
