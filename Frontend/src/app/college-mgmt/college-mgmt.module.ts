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
import { TeacherListComponent } from './teacher-list/teacher-list.component';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { StudentListComponent } from './student-list/student-list.component';
import { CreateGradeComponent } from './create-grade/create-grade.component';
import { CourseReportComponent } from './course-report/course-report.component';
import { SubjectReportComponent } from './subject-report/subject-report.component';
import { StudentReportComponent } from './student-report/student-report.component';


@NgModule({
  declarations: [ 
    CreateCourseComponent, CreateSubjectComponent, CreateTeacherComponent, CreateStudentComponent, SubjectsToCoursesComponent, StudentsToCoursesComponent, CourseListComponent, TeacherListComponent, SubjectListComponent, StudentListComponent, CreateGradeComponent, CourseReportComponent, SubjectReportComponent, StudentReportComponent
  ],
  imports: [
    CommonModule,
    CollegeMgmtRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CollegeMgmtModule { }
