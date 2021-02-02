import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AccountManagementComponent } from './account-management/account-management.component';
import { LogInComponent } from './account-management/log-in/log-in.component';
import { SignUpComponent } from './account-management/sign-up/sign-up.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountManagementComponent,
    LogInComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
