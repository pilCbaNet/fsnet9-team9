import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/cuenta/transaccion';

@Injectable({
  providedIn: 'root'
})
export class DepositoService {
  url: string="https://localhost:7208/agregarTransaccion/deposito";

  constructor(private http : HttpClient) { }

  Depositar(transaccion:Transaccion):Observable<any>{
    return this.http.post(this.url, transaccion);
  }
}
