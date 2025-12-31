import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../../../service/user.service';
import { User } from '../../../model/user.model';
import { RouterLink } from '@angular/router';
import { RoleService } from '../../../service/role.service';
import { Role } from '../../../model/role.model';

@Component({
  selector: 'app-user-list',
  imports: [RouterLink],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {

  usersList: User[] = [];
  role: Role[] = [];

  userService = inject(UserService);
  roleService = inject(RoleService);

  ngOnInit(): void {
    this.getAllUsers();
    this.loadRoles();
  }

  getAllUsers(){
    this.userService.getusers().subscribe((data)=>{
      this.usersList = data;
      console.log(this.usersList);
    })
  }

  private loadRoles(): void {
    this.roleService.getRoles().subscribe({
      next: (roles: Role[]) => {
        this.role = roles;
      },
      error: (err) =>{
        console.error('Error loading roles:', err);
      }
    });
  }

  getRoleName(roleID: number): string {
    const role = this.role.find(r => r.roleID === roleID);
    return role ? role.roleName : 'Unknown';
  }

  onDeleteUser(id: number | undefined) {
    if (!id) {
      alert('Error: User ID is missing. Cannot delete this user.');
      return;
    }

    const isDelete = confirm('Are you sure you want to delete this user?');
    if(isDelete){
      this.userService.deleteByUserId(id).subscribe({
        next: () => {
          alert('User deleted successfully');
          this.getAllUsers();
        },
        error: (error) => {
          alert('Failed to delete the user. Please try again.');
          console.error('Delete error:', error);
        }

      });
    }
  }
}
