import { Component, OnInit } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-configuration.module';
@Component({
    //moduleId: module.id,
    selector: 'app-header',
    templateUrl: './app-header.html',
    //styleUrls: ['./app-header.css']
})
export class AppHeader implements OnInit {
    constructor( 
        @Inject(APP_CONFIG) private config: AppConfig ) {
    
      }

     ngOnInit() {

     }

}
