import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogInUserModelRequest } from './log-in-ModelRequest';
import { NgForm }   from '@angular/forms';
import { Router } from '@angular/router';
import { NotifierService } from "angular-notifier";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  public user: LogInUserModelRequest = new LogInUserModelRequest();

  constructor(private router: Router, private http: HttpClient, private notifier: NotifierService, private spinner: NgxSpinnerService) { 
  }

  ngOnInit(){}

  login(form: NgForm){
      this.spinner.show();
      this.http.post("https://localhost:44374/api/Account/logIn", this.user).subscribe(response => {
      const token = (<any>response).token;
      const user = (<any>response).model;
      localStorage.setItem("jwt", token);
      localStorage.setItem("user", JSON.stringify(user));
      this.router.navigate(["home"]);
    }, err => {
     this.notifier.notify("error", err.error);
  })
  this.spinner.hide();
  }
}