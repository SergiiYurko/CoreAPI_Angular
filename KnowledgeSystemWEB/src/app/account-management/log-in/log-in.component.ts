import { Component, OnInit } from '@angular/core';
import { LogInUserModelRequest } from './log-in-ModelRequest';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/account-management-service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  public user: LogInUserModelRequest = new LogInUserModelRequest();

  constructor(private auth: AuthenticationService) {
  }

  ngOnInit() { }

  login(form: NgForm) {
    this.auth.logIn(this.user);
  }
}