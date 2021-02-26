import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LogInComponent } from './account-management/log-in/log-in.component';
import { SignUpComponent } from './account-management/sign-up/sign-up.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";
import { HomeComponent } from './home/home.component'
import { AuthGuard } from './services/auth-guard-service';
import { ProfileComponent } from './profile/profile.component';
import { NotifierModule } from "angular-notifier";
import { HeaderComponent } from './component/header/header-component';
import { FooterComponent } from './component/footer/footer-component';
import { SkillsComponent } from './skills/skills.component';
import { UserProfileResolve } from './resolvers/user-profile-resolve';
import { UserTechnologiesResolve } from './resolvers/user-technologies-resolve';

export function GetToken() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    SignUpComponent,
    HomeComponent,
    ProfileComponent,
    HeaderComponent,
    FooterComponent,
    SkillsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, resolve: {technologies: UserTechnologiesResolve}, canActivate: [AuthGuard] },
      { path: "home", component: HomeComponent, resolve: {technologies: UserTechnologiesResolve}, canActivate: [AuthGuard] },
      { path: "login", component: LogInComponent },
      { path: "signup", component: SignUpComponent },
      { path: "profile", component: ProfileComponent, resolve: {profile: UserProfileResolve}, canActivate: [AuthGuard] },
      { path: "skills", component: SkillsComponent, canActivate: [AuthGuard] },
      { path: "**", component: HomeComponent, resolve: {technologies: UserTechnologiesResolve}, canActivate: [AuthGuard] }
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: GetToken,
        allowedDomains: ["localhost:44374"],
        disallowedRoutes: []
      }
    }),
    HttpClientModule,
    NotifierModule.withConfig({
      position: {
        horizontal: {
          position: 'right'
        },
        vertical: {
          position: 'top',
          distance: 60
        },
      },
      behaviour: {
        stacking: 3
      },
    }),
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule {
}
