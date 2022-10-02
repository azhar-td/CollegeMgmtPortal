import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
    
import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Course } from './course';
import { Teacher } from './teacher';
import { Subject } from './subject';
import { Student } from './student';
import { CourseDetail } from './course-detail';
import { AssignedStudent } from './assigned-student';

@Injectable({
  providedIn: 'root'
})
export class CollegeMgmtService {
  private apiURL = "https://localhost:44315/api/";
    
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept' : 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }

  createCourse(course : any) : Observable<Course>{
    return this.httpClient.post<Course>(this.apiURL + 'course/', JSON.stringify(course), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  createCourseDetail(courseDetail : CourseDetail) : Observable<CourseDetail>{
    return this.httpClient.post<CourseDetail>(this.apiURL + 'course/AssignSubjectAndTeacher/', JSON.stringify(courseDetail), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  createAssignedStudent(assignedStudent : AssignedStudent) : Observable<AssignedStudent>{
    return this.httpClient.post<AssignedStudent>(this.apiURL + 'course/AssignStudent/', JSON.stringify(assignedStudent), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  createSubject(subject : any) : Observable<Subject>{
    return this.httpClient.post<Subject>(this.apiURL + 'subject/', JSON.stringify(subject), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  createTeacher(teacher : Teacher) : Observable<Teacher>{
    return this.httpClient.post<Teacher>(this.apiURL + 'teacher/', JSON.stringify(teacher), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  createStudent(student : Student) : Observable<Student>{
    return this.httpClient.post<Student>(this.apiURL + 'student/', JSON.stringify(student), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getNewRegNum(): Observable<string>{
    return this.httpClient.get(this.apiURL + 'student/getNewRegNum/',{responseType: 'text'})
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllCourses(): Observable<Course[]> {
    return this.httpClient.get<Course[]>(this.apiURL + 'course/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllSubjects(): Observable<Subject[]> {
    return this.httpClient.get<Subject[]>(this.apiURL + 'subject/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllTeachers(): Observable<Teacher[]> {
    return this.httpClient.get<Teacher[]>(this.apiURL + 'teacher/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllStudents(): Observable<Student[]> {
    return this.httpClient.get<Student[]>(this.apiURL + 'student/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllUnAssignedTeachersByCourseId(courseId: any): Observable<Teacher[]> {
    return this.httpClient.get<Teacher[]>(this.apiURL + 'teacher/GetUnAssignedByCourseId?courseId=' + courseId)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllUnAssignedSubjectsByCourseId(courseId: any): Observable<Subject[]> {
    return this.httpClient.get<Subject[]>(this.apiURL + 'subject/GetUnAssignedByCourseId?courseId=' + courseId)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getAllUnAssignedStudents(courseId: any): Observable<Student[]> {
    return this.httpClient.get<Student[]>(this.apiURL + 'student/GetAllUnAssigned/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getCourseById(courseId: any): Observable<Course> {
    return this.httpClient.get<Course>(this.apiURL + 'course/' + courseId)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  errorHandler(error : any) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }

}
