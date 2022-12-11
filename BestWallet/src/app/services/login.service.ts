import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string="https://localhost:7208/api/Usuario/API-BestWallet/usuario/login"
  constructor(private http:HttpClient) { }

  iniciarSesion(login:Login):Observable<any>{
    return this.http.post<any>(this.url,login)
  }
}
