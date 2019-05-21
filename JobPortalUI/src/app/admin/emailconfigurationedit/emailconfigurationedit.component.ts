import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from '../Service/service';
import { Router, ActivatedRoute, ParamMap } from "@angular/router";
import{EncrDecrService} from '../../common/EncrDecrService.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-emailconfigurationedit',
  templateUrl: './emailconfigurationedit.component.html',
  styleUrls: ['./emailconfigurationedit.component.css']
})
export class EmailconfigurationeditComponent implements OnInit {

  name = 'ng2-ckeditor';
  ckeConfig: any;
  mycontent: string;
  log: string = '';
  @ViewChild("myckeditor") ckeditor: any;
  submitted = false;
  myForm: FormGroup;
  Id: number;
  constructor(private formBuilder: FormBuilder,private adminService: AdminService, private EncrDecr:EncrDecrService,private router: Router, private route: ActivatedRoute) {
    //this.mycontent = `<p>My html content</p>`;
  }

  ngOnInit() {
    this.myForm = this.formBuilder.group({
      Id: [''],
      formName: [''],
      formEmailId: [''],
      ccMailId: [''],
      bccEmailId: [''],
      subject: [''],
      purpose: [''],
      mycontent: ['', [Validators.required]]

    });

    this.ckeConfig = {
      allowedContent: false,
      extraPlugins: 'divarea',
      forcePasteAsPlainText: true
    };
     this.Id = this.EncrDecr.get('123456$#@$^@1ERF', localStorage.getItem('MailConfigId'));
    if (this.Id > 0) {
      // this.userService.getUserById(+Id).subscribe(data => {  
      //   this.addForm.controls['id'].setValue(data[0]['id']);
      // this.addForm.controls['firstName'].setValue(data[0]['firstName']);
      // this.addForm.controls['lastName'].setValue(data[0]['lastName']);
      // this.addForm.controls['dob'].setValue(data[0]['dob']);
      // this.addForm.controls['gender'].setValue(data[0]['gender']);
      // this.addForm.controls['emailId'].setValue(data[0]['emailId']);
      // this.addForm.controls['createdDate'].setValue(data[0]['createdDate']);
      // this.addForm.controls['password'].setValue(data[0]['password']);
      // this.addForm.get('password').disable();
      //})  
      // this.btnvisibility = false;  
      // this.empformlabel = 'Edit User';  
      // this.empformbtn = 'Update';  
    }

  }

    // convenience getter for easy access to form fields
    get f() { return this.myForm.controls; }

  onChange($event: any): void {
    console.log("onChange");
    //this.log += new Date() + "<br />";
  }
  saveConfig(myForm) {
    this.submitted = true;
    if (this.myForm.invalid) {
      return;
    }
    console.log(myForm);
  }
  cancel() {
    this.router.navigateByUrl('admin/emailconfiguration')
  }
}
