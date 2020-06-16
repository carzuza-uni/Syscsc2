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
import { AuthAdminGuard } from './services/auth-admin.guard';

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
      canActivate: [AuthAdminGuard]
  },
  {
    path: 'usuarioRegistro',
    component: UsuarioRegistroComponent,
    canActivate: [AuthAdminGuard]
  },
  {
      path: 'usuarioEditar/:id',
      component: UsuarioRegistroComponent,
      canActivate: [AuthAdminGuard]
  },
  {
      path: 'usuarioDetalle/:id',
      component: UsuarioRegistroComponent,
      canActivate: [AuthAdminGuard]
  },
  {
      path: 'productorConsulta',
      component: ProductorConsultaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorRegistro',
      component: ProductorRegistroComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorEditar/:id',
      component: ProductorRegistroComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorDetalle/:id',
      component: ProductorRegistroComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorDatosFamilia/:id',
      component: ProductorDatosFamiliaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorAgroclimatica/:id',
      component: ProductorAgroclimaticaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorFertilizacionNutricion/:id',
      component: ProductorFertilizacionNutricionComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'productorProduccionPecuariaAgricola/:id',
      component: ProductorProducccionPecuariaAgricolaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'formatoAuditoriaConsulta',
      component: FormatoAuditoriaConsultaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'materiaPrimaConsulta',
      component: MateriaPrimaConsultaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'fichaDiagnosticoConsulta',
      component: FichaDiagnosticoConsultaComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'fichaAuditoriaRegistro',
      component: FichaAuditoriaRegistroComponent,
      canActivate: [AuthGuard]
  },
  {
      path: 'cultivoConsulta',
      component: CultivoConsultaComponent,
      canActivate: [AuthAdminGuard]
  },
  {
      path: 'categoriaFAIConsulta',
      component: CategoriaFAIConsultaComponent,
      canActivate: [AuthAdminGuard]
  },
  {
      path: 'itemFAIRegistro',
      component: ItemFAIRegistroComponent,
      canActivate: [AuthAdminGuard]
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
