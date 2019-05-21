import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HttpClientModule,HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MaterialModuleModule} from './material-module.module';
import {MatNativeDateModule} from '@angular/material';
import { LayoutComponent } from './layout/layout.component';
import { LayoutHeaderComponent } from './layout-header/layout-header.component';
import { LayoutFooterComponent } from './layout-footer/layout-footer.component';
import{LoginComponent} from './recruiter/login/login.component'
import {AlumniLoginComponent} from './alumni/login/login.component';
import {AdminLoginComponent} from './admin/login/login.component'
import{RecruiterModule} from './recruiter/recruiter.module';
import{AdminModule} from './admin/admin.module';
import{AppLayoutComponent } from './app-layout/app-layout.component';
import { AuthGuard } from './common/auth-guard.service';
import{HttpConfigInterceptor} from './interceptor/http-interceptor'
//  import {AuthService } from './common/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    LayoutHeaderComponent,
    LayoutFooterComponent,
    LoginComponent,
     LoginComponent,
    AlumniLoginComponent,
    AdminLoginComponent,
    AppLayoutComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModuleModule,
    MatNativeDateModule,
    HttpClientModule,
    RecruiterModule,
    AdminModule,
    
   
  ],
  entryComponents:[AppComponent],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpConfigInterceptor,
    multi: true },
    AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
