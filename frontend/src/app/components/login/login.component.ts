import {Component, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import {AuthService} from "../../shared/services/auth.service";
import {ActivatedRoute, Router} from "@angular/router";
import {first} from "rxjs";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  password = new FormControl('');
  loading = false;

  constructor(private auth: AuthService, private router: Router, private route: ActivatedRoute) {
    // redirect to home if already logged in
    if (this.auth.tokenValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
  }

  onLogin() {
    this.loading = true;
    this.auth.login(this.password.value)
      .pipe(first())
      .subscribe({
        next: () => {
          this.router.navigate(['']);
        },
        error: error => {
          this.loading = false;
        }
      });
  }
}
