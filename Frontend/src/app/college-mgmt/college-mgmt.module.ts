import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollegeMgmtRoutingModule } from './college-mgmt-routing.module';
import { CreateCourseComponent } from './create-course/create-course.component';
import { CreateSubjectComponent } from './create-subject/create-subject.component';
import { CreateTeacherComponent } from './create-teacher/create-teacher.component';
import { CreateStudentComponent } from './create-student/create-student.component';
import { SubjectsToCoursesComponent } from './subjects-to-courses/subjects-to-courses.component';
import { StudentsToCoursesComponent } from './students-to-courses/students-to-courses.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CourseListComponent } from './course-list/course-list.component';


@NgModule({
  declarations: [ 
    CreateCourseComponent, CreateSubjectComponent, CreateTeacherComponent, CreateStudentComponent, SubjectsToCoursesComponent, StudentsToCoursesComponent, CourseListComponent
  ],
  imports: [
    CommonModule,
    CollegeMgmtRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CollegeMgmtModule { }
