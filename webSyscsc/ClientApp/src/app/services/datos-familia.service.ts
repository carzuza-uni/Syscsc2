import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { DatosFamilia } from '../syscsc/models/datos-familia';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DatosFamiliaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { 
    this.baseUrl = baseUrl;
  }

  post(data: DatosFamilia): Observable<DatosFamilia>{
    return this.http.post<DatosFamilia>(this.baseUrl + 'api/DatosFamilia', data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<DatosFamilia>('Registrar datos familia', null))
      );
  }

  put(id: number, data: DatosFamilia): Observable<DatosFamilia>{
    
    data.identificacion = id;
    return this.http.put<DatosFamilia>(this.baseUrl + 'api/DatosFamilia/'+id, data)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<DatosFamilia>('Registrar data', null))
      );
  }

  get(id: number): Observable<DatosFamilia[]>{
    return this.http.get<DatosFamilia[]>(this.baseUrl + 'api/DatosFamilia/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<DatosFamilia[]>('Consulta datos familia', null))
      );
  }
}
