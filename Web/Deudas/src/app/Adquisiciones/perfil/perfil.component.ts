import { Component, OnInit } from '@angular/core';
//Servicios
import {AuthenticationService} from "../../Servicios/login/authentication.service";
import {StorageService} from "../../Servicios/storage.service";
import {MensajesService} from "../../Servicios/mensajes.service";

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  constructor(
      private authenticationService: AuthenticationService,
      public storageService: StorageService,
      private mensajes:MensajesService
  ) { }

  ngOnInit() {
  }

}
