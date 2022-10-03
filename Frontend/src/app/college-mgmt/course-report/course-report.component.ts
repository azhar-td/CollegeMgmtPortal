import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { CourseReport } from '../course-report';

@Component({
  selector: 'app-course-report',
  templateUrl: './course-report.component.html',
  styleUrls: ['./course-report.component.css']
})
export class CourseReportComponent implements OnInit {

  reportObjects: CourseReport[] = [];

  constructor(public collegeMgmtService : CollegeMgmtService) { }

  ngOnInit(): void {
    this.collegeMgmtService.getCourseReport().subscribe((data: CourseReport[])=>{
      this.reportObjects = data;
      console.log(this.reportObjects);
    }) 
  }

}
