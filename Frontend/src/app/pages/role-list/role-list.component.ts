import { Component, OnInit } from '@angular/core';
import { RoleService } from '../../service/role.service';
import { Role } from '../../model/role.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-role-list',
  imports: [RouterLink],
  templateUrl: './role-list.component.html',
  styleUrl: './role-list.component.css',
})
export class RoleListComponent implements OnInit {
  roleList: Role[] = [];

  constructor(private roleService: RoleService) {}

  ngOnInit(): void {
    this.getAllRoles();
  }

  getAllRoles() {
    this.roleService.getRoles().subscribe((data) => {
      this.roleList = data;
      console.log(this.roleList);
    });
  }

  onDeleteRole(id: number | undefined) {
    if (!id) {
      alert('Error: Role ID is missing. Cannot delete this role.');
      return;
    }

    const isDelete = confirm('Are you sure you want to delete this role?');
    if (isDelete) {
      this.roleService.deleteByRoleId(id).subscribe({
        next: () => {
          alert('Role deleted successfully');
          this.getAllRoles();
        },
        error: (error) => {
          alert('Failed to delete the role. Please try again.');
          console.error('Delete error:', error);
        },
      });
    }
  }
}
