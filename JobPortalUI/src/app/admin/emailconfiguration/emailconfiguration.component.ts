import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AdminService } from '../Service/service';
import { Router } from "@angular/router";
import {EncrDecrService} from '../../common/EncrDecrService.service';
@Component({
  selector: 'app-emailconfiguration',
  templateUrl: './emailconfiguration.component.html',
  styleUrls: ['./emailconfiguration.component.css']
})
export class EmailconfigurationComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private EncrDecr:EncrDecrService, private adminService: AdminService, private router: Router) { }
  users: Array<Object>;

  mailConfig = [
    {
      "Id": "1",
      "Subject": "New Recruiter Signup",
      "Purpose": "Mail to admin when a new recruiter registers",
      "seq": "1"
    },
    {
      "Id": "2",
      "Subject": "New recruiter registration",
      "Purpose": "Mail to recruiter on registration",
      "seq": "2"
    },
    {
      "Id": "3",
      "Subject": "Forgot Password request",
      "Purpose": "Reply to password request of recruiter",
      "seq": "3"
    }
  ]

  ngOnInit() {
    // this.adminService.getUsers().subscribe((data) => {
    // this.userData = data; 
    this.users = this.mailConfig;
    // });

  }
  disabledmail(mailConfig) {
    console.log(mailConfig);
    // this.userService.deleteUser(user).subscribe(data => {
    //   alert("Deleted successfully")
    //   this.users=this.users.filter(a=>a !== user);
    // });
  }
  editmail(mailConfig): void {
    
    var encryptedId = this.EncrDecr.set('123456$#@$^@1ERF', mailConfig.Id);
    localStorage.setItem("MailConfigId", encryptedId);
    this.router.navigate(['/admin/emailconfigurationEdit']);

  }

}
