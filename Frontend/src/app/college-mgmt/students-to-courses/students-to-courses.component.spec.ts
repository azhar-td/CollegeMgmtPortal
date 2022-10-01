import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentsToCoursesComponent } from './students-to-courses.component';

describe('StudentsToCoursesComponent', () => {
  let component: StudentsToCoursesComponent;
  let fixture: ComponentFixture<StudentsToCoursesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentsToCoursesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentsToCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
