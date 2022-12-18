import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './layout/nav/nav.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { LandingComponent } from './pages/landing/landing.component';
import { MovimientosComponent } from './pages/movimientos/movimientos.component';
import { RegistroComponent } from './pages/registro/registro.component';
import {HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { LoguearseComponent } from './pages/loguearse/loguearse.component';
import { DepositoComponent } from './pages/deposito/deposito.component';
import { RetiroComponent } from './pages/retiro/retiro.component';
import { TipoTransaccionPipe } from './pipes/tipo-transaccion.pipe';

const Routes: Routes = [
  { path: 'loguearse', component: LoguearseComponent },

]

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    FooterComponent,
    HeaderComponent,
    LandingComponent,
    MovimientosComponent,
    RegistroComponent,
    LoguearseComponent,
    DepositoComponent,
    RetiroComponent,
    TipoTransaccionPipe,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      Routes,  { enableTracing: true }
      )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
