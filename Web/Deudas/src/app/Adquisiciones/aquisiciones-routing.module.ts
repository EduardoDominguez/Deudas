import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { PeriodosComponent } from './Catalogos/periodos/periodos.component';
import { DireccionesComponent } from './Catalogos/direcciones/direcciones.component';

import { ProcedimientosComponent } from './Catalogos/procedimientos/procedimientos.component';
import { UsuariosRolesComponent } from './Catalogos/usuarios-roles/usuarios-roles.component';
import { CogComponent } from './Catalogos/cog/cog.component';


import { PerfilComponent } from './perfil/perfil.component';

import { AgregarProgramacionComponent } from './Programacion/agregar-programacion/agregar-programacion.component';

import { NotfoundComponent } from '../Componentes/notfound/notfound.component';

const adqRoutes: Routes = [
  { path: 'login', redirectTo:"/Login", pathMatch: 'full'},
  {
      path: '',
      component: DashboardComponent,
      children: [
        { path: 'catalogos/periodos', component: PeriodosComponent},  
        { path: 'catalogos/direcciones', component: DireccionesComponent},  
        { path: 'catalogos/procedimientos', component: ProcedimientosComponent},
        { path: 'catalogos/usuarios-roles', component: UsuariosRolesComponent},
        { path: 'catalogos/cog', component: CogComponent},
        { path: 'perfil', component: PerfilComponent},
        { path: 'programacion/agregar', component: AgregarProgramacionComponent},
        //{ path: '**', component:NotfoundComponent},
      ]
  },  
  
];

@NgModule({
  imports: [
    RouterModule.forChild(adqRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AdquisicionesRoutingModule { }