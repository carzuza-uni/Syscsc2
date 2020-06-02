import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { UsuarioConsultaComponent } from './syscsc/usuario-consulta/usuario-consulta.component';
import { UsuarioRegistroComponent } from './syscsc/usuario-registro/usuario-registro.component';
import { ProductorConsultaComponent } from './syscsc/productor-consulta/productor-consulta.component';
import { FormatoAuditoriaConsultaComponent } from './syscsc/formato-auditoria-consulta/formato-auditoria-consulta.component';
import { MateriaPrimaConsultaComponent } from './syscsc/materia-prima-consulta/materia-prima-consulta.component';
import { FichaDiagnosticoConsultaComponent } from './syscsc/ficha-diagnostico-consulta/ficha-diagnostico-consulta.component';
import { FichaAuditoriaRegistroComponent } from './syscsc/ficha-auditoria-registro/ficha-auditoria-registro.component';
import { ProductorDetalleComponent } from './syscsc/productor-detalle/productor-detalle.component';
import { ProductorProducccionPecuariaAgricolaComponent } from './syscsc/productor-producccion-pecuaria-agricola/productor-producccion-pecuaria-agricola.component';
import { ProductorFertilizacionNutricionComponent } from './syscsc/productor-fertilizacion-nutricion/productor-fertilizacion-nutricion.component';
import { ProductorAgroclimaticaComponent } from './syscsc/productor-agroclimatica/productor-agroclimatica.component';
import { ProductorDatosFamiliaComponent } from './syscsc/productor-datos-familia/productor-datos-familia.component';
import { ProductorRegistroComponent } from './syscsc/productor-registro/productor-registro.component';
import { CultivoConsultaComponent } from './syscsc/cultivo-consulta/cultivo-consulta.component';
import { CategoriaFAIConsultaComponent } from './syscsc/categoria-faiconsulta/categoria-faiconsulta.component';
import { ItemFAIRegistroComponent } from './syscsc/item-fairegistro/item-fairegistro.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './services/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
      path: 'personaConsulta',
      component: PersonaConsultaComponent
  },
  {
      path: 'personaRegistro',
      component: PersonaRegistroComponent
  },
  {
      path: 'usuarioConsulta',
      component: UsuarioConsultaComponent,
      canActivate: [AuthGuard]
  },
  {
    path: 'usuarioRegistro',
    component: UsuarioRegistroComponent
  },
  {
      path: 'usuarioEditar/:id',
      component: UsuarioRegistroComponent
  },
  {
    path: 'usuarioDetalle/:id',
    component: UsuarioRegistroComponent
  },
  {
      path: 'productorConsulta',
      component: ProductorConsultaComponent
  },
  {
      path: 'productorRegistro',
      component: ProductorRegistroComponent
  },
  {
      path: 'productorEditar/:id',
      component: ProductorRegistroComponent
  },
  {
      path: 'productorDetalle/:id',
      component: ProductorRegistroComponent
  },
  {
      path: 'productorDatosFamilia/:id',
      component: ProductorDatosFamiliaComponent
  },
  {
      path: 'productorAgroclimatica/:id',
      component: ProductorAgroclimaticaComponent
  },
  {
      path: 'productorFertilizacionNutricion/:id',
      component: ProductorFertilizacionNutricionComponent
  },
  {
      path: 'productorProduccionPecuariaAgricola/:id',
      component: ProductorProducccionPecuariaAgricolaComponent
  },
  {
      path: 'formatoAuditoriaConsulta',
      component: FormatoAuditoriaConsultaComponent
  },
  {
      path: 'materiaPrimaConsulta',
      component: MateriaPrimaConsultaComponent
  },
  {
      path: 'fichaDiagnosticoConsulta',
      component: FichaDiagnosticoConsultaComponent
  },
  {
      path: 'fichaAuditoriaRegistro',
      component: FichaAuditoriaRegistroComponent
  },
  {
      path: 'cultivoConsulta',
      component: CultivoConsultaComponent
  },
  {
      path: 'categoriaFAIConsulta',
      component: CategoriaFAIConsultaComponent
  },
  {
      path: 'itemFAIRegistro',
      component: ItemFAIRegistroComponent
  },

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
