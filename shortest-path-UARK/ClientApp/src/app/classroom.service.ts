import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
/* Error handling */
import { catchError, map, tap } from 'rxjs/operators';

import { Classroom } from './classroom';
import { FormGroup } from '@angular/forms';

/** Many servers require extra headers for 'save' (i.e POST) operations */
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class ClassroomService {
  /** 
  * :base/:collectionName
  * base is the resource to which requests are made.
  * collectionName...data object 
  */
  private baseUrl = 'api/PathData/PostClassrooms';

  /* Inject HttpClient, Inject MessageService */
  constructor(
    private http: HttpClient){ }

  /** Send FormGroup to server. */
  onSubmit(classroomForm: FormGroup) {
    return this.http.post<FormGroup>(this.baseUrl, classroomForm, httpOptions);
  }

  /**
  * TODO: http.get method to get the map image
  */
  //...
}