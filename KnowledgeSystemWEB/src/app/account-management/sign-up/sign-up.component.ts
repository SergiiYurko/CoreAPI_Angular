import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SignUpUserModelRequest } from './sign-up-ModelRequest';
import { AuthenticationService } from 'src/app/services/account-management-service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public user: SignUpUserModelRequest = new SignUpUserModelRequest();
  constructor(private service: AuthenticationService) { }

  ngOnInit(): void {
  }

  signup(form: NgForm) {
    this.service.signUp(this.user);
  }
}