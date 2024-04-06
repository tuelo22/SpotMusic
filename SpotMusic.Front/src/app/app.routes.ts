import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NovousuarioComponent } from './novousuario/novousuario.component';
import { AuthGuard } from './guards/auth.guard';
import { DetailAutorComponent } from './detail-autor/detail-autor.component';
import { BuscarComponent } from './buscar/buscar.component';
import { FavoritosComponent } from './favoritos/favoritos.component';

export const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'home',
    canActivate: [AuthGuard],
    component: HomeComponent
  },
  {
    path: 'novousuario',
    component: NovousuarioComponent,
  },
  {
    path: 'detail/:id',
    component: DetailAutorComponent
  },
  {
    path: 'buscar',
    component: BuscarComponent
  },
  {
    path: 'favoritos',
    component: FavoritosComponent
  }

];
