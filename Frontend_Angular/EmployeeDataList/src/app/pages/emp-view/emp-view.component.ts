import { Component, Input, input, OnInit } from '@angular/core';
import { EmployeeDTO } from '../../Models/EmployeeDTO';
import { EmpViewService } from './emp-view.service';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-emp-view',
  templateUrl: './emp-view.component.html',
  styleUrl: './emp-view.component.scss'
})
export class EmpViewComponent implements OnInit {

  @Input() deleteid?: number;


  displayedColumns: string[] = ['autoId', 'empId', 'firstName', 'lastName', 'nic', 'dob', 'gender', 'remove'];
  


  

  Employeelist: any;

  Empdata: any[] = [];

  delEmployee: EmployeeDTO = new EmployeeDTO();

  totalCount : number =0;
  empcount :number =0;
  page : number =1 ;
  pageSize :number = 10;


  constructor(private empviewservice: EmpViewService) { }
  ngOnInit(): void { 
  this.page = 1;
  this.pageSize  = 10;
  }


  getemployeelist(): void {
    // this.Employees = this.empviewservice.getEmployeeList();
    console.log("button pressed");
    // console.log(this.Employees);

    this.empviewservice.getemployeelist( this.page, this.pageSize).subscribe((data) => {
      this.Employeelist = data;
      this.totalCount= this.Employeelist.count;
      this.Empdata = this.Employeelist.data;
      console.log (data)
     // console.log("data", this.Employeelist.data);
    },
    err =>{
      Swal.fire({
        title: 'List Display Failed',
        text: 'Try Tuning up the Backend Server',
        icon: 'warning'
      })
    }
    );

  


  }

  nextPage():void{
      console.log("next page");
      
      this.empcount= this.Empdata.length;
      var totalPages = Math.ceil(this.totalCount / this.pageSize);
    //  (int)Math.Ceiling((decimal)totalCount/ pageSize);
    
    if(this.page< totalPages){
      this.page++;
      this.getemployeelist();
    }
  
      

  }
  previousPage():void{
     
      if(this.page>1){
        
      this.page--;
      this.getemployeelist();
      }else
      { console.log("previous page");}

  }



  deleteEmp(delid: number): void {

    console.log("Remove button presses");

    this.empviewservice.rememployee(delid)
    .subscribe((data) => {
      this.delEmployee = data;
      console.log(this.delEmployee);

      Swal.fire({
        title: "Successfully Removed",
        text: `Employee ID ${delid} Removed` ,
        icon: 'success',

      })
    },
    err => {
      if (err) {

        console.log(err);
        Swal.fire({
          title: 'WARNING',
          icon: 'warning',
          text: err,
          timer: 3000
        })
      }
    }
  );


    setTimeout(() => {
      console.log("Delayed execution after 1 seconds");
      this.getemployeelist();
    },770);

    

  }

  reload () : void {
    this.ngOnInit();
  }
}
