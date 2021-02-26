import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { GroupTechnology } from "../home/Models/GroupTechnology";
import { Technology } from "../home/Models/Technology"
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class HomeService {

    private apiUrl: string = "https://localhost:44374/api/Home";

    constructor(private http: HttpClient) { }

    getTechnologies(): Observable<Technology[]> {
        const params = new HttpParams().set("userId", (JSON.parse(localStorage.getItem('user') || '{}')).id.toString());
        return this.http.get<Technology[]>(this.apiUrl + "/getUserTechnologies", { params });
    }
}