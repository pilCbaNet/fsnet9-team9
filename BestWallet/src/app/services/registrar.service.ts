import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from '../models/registro/registro';

@Injectable({
  providedIn: 'root'
})
export class RegistrarService {

  constructor(private http:HttpClient) { }

  crearRegistro(registro:Register):Observable<any>
    {
      return this.http.post('http://localhost:3000/usuarios',registro);
    }
  
  crearCuenta():Observable<any>{
    return this.http.post()
  }

}
