import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Interprete } from '../model/Interprete';

@Injectable({
  providedIn: 'root'
})
export class InterpreteService {

  constructor(private httpClient: HttpClient) { }

  public getInterprete(): Observable<Interprete[]> {
    return this.httpClient.get<Interprete[]>("url");
  }
}
