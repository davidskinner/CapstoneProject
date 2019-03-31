import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassroomsEditorComponent } from './classrooms-editor.component';

describe('ClassroomsEditorComponent', () => {
  let component: ClassroomsEditorComponent;
  let fixture: ComponentFixture<ClassroomsEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClassroomsEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassroomsEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
