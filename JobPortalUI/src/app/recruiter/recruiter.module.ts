import { NgModule, NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';
import { RecruiterRoutingModule } from './recruiter-routing.module';
//import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import {MaterialModuleModule} from '../material-module.module';
import { RecruiterHomeComponent } from './recruiter-home/recruiter-home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import {CommonpagesModule} from '../commonpages/commonpages.module';

@NgModule({
  declarations: [ RegistrationComponent, RecruiterHomeComponent, DashboardComponent,
  ],
  imports: [
    CommonModule,
    RecruiterRoutingModule,
    MaterialModuleModule,ReactiveFormsModule,CommonpagesModule
  
  ],
   entryComponents:[RegistrationComponent],
schemas: [
CUSTOM_ELEMENTS_SCHEMA,
NO_ERRORS_SCHEMA
],
exports:[RegistrationComponent] 

})
export class RecruiterModule { }
