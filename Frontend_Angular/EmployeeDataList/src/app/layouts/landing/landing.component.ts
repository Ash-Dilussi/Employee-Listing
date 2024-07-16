import { Component, Input } from '@angular/core';
import { AuthUserDTO } from '../../Models/AuthUserDTO';
import { LandingService } from './landing.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { response } from 'express';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.scss'
})
export class LandingComponent {

@Input() auser: AuthUserDTO = new AuthUserDTO();

tokentxt : string = "";


constructor(private _landingService: LandingService, private router: Router ){}


login (loginuser : AuthUserDTO){
  console.log("login processing")

  this._landingService.login(loginuser).subscribe(
    (data)=>{
      if(data){
        
        this.tokentxt = data.data;
     //   let respone = data;
      console.log(this.tokentxt)
      // Swal.fire({
      //   title:"Welcome !",
      //   icon: "success",
      //   text: "Succefully Registerd New User"
      // });

      localStorage.setItem('angulatAuthToken', this.tokentxt);

     this.router.navigateByUrl('./layouts/sidebar/sidebar.component');
      }
    },
    err=>{
      Swal.fire(
        {
          title:"Login Failed !",
          icon: "warning",
          text: 'Username / Password Missmatch.' 
        }
      )
    }
  );
}

register (newuser : AuthUserDTO){
console.log("Reg button pressed");
  this._landingService.register(newuser).subscribe(
    data=>{
      console.log(data)
      Swal.fire({
        title:"Welcome !",
        icon: "success",
        text: "Succefully Registerd New User"
      })
    },
    err=>{
      Swal.fire(
        {
          title:"Failed !",
          icon: "warning",
          text: 'New Registration Failed  ${err}'
        }
      )
    }
  );
}

goin (newuser : AuthUserDTO){
  
}

  
}
