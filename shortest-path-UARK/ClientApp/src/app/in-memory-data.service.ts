/* TESTING: File kept, but no longer used. Used only to simulate a real server. */

import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const classrooms = [
      { id: 1, buildingName: 'ARKU' },
      { id: 2, buildingName: 'CHEM' },
      { id: 3, buildingName: 'GEAR' },
      { id: 4, buildingName: 'BELL' },
      { id: 5, buildingName: 'FERR' },
      { id: 6, buildingName: 'AGRI' },
      { id: 7, buildingName: 'JBHT' },
      { id: 8, buildingName: 'MAIN' },
      { id: 9, buildingName: 'ROSE' },
      { id: 10, buildingName: 'MUSC' }
    ];
    return {classrooms};
  }
}
