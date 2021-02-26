import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { NotifierService } from "angular-notifier";
import { UserInfo } from "../profile/Models/UserInfo";
import { Observable } from 'rxjs'

@Injectable({
    providedIn: 'root'
})
export class ProfileService {
    private apiUrl: string = "https://localhost:44374/api/Profile";
    private user: UserInfo = new UserInfo();
    
    constructor(private http: HttpClient, private route: Router, private notifier: NotifierService) {
    }

    editProfile(user: UserInfo) {
        this.http.post("https://localhost:44374/api/Profile", user).subscribe(response => {
            this.notifier.notify("success", "Successfully updated.")
        }, err => {
            this.notifier.notify("error", err.error);
        });
    }

    getUser(id: string): Observable<UserInfo> {
        const params = new HttpParams().set("Id", id);
        return this.http.get<UserInfo>("https://localhost:44374/api/Profile", { params });
    }
}