import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import{FormGroup,FormControl, ReactiveFormsModule, Validators} from '@angular/forms'
import{MatCardModule}from '@angular/material/card'
import {MatFormFieldModule} from '@angular/material/form-field'
import {MatInputModule} from '@angular/material/input'
import {MatButtonModule} from '@angular/material/button';
import { UserService } from '../../Services/user.service';
import { ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-reset-pass',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule],
  templateUrl: './reset-pass.component.html',
  styleUrl: './reset-pass.component.css'
})
export class ResetPassComponent implements OnInit {

Email:string="";
  constructor(private userservice:UserService,private route: ActivatedRoute) {
    this.route.queryParamMap.subscribe((params:any) => { this.Email = params.get("Email") });
  }
flag:Boolean=false
resetform!:FormGroup
StrongPasswordRegx: RegExp =
  /^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\D*\d).{8,}$/;


  
ngOnInit(): void {
  this.resetform=new FormGroup({
    password:new FormControl('',[Validators.required,Validators.pattern(this.StrongPasswordRegx)]),
    confirmpassword:new FormControl('',[Validators.required,])
  })

  console.log(this.Email)
}


ResetPass() {

  const resetPayload = {
    Email: this.Email,
    Password: this.resetform.get('password')?.value
  }

  if(this.resetform.valid){
    if(this.resetform.get('password')?.value != this.resetform.get('confirmpassword')?.value){
      this.flag=true
      alert("Password and Confirm Password should be same");
    }
    
    this.userservice.ResetPassPut(resetPayload).subscribe({
      next:(data)=>{
        alert("Password Reset Successfully");
      },
      error(err) {
        alert("Password Reset Failed");
      },
    });
  }
  else{alert("Invalid field input")}

}


}
