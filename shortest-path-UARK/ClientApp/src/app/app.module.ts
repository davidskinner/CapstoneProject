import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
/* Enable HTTP services. HttpClient Angular mechanism for communicating w/ a remote server over HTTP. */
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SchoolMapComponent } from './schoolMap/schoolMap.component';
import { ClassroomsEditorComponent } from './classrooms-editor/classrooms-editor.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    SchoolMapComponent,
    ClassroomsEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
