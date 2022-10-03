import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollegeMgmtService } from '../college-mgmt.service';
import { SubjectReport } from '../subject-report';

@Component({
  selector: 'app-subject-report',
  templateUrl: './subject-report.component.html',
  styleUrls: ['./subject-report.component.css']
})
export class SubjectReportComponent implements OnInit {

  reportObjects: SubjectReport[] = [];
  courseId!: number;

  constructor(public collegeMgmtService : CollegeMgmtService, private route: ActivatedRoute) {
    this.courseId = this.route.snapshot.params['courseId'];
   }

  ngOnInit(): void {
    this.collegeMgmtService.getSubjectReportByCourseId(this.courseId).subscribe((data: SubjectReport[])=>{
      this.reportObjects = data;
    }) 
  }

}
