import { Component, OnInit } from '@angular/core';
import { Cultivo } from '../models/cultivo';
import { ActivatedRoute } from '@angular/router';
import { CultivoService } from 'src/app/services/cultivo.service';

@Component({
  selector: 'app-cultivo-consulta',
  templateUrl: './cultivo-consulta.component.html',
  styleUrls: ['./cultivo-consulta.component.css']
})
export class CultivoConsultaComponent implements OnInit {
  cultivo: Cultivo;
  cultivos: Cultivo[];
  id;
  constructor(private route: ActivatedRoute, private cultivoService: CultivoService) { }

  ngOnInit() {
    this.cultivo = new Cultivo();
    this.get();
  }

  editar(index){
    this.cultivo.nombre = this.cultivos[index].nombre;
    this.id = this.cultivos[index].cultivoId;
  }

  add(){
    if(!this.cultivo.nombre){
      alert('Debe completar el campo Nombre.');
      return false;
    }
    if(this.id){
      this.put();
    }else{
      this.cultivoService.post(this.cultivo).subscribe(p => {
        if (p) {
          this.cultivo.nombre = '';
          alert('Registro realizado con exito!');
        }
        this.get();
      });
    }
    
  }

  put(){
    if(!this.cultivo.nombre){
      alert('Debe completar el campo Nombre.');
      return false;
    }
    this.cultivoService.put(this.id,this.cultivo).subscribe(p => {
      if (!p) {
        this.cultivo.nombre = '';
        this.id = null;
        alert('Registro realizado con exito!');
      }
      this.get();
    });
  }

  get(){
    this.cultivoService.get().subscribe(result => {
      this.cultivos = result;
    });
  }

}
