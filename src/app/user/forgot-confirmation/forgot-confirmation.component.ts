import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';


@Component({
  selector: 'app-forgot-confirmation',
  standalone: true,
  imports: [CommonModule,MatCardModule,MatButtonModule],
  templateUrl: './forgot-confirmation.component.html',
  styleUrl: './forgot-confirmation.component.css'
})
export class ForgotConfirmationComponent {
constructor(private router:Router){}
  public GoBack() {
    this.router.navigate(['/'])
  }
  
}
