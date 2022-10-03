import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollegeMgmtService } from '../college-mgmt.service';
import { StudentReport } from '../student-report';

@Component({
  selector: 'app-student-report',
  templateUrl: './student-report.component.html',
  styleUrls: ['./student-report.component.css']
})
export class StudentReportComponent implements OnInit {

  reportObjects: StudentReport[] = [];
  subjectId!: number;

  constructor(public collegeMgmtService : CollegeMgmtService, private route: ActivatedRoute) {
    this.subjectId = this.route.snapshot.params['subjectId'];
   }

  ngOnInit(): void {
    this.collegeMgmtService.getStudentReportBySubjectId(this.subjectId).subscribe((data: StudentReport[])=>{
      this.reportObjects = data;
    }) 
  }

}
