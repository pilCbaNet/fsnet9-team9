import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {
  url: string="https://localhost:7208/api/Usuario/API-BestWallet/usuario/login"
  constructor(private http: HttpClient) { 
    console.log("El servicio movimientos esta corriendo")
  }

  obtenerMovimientos():Observable<any>
  {
    return this.http.get(this.url);
  }
}
