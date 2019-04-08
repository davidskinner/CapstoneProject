import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';

import { ClassroomService } from '../classroom.service';
import { Classroom } from '../classroom';

@Component({
  selector: 'app-classrooms-editor',
  templateUrl: './classrooms-editor.component.html',
  styleUrls: ['./classrooms-editor.component.css']
})
export class ClassroomsEditorComponent implements OnInit {
  /** Definition of classroomForm property */
  classroomForm: FormGroup;

  /* Inject the ClassService */
  constructor(
    private classroomService: ClassroomService) { }

  ngOnInit() {
    /** Initialize Form */
    this.initializeForm();
  }

  /** Initialize the classroomForm */
  initializeForm(): void {
    let classrooms: FormArray = new FormArray([]);
    this.classroomForm = new FormGroup({
      classrooms: classrooms
    })

    /** Create the first class */
    this.addClassroom();
  }

  /** Add a classroom FormGroup... 
   * methodName(parameters): return 
  */
  addClassroom(classroom?: Classroom): void {
    /** https://www.tutorialrepublic.com/javascript-tutorial/javascript-if-else-statements.php
     * Ternary Operator: var result = (condition) ? value1 : value2, where value1 is true and value2 is false
     * */
    let className = classroom ? classroom.className : '';
    let buildingName = classroom ? classroom.buildingName : '';
    let classTime = classroom ? classroom.classTime : '';
    (<FormArray>this.classroomForm.controls['classrooms']).push(
      new FormGroup({
        className: new FormControl(className),
        buildingName: new FormControl(buildingName, Validators.required),
        classTime: new FormControl(classTime, Validators.required)
      })
    )
  }

 /** 
 *   Method will send the data with all the class information to the server.
 *   Nested JSON object.
 */
 onSubmit() {
    this.classroomService.onSubmit(this.classroomForm.value)
      .subscribe(
        /** TESTING:... */
        variableName => console.warn(this.classroomForm.value)
      );
  }
}
