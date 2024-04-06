import { Component, OnInit } from '@angular/core';
import { Autor } from '../model/Autor';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { AutorService } from '../services/autor.service';
import { Album, Musica } from '../model/Album';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { UsuarioService } from '../services/usuario.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MusicasService } from '../services/musicas.service';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-detail-autor',
  standalone: true,
  imports: [MatExpansionModule, CommonModule, MatCardModule, MatButtonModule, MatListModule, MatCheckboxModule],
  templateUrl: './detail-autor.component.html',
  styleUrl: './detail-autor.component.css'
})
export class DetailAutorComponent implements OnInit {

  idAutor = '';
  autor!: Autor;
  albuns!: Album[];

  constructor(private route: ActivatedRoute, private autorService: AutorService, private musicasService: MusicasService,
    private usuarioService: UsuarioService, private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    var idusuario = this.usuarioService.GetIdUsuario();

    if (idusuario != null) {
      this.idAutor = this.route.snapshot.params["id"];

      this.autorService.getAutor(this.idAutor).subscribe(response => {
        this.autor = response;
      });

      this.autorService.getAlbuns(idusuario as String, this.idAutor).subscribe(response => {
        this.albuns = response;
      });
    }
  }
  public voltar() {
    this.router.navigate([""])
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
