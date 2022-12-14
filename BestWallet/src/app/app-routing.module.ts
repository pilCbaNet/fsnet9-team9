import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { MovimientosComponent } from './pages/movimientos/movimientos.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { DepositoComponent } from './pages/deposito/deposito.component';
import { RetiroComponent } from './pages/retiro/retiro.component';
import { LoguearseComponent } from './pages/loguearse/loguearse.component';

const routes: Routes = [
  {path: 'home', component: LandingComponent },
  {path: 'movimientos', component: MovimientosComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full' },
  {path: 'registro', component: RegistroComponent},
  {path: 'deposito', component: DepositoComponent},
  {path: 'retiro', component: RetiroComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
