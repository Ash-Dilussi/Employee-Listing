import { Injectable, Input } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { EmployeeDTO } from '../../Models/EmployeeDTO';

@Injectable({
  providedIn: 'root'
})
export class EmpViewService {

 
  private _baseUrl: string = environment.API_URL;
  private geturl = '/api/Employee/GetAllEmployees';
  private delurl = '/api/Employee/DeleteEmployee';

  constructor(private http: HttpClient) { }


  getemployeelist(page: number, pageSize: number): Observable<any[]> {
    //const apiURL = this._baseUrl + '/api/Employee/GetAllEmployees';
   // return  this.http.get<any[]>(apiURL);
    
    return this.http.get<any>(this._baseUrl+ this.geturl+`?page=${page}&pageSize=${pageSize}`);
  }
  rememployee(id : number) : Observable<any> {
    return this.http.delete<any>(this._baseUrl + this.delurl + `${id}`);
  }

 // `${this.apiUrl}/${id}`

}
