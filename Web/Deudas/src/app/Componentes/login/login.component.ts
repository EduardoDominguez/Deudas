import {Component} from "@angular/core";
import {Router} from "@angular/router";

import {LoginObject} from "../../Clases/login/LoginObject";
import {AuthenticationService} from "../../Servicios/login/authentication.service";
import {TokenService} from "../../Servicios/token.service";
import {StorageService} from "../../Servicios/storage.service";
import {MensajesService} from "../../Servicios/mensajes.service";

import {Sesion} from "../../Clases/Sesion";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {  
  public loading = false;

  usuario :string;
  password :string;
  
  constructor(
              private authenticationService: AuthenticationService,
              private storageService: StorageService,
              private router: Router,
              private mensajes:MensajesService,
              private tokenService: TokenService, ) { }
          
  ngOnInit() {
    this.usuario = "";
    this.password = "";

    if(this.storageService.isAuthenticated())
      this.storageService.removeCurrentSession();
  }

  iniciarSesion(){
    this.loading = true;
    let login = new LoginObject({username:this.usuario , password: this.password});
    //TokenService

    this.tokenService.getToken(login).subscribe(
      respuesta  => {
        console.log(respuesta);
        
        if(respuesta!= ""){
          this.authenticationService.login(login).subscribe(
            data  => {
              if(data.estatus)
                this.correctLogin(data.data);
              else
                this.mensajes.showWarning(data.mensaje);
                
              this.loading = false;
          }, error => {
              //console.log(error);
              this.mensajes.showError(error.name);
              this.loading = false;
          });
        }
        else
          this.mensajes.showWarning(data.mensaje);
          
        this.loading = false;
    }, error => {
        //console.log(error);
        this.mensajes.showError(error.name);
        this.loading = false;
    });
    /*
    this.authenticationService.login(login).subscribe(
      data  => {
        if(data.estatus)
          this.correctLogin(data.data);
        else
          this.mensajes.showWarning(data.mensaje);
          
        this.loading = false;
    }, error => {
        //console.log(error);
        this.mensajes.showError(error.name);
        this.loading = false;
    });*/
  }

  /*public submitLogin(): void {
    this.submitted = true;
    this.error = null;
    if(this.loginForm.valid){
      this.authenticationService.login(new LoginObject(this.loginForm.value)).subscribe(
        data => this.correctLogin(data),
        error => this.error = JSON.parse(error._body)
      )
    }
  }*/

  private correctLogin(data: Sesion){
    this.storageService.setCurrentSession(data);
    this.router.navigate(['/']);
  }
}