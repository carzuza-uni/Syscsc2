import { Pipe, PipeTransform } from '@angular/core';
import { Productor } from '../syscsc/models/productor';

@Pipe({
  name: 'filtroProductor'
})
export class FiltroProductorPipe implements PipeTransform {

  transform(productor: Productor[], searchText: string): any {
    if(searchText == null){
      return productor;
    }
    return productor.filter(u => u.nombrePredio.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 || u.cedula.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 || u.cedulaCafetera.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 || u.codigoFinca.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 );
  }

}
