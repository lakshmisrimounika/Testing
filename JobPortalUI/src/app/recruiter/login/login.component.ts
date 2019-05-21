import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { RecruiterService } from '../Service/service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  empformlabel: string = 'Recruiter Login';

  constructor(private formBuilder: FormBuilder, private router: Router, private recruiterService: RecruiterService) {

  }
  loginForm: FormGroup; display = 'none';
  nameList: any; submitted = false;
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
    this.recruiterService.loginauthenticate(this.loginForm.controls['LoginId'].value, this.loginForm.controls['Password'].value).subscribe(data => {

      if (data == "" || data == null) {
        alert("Please Check EmailID and Password")
      }
      else {
        alert('Login Successfully');
        localStorage.setItem('userToken', data.token);
        localStorage.setItem('user', 'recruiter');
        console.log(data);
         localStorage.setItem('userName',data.loginID);
        this.router.navigateByUrl('recruiter/dashboard');
      }
    },
      error => {
        alert(error);
      });
    //  this.router.navigateByUrl('recruiter/dashboard');
  }

  ForgotPassword() {
    this.submitted1 = true;
    if (this.forgotForm.invalid) {
      return;
    }
    if (this.forgotForm.controls['email'].value == "") {
      alert("Please Ennter EmailID");
    }
    else {
      // let valid=this.validation.validate(EmailID);
      this.recruiterService.forgotpassword(this.forgotForm.controls['email'].value).subscribe(data => {
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


// @Component({
//   selector: 'app-login-forgotpassworddialog',
//   templateUrl: '../../forgotpassworddialog.html',
// })
// export class forgotpassworddialog {
//   msg: boolean;
//   constructor(
//     public dialogRef: MatDialogRef<forgotpassworddialog>,
//     @Inject(MAT_DIALOG_DATA) public data: any) { }

//   onNoClick(): void {
//     this.dialogRef.close();
//   }
//   ForgotEmail(emailId: string) {

//     if (emailId == "" || emailId == null) {
//       alert("enter ur emailid");
//       return;
//     }
//     else {
//       alert(emailId);
//     }
//     // this.msg=this.validemail.isEmail(emailId);
//     //alert(this.msg);
//   }
// }
