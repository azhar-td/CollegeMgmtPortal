import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Student } from '../student';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  students: Student[]=[]

  constructor(public collegeMgmtService: CollegeMgmtService) { }

  ngOnInit(): void {
    this.collegeMgmtService.getAllStudents().subscribe((data: Student[])=>{
      this.students = data;
      console.log(this.students);
    }) 
  }
}
