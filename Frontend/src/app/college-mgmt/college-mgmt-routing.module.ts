import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './course-list/course-list.component';
import { CreateCourseComponent } from './create-course/create-course.component';

const routes: Routes = [
  { path: '', redirectTo: 'course/list', pathMatch: 'full'},
  { path: 'course/create', component: CreateCourseComponent},
  { path: 'course/list', component: CourseListComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollegeMgmtRoutingModule { }
