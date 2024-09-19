import api from './api';
import { Task } from '../models/Task';

interface TaskResponse {
  status: number;
  success: boolean;
  data: Task;
}

interface TaskListResponse {
  status: number;
  success: boolean;
  data: Task[];
}

export const getTask = async (id: string) => {
  try {
    const response = await api.get<TaskResponse>(`/task/${id}`);
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch task');
  }
};

export const getTasks = async () => {
  try {
    const response = await api.get<TaskListResponse>('/tasks');
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch tasks');
  }
};

export const createTask = async (taskData: Omit<Task, 'TaskId'>) => {
  try {
    const response = await api.post<TaskResponse>('/task', taskData);
    return response.data;
  } catch (error) {
    throw new Error('Failed to create task');
  }
};

export const updateTask = async (id: string, taskData: Partial<Omit<Task, 'TaskId'>>) => {
  try {
    const response = await api.put<TaskResponse>(`/task/${id}`, taskData);
    return response.data;
  } catch (error) {
    throw new Error('Failed to update task');
  }
};

export const deleteTask = async (id: string) => {
  try {
    const response = await api.delete<TaskResponse>(`/task/${id}`);
    return response.data;
  } catch (error) {
    throw new Error('Failed to delete task');
  }
};
