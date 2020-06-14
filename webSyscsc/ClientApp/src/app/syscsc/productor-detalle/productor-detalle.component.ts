import { Component, OnInit } from '@angular/core';
import { ProductorService } from 'src/app/services/productor.service';
import { ActivatedRoute } from '@angular/router';
import { Productor } from '../models/productor';

@Component({
  selector: 'app-productor-detalle',
  templateUrl: './productor-detalle.component.html',
  styleUrls: ['./productor-detalle.component.css']
})
export class ProductorDetalleComponent implements OnInit {
  productor: Productor;
  productorId;
  constructor(private route: ActivatedRoute, private productorService: ProductorService) {
    this.productorId = route.snapshot.params['id'];
    console.log('productorId', this.productorId);
    if(!this.productorId){
      //redireccionar al listado
    }
  }

  ngOnInit() {
    this.productor = new Productor();
    this.get();
  }

  get(){
    this.productorService.detalle(this.productorId).subscribe(result => {
      this.productor = result;
      console.log('productor', this.productor);
    });
  }

}
