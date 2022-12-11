import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from '../models/registro/registro';

@Injectable({
  providedIn: 'root'
})
export class RegistrarService {
  url: string = "https://localhost:7208/api/Usuario/API-BestWallet/usuario/registrar"

  constructor(private http:HttpClient) { }

  crearRegistro(registro:Register):Observable<any>
    {
      return this.http.post<any>(this.url, registro);
    }
}
