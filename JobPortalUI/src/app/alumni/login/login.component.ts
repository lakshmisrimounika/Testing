import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AlumniService } from '../Service/service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AlumniService]
})
export class AlumniLoginComponent implements OnInit {
  empformlabel: string = 'Alumni Login';

  constructor(private formBuilder: FormBuilder, private router: Router, private alumniService: AlumniService) {

  }
  loginForm: FormGroup; display = 'none';
  submitted = false;
  submitted1 = false;
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
    this.alumniService.loginauthenticate(this.loginForm.controls['LoginId'].value, this.loginForm.controls['Password'].value).subscribe(data => {


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
        localStorage.setItem('userName',"alumni");
      }
       localStorage.setItem('user', 'alumni');
      // localStorage.setItem('userName','alumni');
      this.router.navigateByUrl('alumni/dashboard');

    },
      error => {
        alert(error);
      });
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
      this.alumniService.forgotpassword(this.forgotForm.controls['email'].value).subscribe(data => {
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

