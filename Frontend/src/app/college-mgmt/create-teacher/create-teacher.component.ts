import { Component, OnInit } from '@angular/core';

import { CollegeMgmtService } from '../college-mgmt.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { formatDate } from '@angular/common';
import { Teacher } from '../teacher';

@Component({
  selector: 'app-create-teacher',
  templateUrl: './create-teacher.component.html',
  styleUrls: ['./create-teacher.component.css']
})
export class CreateTeacherComponent implements OnInit {
  form!: FormGroup;
  teacher!: Teacher;

  constructor(
    public collegeMgmtService: CollegeMgmtService,
    private router: Router
  ) { }

  ngOnInit(): void {
    //startDate: [formatDate(this.post.startDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      birthday: new FormControl('', [Validators.required]),
      salary: new FormControl('',[Validators.required])
    });
  }
  get f(){
    return this.form.controls;
  }
  submit(){
    //this.teacher.salary = parseInt(this.form.value.get("salary"));
    this.collegeMgmtService.createTeacher(this.form.value).subscribe((res:any) => {
         console.log('Teacher created successfully!');
         this.router.navigateByUrl('teacher/list');
    })
  }
}
