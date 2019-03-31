import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
/* Error handling */
import { catchError, map, tap } from 'rxjs/operators';

import { Classroom } from './classroom';
/* TESTING: Testing purposes only. */
import { MessageService } from './message.service';
import { FormGroup } from '@angular/forms';

/** Many servers require extra headers for 'save' (i.e POST) operations */
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class ClassroomService {
  /* TODO: Connect to real server
  * TESTING:...
  :base/:collectionName...the address of the buildings resource on the server.
  base is the resource to which requests are made.
  collectionName is the buildings data object in the in-memory-data-service.ts file. */
  private classroomsUrl = 'api/classrooms'; // URL to web api

  /* Inject HttpClient, Inject MessageService */
  constructor(
    private http: HttpClient,
    /* TESTING: Testing purposes only. */
    private messageService: MessageService){ }

  /** TODO: Implement onSubmit() method. Send to server. */
  onSubmit(classroomForm: FormGroup) {
    return this.http.post<FormGroup>(this.classroomsUrl, classroomForm, httpOptions).pipe(
      tap(_ => this.log('added form to the server')),
      catchError(this.handleError<FormGroup>('onSubmit'))
    );
  }

  /* TESTING:...*/
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    }
  }

  /* 
  TESTING:...
  Log a ClassroomService message with the MessageService
  */
  private log(message: string) {
    this.messageService.add(`ClassroomService: ${message}`);
  }
}