import { Component, OnInit, ViewChild } from '@angular/core';
import {Router} from "@angular/router";

import {AuthenticationService} from "../../Servicios/login/authentication.service";
import {StorageService} from "../../Servicios/storage.service";
import {MensajesService} from "../../Servicios/mensajes.service";

import { CookieService } from 'ngx-cookie-service';

import { LoadingService } from '../Servicios/loading.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  
  public loading: boolean;
  public _opened: boolean = false;
  public _closeOnClickOutSide: boolean;
  public _mode : string;
  public _dock:boolean;
  public _dockedSize: string;
  //public _colapsarMenu :boolean = false; //Controla la vista del menú  

  constructor(
    private storageService: StorageService,
    private router: Router,
    private cookieService: CookieService,
    private loadingService: LoadingService
    ) { }

    

  ngOnInit() : void {
    console.log(this.storageService.getCurrentSession());
    if(this.storageService.getCurrentSession() == null)
        this.storageService.logout();
    
    this.loading = false;
    //this._autoCollapseOnInit = false;
    this._closeOnClickOutSide = true;
    this._mode = 'push';
    this._dock = true;
    this._dockedSize = '50px';

    /*setTimeout(() => {
      if(this.cookieService.check('_opened')){
        this._opened = this.cookieService.get('_opened').toLowerCase() == 'true' ? true : false;
        //this._colapsarMenu = this._opened;
      }
    });*/

    //setTimeout(() => {
      this.loadingService.change.subscribe( (isOpen) => {
        //console.log(isOpen);
        this.loading = isOpen;
      });
    //});
  }

  validaSesionActiva() : boolean {
    return this.storageService.isAuthenticated();
  }
 
  _toggleSidebar(mode, menu) {
    this._opened = mode.menuToggler;
    menu.toggleCollapsed(!this._opened);
    //this._colapsarMenu = this._opened;
   // this.cookieService.set('_opened', String(this._opened));
  }

  onClosed(event){
    document.getElementsByTagName("aside")[0].removeAttribute("style");
  }  

  /*private _toggleLoading(event){
    console.log(event);
    this.loading = event.show;
  }*/
}