import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { BehaviorSubject, map, Observable, tap } from 'rxjs';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string="https://localhost:7208/api/Usuario/API-BestWallet/usuario/login";

  loggedIn = new BehaviorSubject<boolean>(false);
  currentUserSubject: BehaviorSubject<Login>;
  currentUser: Observable<Login>;

  constructor(private http:HttpClient, private router:Router) {
    this.currentUserSubject = new BehaviorSubject<Login>(JSON.parse(localStorage.getItem('currentUser') || '{}'));
    this.currentUser = this.currentUserSubject.asObservable();
   }

  iniciarSesion(login:Login):Observable<any>{
    return this.http.post<any>(this.url,login)
    .pipe(tap(data => {
      sessionStorage.setItem('currentUser',data);
      this.currentUserSubject.next(data);
      this.loggedIn.next(true);
      return data;
    }));
  }
  cerrarSesion(): void {
    sessionStorage.removeItem('currentUser');
    this.loggedIn.next(false);
  }
  get usuarioAutenticado(){
    return this.currentUserSubject.value;
  }
  get estaAutenticado(): Observable<boolean> {
    if(!this.loggedIn.getValue()){
      this.router.navigate(['home']);
    }
    return this.loggedIn.asObservable();
  }
}