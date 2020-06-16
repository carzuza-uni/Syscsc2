import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { InsumoExterno } from '../syscsc/models/insumo-externo';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InsumoExternoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
   }

  post(data: InsumoExterno): Observable<InsumoExterno>{
    return this.http.post<InsumoExterno>(this.baseUrl + 'api/InsumoExterno', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<InsumoExterno>('Registrar datos', null))
      );
  }

  put(id: number, data: InsumoExterno): Observable<InsumoExterno>{
    
    data.insumoExternoId = id;
    return this.http.put<InsumoExterno>(this.baseUrl + 'api/InsumoExterno/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<InsumoExterno>('Registrar datos', null))
      );
  }

  get(id: number): Observable<InsumoExterno[]>{
    return this.http.get<InsumoExterno[]>(this.baseUrl + 'api/InsumoExterno/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<InsumoExterno[]>('Consulta datos', null))
      );
  }
}
