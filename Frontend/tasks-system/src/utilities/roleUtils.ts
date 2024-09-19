// roleUtils.ts

// Define los roles como constantes
export const ROLES = {
    ADMIN: 'Admin',
    SUPERVISOR: 'Supervisor',
    EMPLOYEE: 'Employee',
  };
  
  // Función para verificar si un usuario tiene un rol específico
  export const hasRole = (userRoles: string[], role: string) => {
    return userRoles.includes(role);
  };
  
  // Función para obtener los roles permitidos para una acción específica (ejemplo)
  export const getAllowedRolesForAction = (action: string) => {
    switch (action) {
      case 'manageUsers':
        return [ROLES.ADMIN];
      case 'assignTasks':
        return [ROLES.ADMIN, ROLES.SUPERVISOR];
      case 'viewTasks':
        return [ROLES.ADMIN, ROLES.SUPERVISOR, ROLES.EMPLOYEE];
      default:
        return [];
    }
  };
  