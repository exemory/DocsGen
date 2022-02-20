import {Component} from '@angular/core';
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
    this.auth.token.subscribe(res => this.loggedIn = res);
  }

  logout() {
    this.auth.logout();
  }
}
