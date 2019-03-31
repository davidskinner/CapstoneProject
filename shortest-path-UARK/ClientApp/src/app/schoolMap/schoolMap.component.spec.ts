import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolMapComponent } from './schoolMap.component';

describe('SchoolMapComponent', () => {
  let component: SchoolMapComponent;
  let fixture: ComponentFixture<SchoolMapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolMapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
