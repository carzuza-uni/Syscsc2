import { Component, OnInit } from '@angular/core';
import { DatosFamilia } from '../models/datos-familia';
import { ActivatedRoute } from '@angular/router';
import { DatosFamiliaService } from 'src/app/services/datos-familia.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-productor-datos-familia',
  templateUrl: './productor-datos-familia.component.html',
  styleUrls: ['./productor-datos-familia.component.css']
})
export class ProductorDatosFamiliaComponent implements OnInit {
  datosFamilias: DatosFamilia[];
  datosFamilia: DatosFamilia;
  identificacion;
  productorId;
  formGroup: FormGroup;
  identificacionForm;
  constructor(
    private route: ActivatedRoute, 
    private datosFamiliaService: DatosFamiliaService, 
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  ) { 
    
  }

  ngOnInit() {
    this.productorId = this.route.snapshot.params['id'];
    console.log('productorId', this.productorId);
    this.buildForm();
    
    this.get();
  }

  private buildForm() {
    this.limpiarCampos();
    this.formGroup = this.formBuilder.group({
      identificacion: [this.identificacionForm, [Validators.required, Validators.min(1)]],
      nombre: [this.datosFamilia.nombre, Validators.required],
      fechaNacimiento: [this.datosFamilia.fechaNacimiento, Validators.required],
      parentesco: [this.datosFamilia.parentesco, Validators.required],
      tipoPoblacion: [this.datosFamilia.tipoPoblacion, Validators.required],
      afilicionSalud: [this.datosFamilia.afilicionSalud, Validators.required],
      nivelEducativo: [this.datosFamilia.nivelEducativo, Validators.required],
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

  editar(index){
    this.datosFamilia.identificacion = this.datosFamilias[index].identificacion;
    this.datosFamilia.nombre = this.datosFamilias[index].nombre;
    this.datosFamilia.fechaNacimiento = this.datosFamilias[index].fechaNacimiento;
    this.datosFamilia.parentesco = this.datosFamilias[index].parentesco;
    this.datosFamilia.tipoPoblacion = this.datosFamilias[index].tipoPoblacion;
    this.datosFamilia.afilicionSalud = this.datosFamilias[index].afilicionSalud;
    this.datosFamilia.nivelEducativo = this.datosFamilias[index].nivelEducativo;

    this.identificacion = this.datosFamilias[index].identificacion;
  }

  add(){
    this.datosFamilia.identificacion = Number(this.formGroup.value.identificacion);
    this.datosFamilia.nombre = this.formGroup.value.nombre;
    this.datosFamilia.fechaNacimiento = this.formGroup.value.fechaNacimiento;
    this.datosFamilia.parentesco = this.formGroup.value.parentesco;
    this.datosFamilia.tipoPoblacion = this.formGroup.value.tipoPoblacion;
    this.datosFamilia.afilicionSalud = this.formGroup.value.afilicionSalud;
    this.datosFamilia.nivelEducativo = this.formGroup.value.nivelEducativo;

    this.datosFamilia.productorId = Number(this.productorId);
    if(this.identificacion > 0){
      this.put();
    }else{
      this.datosFamiliaService.post(this.datosFamilia).subscribe(p => {
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
    this.datosFamiliaService.put(this.identificacion,this.datosFamilia).subscribe(p => {
      if (p) {
        this.limpiarCampos();
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Actualización realizada con exito!';
        this.get();
        this.buildForm();
      }      
    });
  }

  get(){
    this.datosFamiliaService.get(this.productorId).subscribe(result => {
      this.datosFamilias = result;
    });
  }

  limpiarCampos(){
    this.datosFamilia = new DatosFamilia();
    
    this.identificacion = 0;
    this.identificacionForm = '';
    this.datosFamilia.identificacion = 0;
    this.datosFamilia.productorId = 0;
    this.datosFamilia.nombre = '';
    this.datosFamilia.fechaNacimiento = '';
    this.datosFamilia.parentesco = '';
    this.datosFamilia.tipoPoblacion = '';
    this.datosFamilia.afilicionSalud = '';
    this.datosFamilia.nivelEducativo = '';
  }
}
