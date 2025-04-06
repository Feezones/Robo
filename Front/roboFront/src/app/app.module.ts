import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoboHeadComponent } from './robo-head/robo-head.component';
import { RoboBodyComponent } from './robo-body/robo-body.component';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RoboHeadComponent,
    RoboBodyComponent,
    AppComponent
  ],
  providers: [],
})
export class AppModule { }
