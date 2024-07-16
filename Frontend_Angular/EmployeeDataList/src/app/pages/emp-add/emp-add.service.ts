import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpAddService {

  constructor(private http: HttpClient) { }

  private _baseUrl: string = environment.API_URL;
  private url = '/api/Employee/AddEmployee';

  addEmp(emp: EmployeeDTO) :Observable<any[]>{
  

    return this.http.post<EmployeeDTO[]>(this._baseUrl+this.url,emp);

  
    
  }
}
