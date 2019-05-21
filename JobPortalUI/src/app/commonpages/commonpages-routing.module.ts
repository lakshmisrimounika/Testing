import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PostjobComponent} from './postjob/postjob.component';
import {ListingjobComponent} from './listingjob/listingjob.component';
import {UpdatestatusComponent} from './updatestatus/updatestatus.component';
import {AppliedalumnilistingsComponent} from './appliedalumnilistings/appliedalumnilistings.component';
import {ViewalljobComponent} from './viewalljob/viewalljob.component'
const routes: Routes = [
  {path:'postjob', component:PostjobComponent },
  {path:'listjob', component:ListingjobComponent},
  {path:'updatestatus', component:UpdatestatusComponent}, 
  {path:'appliedalumnilisting', component:AppliedalumnilistingsComponent},
  {path:'viewalljob', component:ViewalljobComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
