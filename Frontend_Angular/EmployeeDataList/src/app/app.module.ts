import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpAddComponent } from './pages/emp-add/emp-add.component';
import { EmpViewComponent } from './pages/emp-view/emp-view.component';
import { EmpNICaddComponent } from './pages/emp-nicadd/emp-nicadd.component';
import { EmpUpdateComponent } from './pages/emp-update/emp-update.component';
import { SidebarComponent } from './layouts/sidebar/sidebar.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { FormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import { LandingComponent } from './layouts/landing/landing.component';
import { AllpageComponent } from './layouts/allpage/allpage.component';
import { Router } from '@angular/router';
import { AuthInterceptor } from './environment/environment.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    EmpAddComponent,
    EmpViewComponent,
    EmpNICaddComponent,
    EmpUpdateComponent,
    SidebarComponent,
    LandingComponent,
    AllpageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
   MatButtonModule,
   MatIconModule,
   MatTableModule,
   MatFormFieldModule,
   MatInputModule,
   SweetAlert2Module,

   

  ],
  providers: [
    //provideClientHydration(),
    provideAnimationsAsync('noop'),
    provideAnimationsAsync(),
    {
    provide: HTTP_INTERCEPTORS, 
    useClass: AuthInterceptor,
    multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
