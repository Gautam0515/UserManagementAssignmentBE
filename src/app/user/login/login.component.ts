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
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

constructor(private router:Router,private userservice:UserService){}
loginform!:FormGroup
ngOnInit(): void {
  this.loginform=new FormGroup({
    email:new FormControl('',[Validators.email,Validators.required]),
    password:new FormControl('',[Validators.required])
  })
}

frogotnav() {
  this.router.navigate(['/forgot']);
}

SignIn() {


if(this.loginform.valid){

  const cred = {
    Email: this.loginform.get('email')?.value,
    Password: this.loginform.get('password')?.value
  }

  this.userservice.LoginCheckPost(cred).subscribe({
    next: response => {
      console.log('Data posted successfully', response);
      localStorage.setItem('token',response);
      this.router.navigate(['/dash']);
    },
    error: error => {
      console.error('Error posting data', error);
      alert("Invalid Email or Password")
    }
  });
  }

  else{
    alert("Invalid Form Fields Please Check Again")
  }

}

}
