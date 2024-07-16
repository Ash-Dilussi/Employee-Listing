import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { AuthUserDTO } from '../../Models/AuthUserDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LandingService {


  private _baseUrl: string = environment.API_URL;
  private url = '/api/AuthUser';

  
  constructor(private _http: HttpClient) {  }

  public register(user: AuthUserDTO): Observable<any> {
    return this._http.post<any>(
      this._baseUrl + this.url+`/register`,user
    );
  }

  public login(user: AuthUserDTO): Observable<any> {
    return this._http.post(this._baseUrl + this.url+`/login`, user);
  }

  public getIn(): Observable<string> {
    return this._http.get(this._baseUrl + this.url, {
      responseType: 'text',
    });
  }



}
