import { Component } from '@angular/core';

import {MensajesService} from './Servicios/mensajes.service';
import {StorageService} from './Servicios/storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProgramaAnualAdquisiciones';

  constructor(private storageService: StorageService) { }

  ngOnInit() {
  }
  
  ngOnDestroy() {
    if(this.validaSesionActiva){
      this.storageService.removeCurrentSession();
    } 
   }

  validaSesionActiva() : boolean{
    return this.storageService.isAuthenticated();
  }
}
