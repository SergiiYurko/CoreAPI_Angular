import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/account-management-service';

@Component({
  selector: 'app-header',
  templateUrl: './header-component.html',
  styles: [
  ]
})
export class HeaderComponent implements OnInit {

  constructor(private service: AuthenticationService) {
  }

  ngOnInit(): void {
  }

  logout() {
    this.service.logOut();
  }

  isUserAuthorized(): boolean{
    return this.service.isUserAuthorized();
  }
}