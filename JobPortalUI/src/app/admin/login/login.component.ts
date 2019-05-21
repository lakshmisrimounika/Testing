import { Component, Inject, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
//import { ValidationComponent } from '../../validations/validation';
import { Router } from "@angular/router";
import { AdminService } from '../Service/service'
import { ErrorStateMatcher } from '@angular/material/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class AdminLoginComponent implements OnInit {
  empformlabel: string = 'Admin Login';

  constructor(private formBuilder: FormBuilder, private router: Router, private adminService: AdminService) {

  }
  loginForm: FormGroup; display = 'none';
  submitted = false; submitted1 = false;
  forgotForm: FormGroup;


  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      LoginId: ['', [Validators.required]],
      Password: ['', [Validators.required]]

    });
    this.forgotForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }
  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }
  get f1() { return this.forgotForm.controls; }


  onLogin() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.adminService.loginauthenticate(this.loginForm.controls['LoginId'].value, this.loginForm.controls['Password'].value).subscribe(data => {
      if (data == "" || data == null) {
        alert("Please Check EmailID and Password")
      }
      else {
        alert('Login Successfully');
        if(data.token !=null)
        {
          localStorage.setItem('userToken',data.token);
        }
        else{
          localStorage.setItem('userToken',"45354jj");
        }
        if(data.loginID !=null)
        {
          localStorage.setItem('userName',data.loginID);
        }
        else{
          localStorage.setItem('userName',"Admin");
        }
         //localStorage.setItem('userToken','32424vf');
         localStorage.setItem('user', 'admin');
        //  localStorage.setItem('userName',data.loginID);'
       // localStorage.setItem('userName','Admin');
        this.router.navigateByUrl('admin/dashboard');
      }
    },
      error => {
        alert(error);
      });
    //this.router.navigateByUrl('admin/dashboard'); 
  }

  ForgotPassword() {

    this.submitted1 = true;
    if (this.forgotForm.invalid) {
      return;
    }
    if (this.forgotForm.controls['email'].value == "") {
      alert("Please Enter EmailID");
    }
    else {
      // let valid=this.validation.validate(EmailID);
      this.adminService.forgotpassword(this.forgotForm.controls['email'].value).subscribe(data => {

        console.log(data);
        alert('Password has been sent to your Email..!');
        this.onCloseHandled();
      },
        err => console.log(err));
    }
  }

  openDialog() {
    this.display = 'block';
  }

  onCloseHandled() {
    this.display = 'none';
  }

}

