import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../service/user.service';
import { UpdateuserDto } from '../../../model/user.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from '../../../model/role.model';
import { RoleService } from '../../../service/role.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-user',
  imports: [FormsModule, CommonModule],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css',
})
export class EditUserComponent implements OnInit {
  editUser: UpdateuserDto = {
    firstName: '',
    lastName: '',
    contactNo: '',
    roleID: 0,
    isActive: true,
  };
  userId: number = 0;
  roles: Role[] = [];

  userService = inject(UserService);
  route = inject(ActivatedRoute);
  router = inject(Router);
  roleService = inject(RoleService);

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadUser(this.userId);
    this.roleService.getRoles().subscribe((res) => {
      this.roles = res;
    });
  }

  loadUser(id: number) {
    this.userService.getUserById(id).subscribe((res) => {
      this.editUser = res;
    });
  }

  updateUser() {
    this.userService.updateUser(this.userId, this.editUser).subscribe((res) => {
      alert('User updated successfully');
      this.router.navigate(['/user-list']);
    });
  }
}
