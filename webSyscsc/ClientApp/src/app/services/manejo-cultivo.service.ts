import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { ManejoCultivo } from '../syscsc/models/manejo-cultivo';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ManejoCultivoService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }

  post(data: ManejoCultivo): Observable<ManejoCultivo>{
    return this.http.post<ManejoCultivo>(this.baseUrl + 'api/ManejoCultivo', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<ManejoCultivo>('Registrar manejo cultivo', null))
      );
  }

  put(id: number, data: ManejoCultivo): Observable<ManejoCultivo>{    
    data.manejoCultivoId = id;
    return this.http.put<ManejoCultivo>(this.baseUrl + 'api/ManejoCultivo/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<ManejoCultivo>('Registrar data', null))
      );
  }

  get(id: number): Observable<ManejoCultivo[]>{
    return this.http.get<ManejoCultivo[]>(this.baseUrl + 'api/ManejoCultivo/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<ManejoCultivo[]>('Consulta manejo cultivo', null))
      );
  }
}
