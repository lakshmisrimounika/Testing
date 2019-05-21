import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AdminService} from '../../admin/Service/service'
import { DatePipe } from '@angular/common';
import { FileUploader} from 'ng2-file-upload';
import { HttpClient, HttpRequest,HttpHeaders, HttpEventType, HttpResponse } from '@angular/common/http'
import { Router } from "@angular/router";
import{ configurations } from '../../configuration/app.config';

const URL=configurations.baseUrl+'UploadFile';
@Component({
  selector: 'app-postjob',
  templateUrl: './postjob.component.html',
  styleUrls: ['./postjob.component.css']
})
export class PostjobComponent implements OnInit {

  postJobForm:FormGroup;submitted = false; 
  uploader:FileUploader;fileName:string;
  hasBaseDropZoneOver:boolean;currentUser:any;
  hasAnotherDropZoneOver:boolean;
  response:string;url:any;path:any;

  roleFunction: any[] = ['Others'];
  CountryData : any[] = ['India', 'US', 'UK'];
  jobCategory : any[] = [
    { value: '1', viewValue: 'India' },
    { value: '2', viewValue: 'US' },
    { value: '3', viewValue: 'uk' }
  ];
  CurrencyData: any[] = ['INR', 'ZAR'];
  yearOfExpData: any[] = ['1', '2'];
  domesticDayWiseCounters:any[]=['1','2'];
  cgpa:any[]=['1','2'];

  // constructor(private formBuilder: FormBuilder,private adminService:AdminService,public datepipe: DatePipe,private http:HttpClient) { 
    
  // }
  constructor(private formBuilder: FormBuilder,private router:Router,private adminService:AdminService,public datepipe: DatePipe,private http:HttpClient) {
    //this.currentUser=localStorage.getItem('emailId');
    this.uploader = new FileUploader({
      url: URL,
      disableMultipart: true, // 'DisableMultipart' must be 'true' for formatDataFunction to be called.
      formatDataFunctionIsAsync: true,
      formatDataFunction: async (item) => {
        return new Promise( (resolve, reject) => {
          resolve({
            // name: item._file.name,
            // length: item._file.size,
             contentType: item._file.type,
            // date: new Date()
            fileName: item._file.name,
            filePath: item._file.name
          });
        });
      }
    });

    this.hasBaseDropZoneOver = false;
    this.hasAnotherDropZoneOver = false;

    this.response = '';

    this.uploader.response.subscribe( res => this.response = res );
       }

  ngOnInit() {
    this.postJobForm = this.formBuilder.group({
      jobID: ['0'],
      jobTitle: ['', [Validators.required]],
      roleFunction: [null, [Validators.required]],
      jobCategoryID: [null, [Validators.required]],
      jobDescription: ['', [Validators.required]],
      uploader: ['', [Validators.required]],
      salrange: ['', [Validators.required]],
      currency: [null, [Validators.required]],
      yearofExp: [null, [Validators.required]],
      division: ['', [Validators.required]],
      emailID: ['', [Validators.required,Validators.email]],
      name: ['', [Validators.required]],
      location: ['', [Validators.required]],
      countryID: [null, [Validators.required]],
      deadlineDate: [null, [Validators.required]],
      expectedDateofShortlist: ['', [Validators.required]],
      domesticDayWiseCounters: [null, [Validators.required]],
      cgpa: [null, [Validators.required]],
      value:null

  });
 
  }

  // convenience getter for easy access to form fields
get f() { return this.postJobForm.controls; }

onPostJob() {
  this.submitted = true;
  if (this.postJobForm.invalid) {
    return;
}

let postjobDetails=this.postJobForm.value;
postjobDetails.companyID=175;
postjobDetails.jobFilePath=this.fileName;
postjobDetails.deadlineDate = this.datepipe.transform(this.postJobForm.controls['deadlineDate'].value, 'yyyy-MM-dd');
postjobDetails.expectedDateofShortlist = this.datepipe.transform(this.postJobForm.controls['expectedDateofShortlist'].value, 'yyyy-MM-dd');
this.adminService.AddPostJob(postjobDetails).subscribe(data=>{
  alert("Post Job Successfully");
  this.router.navigateByUrl('./admin/viewalljob');
},
error => {
  alert(error);  
});

}
GetHttpHeaders(): HttpHeaders {
  const headers = new HttpHeaders().set('content-type', 'application/json');
  return headers;
}

uploaderItem(file){
  if(file.length == 0){
    alert("Please Upload file")
  }
  else{
  var formData: FormData = new FormData();
  this.fileName=file[0]._file.name;
  formData.append("image", file[0]._file, file[0]._file.name);
 
  const uploadReq = new HttpRequest('POST', `http://172.16.9.118/JobPortal/api/UploadFile`, formData, {
    reportProgress: true,
  });
this.http.request(uploadReq).subscribe(event => {
this.uploader.queue = []; 
// if (event.type == HttpEventType.UploadProgress)
// {
  
//   //file.progress = Math.round(100 * event.loaded / event.total);
// }
 // this.progress = Math.round(100 * event.loaded / event.total);
 if (event.type === HttpEventType.Response)
{
  file.isSuccess=true;
  file.isUploading=true;
  alert("Uploaded Sucessfully")
  //this.message = event.body.toString();
}

},  
error => {  
file.isError=true;
});
}
}
cancel(){
  this.router.navigateByUrl('/recruiter/viewalljob')
}
}
