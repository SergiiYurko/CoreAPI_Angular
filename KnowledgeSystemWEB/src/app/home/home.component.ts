import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Technology } from './Models/Technology';
import { User } from './Models/User'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
    `.grid {
        display: grid;
        grid-template-columns: 1fr 1fr 1fr 1fr;
        grid-gap: 1rem 1rem;
      }
      .left {
        width: 20%;
      }
      .right {
        width: 20%;
      }
      .center {
        flex-grow: 1;
        text-align: center;
      }
      .cont {
        display: flex;
      }
      .container_technology {
        display: inline-flex;        
      }

    `]
})
export class HomeComponent implements OnInit {

  public user:User = JSON.parse(localStorage.getItem('user') || '{}')
  public technologies: Technology [] = [];
  
  constructor(private route: Router, private http: HttpClient) { }

  ngOnInit(): void {
    const params = new HttpParams().set("userId", this.user.id.toString());
    this.http.get("https://localhost:44374/api/Home/getUserTechnologies", {params}).subscribe(response => this.technologies = <Technology[]>response);
  }

  logout(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("user");
    this.route.navigate(["login"]);

  }
}