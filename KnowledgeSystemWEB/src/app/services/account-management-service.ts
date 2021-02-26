import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LogInUserModelRequest } from "../account-management/log-in/log-in-ModelRequest";
import { NotifierService } from "angular-notifier";
import { SignUpUserModelRequest } from "../account-management/sign-up/sign-up-ModelRequest";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    private apiUrl: string = "https://localhost:44374/api/Account";

    constructor(private http: HttpClient, private notifier: NotifierService, private router: Router) { }

    logIn(user: LogInUserModelRequest) {
        this.http.post(this.apiUrl + "/logIn", user).subscribe(response => {
            const token = (<any>response).token;
            const user = (<any>response).model;
            localStorage.setItem("jwt", token);
            localStorage.setItem("user", JSON.stringify(user));
            this.router.navigate(["home"]);
        }, error => {
            this.notifier.notify("error", error.error);
        })
    }

    logOut() {
        localStorage.removeItem("jwt");
        localStorage.removeItem("user");
        this.router.navigate(["login"]);
    }

    signUp(user: SignUpUserModelRequest) {
        if (user.password == user.repeatPassword) {
            this.http.post(this.apiUrl + "/signUp", user, { responseType: 'text' }).subscribe(response => {
                this.router.navigate(["login"]);
            }, err => {
                this.notifier.notify("error", err.error);
            })
        }
        else {
            this.notifier.notify("error", "Passwords don't match.");
        }
    }

    isUserAuthorized(): boolean {
        const token = localStorage.getItem("jwt");
        if (token) {
            return true;
        }

        return false
    }
}