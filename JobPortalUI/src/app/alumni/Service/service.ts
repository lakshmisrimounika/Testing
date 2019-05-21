import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import  {  Observable  }  from  'rxjs';
import { configurations } from '../../configuration/app.config'
import { element } from '../../../../node_modules/protractor';

@Injectable({
  providedIn: 'root'
})
export class AlumniService {

  constructor(private http: HttpClient) { }

  GetHttpHeaders(): HttpHeaders {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return headers;
  }


  loginauthenticate(LoginId: string, Password: string): Observable<any> {
    return   this.http.post(configurations.baseUrl + 'Login/Alumni', { LoginId, Password });
  }

  forgotpassword(EmailID: string): Observable<any> {
    return  this.http.post(configurations.baseUrl  + 'ForgotPassword/Recruiter', { EmailID }, { headers:  this.GetHttpHeaders() });
  }

}
