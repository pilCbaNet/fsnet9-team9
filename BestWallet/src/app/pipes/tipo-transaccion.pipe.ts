import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tipoTransaccion'
})
export class TipoTransaccionPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    let texto: string ='';
    if(value == 2){ texto= 'Retiro'}
    else if (value == 3){texto= 'Depósito'};
    return texto;
  }

}
