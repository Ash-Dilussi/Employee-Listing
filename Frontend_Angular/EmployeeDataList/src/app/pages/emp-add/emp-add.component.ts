import { Component, Input } from '@angular/core';
import Swal from 'sweetalert2';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { EmpAddService } from './emp-add.service';

@Component({
  selector: 'app-emp-add',
  templateUrl: './emp-add.component.html',
  styleUrl: './emp-add.component.scss'
})
export class EmpAddComponent {

  
  @Input() nEmployee?: EmployeeDTO = new EmployeeDTO(
    
  );

  response : any ;
  constructor(private empservice: EmpAddService){};
  
addEmpl(upemp: EmployeeDTO){

  this.empservice.addEmp(upemp).subscribe(
    data =>
     {
      console.log(data);
      this.response = data;


      Swal.fire({
        title: "Success",
        text: "Listing Created Syccessfully",
        icon: 'success',

      })
     },
      err => {
        if (err) {

          console.log(err.status);
          if(err.status == 401){
            Swal.fire({
              title: 'WARNING',
              icon: 'warning',
              text: 'UnAuthorized',
            })
          }else{
          Swal.fire({
            title: 'WARNING',
            icon: 'warning',
            text: err,
            timer: 3000
          })};
        }
      }

  )
}
}
