import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
user:string;
    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('userToken')) {
            return true;
        }
    // else{
        // this.user=localStorage.getItem('user');
        //  if(this.user == "admin"){
        //     this.router.navigate(['/'], { queryParams: { returnUrl: state.url }});
        //  } else if(this.user == "recruiter"){
        //     this.router.navigate(['/admin'], { queryParams: { returnUrl: state.url }});
        //  } else if(this.user == "alumni"){
        //     this.router.navigate(['/alumni'], { queryParams: { returnUrl: state.url }});
        //  }
        //  else{
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/recruiter']);
       //  }
        return false;
    //}
}
}