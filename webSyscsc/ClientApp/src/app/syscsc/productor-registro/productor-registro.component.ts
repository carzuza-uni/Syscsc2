import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductorService } from 'src/app/services/productor.service';
import { Productor } from '../models/productor';

@Component({
  selector: 'app-productor-registro',
  templateUrl: './productor-registro.component.html',
  styleUrls: ['./productor-registro.component.css']
})
export class ProductorRegistroComponent implements OnInit {
  productor: Productor;
  productorId;
  constructor(private route: ActivatedRoute, private productorService: ProductorService) { 
    this.productorId = route.snapshot.params['id'];
    console.log('productorId', this.productorId);
  }

  ngOnInit() {
    this.productor = new Productor();
    if(this.productorId){
      this.get();
    }
  }

  add(){
    this.productor.municipioId = Number(this.productor.municipioId);
    this.productorService.post(this.productor).subscribe(p => {
      if (p) {
        this.productor.nombre = '';
        this.productor.municipioId = 0;
        this.productor.cedula = '';
        this.productor.cedulaCafetera = '';
        this.productor.nombrePredio = '';
        this.productor.codigoFinca = '';
        this.productor.codigoSICA = '';
        this.productor.actividades = '';
        this.productor.telefono = '';
        this.productor.afiliacionSalud = '';
        alert('Registro realizado con exito!');
      }
    });
    
    
  }

  get(){
    this.productorService.detalle(this.productorId).subscribe(result => {
      this.productor = result;
      console.log('productor', this.productor);
    });
  }

}
