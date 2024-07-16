import { Component, EventEmitter, Input, OnInit, Output, output } from '@angular/core';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { EmpNicaddService } from './emp-nicadd.service';
import { error } from 'console';
import Swal from 'sweetalert2';
import { errorDTO } from '../../Models/errorDTO';

@Component({
  selector: 'app-emp-nicadd',
  templateUrl: './emp-nicadd.component.html',
  styleUrl: './emp-nicadd.component.scss'
})


export class EmpNICaddComponent implements OnInit {

  @Input() nEmployee?: EmployeeDTO = new EmployeeDTO();
  @Output() employeeUpdated = new EventEmitter<EmployeeDTO[]>();

  toptext: String = "Employee";

  displayText: String = "";

  response1: any;
  outmsg: any;
  entemp: any[] = [];
  textobj: string = "";
  empdata: EmployeeDTO = new EmployeeDTO();
  errcode: string = "";


  errbreakobj: errorDTO = new errorDTO();

  constructor(private empNicaddService: EmpNicaddService) { }


  ngOnInit(): void { }




  async addempwithnic(nEmployee: EmployeeDTO) {

    try {
      // var isexist =
      await this.empNicaddService.empIsExist(nEmployee.empId).toPromise(
        // data => {
        //   console.log(data);
        // },
        // err => {
        //   if (err) {
        //     // Swal.fire({
        //     //   title: "Employee Already Exist",
        //     //   icon: 'warning',
        //     //   text: "Employee Currently Existing in the Company"
        //     // });
        //   };
        // }
      ).catch(error => {
        this.errcode = "Employee Currently Existing in the Company (new method)";
        if(error.status == 401){
          this.errcode = 'UnAuthorized';
        }
        throw new DOMException("call:l exist_err");
      });

      // if (isexist == null) {


      //   Swal.fire({
      //     title: "Employee Already Exist",
      //     icon: 'warning',
      //     text: "Employee Currently Existing in the Company"
      //   });
      //   return;
      // }




      // var validNIC = 
      await this.empNicaddService.nICValidation(nEmployee.NIC).toPromise(
        // data => {
        //   console.log(data);
        // },
        // err => {
        //   if (err) {
        //       this.errcode= 'Invalid NIC number or lenght (new)';
        //     Swal.fire({
        //       title: 'Invalid NIC',
        //       text: 'Invalid NIC number or lenght',
        //       icon: 'warning'
        //     });
        //     return;
        //   }
        // }
).then(response =>{
  console.log(response);
}).catch(error=>{
  if(error){
    this.errcode= 'Invalid NIC number or lenght(new method)';
    if(error.status == 401){
      this.errcode = 'UnAuthorized';
    }
    throw new DOMException("call:2 NIC_err");
  }
});




       await this.empNicaddService.addEmpNIC(nEmployee).toPromise(
        // this.response => {
        //   this.employeeUpdated.emit(data);
        //   console.log(data);
        //   // if (data != null) {
        //   //   this.displayText = "Employee Added Successfully";
        //   // };
        //   this.response = data;
        //   this.outmsg = this.response.message;
        //   this.entemp = this.response.data;

        //   this.empdata = this.response.data;
        //   console.log(this.entemp);
        //   let textforpop: string = `Employee ${this.empdata.firstName} ${this.empdata.lastName} was added`

        //   Swal.fire({
        //     title: this.outmsg,
        //     text: textforpop,
        //     icon: 'success',

        //   })
        // },
        // err => {
        //   if (err) {

        //     console.log(err);
        //     Swal.fire({
        //       title: 'WARNING',
        //       icon: 'warning',
        //       text: err,
        //       timer: 3000
        //     })
        //   }
        // }

      ).then(response => {
        console.log(response);
        this.response1 = response;
        this.outmsg = this.response1.message;
        this.empdata = this.response1.data;
        let textforpop: string = `Employee ${this.empdata.firstName} ${this.empdata.lastName} was added`;

        Swal.fire({
          title: this.outmsg,
          text: textforpop,
          icon: 'success',

        });
      }).catch((error: any) => {

        if (error) {
          this.errcode = "Server Error"
        };
      });



    }
    catch (error: any) {
      

      console.error(error);

      if(error.status === 401){
        this.errcode = "Not Authorized";
      }


      Swal.fire({
        title: 'Failed',
        text: this.errcode,
        icon: 'warning',

      });
    }

  }

}