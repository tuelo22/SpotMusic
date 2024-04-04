import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/Usuario';
import { urlback } from './urlback';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  public autenticar(email: String, senha: String): Observable<Usuario> {
    return this.http.post<Usuario>(`${urlback}/login`, {
      email: email,
      senha: senha
    });
  }

  public Cadastrar(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${urlback}/api/Usuario`, usuario);
  }

  public IsLogado(): Boolean {
    var user = sessionStorage.getItem('user');
    return user != null;
  }

  public logout() {
    sessionStorage.removeItem('user');
  }
}
