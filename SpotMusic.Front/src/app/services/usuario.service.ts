import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/Usuario';
import { urlback } from './urlback';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }
  decodeToken: any;

  private url = "https://localhost:7184/connect/token"

  public autenticar(email: string, senha: string): Observable<Usuario> {
    let body = new URLSearchParams();
    body.set("username", email);
    body.set("password", senha);
    body.set("client_id", "client-angular-spotmusic");
    body.set("client_secret", "SpotMusicScope");
    body.set("grant_type", "password");
    body.set("scope", "SpotMusicScope");

    let options = {
      headers: new HttpHeaders().set("Content-Type", "application/x-www-form-urlencoded")
    }

    return this.http.post(`${this.url}`, body.toString(), options);
  }

  public IniciaSessao(response: any) {
    this.decodeToken = jwtDecode(response.access_token);

    sessionStorage.setItem("user", this.decodeToken.id);
    sessionStorage.setItem("access_token", response.access_token);
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
    sessionStorage.removeItem('access_token');
  }

  public GetToken(): String | null {
    return sessionStorage.getItem('access_token')
  }

  public GetIdUsuario(): String | null {
    return sessionStorage.getItem('user')
  }
}
