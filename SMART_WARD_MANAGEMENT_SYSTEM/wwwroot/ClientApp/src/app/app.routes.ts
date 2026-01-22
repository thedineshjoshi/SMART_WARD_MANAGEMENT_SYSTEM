import { Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { DashboardComponent } from './Components/layout/dashboard/dashboard.component';
import { LayoutComponent } from './Components/layout/layout.component';
import { UserRegisterComponent } from './Components/user-register/user-register.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'ward',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        component: DashboardComponent,
      },
    ],
  },
  {path:'registerUser',component:UserRegisterComponent,pathMatch:'full'}
];
