import { Component, OnInit } from '@angular/core';
import {Router, Route} from "@angular/router";
import{AppliedalumnilistingsComponent} from '../commonpages/appliedalumnilistings/appliedalumnilistings.component'
import { Location } from "@angular/common";

@Component({
  selector: 'layout-header',
  templateUrl: './layout-header.component.html',
  styleUrls: ['./layout-header.component.css']
})
export class LayoutHeaderComponent implements OnInit {
  title:string;userName:string;user:any;
  constructor(private router:Router,private location:Location) { }

  ngOnInit() {
    this.title = 'JobPortal';
    this.userName=localStorage.getItem('userName');
   this.user=localStorage.getItem('user');
  //  if(this.user == "admin"){
  //   this.user=2;
  //  } if(this.user == "recruiter"){
  //   this.user=1;
  //  } if(this.user == "alumni"){
  //   this.user=3;
  //  }
   
  }
  logout(){
      //localStorage.clear();
    // localStorage.removeItem('user');
    if(this.user == "admin"){
   
      localStorage.removeItem('userToken');
      this.router.navigateByUrl('admin');
    }
    else if(this.user == "recruiter"){
      localStorage.removeItem('userToken');
      this.router.navigateByUrl('recruiter');
    }
    else if(this.user == "alumni"){
      localStorage.removeItem('userToken');
      this.router.navigateByUrl('alumni');
    }
      

    // var user=localStorage.getItem('user');
    // if(user == 'admin'){
    //   this.location.replaceState('/'); 
    //   localStorage.removeItem('user');
    //   this.router.navigate(['/admin']);
    //   // this.router.navigateByUrl('admin');  
    // }
    // else if(user == 'alumni'){  
    //   localStorage.removeItem('user');
    //   this.router.navigateByUrl('/alumni'); 
    // }
    // else if(user =='recruiter'){
    //   localStorage.removeItem('user');
    //   this.router.navigateByUrl('/'); 
    // }
   // this.router.navigateByUrl('admin/login'); 
 
  }
}