import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from "rxjs/operators";
import { configurations } from '../../configuration/app.config';

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private http: HttpClient) { }

  GetHttpHeaders(): HttpHeaders {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return headers;
  }

  loginauthenticate(LoginId: string, Password: string): Observable<any> {
    // const httpheaders=new HttpHeaders().set("Content-Type","application/json");
    return this.http.post(configurations.baseUrl + 'RecruiterAuthentication/authenticate', { LoginId, Password }, { headers: this.GetHttpHeaders() });
  }

  createRecruiterComapnyDetails(companydetails): Observable<any> {
    return this.http.post(configurations.baseUrl + 'RecruiterRegistration', companydetails, { headers: this.GetHttpHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  createRecruiterContactDetails(contactDetails): Observable<any> {
    return this.http.post(configurations.baseUrl + 'RecruiterRegistration/PostRecruiterContact', contactDetails, { headers: this.GetHttpHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  getRecruiterRegistrationCaptcha(): Observable<any> {
    return this.http.get(configurations.baseUrl + 'RecruiterRegistration', { headers: this.GetHttpHeaders() })
    .pipe(
      catchError(this.handleError)
    );
  }
  forgotpassword(EmailID: string): Observable<any> {
    return this.http.post(configurations.baseUrl + 'ForgotPassword/Recruiter', { EmailID }, { headers: this.GetHttpHeaders() });
  }
  
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      let errormessage = error.error.errors;
      let alertMessage = '';
      for (var i in errormessage) {
        alertMessage += errormessage[i] + "\n";
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong,
        console.error(
          `Backend returned code ${error.status}, ` +
          `body was: ${errormessage[i]}`);
      }
      alert(alertMessage);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };
}

