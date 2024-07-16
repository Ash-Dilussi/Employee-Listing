import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../../environment/environment';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { Task } from 'zone.js/lib/zone-impl';

@Injectable({
  providedIn: 'root'
})
export class EmpNicaddService {

  constructor(private http: HttpClient) { }

  private _baseUrl: string = environment.API_URL;
  private url = '/api/Employee/AddEmployeeWithNIC';
  private nicvalidationurl = '/api/Employee/NICValidation';
  private empIsExisturl = '/api/Employee/EmpIsExist';


  nICValidation(nICNumber : string | any) : Observable<any> {
    return this.http.get<any>(this._baseUrl+this.nicvalidationurl+ `${nICNumber}`);

  }
  
  empIsExist(employeeid : number| any) : Observable<any> {
    return this.http.get<any>(this._baseUrl+this.empIsExisturl+`${employeeid}`);

  }

  addEmpNIC(emp: EmployeeDTO) :Observable<any[]>{
  
    return this.http.post<EmployeeDTO[]>(this._baseUrl+this.url,emp)
          .pipe(catchError(this.handleError)
        );
  }

  private handleError(error: HttpErrorResponse): Observable<any>{
    
    console.error( error);
    let errorMessage = 'Unknown error occurred'; // Default error message
    
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    
    console.log(errorMessage)
    return throwError(errorMessage);
  }
}
