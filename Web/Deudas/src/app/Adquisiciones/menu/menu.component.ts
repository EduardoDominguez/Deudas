import { Component, Output, EventEmitter, OnInit, Input } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import {AuthenticationService} from "../../Servicios/login/authentication.service";
import {StorageService} from "../../Servicios/storage.service";
import {MensajesService} from "../../Servicios/mensajes.service";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
    isActive: boolean;
    collapsed: boolean;
    showMenu: string;
    pushRightClass: string;

    public nombreCompleto : string;

    public loading = true;

    @Output() collapsedEvent = new EventEmitter<boolean>();
    
    constructor(
      private authenticationService: AuthenticationService,
      private storageService: StorageService,
      private mensajes:MensajesService,
      //private translate: TranslateService,
      public router: Router) {
        /*this.translate.addLangs(['en', 'fr', 'ur', 'es', 'it', 'fa', 'de']);
        this.translate.setDefaultLang('en');
        const browserLang = this.translate.getBrowserLang();
        this.translate.use(browserLang.match(/en|fr|ur|es|it|fa|de/) ? browserLang : 'en');*/

        /*this.router.events.subscribe(val => {
         
            if (
                val instanceof NavigationEnd &&
                window.innerWidth <= 992 &&
                this.isToggled()
            ) {
                this.toggleSidebar();
            }
        });*/
    }

    ngOnInit() {
        this.isActive = false;
        this.collapsed = true;//Hasta antes de usar el input
        this.showMenu = '';
        this.pushRightClass = 'push-right';

        this.nombreCompleto = this.storageService.getCurrentSession().user.full_name;
    }
  
    onLoggedout(){
      this.loading = true;
      this.authenticationService.logout().subscribe(
        data  => {
          this.storageService.logout();
          this.loading = false;
      }, error => {
          this.mensajes.showError(error.message);
          this.loading = false;
      });
    }

    eventCalled() {
        this.isActive = !this.isActive;
    }

    addExpandClass(element: any) {
        if (element === this.showMenu) {
            this.showMenu = '0';
        } else {
            this.showMenu = element;
        }
    }

    toggleCollapsed(collapsedParam?: boolean):void {
        if(collapsedParam != undefined)
            this.collapsed = collapsedParam;
        else
            this.collapsed = !this.collapsed;

        this.collapsedEvent.emit(this.collapsed);
    }

    isToggled(): boolean {
        const dom: Element = document.querySelector('body');
        return dom.classList.contains(this.pushRightClass);
    }

    toggleSidebar() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle(this.pushRightClass);
    }

    /*rltAndLtr() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle('rtl');
    }*/

    /*changeLang(language: string) {
        this.translate.use(language);
    }*/

    /*onLoggedout() {
        localStorage.removeItem('isLoggedin');
    }*/
}