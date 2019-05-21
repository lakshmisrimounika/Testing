import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';

import { CKEditorModule } from 'ng2-ckeditor';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,CKEditorModule,FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
