import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClassroomsEditorComponent } from './classrooms-editor/classrooms-editor.component';
import { SchoolMapComponent } from './schoolMap/schoolMap.component';

/* 
Angular Route tells the router which view to display when a user clicks a link. 
path: a string that matches the URL in the browser address bar.
component: the component that the router should create when navigating to this route.
The first route is the default route, to make the app navigate to the map automatically.
*/
const routes: Routes = [
  { path: '', redirectTo: '/schoolMap', pathMatch: 'full' },
  { path: 'schoolMap', component: SchoolMapComponent },
  { path: 'classrooms-editor', component: ClassroomsEditorComponent }
];

/*
Initialize the router and start listening for browser location changes and configure by
calling .forRoot(routes).
Exporting RouterModule makes router directives available for use in the AppModule components. 
*/
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
