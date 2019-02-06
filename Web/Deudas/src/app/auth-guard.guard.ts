import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import {StorageService} from './Servicios/storage.service';

@Injectable()
export class AuthGuard implements CanActivate {
    
    constructor(
        public router: Router,
        private storageService: StorageService) { }

    canActivate(): boolean {
        console.log('Entro');
        if (this.storageService.isAuthenticated()) {
            this.router.navigate(['Login']);
            return false;
        }

        return true;
    }
}
