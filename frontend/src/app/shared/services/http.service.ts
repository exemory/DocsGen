import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  // Define API
  apiURL: string = environment.apiURL;

  constructor(private http: HttpClient) {
  }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  get(apiRoute: string): Observable<any> {
    return this.http.get(this.apiURL + apiRoute, this.httpOptions);
  }

  post(apiRoute: string, body: any): Observable<any> {
    return this.http.post(this.apiURL + apiRoute, body, this.httpOptions);
  }

  postWithCustomOptions(apiRoute: string, body: any, options: any): Observable<any> {
    return this.http.post(this.apiURL + apiRoute, body, options);
  }

  put(apiRoute: string, body: any): Observable<any> {
    return this.http.put(this.apiURL + apiRoute, body, this.httpOptions);
  }

  delete(apiRoute: string): Observable<any> {
    return this.http.delete(this.apiURL + apiRoute, this.httpOptions);
  }
}
