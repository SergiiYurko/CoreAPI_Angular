import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HomeService } from '../services/home-service';
import { GroupTechnology } from './Models/GroupTechnology';
import * as helper from "../services/Helpers"

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  public groupTechnologies: GroupTechnology[] = [];

  constructor(private router: Router, private service: HomeService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => this.groupTechnologies = helper.groupByTitle(data.technologies));
  }

  onProfileClick() {
    this.router.navigate(["profile"]);
  }

  onSkillsClick() {
    this.router.navigate(["skills"]);
  }
}