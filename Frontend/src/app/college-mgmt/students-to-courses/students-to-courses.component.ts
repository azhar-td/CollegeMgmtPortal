import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Course } from '../course';
import { Student } from '../student';

@Component({
  selector: 'app-students-to-courses',
  templateUrl: './students-to-courses.component.html',
  styleUrls: ['./students-to-courses.component.css']
})
export class StudentsToCoursesComponent implements OnInit {
  course!: Course;
  unAssignedStudents: Student[] = [];
  courseId!: number;
  form!: FormGroup;

  constructor(public collegeMgmtService : CollegeMgmtService, private route: ActivatedRoute, private router: Router) {
    this.courseId = this.route.snapshot.params['courseId'];
    this.form = new FormGroup({
      courseName: new FormControl('', [Validators.required]),
      courseId: new FormControl('', [Validators.required]),
      studentId: new FormControl('', [Validators.required])
    });

    this.collegeMgmtService.getCourseById(this.courseId).subscribe((data: Course)=>{
      this.course = data;
      this.form.patchValue({
        courseName : this.course.name,
        courseId: this.courseId
      });
    }) 

    this.collegeMgmtService.getAllUnAssignedStudents(this.courseId).subscribe((data: Student[])=>{
      this.unAssignedStudents = data;
    }) 
  }

  ngOnInit(): void {
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    this.form.patchValue({
      courseId: parseInt(this.form.value["courseId"]),
      studentId: parseInt(this.form.value["studentId"])
    });
    this.collegeMgmtService.createAssignedStudent(this.form.value).subscribe((res:any) => {
         console.log('Student assigned to course successfuly!');
         this.router.navigateByUrl('');
    })
  }

}
