import { Component, OnInit } from '@angular/core';
import { InsumoExterno } from '../models/insumo-externo';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InsumoInterno } from '../models/insumo-interno';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InsumoExternoService } from 'src/app/services/insumo-externo.service';
import { InsumoInternoService } from 'src/app/services/insumo-interno.service';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-productor-fertilizacion-nutricion',
  templateUrl: './productor-fertilizacion-nutricion.component.html',
  styleUrls: ['./productor-fertilizacion-nutricion.component.css']
})
export class ProductorFertilizacionNutricionComponent implements OnInit {

  //INSUMO EXTERNO
  insumoExterno: InsumoExterno;
  insumoExternoId;
  insumoExternos: InsumoExterno[];
  formGroupExterno: FormGroup;

  //INSUMO INTERNO
  insumoInterno: InsumoInterno;
  insumoInternoId;
  insumoInternos: InsumoInterno[];
  formGroupInterno: FormGroup;

  productorId;

  constructor(
    private route: ActivatedRoute, 
    private insumoExternoService: InsumoExternoService, 
    private insumoInternoService: InsumoInternoService, 
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.productorId = this.route.snapshot.params['id'];
    console.log('productorId', this.productorId);
    this.buildFormExterno();
    this.buildFormInterno();
    
    this.getExterno();
    this.getInterno();
  }
  
  //INSUMO EXTERNO
  private buildFormExterno() {
    this.limpiarCamposExterno();
    this.formGroupExterno = this.formBuilder.group({
      nombre: [this.insumoExterno.nombre, Validators.required],
      fabricante: [this.insumoExterno.fabricante, Validators.required],
      registroICA: [this.insumoExterno.registroICA, Validators.required],
      composicion: [this.insumoExterno.composicion, Validators.required],
      dosis: [this.insumoExterno.dosis, Validators.required],
      cantidad: [this.insumoExterno.cantidad, Validators.required],
      fechaAplicacion: [this.insumoExterno.fechaAplicacion, Validators.required],
      lugarAplicacion: [this.insumoExterno.lugarAplicacion, Validators.required],
    });
  }    

  get controlExterno() { 
    return this.formGroupExterno.controls;
  }

  onSubmitExterno() {
    if (this.formGroupExterno.invalid) {
      return;
    }
    this.addExterno();
  }

  addExterno(){
    this.insumoExterno.nombre = this.formGroupExterno.value.nombre;
    this.insumoExterno.fabricante = this.formGroupExterno.value.fabricante;
    this.insumoExterno.registroICA = this.formGroupExterno.value.registroICA;
    this.insumoExterno.composicion = this.formGroupExterno.value.composicion;
    this.insumoExterno.dosis = this.formGroupExterno.value.dosis;
    this.insumoExterno.cantidad = this.formGroupExterno.value.cantidad;
    this.insumoExterno.fechaAplicacion = this.formGroupExterno.value.fechaAplicacion;
    this.insumoExterno.lugarAplicacion = this.formGroupExterno.value.lugarAplicacion;

    this.insumoExterno.productorId = Number(this.productorId);
    if(this.insumoExternoId > 0){
      this.putExterno();
    }else{
      this.insumoExternoService.post(this.insumoExterno).subscribe(p => {
        if (p) {
          this.limpiarCamposExterno();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Registro realizado con exito!';
          this.getExterno();
          this.buildFormExterno();
        }        
      });
    }
  }

  putExterno(){
    this.insumoExternoService.put(this.insumoExternoId,this.insumoExterno).subscribe(p => {
      if (p) {
        this.limpiarCamposExterno();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';        
        this.buildFormExterno();
        this.getExterno();
      }      
    });
  }

  getExterno(){
    this.insumoExternoService.get(this.productorId).subscribe(result => {      
      this.insumoExternos = result;
    });
  }

  editarExterno(index){
    this.insumoExterno.nombre = this.insumoExternos[index].nombre;
    this.insumoExterno.fabricante = this.insumoExternos[index].fabricante;
    this.insumoExterno.registroICA = this.insumoExternos[index].registroICA;
    this.insumoExterno.composicion = this.insumoExternos[index].composicion;
    this.insumoExterno.dosis = this.insumoExternos[index].dosis;
    this.insumoExterno.cantidad = this.insumoExternos[index].cantidad;
    this.insumoExterno.fechaAplicacion = this.insumoExternos[index].fechaAplicacion;
    this.insumoExterno.lugarAplicacion = this.insumoExternos[index].lugarAplicacion;

    this.insumoExternoId = this.insumoExternos[index].insumoExternoId;
  }

  limpiarCamposExterno(){
    this.insumoExterno = new InsumoExterno();
    this.insumoExternoId = 0;

    this.insumoExterno.nombre = '';
    this.insumoExterno.fabricante = '';
    this.insumoExterno.registroICA = '';
    this.insumoExterno.composicion = '';
    this.insumoExterno.dosis = '';
    this.insumoExterno.cantidad = '';
    this.insumoExterno.fechaAplicacion = ''; 
    this.insumoExterno.lugarAplicacion = '';  
  }

  //INSUMO INTERNO
  private buildFormInterno() {
    this.limpiarCamposInterno();
    this.formGroupInterno = this.formBuilder.group({
      nombre: [this.insumoInterno.nombre, Validators.required],
      materialesUsado: [this.insumoInterno.materialesUsado, Validators.required],
      procedimiento: [this.insumoInterno.procedimiento, Validators.required],
      tiempoPreparacion: [this.insumoInterno.tiempoPreparacion, Validators.required],
      metodoPreparacion: [this.insumoInterno.metodoPreparacion, Validators.required],
      dosis: [this.insumoInterno.dosis, Validators.required],
      cantidad: [this.insumoInterno.cantidad, Validators.required],
      fechaAplicacion: [this.insumoInterno.fechaAplicacion, Validators.required],
      lugarAplicacion: [this.insumoInterno.lugarAplicacion, Validators.required],
    });
  }    

  get controlInterno() { 
    return this.formGroupInterno.controls;
  }

  onSubmitInterno() {
    if (this.formGroupInterno.invalid) {
      return;
    }
    this.addInterno();
  }

  addInterno(){
    this.insumoInterno.nombre = this.formGroupInterno.value.nombre;
    this.insumoInterno.materialesUsado = this.formGroupInterno.value.materialesUsado;
    this.insumoInterno.procedimiento = ''+this.formGroupInterno.value.procedimiento;
    this.insumoInterno.tiempoPreparacion = this.formGroupInterno.value.tiempoPreparacion;
    this.insumoInterno.metodoPreparacion = this.formGroupInterno.value.metodoPreparacion;
    this.insumoInterno.dosis = this.formGroupInterno.value.dosis;
    this.insumoInterno.cantidad = this.formGroupInterno.value.cantidad;
    this.insumoInterno.fechaAplicacion = this.formGroupInterno.value.fechaAplicacion;
    this.insumoInterno.lugarAplicacion = this.formGroupInterno.value.lugarAplicacion;

    this.insumoInterno.productorId = Number(this.productorId);
    if(this.insumoInternoId > 0){
      this.putInterno();
    }else{
      this.insumoInternoService.post(this.insumoInterno).subscribe(p => {
        if (p) {
          this.limpiarCamposInterno();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Registro realizado con exito!';
          this.getInterno();
          this.buildFormInterno();
        }        
      });
    }
  }

  putInterno(){
    this.insumoInternoService.put(this.insumoInternoId,this.insumoInterno).subscribe(p => {
      if (p) {
        this.limpiarCamposInterno();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';        
        this.buildFormInterno();
        this.getInterno();
      }      
    });
  }

  getInterno(){
    this.insumoInternoService.get(this.productorId).subscribe(result => {      
      this.insumoInternos = result;
    });
  }

  editarInterno(index){
    this.insumoInterno.nombre = this.insumoInternos[index].nombre;
    this.insumoInterno.materialesUsado = this.insumoInternos[index].materialesUsado;
    this.insumoInterno.procedimiento = this.insumoInternos[index].procedimiento;
    this.insumoInterno.tiempoPreparacion = this.insumoInternos[index].tiempoPreparacion;
    this.insumoInterno.metodoPreparacion = this.insumoInternos[index].metodoPreparacion;
    this.insumoInterno.dosis = this.insumoInternos[index].dosis;
    this.insumoInterno.cantidad = this.insumoInternos[index].cantidad;
    this.insumoInterno.fechaAplicacion = this.insumoInternos[index].fechaAplicacion;
    this.insumoInterno.lugarAplicacion = this.insumoInternos[index].lugarAplicacion;

    this.insumoInternoId = this.insumoInternos[index].insumoInternoId;
  }

  limpiarCamposInterno(){
    this.insumoInterno = new InsumoInterno();
    this.insumoInternoId = 0;

    this.insumoInterno.nombre = '';
    this.insumoInterno.materialesUsado = '';
    this.insumoInterno.procedimiento = '';
    this.insumoInterno.tiempoPreparacion = '';
    this.insumoInterno.metodoPreparacion = '';
    this.insumoInterno.dosis = '';
    this.insumoInterno.cantidad = '';
    this.insumoInterno.fechaAplicacion = '';
    this.insumoInterno.lugarAplicacion = '';
  }

}
