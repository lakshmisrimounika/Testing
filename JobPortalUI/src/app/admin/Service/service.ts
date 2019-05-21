import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { configurations } from '../../configuration/app.config';
import { IActivateRecruiter } from '../Model/activateRecruiters';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  authHeader: string;
  //  loginurl: string = 'http://172.16.8.126/JobPortal/api/Login'; 

  constructor(private http: HttpClient) { }

  GetHttpHeaders(): HttpHeaders {
    let headers = new HttpHeaders().set('content-type', 'application/json');
    //headers = headers.append('Authorization', 'Bearer ' + localStorage.getItem('userToken'));
    //console.log(headers);
    return headers;
  }

  loginauthenticate(loginID: string, password: string): Observable<any> {
    const httpheaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post(configurations.baseUrl + 'Login/Staff', { loginID, password });
  }


  forgotpassword(EmailID: string): Observable<any> {
    return this.http.post(configurations.baseUrl + 'ForgotPassword/Recruiter', { EmailID }, { headers: this.GetHttpHeaders() });
  }

  ActivateRecruiters(): Observable<any> {
    return this.http.get<IActivateRecruiter[]>(configurations.baseUrl + 'ManageRecruiters', { headers: this.GetHttpHeaders() });
  }

  getContactDetalsbyId(CompanyID: number) {
    return this.http.post(configurations.baseUrl + 'ManageRecruiters/FetchAllContacts', { CompanyID }, { headers: this.GetHttpHeaders() });
  }

  getCompanyDetalsbyId(CompanyID: number) {
    return this.http.post(configurations.baseUrl + 'ManageRecruiters/FetchCompany', { CompanyID }, { headers: this.GetHttpHeaders() });
  }

  AddPostJob(postjobdetails): Observable<any> {
    return  this.http.post(configurations.baseUrl  + 'PostJob/Staff', postjobdetails, { headers:  this.GetHttpHeaders() });
    }
    // uploadFile(formData): Observable<any> {
    // debugger;
    // return  this.http.post('http://172.16.9.118/JobPortal/api/UploadFile', formData, { headers:  this.GetHttpHeaders() });
    // } 

}