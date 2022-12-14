import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/cuenta/transaccion';

@Injectable({
  providedIn: 'root'
})
export class RetiroService {
  url: string="https://localhost:7208/agregarTransaccion/retiro";

  constructor(private http : HttpClient) { }

  Retirar(transaccion:Transaccion):Observable<any>{
    return this.http.post(this.url, transaccion);
  }
}
