import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { EmpUpdateService } from './emp-update.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-emp-update',
  templateUrl: './emp-update.component.html',
  styleUrl: './emp-update.component.scss'
})
export class EmpUpdateComponent {

  @Input() nEmployee?: EmployeeDTO = new EmployeeDTO();

  response: any;
  errcode: string = "";
  constructor(private empservice: EmpUpdateService) { };

  async updateEmpl(upemp: EmployeeDTO) {

    try {
      await this.empservice.empIsExist(upemp.empId).toPromise(
        // data => {
        //   //  console.log(data);

        // },
        // error => {
        //   Swal.fire({
        //     title: "Employee Missing",
        //     icon: 'warning',
        //     text: 'Mentioned Employee is not available.'
        //   });
        //   return;
        // }
      ).catch(error => {
        if (error) {
          this.errcode = 'Employee does Not Exist';
          throw new DOMException(error);
        }
      }
      );

      await this.empservice.updateEmp(upemp).toPromise(
        // data => {
        //   console.log(data);
        //   this.response = data;


        //   Swal.fire({
        //     title: "Success",
        //     text: "Listing Updated Syccessfully",
        //     icon: 'success',

        //   })
        // }
      ).then(
        data => {
          console.log(data);
          Swal.fire({
            
            title: "Success",
            text: "Listing Updated Syccessfully",
            icon: 'success',

          })
        }
      ).catch(error => {
        debugger
        if (error) {
          this.errcode = 'Listing Update method failed';
        }
      });
    }
    catch (error) {
      {
        console.log(error);
        Swal.fire({
          title: 'WARNING',
          icon: 'warning',
          text: this.errcode,
          timer: 3000
        })
      }
    }
  }
}
