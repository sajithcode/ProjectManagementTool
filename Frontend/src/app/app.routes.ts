import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { CreateUserComponent } from './pages/create-user/create-user.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { RoleListComponent } from './pages/role-list/role-list.component';
import { CreateRoleComponent } from './pages/create-role/create-role.component';
import { EditRoleComponent } from './pages/edit-role/edit-role.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: 'user-list',
                component: UserListComponent
            },
            {
                path: 'createUser',
                component: CreateUserComponent
            },
            {
                path: 'role-list',
                component: RoleListComponent
            },
            {
                path: 'createRole',
                component: CreateRoleComponent
            },
            {
                path: 'editRole/:id',
                component: EditRoleComponent
            }
        ]
    }
];
