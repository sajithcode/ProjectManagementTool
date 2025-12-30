import { Component, inject } from '@angular/core';
import { RoleService } from '../../service/role.service';
import { Role } from '../../model/role.model';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-role',
  imports: [FormsModule],
  templateUrl: './create-role.component.html',
  styleUrl: './create-role.component.css'
})
export class CreateRoleComponent {

  newRole: Role = {
    roleName: '',
    roleDescription: '',
  };

  // constructor(private roleService: RoleService) { }
  roleService = inject(RoleService);
  router = inject(Router);

  createRole(){
    debugger;
    this.roleService.CreateRole(this.newRole).subscribe(res=>{
      alert('Role created successfully');
      this.newRole = { roleName: '', roleDescription: ''};
      this.router.navigate(['/role-list']);
    });
  }


}


// roleID: number;
// roleName: string;
// roleDescription: string;
// status: boolean;