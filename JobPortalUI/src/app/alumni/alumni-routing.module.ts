import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DashboardComponent} from './dashboard/dashboard.component';
import {ApplyjobComponent} from './applyjob/applyjob.component';
import{ViewprofileComponent} from './viewprofile/viewprofile.component'
import {AppliedalumnilistingsComponent} from '../commonpages/appliedalumnilistings/appliedalumnilistings.component';
import {ListingjobComponent} from '../commonpages/listingjob/listingjob.component';
import {PostjobComponent} from '../commonpages/postjob/postjob.component';
import {UpdatestatusComponent} from '../commonpages/updatestatus/updatestatus.component';

const routes: Routes = [
  //{path:'', component:AlumniLoginComponent},
  {path:'dashboard', component:DashboardComponent},
  {path:'applyjob', component:ApplyjobComponent},
  {path:'viewprofile', component:ViewprofileComponent},
  {path:'appliedalumnilisting', component:AppliedalumnilistingsComponent},
  {path:'listingjob', component:ListingjobComponent},
  {path:'postjob', component:PostjobComponent},
  {path:'updatestatus', component:UpdatestatusComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlumniRoutingModule { }
