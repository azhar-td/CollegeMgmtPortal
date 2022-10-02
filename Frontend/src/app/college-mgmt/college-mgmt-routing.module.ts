import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './course-list/course-list.component';
import { CreateCourseComponent } from './create-course/create-course.component';
import { CreateSubjectComponent } from './create-subject/create-subject.component';
import { CreateTeacherComponent } from './create-teacher/create-teacher.component';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { TeacherListComponent } from './teacher-list/teacher-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'course/list', pathMatch: 'full'},
  { path: 'course/create', component: CreateCourseComponent},
  { path: 'course/list', component: CourseListComponent},
  { path: 'teacher/create', component: CreateTeacherComponent},
  { path: 'teacher/list', component: TeacherListComponent},
  { path: 'subject/create', component: CreateSubjectComponent},
  { path: 'subject/list', component: SubjectListComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollegeMgmtRoutingModule { }
