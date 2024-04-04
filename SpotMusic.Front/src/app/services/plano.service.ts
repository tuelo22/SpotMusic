import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Plano } from '../model/Plano';
import { urlback } from './urlback';

@Injectable({
  providedIn: 'root'
})
export class PlanoService {

  constructor(private httpClient: HttpClient) { }

  public getPlanos(): Observable<Plano[]> {
    return this.httpClient.get<Plano[]>(`${urlback}/api/Usuario/ObterPlanos`);
  }
}
