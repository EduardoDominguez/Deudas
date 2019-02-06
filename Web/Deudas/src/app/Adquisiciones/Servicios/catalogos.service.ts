import {Injectable} from "@angular/core";
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

//import {Sesion} from "../../Clases/Sesion";
import {Periodo} from "../Clases/Periodos";

//Direcciones
import {ConsultaUrsResponse} from "../Clases/Response/ConsultaURsResponse";
//import {UrsRequest} from "../Clases/Request/URsRequest";

//Cog
import {ConsultaCogResponse} from "../Clases/Response/ConsultaCogResponse";
//import {UrsRequest} from "../Clases/Request/URsRequest";
//import {Cog} from "../Clases/COG";

//Periodos
import {ConsultaPeriodosResponse} from "../Clases/Response/ConsultaPeriodosResponse";

//Inserta Periodos
import {InsertaPeriodosRequest} from "../Clases/Request/InsertaPeriodosRequest";

import {ConsultaProcedimientosResponse} from "../Clases/Response/ConsultaProcedimientosResponse";

//Usuarios roles
import {ConsultaUsuariosRolesResponse} from "../Clases/Response/ConsultaUsuariosRolesResponse";

//Globales
import {Globales} from '../../Gobales/Globales';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class CatalogosService {
  //private basePath = 'http://localhost:3000/catalogos/';
  private basePath : string;


  constructor( private http: HttpClient, private globales: Globales) 
  {
      this.basePath = globales.IP_SERVER+'catalogos/'; 
  }
  
  /** POST: add a new hero to the server */
  getPeriodos (): Observable<ConsultaPeriodosResponse>{
    return this.http.get<ConsultaPeriodosResponse>(this.basePath+ 'periodos', httpOptions).pipe(
      tap(() =>console.log("Petición HTTP para periodos ejecutada")),
      map(res =>  res as ConsultaPeriodosResponse),
      //catchError(this.handleError<Sesion>('login', new Sesion()))
    );
  }

  /** POST: add a new hero to the server */
  insertaPeriodos (pPeriodos : Periodo[]): Observable<ConsultaPeriodosResponse>{
    return this.http.post<ConsultaPeriodosResponse>(this.basePath+ 'periodos', pPeriodos, httpOptions).pipe(
      tap(() =>console.log("Petición HTTP para insertar periodos ejecutada")),
      map(res  =>  res as ConsultaPeriodosResponse),
      //catchError(this.handleError<Sesion>('login', new Sesion()))
    );
  }

  getURs (): Observable<ConsultaUrsResponse>{
    /*let listaPeriodos: UR[] = [
      { id: 1, clave_ur: 1710, nombre: "Direccion de desarrollo institucional", coordinador_administrativo:"Mario Dominguez", director: "Yo"},
      { id: 2, clave_ur: 4221, nombre: "Direccion de desarrollo rural", coordinador_administrativo:"Eduardo Dominguez", director: "Yo"},
      { id: 3, clave_ur: 1123, nombre: "Direccion de desarrollo social", coordinador_administrativo:"Mario Dominguez", director: "Yo"},
    ]
    return of(listaPeriodos);*/
    //Pendiente obtener info desde servicio
    //return this.httpCliente.get<Post[]>('https://jsonplaceholder.typicode.com/posts')
    return this.http.get<ConsultaUrsResponse>(this.basePath+ 'direcciones', httpOptions).pipe(
      tap(() =>console.log("Petición HTTP para direcciones ejecutada")),
      map(res  =>  res as ConsultaUrsResponse),
      //catchError(this.handleError<Sesion>('login', new Sesion()))
    );
  }

  getProcedimientos (): Observable<ConsultaProcedimientosResponse>{
    /*let listaPeriodos: Procedimiento[] = [
      { id: 1, tipo: "Adjudicación Directa", limite_inferior: 1, limite_superior: 1528235.00 },
      { id: 2, tipo: "Licitación Restringida", limite_inferior:  1528235.01, limite_superior:  2785643.00 },
      { id: 3, tipo: "Licitación Pública ", limite_inferior:  2785643.01, limite_superior:  999999999999 },
    ]
    return of(listaPeriodos);*/
    //Pendiente obtener info desde servicio
    return this.http.get<ConsultaProcedimientosResponse>(this.basePath+ 'procedimientos', httpOptions).pipe(
      tap(() =>console.log("Petición HTTP para procedimientos ejecutada")),
      map(res  =>  res as ConsultaProcedimientosResponse),
      //catchError(this.handleError<Sesion>('login', new Sesion()))
    );
  }

 getDirecciones(): Observable<Boolean> {
    //return this.http.post(this.basePath + 'logout', {}).map(this.extractData);
    return this.http.post<Boolean>(this.basePath+ 'login', {}, httpOptions).pipe(
      tap(_=>console.log('sesión cerrada')),
      catchError(this.handleError<Boolean>('logout'))
    );
 }

 getUsuarios(): Observable<ConsultaUsuariosRolesResponse> {
  /*let listaUsuarios: Usuario[] = [
    { id: 1, clave: 24770, nombre_completo: "Mario Eduardo Domínguez Meléndez", correo:"mario.dominguez@leon.gob.mx", rol:"Administrador"},
    { id: 2, clave: 12345, nombre_completo: "Mario Eduardo Domínguez Meléndez", correo:"mario.dominguez@leon.gob.mx", rol:"Capturista"},
    { id: 3, clave: 24771, nombre_completo: "Mario Eduardo Domínguez Meléndez", correo:"mario.dominguez@leon.gob.mx", rol:"TI"},
    { id: 4, clave: 35478, nombre_completo: "Mario Eduardo Domínguez Meléndez", correo:"mario.dominguez@leon.gob.mx", rol:"Coordinador"},
  ]
  return of(listaUsuarios);*/
  return this.http.get<ConsultaUsuariosRolesResponse>(this.basePath+ 'usuarios-roles', httpOptions).pipe(
    tap(() =>console.log("Petición HTTP para direcciones ejecutada")),
    map(res  =>  res as ConsultaUsuariosRolesResponse),
    //catchError(this.handleError<Sesion>('login', new Sesion()))
  );
}

 getCOG(): Observable<ConsultaCogResponse> {
  /*let listaCog: Cog[] = [
    { id: 1, partida: "65404", nombre: "Materiales y útiles"},
    { id: 2, partida: "40021", nombre: "Impresiones oficiales"},
    { id: 3, partida: "12314", nombre: "Maquinaria, otros equipos y herramientas"},
  ]
  return of(listaCog);*/

  return this.http.get<ConsultaCogResponse>(this.basePath+ 'cog', httpOptions).pipe(
    tap(() =>console.log("Petición HTTP para cogs ejecutada")),
    map(res  =>  res as ConsultaCogResponse),
    //catchError(this.handleError<Sesion>('login', new Sesion()))
  );
}

 private extractData(res: Response) {
    let body = res.json();
    return body;
 }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
      
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}