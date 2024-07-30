import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SideMenuComponent } from './side-menu/side-menu.component';

const routes: Routes = [
  {path:'',component:SideMenuComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }
