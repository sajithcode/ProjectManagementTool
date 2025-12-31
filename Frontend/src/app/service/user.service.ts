import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateuserDto, UpdateuserDto, User } from '../model/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getusers(): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:44382/api/User');
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`https://localhost:44382/api/User/${id}`);
  }

  createUser(user: CreateuserDto): Observable<User> {
    return this.http.post<User>('https://localhost:44382/api/User', user);
  }

  updateUser(id: number, user: UpdateuserDto): Observable<User> {
    return this.http.put<User>(`https://localhost:44382/api/User/${id}`, user);
  }

  deleteByUserId(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44382/api/User/${id}`);
  }
}
