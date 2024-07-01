import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioService } from '../services/usuario.service';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {
  constructor(private usuarioService: UsuarioService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Obtenha o token de autorização do sessionStorage
    const authToken = this.usuarioService.GetToken();

    // Clone a requisição e adicione o cabeçalho de autorização com o token
    if (authToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${authToken}`
        }
      });
    }

    // Envie a requisição com o cabeçalho modificado
    return next.handle(request);
  }
}