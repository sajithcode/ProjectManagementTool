import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../../../service/user.service';
import { CreateuserDto } from '../../../model/user.model';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RoleService } from '../../../service/role.service';
import { Role } from '../../../model/role.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-user',
  imports: [FormsModule, CommonModule],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent implements OnInit{

  newUser: CreateuserDto = {
    firstName: '',
    lastName: '',
    email: '',
    contactNo: '',
    password: '',
    roleID: 0
  }

  roles: Role[] = [];

  userService = inject(UserService);
  router = inject(Router);
  roleService = inject(RoleService);

  ngOnInit(): void {
    this.roleService.getRoles().subscribe(roles => {
      this.roles = roles;
    })
  }


  createUser(){
    this.userService.createUser(this.newUser).subscribe(res => {
      alert('User created successfully');
      this.newUser = {
        firstName: '',
        lastName: '',
        email: '',
        contactNo: '',
        password: '',
        roleID: 0
      };
      this.router.navigate(['/user-list']);
    })
  }
}
