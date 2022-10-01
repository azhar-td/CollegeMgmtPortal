import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectsToCoursesComponent } from './subjects-to-courses.component';

describe('SubjectsToCoursesComponent', () => {
  let component: SubjectsToCoursesComponent;
  let fixture: ComponentFixture<SubjectsToCoursesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjectsToCoursesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectsToCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
