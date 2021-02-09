import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUpUserModelRequest } from './sign-up-ModelRequest';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public user: SignUpUserModelRequest = new SignUpUserModelRequest();
  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  signup(form: NgForm){
    this.http.post("https://localhost:44374/api/Account/signUp", this.user).subscribe(response => {
      this.router.navigate(["login"]);
    })
  }
}