export class Transaccion{
    IdTransaccion: number;
    IdTipoTransaccion: number;
    Fecha: Date;
    Monto : number;
    IdCuenta: number;
  
    constructor(IdTransaccion: number,IdTipoTransaccion: number,Fecha: Date,Monto : number, IdCuenta: number){
      this.IdTransaccion = IdTransaccion;
      this.IdTipoTransaccion = IdTipoTransaccion;
      this.Fecha = Fecha;
      this.Monto = Monto;
      this.IdCuenta = IdCuenta;
    }
}