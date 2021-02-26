import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Technology } from "../home/Models/Technology";
import { HomeService } from "../services/home-service";

@Injectable({
    providedIn: "root"
})
export class UserTechnologiesResolve implements Resolve<Technology[]> {

    constructor(private service: HomeService){}

    resolve(route: ActivatedRouteSnapshot): Observable<Technology[]> {
        return this.service.getTechnologies();
    }

}