import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from '../model/role.model';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  constructor(private http: HttpClient) {}

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>('https://localhost:44382/api/Roles');
  }

  getRoleById(id: number): Observable<Role> {
    return this.http.get<Role>(`https://localhost:44382/api/Roles/${id}`);
  }

  CreateRole(role: Role): Observable<Role> {
    return this.http.post<Role>('https://localhost:44382/api/Roles', role);
  }

  updateRole(id: number, role: Role): Observable<Role> {
    return this.http.put<Role>(`https://localhost:44382/api/Roles/${id}`, role);
  }

  deleteByRoleId(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44382/api/Roles/${id}`);
  }
}
