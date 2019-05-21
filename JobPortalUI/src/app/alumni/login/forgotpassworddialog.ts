import { Component,Inject, OnInit} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

@Component({
    selector: 'app-login-forgotpassworddialog',
    templateUrl: '../../forgotpassworddialog.html',
  })
  export class forgotpassworddialog {
   msg:boolean;
    constructor(
      public dialogRef: MatDialogRef<forgotpassworddialog>,
      @Inject(MAT_DIALOG_DATA) public data: any) { }
  
    onNoClick(): void {
      this.dialogRef.close();
    }
    ForgotEmail(emailId:string)
    {
    
       if(emailId == "" || emailId == null)
       {
        alert("Enter your EmailID");
        return;
       } 
       else{
        alert(emailId);
       }
       // this.msg=this.validemail.isEmail(emailId);
        //alert(this.msg);
    }
  }