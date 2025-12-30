import { Component, inject, OnInit } from '@angular/core';
import { RoleService } from '../../service/role.service';
import { Role } from '../../model/role.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-role',
  imports: [FormsModule],
  templateUrl: './edit-role.component.html',
  styleUrl: './edit-role.component.css',
})
export class EditRoleComponent implements OnInit {
  editRole: Role = {
    // roleID: 0,
    roleName: '',
    roleDescription: '',
    status: true,
  };
  roleId: number = 0;

  roleService = inject(RoleService);
  route = inject(ActivatedRoute);
  router = inject(Router);

  ngOnInit() {
    this.roleId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadRole(this.roleId);
  }

  loadRole(id: number) {
    this.roleService.getRoleById(id).subscribe((res) => {
      this.editRole = res;
    });
  }

  updateRole() {
    // this.editRole.roleID = this.roleId;
    this.roleService.updateRole(this.roleId, this.editRole).subscribe((res) => {
      alert('Role updated successfully');
      this.router.navigate(['/role-list']);
    });
  }
}
