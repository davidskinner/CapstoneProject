import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
/* Error handling */
import { catchError, map, tap } from 'rxjs/operators';

import { Classroom } from './classroom';
import { FormGroup } from '@angular/forms';
/* TESTING: Testing purposes only. */
import { MessageService } from './message.service';

/** Many servers require extra headers for 'save' (i.e POST) operations */
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}





@Injectable({
  providedIn: 'root'
})
export class ClassroomService {
  /** 
  * TODO: Connect to real server
  * 
  * :base/:collectionName
  * base is the resource to which requests are made.
  * collectionName...data object 
  */
  private baseUrl = 'api/PathData/onSubmit';

  /* Inject HttpClient, Inject MessageService */
  constructor(
    private http: HttpClient,
    /* TESTING: Testing purposes only. */
    private messageService: MessageService){ }

  /** Send FormGroup to server. */
  onSubmit(classroomForm: FormGroup) {
    return this.http.post<FormGroup>(this.baseUrl, classroomForm, httpOptions).pipe(
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