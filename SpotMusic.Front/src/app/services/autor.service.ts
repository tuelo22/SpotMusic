import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Autor } from '../model/Autor';
import { Observable } from 'rxjs';
import { urlback } from './urlback';
import { Album } from '../model/Album';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  constructor(private httpClient: HttpClient) { }

  public getAutores(): Observable<Autor[]> {
    return this.httpClient.get<Autor[]>(`${urlback}/api/Autor`);
  }

  public getAlbuns(IdUsuario: String, Idautor: String): Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${urlback}/api/Autor/${IdUsuario}/albums/${Idautor}`);
  }

  public getAutor(autor: String): Observable<Autor> {
    return this.httpClient.get<Autor>(`${urlback}/api/Autor/${autor}`);
  }
}
