import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css']
})
export class CreateCourseComponent implements OnInit {

  form!: FormGroup;
     
  constructor(
    public collegeMgmtService : CollegeMgmtService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required])
    });
  }
  get f(){
    return this.form.controls;
  }

  submit(){
    this.collegeMgmtService.createCourse(this.form.value).subscribe((res:any) => {
         console.log('Course created successfully!');
         this.router.navigateByUrl('');
    })
  }
}
