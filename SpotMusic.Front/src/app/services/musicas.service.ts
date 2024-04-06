import { Injectable } from '@angular/core';
import { Musica } from '../model/Album';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { urlback } from './urlback';

@Injectable({
  providedIn: 'root'
})
export class MusicasService {

  constructor(private httpClient: HttpClient) { }

  public getMusicas(IdUsuario: String, texto: String): Observable<Musica[]> {
    return this.httpClient.get<Musica[]>(`${urlback}/api/musica/${IdUsuario}/buscar/${texto}`);
  }

  public AdicionarFavorito(musicaId: String, usuarioId: String): Observable<Musica> {
    return this.httpClient.post<Musica>(`${urlback}/api/musica/adicionarfavorito`, {
      musicaId: musicaId,
      usuarioId: usuarioId
    });
  }

  public getMusicasFavoritas(IdUsuario: String): Observable<Musica[]> {
    return this.httpClient.get<Musica[]>(`${urlback}/api/musica/${IdUsuario}/favoritas`);
  }
}
