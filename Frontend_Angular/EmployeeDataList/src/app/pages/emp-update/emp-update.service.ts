import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable } from 'rxjs';
import { EmployeeDTO } from '../../Models/EmployeeDTO';

@Injectable({
  providedIn: 'root'
})
export class EmpUpdateService {



  constructor(private http: HttpClient) { }

  private _baseUrl: string = environment.API_URL;
  private url = '/api/Employee/UpdateEntry';
  private getbyIdURL = '/api/Employee/GetById';

  updateEmp(emp: EmployeeDTO) :Observable<any[]>{
    return this.http.post<EmployeeDTO[]>(this._baseUrl+this.url,emp);

  };



  empIsExist(employeeid : number| any) : Observable<any> {

   
    return this.http.get<any>(this._baseUrl+this.getbyIdURL+`${employeeid}`);

  }
}
