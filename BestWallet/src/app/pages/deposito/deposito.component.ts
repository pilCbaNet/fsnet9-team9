import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Transaccion } from 'src/app/models/cuenta/transaccion';
import { DepositoService } from 'src/app/services/deposito.service';

@Component({
  selector: 'app-deposito',
  templateUrl: './deposito.component.html',
  styleUrls: ['./deposito.component.css']
})
export class DepositoComponent implements OnInit {

  depositoForm: FormGroup;
  transaccion = {} as Transaccion;
  saldo: number=0;

  constructor(
    private formBuilder: FormBuilder,
    private depositoService : DepositoService,
    private router:Router) {
      this.depositoForm = this.formBuilder.group({
        importe:['',[Validators.required]]
      });
     }

  ngOnInit(): void {
  }

  depositar(){
    this.transaccion.Fecha= new Date();
    this.transaccion.IdTipoTransaccion= 3;
    this.transaccion.Monto= this.depositoForm.value.importe;
    this.transaccion.IdCuenta= 4;
    this.depositoService.Depositar(this.transaccion).subscribe((data) =>{
      if(data.ok){
        alert("Depósito exitoso");
      }else{
        alert("Error al registrar transacción");
      }
      this.router.navigate(['movimientos']);
      })
  }

}
