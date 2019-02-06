import {Injectable} from "@angular/core";
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {Sesion} from "../../Clases/Sesion";
import {LoginObject} from "../../Clases/login/LoginObject";

//Globales
import {Globales} from '../../Gobales/Globales';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  //private basePath = 'http://localhost:3000/autenticar/';
  //private basePath = 'autenticar/';
  private basePath : string;


  constructor( private http: HttpClient, private globales: Globales) 
  {
      this.basePath = globales.IP_SERVER+'autenticar/'; 
  }
  
  /** POST: add a new hero to the server */
  login (loginObj: LoginObject): Observable<Sesion> {
    console.log(loginObj);
    return this.http.post<Sesion>(this.basePath+ 'login', loginObj, httpOptions).pipe(
      tap(() =>console.log("Petición HTTP ejecutada")),
      map(res  =>  res as Sesion),
      //catchError(this.handleError<Sesion>('login', new Sesion()))
    );
  }

 logout(): Observable<Boolean> {
    //return this.http.post(this.basePath + 'logout', {}).map(this.extractData);
    return this.http.post<Boolean>(this.basePath+ 'login', {}, httpOptions).pipe(
      tap(_=>console.log('sesión cerrada')),
      catchError(this.handleError<Boolean>('logout'))
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