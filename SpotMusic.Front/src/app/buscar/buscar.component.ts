import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Musica } from '../model/Album';
import { MatListModule } from '@angular/material/list';
import { MusicasService } from '../services/musicas.service';
import { UsuarioService } from '../services/usuario.service';
import { MatCheckboxModule } from '@angular/material/checkbox';;

@Component({
  selector: 'app-buscar',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatCardModule, MatButtonModule, FormsModule, ReactiveFormsModule, CommonModule,
    MatListModule, MatCheckboxModule],
  templateUrl: './buscar.component.html',
  styleUrl: './buscar.component.css'
})
export class BuscarComponent {
  texto = new FormControl('', [Validators.required]);
  musicas !: Musica[] | null;
  constructor(private _snackBar: MatSnackBar, private musicasService: MusicasService, private usuarioService: UsuarioService) { }

  public Limpar() {
    if (this.musicas != null) {
      this.musicas = null;
      this.texto.reset();
    }
  }
  public buscar() {
    if (this.texto.invalid) {
      let snackBarRef = this._snackBar.open('Por favor informar um texto para buscar as musicas.', 'Fechar');
      return;
    }

    var idusuario = this.usuarioService.GetIdUsuario();
    if (idusuario != null) {
      this.musicasService.getMusicas(idusuario as String, this.texto.getRawValue() as String).subscribe(response => {
        this.musicas = response;

        if (this.musicas.length == 0) {
          let snackBarRef = this._snackBar.open('Não foram encontrados dados para a pesquisa.', 'Fechar');
        }
      });
    }
  }

  public onSelectionChange(event: any) {
    this.adicionarFavoritos(event.source.value);
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
