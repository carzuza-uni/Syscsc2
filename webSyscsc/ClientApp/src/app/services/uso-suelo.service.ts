import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { UsoSuelo } from '../syscsc/models/uso-suelo';

@Injectable({
  providedIn: 'root'
})
export class UsoSueloService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }

  post(data: UsoSuelo): Observable<UsoSuelo>{
    return this.http.post<UsoSuelo>(this.baseUrl + 'api/UsoSuelo', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<UsoSuelo>('Registrar uso suelo', null))
      );
  }

  put(id: number, data: UsoSuelo): Observable<UsoSuelo>{
    
    data.usoSueloId = id;
    return this.http.put<UsoSuelo>(this.baseUrl + 'api/UsoSuelo/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<UsoSuelo>('Registrar data', null))
      );
  }

  get(id: number): Observable<UsoSuelo[]>{
    return this.http.get<UsoSuelo[]>(this.baseUrl + 'api/UsoSuelo/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<UsoSuelo[]>('Consulta uso suelo', null))
      );
  }
}
