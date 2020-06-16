import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { Agroclimatica } from '../syscsc/models/agroclimatica';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AgroclimaticaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { 
    this.baseUrl = baseUrl;
  }

  post(data: Agroclimatica): Observable<Agroclimatica>{
    return this.http.post<Agroclimatica>(this.baseUrl + 'api/Agroclimatica', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Agroclimatica>('Registrar agroclimatica', null))
      );
  }

  put(id: number, data: Agroclimatica): Observable<Agroclimatica>{    
    data.agroclimaticaId = id;
    return this.http.put<Agroclimatica>(this.baseUrl + 'api/Agroclimatica/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Agroclimatica>('Registrar data', null))
      );
  }

  get(id: number): Observable<Agroclimatica>{
    return this.http.get<Agroclimatica>(this.baseUrl + 'api/Agroclimatica/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<Agroclimatica>('Consulta agroclimatica', null))
      );
  }
}
