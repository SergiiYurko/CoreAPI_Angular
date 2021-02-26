import { Component, OnInit } from '@angular/core';
import { UserInfo } from './Models/UserInfo';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ProfileService } from '../services/profile-service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user: UserInfo = new UserInfo();

  constructor(private router: Router, private service: ProfileService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.user = data.profile
    });
  }

  onCancelClick() {
    this.router.navigate(["home"]);
  }

  editProfile(form: NgForm) {
    this.service.editProfile(this.user);
  }
}