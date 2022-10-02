import { Component, OnInit } from '@angular/core';

import { CollegeMgmtService } from '../college-mgmt.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.css']
})
export class CreateStudentComponent implements OnInit {

  form!: FormGroup;
  newRegNum!: string;

  constructor(
    public collegeMgmtService: CollegeMgmtService,
    private router: Router
  ) { 

    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      birthday: new FormControl('', [Validators.required]),
      regNum: new FormControl('',[Validators.required])
    });

    this.collegeMgmtService.getNewRegNum().subscribe((data: string)=>{
      this.newRegNum = data;
      this.form.patchValue({
        regNum : this.newRegNum
      });
    }) 
  }

  ngOnInit(): void {
    //startDate: [formatDate(this.post.startDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
  }
  get f(){
    return this.form.controls;
  }
  submit(){
    //this.teacher.salary = parseInt(this.form.value.get("salary"));
    this.collegeMgmtService.createStudent(this.form.value).subscribe((res:any) => {
         console.log('Student created successfully!');
         this.router.navigateByUrl('student/list');
    })
  }

}
