import { Component, OnInit } from '@angular/core';
import { CollegeMgmtService } from '../college-mgmt.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrls: ['./create-subject.component.css']
})
export class CreateSubjectComponent implements OnInit {
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
    this.collegeMgmtService.createSubject(this.form.value).subscribe((res:any) => {
         console.log('Subject created successfully!');
         this.router.navigateByUrl('subject/list');
    })
  }
}
