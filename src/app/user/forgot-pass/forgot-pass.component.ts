import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import{FormGroup,FormControl, ReactiveFormsModule, Validators} from '@angular/forms'
import{MatCardModule}from '@angular/material/card'
import {MatFormFieldModule} from '@angular/material/form-field'
import {MatInputModule} from '@angular/material/input'
import {MatButtonModule} from '@angular/material/button';
import { Router } from '@angular/router';
import { UserService } from '../../Services/user.service';
@Component({
  selector: 'app-forgot-pass',
  standalone: true,
  imports: [MatButtonModule,MatInputModule,MatFormFieldModule,MatCardModule,ReactiveFormsModule,CommonModule],
  templateUrl: './forgot-pass.component.html',
  styleUrl: './forgot-pass.component.css'
})
export class ForgotPassComponent implements OnInit{


  constructor(private router: Router,private userservice:UserService){}
  forgotform!:FormGroup
ngOnInit(): void {
  this.forgotform=new FormGroup({
    email:new FormControl('',[Validators.required,Validators.email])
    })
}

public GoBack() {
  this.router.navigate(['/'])
}

forgotconfirm() {
  if(this.forgotform.valid){
    this.userservice.ForgotCredPost(this.forgotform.value).subscribe({
      next: response => {
        try {
          response
        } catch (error) {
          alert("User not found no email sent")
        }
        this.router.navigate(['/forgotconfirm'])
      },
      error: error => {
        console.error('Error posting data', error);
        alert("Invalid Email or Password")
      }
    })

  }
  else{
    alert("Please enter a email")
  }
}

}
