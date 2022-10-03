import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Course } from '../course';
import { Student } from '../student';
import { Subject } from '../subject';
import { Teacher } from '../teacher';

@Component({
  selector: 'app-create-grade',
  templateUrl: './create-grade.component.html',
  styleUrls: ['./create-grade.component.css']
})
export class CreateGradeComponent implements OnInit {
  assignedSubjects: Subject[] = []
  assignedStudents: Student[] = []
  course!: Course;
  courseId!: number;
  form!: FormGroup;
  
  constructor(public collegeMgmtService : CollegeMgmtService, private route: ActivatedRoute, private router: Router) {
    this.courseId = this.route.snapshot.params['courseId'];
    this.form = new FormGroup({
      courseName: new FormControl('', [Validators.required]),
      subjectId: new FormControl('', [Validators.required]),
      studentId: new FormControl('',[Validators.required]),
      grades: new FormControl('',[Validators.required,Validators.pattern('^[1-9][0-9]?$|^100$')])
    });

    this.collegeMgmtService.getCourseById(this.courseId).subscribe((data: Course)=>{
      this.course = data;
      this.form.patchValue({
        courseName : this.course.name,
        courseId: this.courseId
      });
    }) 

    this.collegeMgmtService.getAllAssignedSubjectsByCourseId(this.courseId).subscribe((data: Subject[])=>{
      this.assignedSubjects = data;
    }) 

    this.collegeMgmtService.getAllAssignedStudentsByCourseId(this.courseId).subscribe((data: Student[])=>{
      this.assignedStudents = data;
    }) 
   }

  ngOnInit(): void {
  }

  onSubjectChange(deviceValue:any) {

  }

  get f(){
    return this.form.controls;
  }

  submit(){
    this.form.patchValue({
      subjectId: parseInt(this.form.value["subjectId"]),
      studentId: parseInt(this.form.value["studentId"]),
      grades: parseInt(this.form.value["grades"])
    });
    this.collegeMgmtService.createSubjectGrade(this.form.value).subscribe((res:any) => {
         console.log('Grade created successfully!');
         this.router.navigateByUrl('');
    })
  }

}
