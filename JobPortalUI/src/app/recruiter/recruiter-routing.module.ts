import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import {LoginComponent} from './login/login.component';
import {RecruiterHomeComponent} from './recruiter-home/recruiter-home.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {AppliedalumnilistingsComponent} from '../commonpages/appliedalumnilistings/appliedalumnilistings.component';
import {ListingjobComponent} from '../commonpages/listingjob/listingjob.component';
import {PostjobComponent} from '../commonpages/postjob/postjob.component';
import {UpdatestatusComponent} from '../commonpages/updatestatus/updatestatus.component';
import{ViewalljobComponent} from '../commonpages/viewalljob/viewalljob.component';
const routes: Routes = [
  //{path:'', component:LoginComponent },
  {path:'Home', component:RecruiterHomeComponent},
  {path:'dashboard', component:DashboardComponent},
  {path:'appliedalumnilisting', component:AppliedalumnilistingsComponent},
  {path:'listingjob', component:ListingjobComponent},
  {path:'postjob', component:PostjobComponent},
  {path:'updatestatus', component:UpdatestatusComponent},
  {path:'viewalljob', component:ViewalljobComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
