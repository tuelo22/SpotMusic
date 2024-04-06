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

  public IniciaSessao(Usuario: Usuario) {
    sessionStorage.setItem('user', JSON.stringify(Usuario));
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

  public GetIdUsuario(): String | null {
    var user = sessionStorage.getItem('user');
    if (user != null) {
      const usuario: Usuario = JSON.parse(user);

      return usuario.id as string;
    }
    return null;
  }
}
