import { NgModule } from '@angular/core';
import { CommonModule,DatePipe } from '@angular/common';
import { PostjobComponent } from './postjob/postjob.component';
import { ListingjobComponent } from './listingjob/listingjob.component';
import { UpdatestatusComponent } from './updatestatus/updatestatus.component';
import { AppliedalumnilistingsComponent } from './appliedalumnilistings/appliedalumnilistings.component';
import { ViewalljobComponent } from './viewalljob/viewalljob.component';
import {ReactiveFormsModule,FormsModule} from '@angular/forms';
import { DatepickerModule, BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FileSelectDirective, FileDropDirective,FileUploadModule } from 'ng2-file-upload';
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [PostjobComponent, ListingjobComponent, UpdatestatusComponent, AppliedalumnilistingsComponent, ViewalljobComponent
    //, FileSelectDirective,
    //FileDropDirective
  ],


  imports: [
    CommonModule,ReactiveFormsModule,FormsModule,
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),HttpClientModule,
     FileUploadModule
  ],
  exports:[PostjobComponent, ListingjobComponent, 
    UpdatestatusComponent, AppliedalumnilistingsComponent, ViewalljobComponent,FileUploadModule
  
  ],
  providers: [DatePipe]
})
export class CommonpagesModule { }
