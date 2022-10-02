import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Subject } from '../subject';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {

  subjects: Subject[] = [];

  constructor(public collegeMgmtService : CollegeMgmtService) { }

  ngOnInit(): void {
    this.collegeMgmtService.getAllSubjects().subscribe((data: Subject[])=>{
      this.subjects = data;
      console.log(this.subjects);
    }) 
  }
}
