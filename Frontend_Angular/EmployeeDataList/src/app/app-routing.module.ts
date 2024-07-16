import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpAddComponent } from './pages/emp-add/emp-add.component';
import { EmpNICaddComponent } from './pages/emp-nicadd/emp-nicadd.component';
import { EmpViewComponent } from './pages/emp-view/emp-view.component';
import { EmpUpdateComponent } from './pages/emp-update/emp-update.component';
import { LandingComponent } from './layouts/landing/landing.component';
import { SidebarComponent } from './layouts/sidebar/sidebar.component';
import { AllpageComponent } from './layouts/allpage/allpage.component';

const routes: Routes = [

   {path: '', redirectTo: 'layouts/landing/landing.component' , pathMatch: 'full'},

  {path: 'layouts/landing/landing.component', component: LandingComponent},
  {path: './layouts/sidebar/sidebar.component', component: SidebarComponent},
  
  {path: '', component: AllpageComponent,
    children:[
      
      {path: 'pages/emp-add/emp-add.component', component: EmpAddComponent},
      {path: 'pages/emp-view/emp-view.component', component: EmpViewComponent},
      {path: 'pages/emp-nicadd/emp-nicadd.component', component:EmpNICaddComponent},
      {path: 'pages/emp-update/emp-update.component', component: EmpUpdateComponent}
    ]
  },
   
   
    
  


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
