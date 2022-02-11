import {Component, Inject} from '@angular/core';
import {AuthService} from "./shared/services/auth.service";
import {APP_BASE_HREF} from "@angular/common";

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
