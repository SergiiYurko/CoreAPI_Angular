import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { UserInfo } from "../profile/Models/UserInfo";
import { ProfileService } from "../services/profile-service";

@Injectable({
  providedIn: "root"
})
export class UserProfileResolve implements Resolve<UserInfo> {
  constructor(private service: ProfileService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<UserInfo> {
    return this.service.getUser((JSON.parse(localStorage.getItem('user') || '{}')).id.toString());
  }

} 