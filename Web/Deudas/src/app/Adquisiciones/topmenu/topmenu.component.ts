import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

import { Router } from '@angular/router';
import {AuthenticationService} from "../../Servicios/login/authentication.service";
import {StorageService} from "../../Servicios/storage.service";
import {MensajesService} from "../../Servicios/mensajes.service";

@Component({
  selector: 'app-topmenu',
  templateUrl: './topmenu.component.html',
  styleUrls: ['./topmenu.component.css']
})
export class TopmenuComponent implements OnInit {

  // Usamos el decorador Output
  @Output() CambiaMenu = new EventEmitter();

  public _menuToggler : boolean;
  //private _tipoFlecha : string;

  constructor(
    private authenticationService: AuthenticationService,
      private storageService: StorageService,
      private mensajes:MensajesService,
      public router: Router
  ) { }

  ngOnInit() {
    //this._tipoFlecha = 'fas fa-angle-double-right';
  }

  // Cuando se lance el evento click en la plantilla llamaremos a este método
  toggleMenu(event){
      this._menuToggler = !this._menuToggler;
      // Usamos el método emit
      this.CambiaMenu.emit({menuToggler: this._menuToggler});
  }

  onLoggedout(){
    this.authenticationService.logout().subscribe(
      data  => {
        this.storageService.logout();
    }, error => {
        this.mensajes.showError(error.message);
    });
  }
}
