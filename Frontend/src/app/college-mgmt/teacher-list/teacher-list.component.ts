import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Teacher } from '../teacher';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent implements OnInit {
  teachers: Teacher[]=[]

  constructor(public collegeMgmtService: CollegeMgmtService) { }

  ngOnInit(): void {
    this.collegeMgmtService.getAllTeachers().subscribe((data: Teacher[])=>{
      this.teachers = data;
      console.log(this.teachers);
    }) 
  }

}
