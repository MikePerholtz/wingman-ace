import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppConfigModule } from './app-configuration.module';
import { AppRoutingModule } from "./app-routing.module";

import { AppHeader } from './common/app-header';
//import { LoginComponent } from "./components/account";

@NgModule({
  declarations: [
    AppComponent,
    AppHeader
  ],
  imports: [
    BrowserModule,
    AppConfigModule,
    AppRoutingModule
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
