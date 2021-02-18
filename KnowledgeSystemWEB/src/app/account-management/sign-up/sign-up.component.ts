import { HttpClient,  HttpResponse} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUpUserModelRequest } from './sign-up-ModelRequest';
import { NotifierService } from "angular-notifier";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public user: SignUpUserModelRequest = new SignUpUserModelRequest();
  constructor(private router: Router, private http: HttpClient, private notifier: NotifierService, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  signup(form: NgForm){
    if(this.user.password == this.user.repeatPassword){
      this.spinner.show();
      this.http.post("https://localhost:44374/api/Account/signUp", this.user, {responseType: 'text'}).subscribe(response => {
        this.router.navigate(["login"]);
      }, err => {
          this.notifier.notify("error", err.error);
      })
      this.spinner.hide();
    }
    else{
      this.notifier.notify("error", "Passwords don't match.");
    }
  }
}