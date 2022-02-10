import { Component } from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from "./shared/services/auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isNavSmall = false;
  loggedIn: string = '';

  constructor(private auth: AuthService) {
    // @ts-ignore
    this.auth.token.subscribe(x => this.loggedIn = x);
  }

  logout() {
    this.auth.logout();
  }
}
