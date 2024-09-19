// taskUtils.ts

// Función para verificar si una tarea está en un estado específico
export const isTaskInState = (taskStateId: string, expectedState: string) => {
    return taskStateId === expectedState;
  };
  
  // Función para convertir el estado de una tarea en una etiqueta legible (ejemplo)
  export const getTaskStateLabel = (taskStateId: string) => {
    switch (taskStateId) {
      case '1':
        return 'Pending';
      case '2':
        return 'In Progress';
      case '3':
        return 'Completed';
      default:
        return 'Unknown';
    }
  };
  
  // Función para determinar si una tarea está completada
  export const isTaskCompleted = (taskStateId: string) => {
    return taskStateId === '3'; // Asumiendo que '3' es el estado de completada
  };
  