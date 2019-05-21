import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './recruiter/login/login.component';
import { AlumniLoginComponent } from './alumni/login/login.component';
import { AdminLoginComponent } from './admin/login/login.component';
import { RegistrationComponent } from './recruiter/registration/registration.component';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { AuthGuard } from './common/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { path: 'recruiter', component: LoginComponent },
      { path: 'alumni', component: AlumniLoginComponent  },
      { path: 'admin', component: AdminLoginComponent  },
      { path: 'registration', component: RegistrationComponent },
    ]
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'recruiter', loadChildren: './recruiter/recruiter.module#RecruiterModule', canActivate: [AuthGuard] },
      { path: 'alumni', loadChildren: './alumni/alumni.module#AlumniModule' , canActivate: [AuthGuard]},
      { path: 'admin', loadChildren: './admin/admin.module#AdminModule', canActivate: [AuthGuard] },
    ]
  },
  // App routes goes here here



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
