import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {
  url: string="https://localhost:7208/movimientos/cuenta?idCuenta="
  constructor(private http: HttpClient) { 
    console.log("El servicio movimientos esta corriendo")
  }

  obtenerMovimientos():Observable<any>
  {
    let idCta = 4;
    return this.http.get(this.url + idCta);
  }
}
