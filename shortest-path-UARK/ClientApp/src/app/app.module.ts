import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
/* Enable HTTP services. HttpClient Angular mechanism for communicating w/ a remote server over HTTP. */
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

/* 
TODO: Remove the following two imports. Testing purposes only. 
Simulate communication w/ a remote server by using the In-memory Web API module
*/
//import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService } from './in-memory-data.service';

import { AppComponent } from './app.component';
import { SchoolMapComponent } from './schoolMap/schoolMap.component';
import { ClassroomsEditorComponent } from './classrooms-editor/classrooms-editor.component';
import { AppRoutingModule } from './app-routing.module';
import { MessagesComponent } from './messages/messages.component';

@NgModule({
  declarations: [
    AppComponent,
    SchoolMapComponent,
    ClassroomsEditorComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule//,
    /* TODO: Remove @NgModule.imports import. Simulating. Remove to use real server.*/
    /*HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    )*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
