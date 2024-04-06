import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';
import { UsuarioService } from './services/usuario.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatButtonModule, MatIconModule, MatGridListModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'SpotMusic';
  exibeTitulo: Boolean = false;
  constructor(private usuarioService: UsuarioService, private router: Router) {
  }
  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.exibeTitulo = this.usuarioService.IsLogado();
      }
    });
  }

  public sair() {
    this.exibeTitulo = false;
    this.usuarioService.logout();
    this.router.navigate([""]);
  }

  public home() {
    this.router.navigate(["/home"]);
  }

  public favoritos() {
    this.router.navigate(["/favoritos"]);
  }

  public buscar() {
    this.router.navigate(["/buscar"]);
  }
}
