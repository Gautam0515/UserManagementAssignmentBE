import { NgModule, provideZoneChangeDetection } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes, UserRoutingModule } from './user-routing.module';
import { provideRouter } from '@angular/router';
import { provideClientHydration } from '@angular/platform-browser';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UserRoutingModule
  ],
    providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideClientHydration()]

})
export class UserModule { }
