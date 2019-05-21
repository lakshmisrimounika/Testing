import { NgModule, NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MaterialModuleModule} from '../material-module.module';
import { AdminRoutingModule } from './admin-routing.module';
import {ReactiveFormsModule} from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MailsComponent } from './mails/mails.component';
import { ActivatejobComponent } from './activatejob/activatejob.component';
import {CommonpagesModule} from '../commonpages/commonpages.module';
import { CKEditorModule } from 'ng2-ckeditor';
import { FormsModule } from '@angular/forms';
import { EmailconfigurationComponent } from './emailconfiguration/emailconfiguration.component';
import { EmailconfigurationeditComponent } from './emailconfigurationedit/emailconfigurationedit.component';
import{EncrDecrService} from '../common/EncrDecrService.service';
import { ManageRecruitersComponent } from './manage-recruiters/manage-recruiters.component';
import { ActivaterecruitersComponent } from './activaterecruiters/activaterecruiters.component';

@NgModule({
  declarations: [ DashboardComponent, MailsComponent, ActivatejobComponent,
    EmailconfigurationComponent, EmailconfigurationeditComponent, ActivaterecruitersComponent, ManageRecruitersComponent
],
  imports: [
    CommonModule,
    AdminRoutingModule,MaterialModuleModule,ReactiveFormsModule,CommonpagesModule,
    CKEditorModule,FormsModule
  ],
  entryComponents:[DashboardComponent],
  schemas: [
  CUSTOM_ELEMENTS_SCHEMA,
  NO_ERRORS_SCHEMA
  ],
  exports: [CKEditorModule] ,
  providers: [EncrDecrService], 
})
export class AdminModule { }
