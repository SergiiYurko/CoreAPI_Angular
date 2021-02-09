import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Technology } from './Models/Technology';
import { User } from './Models/User'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {

  public user:User = JSON.parse(localStorage.getItem('user') || '{}')
  public technologies: Technology [] = [];
  
  constructor(private route: Router, private http: HttpClient) { }

  ngOnInit(): void {
    const params = new HttpParams().set("userId", this.user.id.toString());
    this.http.get("https://localhost:44374/api/Home/getUserTechnologies", {params}).subscribe(response => this.technologies = (<any>response).technologyList);
  }

  logout(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("user");
    this.route.navigate(["login"]);
  }
}
