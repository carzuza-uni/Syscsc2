import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { InsumoInterno } from '../syscsc/models/insumo-interno';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InsumoInternoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { 
    this.baseUrl = baseUrl;
  }

  post(data: InsumoInterno): Observable<InsumoInterno>{
    return this.http.post<InsumoInterno>(this.baseUrl + 'api/InsumoInterno', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<InsumoInterno>('Registrar datos', null))
      );
  }

  put(id: number, data: InsumoInterno): Observable<InsumoInterno>{
    
    data.insumoInternoId = id;
    return this.http.put<InsumoInterno>(this.baseUrl + 'api/InsumoInterno/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<InsumoInterno>('Registrar datos', null))
      );
  }

  get(id: number): Observable<InsumoInterno[]>{
    return this.http.get<InsumoInterno[]>(this.baseUrl + 'api/InsumoInterno/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<InsumoInterno[]>('Consulta datos', null))
      );
  }
}
