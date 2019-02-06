import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CurrencyPipe } from '@angular/common';

//Toast
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';

//Loading
import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';

//sidebar
//import { SidebarModule } from 'ng-sidebar';

//Globales
import {Globales} from './Gobales/Globales';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Componentes/login/login.component';
import { NotfoundComponent } from './Componentes/notfound/notfound.component';
//import { AuthGuard } from './auth-guard.guard';

import { AppModuleAdquisiciones  } from './Adquisiciones/app.module.adquisiciones';
import { DireccionesComponent } from './Adquisiciones/Catalogos/direcciones/direcciones.component';
import { UsuariosRolesComponent } from './Adquisiciones/Catalogos/usuarios-roles/usuarios-roles.component';
import { ProcedimientosComponent } from './Adquisiciones/Catalogos/procedimientos/procedimientos.component';
import { CogComponent } from './Adquisiciones/Catalogos/cog/cog.component';
import { AgregarPeriodoComponent } from './Adquisiciones/Catalogos/modales/agregar-periodo/agregar-periodo.component';

//import { AppModuleAdquisiciones  } from './Adquisiciones/app.module..adquisiciones';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { DatepcikerRangeComponent } from './Adquisiciones/Catalogos/comunes/datepciker-range/datepciker-range.component';

import { registerLocaleData } from '@angular/common';
import localeMX from '@angular/common/locales/es-MX';
import { PerfilComponent } from './Adquisiciones/perfil/perfil.component';
import { AgregarProgramacionComponent } from './Adquisiciones/Programacion/agregar-programacion/agregar-programacion.component';

registerLocaleData(localeMX, 'es-MX');

//Pipes
//import { ThousandsPipe } from './Adquisiciones/Pipes/decimal.pipe';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotfoundComponent,
    DireccionesComponent,
    UsuariosRolesComponent,
    ProcedimientosComponent,
    CogComponent,
    AgregarPeriodoComponent,
    DatepcikerRangeComponent,
    PerfilComponent,
    AgregarProgramacionComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar : true
    }), // ToastrModule added
    NgxLoadingModule.forRoot({
      animationType: ngxLoadingAnimationTypes.threeBounce,
      backdropBackgroundColour: 'rgba(0,0,0,0.2)', 
      backdropBorderRadius: '4px',
      primaryColour: '#004CBD', 
      secondaryColour: '#f6901e', 
      tertiaryColour: '#ffffff',
      fullScreenBackdrop:true}),
    AppModuleAdquisiciones,
    AppRoutingModule,
    NgbModule.forRoot(),//Para bootstrap modal, y esas cosas.
    //AppModuleAdquisiciones,
    //SidebarModule.forRoot()
  ],
  //providers: [AuthGuard],
  providers: [{ provide: LOCALE_ID, useValue: 'es-MX' }, CurrencyPipe, Globales],
  bootstrap: [AppComponent]
})
export class AppModule {  }
