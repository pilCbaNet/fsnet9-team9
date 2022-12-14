import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Transaccion } from 'src/app/models/cuenta/transaccion';
import { RetiroService } from 'src/app/services/retiro.service';

@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.css']
})
export class RetiroComponent implements OnInit {

  retiroForm: FormGroup;
  transaccion = {} as Transaccion;
  saldo: number=0;

  constructor(private formBuilder: FormBuilder,
    private retiroService : RetiroService,
    private router:Router) {
      this.retiroForm = this.formBuilder.group({
        monto:['',[Validators.required]]
      });
     }

  ngOnInit(): void {
  }

  retirar(){
    this.transaccion.Fecha= new Date();
    this.transaccion.IdTipoTransaccion= 2;
    this.transaccion.Monto= this.retiroForm.value.monto;
    this.transaccion.IdCuenta= 4;
    this.retiroService.Retirar(this.transaccion).subscribe((data) =>{
      if(data.ok){
        alert("Retiro exitoso");
      }else{
        alert("Error al registrar transacción");
      }
      this.router.navigate(['movimientos']);
      })
  }

}
