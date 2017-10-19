import { Component } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from './app-configuration.module';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  appName = this.config.appName; //mPerholtz DI and App Configuration Global Variables
  //appName ="the wing man;"
 
  
  constructor( 
    @Inject(APP_CONFIG) private config: AppConfig ) {

  }
}
