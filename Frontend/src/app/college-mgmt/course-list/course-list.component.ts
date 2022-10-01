import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Course } from '../course';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  courses: Course[] = [];

  constructor(public collegeMgmtService : CollegeMgmtService) { }

  ngOnInit(): void {
    this.collegeMgmtService.getAllCourses().subscribe((data: Course[])=>{
      this.courses = data;
      console.log(this.courses);
    }) 
  }

}
