import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { CommonModule }   from '@angular/common';

import { DashboardComponent } from './dashboard/dashboard.component';
import { PeriodosComponent } from './Catalogos/periodos/periodos.component';
import { MenuComponent } from './menu/menu.component';
import { TopmenuComponent } from './topmenu/topmenu.component';

//Modales
import {  AgregarPeriodoComponent } from './Catalogos/modales/agregar-periodo/agregar-periodo.component';
//Ruteador
import { AdquisicionesRoutingModule } from './aquisiciones-routing.module';
//Componente sidebar
import { SidebarModule } from 'ng-sidebar';
//Loading
import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';
//Toast
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';
//Cookies
import { CookieService } from 'ngx-cookie-service';
//Servicio para loading
import { LoadingService } from './Servicios/loading.service';
//Servicios para toast
import {MensajesService} from "../Servicios/mensajes.service";

// RECOMMENDED
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


//Directivas
import{OnlyNumber} from './Directives/OnlyNumber';

@NgModule({
  declarations: [
    DashboardComponent,
    PeriodosComponent,
    MenuComponent,
    TopmenuComponent,
    OnlyNumber,
  ],
  imports: [
    CommonModule,
    FormsModule,
    AdquisicionesRoutingModule,    
    BrowserAnimationsModule, // required animations module
    SidebarModule.forRoot(),
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
      
    BsDropdownModule.forRoot(),
  ],
  providers: [CookieService, LoadingService, MensajesService],
  entryComponents: [AgregarPeriodoComponent]
})
export class AppModuleAdquisiciones {  }
