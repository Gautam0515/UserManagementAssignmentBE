import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ForgotPassComponent } from './forgot-pass/forgot-pass.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ForgotConfirmationComponent } from './forgot-confirmation/forgot-confirmation.component';
import { ResetPassComponent } from './reset-pass/reset-pass.component';

export const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'forgot',component:ForgotPassComponent},
  {path:'forgotconfirm',component:ForgotConfirmationComponent},
  {path:'dash',component:DashboardComponent},
  {path:'reset',component:ResetPassComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
