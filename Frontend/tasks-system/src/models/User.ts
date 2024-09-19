import { UserRole } from "./UserRole";
import { UserTask } from "./UserTask";

export interface User {
    userId: string;
    username: string;
    email: string;
    password: string;
    names: string;
    lastNames: string;
    dateOfBirth: string; // ISO 8601 Date String
    createdAt: string; // ISO 8601 Date String
    userRoles: UserRole[];
    userTasks: UserTask[];
  }
  