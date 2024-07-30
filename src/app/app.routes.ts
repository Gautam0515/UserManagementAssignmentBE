import { Routes } from '@angular/router';

export const routes: Routes = [
    {path:'',loadChildren:()=>import('./user/user.module').then(x=>x.UserModule)},
    {path:'shared',loadChildren:()=>import('./shared/shared.module').then(x=>x.SharedModule)}

];
