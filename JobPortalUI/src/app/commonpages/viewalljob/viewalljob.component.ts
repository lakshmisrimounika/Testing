import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
@Component({
  selector: 'app-viewalljob',
  templateUrl: './viewalljob.component.html',
  styleUrls: ['./viewalljob.component.css']
})
export class ViewalljobComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit() {
  }

addNewJob(){
  this.router.navigateByUrl('recruiter/postjob'); 
}
}
