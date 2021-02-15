import { Component, OnInit } from '@angular/core';
import { UserInfo } from './Models/UserInfo';
import { HttpClient, HttpParams } from '@angular/common/http'
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user: UserInfo = new UserInfo();

  constructor(private http: HttpClient, private route:Router) {
   }

  ngOnInit(): void {
    const params = new HttpParams().set("Id", (JSON.parse(localStorage.getItem('user') || '{}')).id.toString());
    this.http.get("https://localhost:44374/api/Profile/userInfo", {params}).subscribe(response => this.user = <UserInfo>response)
  }

  onCancelClick(){
    this.route.navigate(["home"]);   
  }

  editProfile(form: NgForm){
    
  }
}