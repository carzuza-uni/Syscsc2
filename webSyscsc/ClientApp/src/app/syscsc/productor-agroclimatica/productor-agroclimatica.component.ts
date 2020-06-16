import { Component, OnInit } from '@angular/core';
import { Agroclimatica } from '../models/agroclimatica';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AgroclimaticaService } from 'src/app/services/agroclimatica.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { UsoSuelo } from '../models/uso-suelo';
import { ManejoCultivo } from '../models/manejo-cultivo';
import { UsoSueloService } from 'src/app/services/uso-suelo.service';
import { ManejoCultivoService } from 'src/app/services/manejo-cultivo.service';

@Component({
  selector: 'app-productor-agroclimatica',
  templateUrl: './productor-agroclimatica.component.html',
  styleUrls: ['./productor-agroclimatica.component.css']
})
export class ProductorAgroclimaticaComponent implements OnInit {
  //AGROCLIMATICA
  agroclimatica: Agroclimatica;
  agroclimaticaId;
  productorId;
  formGroup: FormGroup;

  //USO SUELO
  usoSuelo: UsoSuelo;
  usoSueloId;
  usoSuelos: UsoSuelo[];
  formGroupUso: FormGroup;

  //MANEJO CULTIVO
  manejoCultivo: ManejoCultivo;
  manejoCultivoId;
  manejoCultivos: ManejoCultivo[];
  formGroupManejo: FormGroup;

  constructor(
    private route: ActivatedRoute, 
    private agroclimaticaService: AgroclimaticaService, 
    private usoSueloService: UsoSueloService, 
    private manejoCultivoService: ManejoCultivoService, 
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.productorId = this.route.snapshot.params['id'];
    console.log('productorId', this.productorId);
    this.buildForm(); 
    this.buildFormUso();   
    this.buildFormManejo();
    this.get();
  }
  //AGROCLIMATICA
  private buildForm() {
    this.limpiarCampos();
    this.formGroup = this.formBuilder.group({
      latitud: [this.agroclimatica.latitud, Validators.required],
      norteLongitud: [this.agroclimatica.norteLongitud, Validators.required],
      este: [this.agroclimatica.este, Validators.required],
      msnm: [this.agroclimatica.msnm, Validators.required],
      analisisSuelo: [this.agroclimatica.analisisSuelo, Validators.required],
      fechaRealizacion: [this.agroclimatica.fechaRealizacion, Validators.required],
      planFertilizacion: [this.agroclimatica.planFertilizacion, Validators.required],
      tipoTextura: [this.agroclimatica.tipoTextura, Validators.required],
      preparacionAbono: [this.agroclimatica.preparacionAbono, Validators.required],
      tipo: [this.agroclimatica.tipo, Validators.required],
      estado: [this.agroclimatica.estado, Validators.required],
      observaciones: [this.agroclimatica.observaciones, Validators.required],
    });
  }    

  get control() { 
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.agroclimatica.latitud = this.formGroup.value.latitud;
    this.agroclimatica.norteLongitud = this.formGroup.value.norteLongitud;
    this.agroclimatica.este = this.formGroup.value.este;
    this.agroclimatica.msnm = this.formGroup.value.msnm;
    this.agroclimatica.analisisSuelo = this.formGroup.value.analisisSuelo;
    this.agroclimatica.fechaRealizacion = this.formGroup.value.fechaRealizacion;
    this.agroclimatica.planFertilizacion = this.formGroup.value.planFertilizacion;
    this.agroclimatica.tipoTextura = this.formGroup.value.tipoTextura;
    this.agroclimatica.preparacionAbono = this.formGroup.value.preparacionAbono;
    this.agroclimatica.tipo = this.formGroup.value.tipo;
    this.agroclimatica.estado = this.formGroup.value.estado;
    this.agroclimatica.observaciones = this.formGroup.value.observaciones;

    this.agroclimatica.productorId = Number(this.productorId);
    if(this.agroclimaticaId > 0){
      this.put();
    }else{
      this.agroclimaticaService.post(this.agroclimatica).subscribe(p => {
        if (p) {
          this.limpiarCampos();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Registro realizado con exito!';
          this.get();
          this.buildForm();
        }        
      });
    }
  }

  put(){
    this.agroclimaticaService.put(this.agroclimaticaId,this.agroclimatica).subscribe(p => {
      if (p) {
        this.limpiarCampos();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';        
        this.buildForm();
        this.get();
      }      
    });
  }

  get(){
    this.agroclimaticaService.get(this.productorId).subscribe(result => {
      if(result){
        this.agroclimatica = result;
        this.agroclimaticaId = this.agroclimatica.agroclimaticaId;
        //LISTAR
        this.getUso();
        this.getManejo();
      }      
    });
  }

  limpiarCampos(){
    this.agroclimatica = new Agroclimatica();
    
    this.agroclimatica.latitud = '';
    this.agroclimatica.norteLongitud = '';
    this.agroclimatica.este = '';
    this.agroclimatica.msnm = '';
    this.agroclimatica.analisisSuelo = '';
    this.agroclimatica.fechaRealizacion = '';
    this.agroclimatica.planFertilizacion = '';
    this.agroclimatica.tipoTextura = '';
    this.agroclimatica.preparacionAbono = '';
    this.agroclimatica.tipo = '';
    this.agroclimatica.estado = '';
    this.agroclimatica.observaciones = '';
    
  }

  //USO SUELOS
  private buildFormUso() {
    this.limpiarCamposUso();
    this.formGroupUso = this.formBuilder.group({
      lote: [this.usoSuelo.lote, Validators.required],
      area: [this.usoSuelo.area, Validators.required],
      usos: [this.usoSuelo.usos, Validators.required],
      sombrio: [this.usoSuelo.sombrio, Validators.required],
      planteadoProximoAno: [this.usoSuelo.planteadoProximoAno, Validators.required],
      pendiente: [this.usoSuelo.pendiente, Validators.required],
      presentaErosion: [this.usoSuelo.presentaErosion, Validators.required],
    });
  }    

  get controlUso() { 
    return this.formGroupUso.controls;
  }

  onSubmitUso() {
    if (this.formGroupUso.invalid) {
      return;
    }
    this.addUso();
  }

  addUso(){
    this.usoSuelo.lote = this.formGroupUso.value.lote;
    this.usoSuelo.area = Number(this.formGroupUso.value.area);
    this.usoSuelo.usos = this.formGroupUso.value.usos;
    this.usoSuelo.sombrio = this.formGroupUso.value.sombrio;
    this.usoSuelo.planteadoProximoAno = this.formGroupUso.value.planteadoProximoAno;
    this.usoSuelo.pendiente = this.formGroupUso.value.pendiente;
    this.usoSuelo.presentaErosion = this.formGroupUso.value.presentaErosion;

    this.usoSuelo.agroclimaticaId = Number(this.agroclimaticaId);
    if(this.usoSueloId > 0){
      this.putUso();
    }else{
      this.usoSueloService.post(this.usoSuelo).subscribe(p => {
        if (p) {
          this.limpiarCamposUso();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Registro realizado con exito!';
          this.getUso();
          this.buildFormUso();
        }        
      });
    }
  }

  putUso(){
    this.usoSueloService.put(this.usoSueloId,this.usoSuelo).subscribe(p => {
      if (p) {
        this.limpiarCamposUso();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';        
        this.buildFormUso();
        this.getUso();
      }      
    });
  }

  getUso(){
    this.usoSueloService.get(this.agroclimaticaId).subscribe(result => {      
      this.usoSuelos = result;
    });
  }

  editarUso(index){
    this.usoSuelo.lote = this.usoSuelos[index].lote;
    this.usoSuelo.area = this.usoSuelos[index].area;
    this.usoSuelo.usos = this.usoSuelos[index].usos;
    this.usoSuelo.sombrio = this.usoSuelos[index].sombrio;
    this.usoSuelo.planteadoProximoAno = this.usoSuelos[index].planteadoProximoAno;
    this.usoSuelo.pendiente = this.usoSuelos[index].pendiente;
    this.usoSuelo.presentaErosion = this.usoSuelos[index].presentaErosion;

    this.usoSueloId = this.usoSuelos[index].usoSueloId;
  }

  limpiarCamposUso(){
    this.usoSuelo = new UsoSuelo();
    this.usoSueloId = 0;

    this.usoSuelo.lote = '';
    this.usoSuelo.area = 0;
    this.usoSuelo.usos = '';
    this.usoSuelo.sombrio = '';
    this.usoSuelo.planteadoProximoAno = '';
    this.usoSuelo.pendiente = '';
    this.usoSuelo.presentaErosion = '';  
  }

  //MANEJO CULTIVOS
  private buildFormManejo() {
    this.limpiarCamposManejo();
    this.formGroupManejo = this.formBuilder.group({
      lote: [this.manejoCultivo.lote, Validators.required],
      variedad: [this.manejoCultivo.variedad, Validators.required],
      numeroArboles: [this.manejoCultivo.numeroArboles, Validators.required],
      sistemaRenovacion: [this.manejoCultivo.sistemaRenovacion, Validators.required],
      fechaSiembra: [this.manejoCultivo.fechaSiembra, Validators.required],
      distanciaSiembra: [this.manejoCultivo.distanciaSiembra, Validators.required],
    });
  }    

  get controlManejo() { 
    return this.formGroupManejo.controls;
  }

  onSubmitManejo() {
    if (this.formGroupManejo.invalid) {
      return;
    }
    this.addManejo();
  }

  addManejo(){
    this.manejoCultivo.lote = this.formGroupManejo.value.lote;
    this.manejoCultivo.variedad = this.formGroupManejo.value.variedad;
    this.manejoCultivo.numeroArboles = ''+this.formGroupManejo.value.numeroArboles;
    this.manejoCultivo.sistemaRenovacion = this.formGroupManejo.value.sistemaRenovacion;
    this.manejoCultivo.fechaSiembra = this.formGroupManejo.value.fechaSiembra;
    this.manejoCultivo.distanciaSiembra = this.formGroupManejo.value.distanciaSiembra;

    this.manejoCultivo.agroclimaticaId = Number(this.agroclimaticaId);
    if(this.manejoCultivoId > 0){
      this.putManejo();
    }else{
      this.manejoCultivoService.post(this.manejoCultivo).subscribe(p => {
        if (p) {
          this.limpiarCamposManejo();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Registro realizado con exito!';
          this.getManejo();
          this.buildFormManejo();
        }        
      });
    }
  }

  putManejo(){
    this.manejoCultivoService.put(this.manejoCultivoId,this.manejoCultivo).subscribe(p => {
      if (p) {
        this.limpiarCamposManejo();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';        
        this.buildFormManejo();
        this.getManejo();
      }      
    });
  }

  getManejo(){
    this.manejoCultivoService.get(this.agroclimaticaId).subscribe(result => {      
      this.manejoCultivos = result;
    });
  }

  editarManejo(index){
    this.manejoCultivo.lote = this.manejoCultivos[index].lote;
    this.manejoCultivo.variedad = this.manejoCultivos[index].variedad;
    this.manejoCultivo.numeroArboles = this.manejoCultivos[index].numeroArboles;
    this.manejoCultivo.sistemaRenovacion = this.manejoCultivos[index].sistemaRenovacion;
    this.manejoCultivo.fechaSiembra = this.manejoCultivos[index].fechaSiembra;
    this.manejoCultivo.distanciaSiembra = this.manejoCultivos[index].distanciaSiembra;

    this.manejoCultivoId = this.manejoCultivos[index].manejoCultivoId;
  }

  limpiarCamposManejo(){
    this.manejoCultivo = new ManejoCultivo();
    this.manejoCultivoId = 0;

    this.manejoCultivo.lote = '';
    this.manejoCultivo.variedad = '';
    this.manejoCultivo.numeroArboles = '';
    this.manejoCultivo.sistemaRenovacion = '';
    this.manejoCultivo.fechaSiembra = '';
    this.manejoCultivo.distanciaSiembra = '';
  }

}
