import api from './api';
import { User } from '../models/User';

interface UserResponse {
  status: number;
  success: boolean;
  data: User;
}

interface UserListResponse {
  status: number;
  success: boolean;
  data: User[];
}

export const getUser = async (id: string) => {
  try {
    const response = await api.get<UserResponse>(`/user/${id}`);
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch user');
  }
};

export const getUsers = async () => {
  try {
    const response = await api.get<UserListResponse>('/users');
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch users');
  }
};

export const updateUser = async (id: string, userData: Partial<User>) => {
  try {
    const response = await api.put<UserResponse>(`/user/${id}`, userData);
    return response.data;
  } catch (error) {
    throw new Error('Failed to update user');
  }
};

export const deleteUser = async (id: string) => {
  try {
    const response = await api.delete<UserResponse>(`/user/${id}`);
    return response.data;
  } catch (error) {
    throw new Error('Failed to delete user');
  }
};

export const postUserRol = async (userId: string, roleId:string) => {
  try {
    const response = await api.post<UserResponse>(`/user/role`, {userId, roleId});
    return response.data;
  } catch (error) {
    throw new Error('Failed to delete user');
  }
};
