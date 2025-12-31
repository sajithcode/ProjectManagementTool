export interface User {
  userID: number;
  firstName: string;
  lastName: string;
  email: string;
  contactNo: string;
  password: string;
  roleID: number;
  isActive: boolean;
}

export interface CreateuserDto {
  firstName: string;
  lastName: string;
  email: string;
  contactNo?: string;
  password: string;
  roleID: number;
}

export interface UpdateuserDto {
  firstName: string;
  lastName: string;
  contactNo?: string;
  roleID: number;
  isActive: boolean;
}
