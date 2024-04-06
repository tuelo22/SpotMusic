import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MusicasService } from '../services/musicas.service';
import { Musica } from '../model/Album';
import { UsuarioService } from '../services/usuario.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-favoritos',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatCardModule, MatButtonModule, FormsModule, ReactiveFormsModule, CommonModule,
    MatListModule, MatCheckboxModule],
  templateUrl: './favoritos.component.html',
  styleUrl: './favoritos.component.css'
})
export class FavoritosComponent implements OnInit {

  musicas !: Musica[];
  constructor(private musicasService: MusicasService, private usuarioService: UsuarioService, private _snackBar: MatSnackBar) {

  }
  ngOnInit(): void {
    this.buscaMusicas();
  }

  private buscaMusicas() {
    var idusuario = this.usuarioService.GetIdUsuario();
    if (idusuario != null) {
      this.musicasService.getMusicasFavoritas(idusuario as String).subscribe(response => {
        this.musicas = response;
      });
    }
  }

  public onSelectionChange(event: any) {
    this.adicionarFavoritos(event.source.value);
    this.buscaMusicas();
  }

  public adicionarFavoritos(musicaId: String) {
    var idusuario = this.usuarioService.GetIdUsuario();

    if (idusuario != null) {
      this.musicasService.AdicionarFavorito(musicaId, idusuario as String).subscribe(
        {
          next: (response) => {
            let snackBarRef = this._snackBar.open('Favoritos alterado com sucesso !', 'Fechar');
          },
          error: (e) => {
            if (e.error) {
              let snackBarRef = this._snackBar.open(`Erro ao alterar favoritos. ${e.error.error}`, 'Fechar');
            }
          }
        });
    }
  }

}
