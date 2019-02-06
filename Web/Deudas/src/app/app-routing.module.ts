import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {LoginComponent} from './Componentes/login/login.component';
import { NotfoundComponent } from './Componentes/notfound/notfound.component';

import { AuthGuard } from './auth-guard.guard';

const routes: Routes = [
  
  //{ path: '', component: LoginComponent, pathMatch:'full' },
  { path: '',   redirectTo: '/Login', pathMatch: 'full' },
  { path: 'Login', component: LoginComponent },
  { path: '**', component: NotfoundComponent},
  {
    path: '',
    loadChildren: './Adquisiciones/app.module.adquisiciones#AppModuleAdquisiciones',
    canLoad: [AuthGuard]
    //data: { preload: true }
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
