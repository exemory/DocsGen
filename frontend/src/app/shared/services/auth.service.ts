import {Injectable} from '@angular/core';
import {HttpService} from "./http.service";
import {BehaviorSubject, delay, filter, map, Observable, of, Subscription, switchMap, tap, timer} from "rxjs";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenSubject: BehaviorSubject<any>;
  public token: Observable<any> | undefined;

  constructor(private http: HttpService, private router: Router) {
    // @ts-ignore
    let getToken = JSON.parse(localStorage.getItem('token'));
    this.tokenSubject = new BehaviorSubject(getToken);
    this.token = this.tokenSubject.asObservable();

    if (getToken && this.tokenExpired(getToken)) {
      this.logout();
    }
  }

  public get tokenValue(): string {
    return this.tokenSubject.value;
  }

  login(password: string) {
    return this.http.post('auth/login', {password})
      .pipe(map(res => {
        localStorage.setItem('token', JSON.stringify(res.token));
        this.tokenSubject.next(res.token);
        return res.token;
      }));
  }

  logout() {
    localStorage.removeItem('token');
    this.tokenSubject.next(null);
    this.router.navigate(['/login']);
  }

  private tokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }
}
