import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import {MatDialogModule} from '@angular/material/dialog';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';

@NgModule({
  imports: [
    AppModule,
    ServerModule,
    //MatDialogModule,
    
  ],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
