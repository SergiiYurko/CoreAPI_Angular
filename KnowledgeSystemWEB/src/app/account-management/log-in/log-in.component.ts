import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogInUserModelRequest } from './log-in-ModelRequest';
import { NgForm }   from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  public user: LogInUserModelRequest = new LogInUserModelRequest();
  invalidLogin: boolean = false;

  constructor(private router: Router, private http: HttpClient) { 
  }

  ngOnInit(){}

  login(form: NgForm){
      this.http.post("https://localhost:44374/api/Account/logIn", this.user).subscribe(response => {
      const token = (<any>response).token;
      const user = (<any>response).model;
      localStorage.setItem("jwt", token);
      localStorage.setItem("user", JSON.stringify(user));
      this.invalidLogin = false;
      this.router.navigate(["home"]);
    }, err => {
   this.invalidLogin = true;
  })
  }
}