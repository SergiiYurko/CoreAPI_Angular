import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { GroupTechnology } from './Models/GroupTechnology';
import { Technology } from './Models/Technology'
import { groupByTitle } from './Helpers';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public groupTechnologies: GroupTechnology [] = [];
  public name: string = (JSON.parse(localStorage.getItem('user') || '{}')).name.toString();
  
  constructor(private route: Router, private http: HttpClient) { }

  ngOnInit(): void {
    const params = new HttpParams().set("userId", (JSON.parse(localStorage.getItem('user') || '{}')).id.toString());
    this.http.get("https://localhost:44374/api/Home/getUserTechnologies", {params}).subscribe(response => this.groupTechnologies = groupByTitle(<Technology[]>response));
  }

  onProfileClick(){
    this.route.navigate(["profile"]);
  }

  logout(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("user");
    this.route.navigate(["login"]);
  }
}