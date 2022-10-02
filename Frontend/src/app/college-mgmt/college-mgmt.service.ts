import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
    
import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Course } from './course';
import { Teacher } from './teacher';

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

  createTeacher(teacher : Teacher) : Observable<Teacher>{
    return this.httpClient.post<Teacher>(this.apiURL + 'teacher/', JSON.stringify(teacher), this.httpOptions)
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

  getAllTeachers(): Observable<Teacher[]> {
    return this.httpClient.get<Teacher[]>(this.apiURL + 'teacher/')
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
