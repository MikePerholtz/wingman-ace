// * mPerholtz - Define Global Application Variable/Contstants here.
// * see https://stackoverflow.com/questions/43193049/app-settings-the-angular-4-way
// * Note: use environment.ts and environment.prod.ts for a simpler basic approach 
// * to global variables that might be specific to prod/dev environments
// * IMPORTANT : Rick Strahls appConfiguration.ts has an appoach that has less cermemony but might
// * not take into account the new angular peferred InjectionToken in 
// * accordance with Dependecy Injection and avoiding "name collision" which frankly sounds bad.


import { NgModule, InjectionToken } from '@angular/core';

export let APP_CONFIG = new InjectionToken<AppConfig>('app.config');

export class AppConfig {
  apiEndpoint: string; //example from SO  post linked above
  appName: string;
}

export const APP_DI_CONFIG: AppConfig = {
  apiEndpoint: 'http://localhost:8000/api/v1',
  appName: 'Wingman'
};

@NgModule({
  providers: [{
    provide: APP_CONFIG,
    useValue: APP_DI_CONFIG
  }]
})
export class AppConfigModule { }