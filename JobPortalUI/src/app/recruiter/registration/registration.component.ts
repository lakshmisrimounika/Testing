import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

import { Country, Titles, RecruiterIndustry } from '../Model/country';

import { recruiterRegistration } from '../Model/registration';
import { RecruiterService } from '../Service/service'
import { CustomValidators } from '../validations/validations';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerFormCompanyDetails: FormGroup;
  registerFormContactDetails: FormGroup;
  recruiterRegistration: recruiterRegistration[] = [];
  submitted = false;
  companyId: any;
  disabled = false;
  fcmarked = false;
  scmarked = false;
  tcmarked = false;
  theCheckbox = false;
  captcha: string = '';
  errormessage: string = '';
  enterNumberOnly: string = '';

  constructor(private formBuilder: FormBuilder, private recruiterService: RecruiterService) { }

  ngOnInit() {
    this.registerFormCompanyDetails = this.formBuilder.group({
      companyID: ['0'],
      companyName: ['', Validators.required],
      website: ['', [Validators.required, CustomValidators.ValidateUrl]],
      industry: ['', Validators.required],
      // address:this.formBuilder.group({
      address1: ['', Validators.required],
      address2: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.minLength(5)]],
      // }),   
    })
    this.registerFormContactDetails = this.formBuilder.group({
      companyID: [this.companyId],

      fcfirstName: ['', Validators.required],
      fclastName: ['', Validators.required],
      fctitle: ['', Validators.required],
      fcdesignation: ['', Validators.required],
      fcphoneNumber: [''],
      fcemailId: ['', [Validators.required, Validators.email]],
      fcsendMail: [''],

      scfirstName: [''],
      sclastName: [''],
      sctitle: [''],
      scdesignation: [''],
      scphoneNumber: [''],
      // scemailId: ['', [Validators.required, CustomValidators.emailDomain('gmail.com')]],
      scemailId: [''],
      scsendMail: [''],

      tcfirstName: ['', Validators.required],
      tclastName: ['', Validators.required],
      tctitle: ['', Validators.required],
      tcdesignation: ['', Validators.required],
      tcphoneNumber: [''],
      tcemailId: ['', [Validators.required, Validators.email]],
      tcsendMail: [''],
      acceptPolicies: [1],

      captcha: ['', Validators.required],
    })
    this.recruiterService.getRecruiterRegistrationCaptcha().subscribe(
      (data) => {
        var spacerequire = '';
        for (let i in data) {
          spacerequire += "  " + data[i] + "  ";
        }
        this.captcha = spacerequire
      })
  }
  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      this.enterNumberOnly = "Please enter only numbers";
      return false;
    }
    this.enterNumberOnly = "";
    return true;
  }

  // Validations for forms
  get f() { return this.registerFormCompanyDetails.controls; }
  get f1() { return this.registerFormContactDetails.controls; }

  countries: Country[] = [
    { value: 'India', viewValue: 'India' },
    { value: 'USA', viewValue: 'USA' },
    { value: 'Austalia', viewValue: 'Austalia' }
  ];

  titles: Titles[] = [
    { value: 'Mr', viewValue: 'Mr' },
    { value: 'Ms', viewValue: 'Ms' },
    { value: 'Dr', viewValue: 'Dr' },
  ]
  rIndustrys: RecruiterIndustry[] = [
    { value: 'Accounting', viewValue: 'Accounting' },
    { value: 'Advertising', viewValue: 'Advertising' },
    { value: 'Air Force', viewValue: 'Air Force' },
  ]

  fctoggleVisibility(e) {
    this.fcmarked = e.target.checked;
  }
  sctoggleVisibility(e) {
    this.scmarked = e.target.checked;
  }
  tctoggleVisibility(e) {
    this.tcmarked = e.target.checked;
  }

  validateCaptcha(e) {
    var spacerequire = '';
    for (let i in e.target.value) {
      spacerequire += "  " + e.target.value[i] + "  ";
    }
    if ((this.captcha) == spacerequire) {
      // this.submit();
      this.errormessage = '';
    }
    else {
      this.errormessage = "please check your captcha it must be match!";
    }
  }

  submit() {
    this.submitted = true;
    if (this.registerFormContactDetails.invalid) {
      return;
    }
    else {
      if (this.registerFormCompanyDetails.value != "" || this.registerFormCompanyDetails.value != null) {
        let companyDetails = JSON.stringify(this.registerFormCompanyDetails.value);
        this.recruiterService.createRecruiterComapnyDetails(companyDetails).subscribe((data) => {
          this.companyId = data;
          localStorage.setItem('key', this.companyId);
          alert(this.companyId);
        })
        // , (err: HttpErrorResponse) => {
        //   alert('test service');
        //   if (err.error instanceof Error) {
        //     console.log(err.error + ' client side error');
        //   } else {
        //     console.log("server side error");
        //   };
        // }
      }
      if (this.registerFormContactDetails.value != "" || this.registerFormContactDetails.value != null) {
        let contactDetails = this.registerFormContactDetails.value;
        let companyID = localStorage.getItem('key');
        contactDetails.tcsendMail = this.fcmarked;
        contactDetails.fcsendMail = this.scmarked;
        contactDetails.scsendMail = this.tcmarked;
        let fc = {
          "companyID": companyID,
          "title": contactDetails.fctitle,
          "firstName": contactDetails.fcfirstName,
          "lastName": contactDetails.fclastName,
          "designation": contactDetails.fcdesignation,
          "mobile": contactDetails.fcphoneNumber,
          "emailID": contactDetails.fcemailId,
          "sendMail": contactDetails.fcsendMail,
        }
        let sc = {
          "companyID": companyID,
          "title": contactDetails.scctitle,
          "firstName": contactDetails.scfirstName,
          "lastName": contactDetails.sclastName,
          "designation": contactDetails.scdesignation,
          "mobile": contactDetails.scphoneNumber,
          "emailID": contactDetails.scemailId,
          "sendMail": contactDetails.scsendMail,
        }
        let tc = {
          "companyID": companyID,
          "title": contactDetails.tctitle,
          "firstName": contactDetails.tcfirstName,
          "lastName": contactDetails.tclastName,
          "designation": contactDetails.tcdesignation,
          "mobile": contactDetails.tcphoneNumber,
          "emailID": contactDetails.tcemailId,
          "sendMail": contactDetails.tcsendMail,
        }
        let total_contacts = [fc, sc, tc];
        //  let myParams ={
        //     sss:  'sererer',
        //     contacts: total_contacts
        //   }
        this.recruiterService.createRecruiterContactDetails(total_contacts).subscribe((data) => { console.log(data) });
      }
    }
  }
}
