import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollegeMgmtRoutingModule } from './college-mgmt-routing.module';
import { CreateCourseComponent } from './create-course/create-course.component';
import { CreateSubjectComponent } from './create-subject/create-subject.component';
import { CreateTeacherComponent } from './create-teacher/create-teacher.component';
import { CreateStudentComponent } from './create-student/create-student.component';


@NgModule({
  declarations: [ 
    CreateCourseComponent, CreateSubjectComponent, CreateTeacherComponent, CreateStudentComponent
  ],
  imports: [
    CommonModule,
    CollegeMgmtRoutingModule
  ]
})
export class CollegeMgmtModule { }
