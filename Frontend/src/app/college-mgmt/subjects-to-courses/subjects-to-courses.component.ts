import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Course } from '../course';
import { CourseDetail } from '../course-detail';
import { Subject } from '../subject';
import { Teacher } from '../teacher';

@Component({
  selector: 'app-subjects-to-courses',
  templateUrl: './subjects-to-courses.component.html',
  styleUrls: ['./subjects-to-courses.component.css']
})
export class SubjectsToCoursesComponent implements OnInit {
  unAssignedSubjects: Subject[] = []
  unAssignedTeachers: Teacher[] = []
  course!: Course;
  courseId!: number;
  form!: FormGroup;
  
  constructor(public collegeMgmtService : CollegeMgmtService, private route: ActivatedRoute, private router: Router) {
    this.courseId = this.route.snapshot.params['courseId'];
    this.form = new FormGroup({
      courseId: new FormControl('', [Validators.required]),
      courseName: new FormControl('', [Validators.required]),
      subjectId: new FormControl('', [Validators.required]),
      teacherId: new FormControl('',[Validators.required])
    });

    this.collegeMgmtService.getCourseById(this.courseId).subscribe((data: Course)=>{
      this.course = data;
      this.form.patchValue({
        courseName : this.course.name,
        courseId: this.courseId
      });
    }) 

    this.collegeMgmtService.getAllUnAssignedSubjectsByCourseId(this.courseId).subscribe((data: Subject[])=>{
      this.unAssignedSubjects = data;
    }) 

    this.collegeMgmtService.getAllUnAssignedTeachersByCourseId(this.courseId).subscribe((data: Teacher[])=>{
      this.unAssignedTeachers = data;
    }) 
   }

  ngOnInit(): void {

  }

  get f(){
    return this.form.controls;
  }

  submit(){
    this.form.patchValue({
      courseName : this.course.name,
      courseId: parseInt(this.form.value["courseId"]),
      subjectId: parseInt(this.form.value["subjectId"]),
      teacherId: parseInt(this.form.value["teacherId"])
    });
    this.collegeMgmtService.createCourseDetail(this.form.value).subscribe((res:any) => {
         console.log('Coursedetail created successfully!');
         this.router.navigateByUrl('');
    })
  }

}
