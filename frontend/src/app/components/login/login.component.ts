import {Component, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import {AuthService} from "../../shared/services/auth.service";
import {ActivatedRoute, Router} from "@angular/router";
import {first} from "rxjs";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  password = new FormControl('');
  loading = false;
  hide = true;

  constructor(private auth: AuthService, private router: Router,
              private route: ActivatedRoute, private toastr: ToastrService) {
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
          if (error.status === 401) this.toastr.error('Невірний пароль!');
          this.loading = false;
        }
      });
  }
}
