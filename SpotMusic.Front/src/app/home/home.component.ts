import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { InterpreteService } from '../services/interprete.service';
import { Interprete } from '../model/Interprete';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";
import { Autor } from '../model/Autor';
import { AutorService } from '../services/autor.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  Autores: Autor[] = [];

  constructor(private autorService: AutorService, private router: Router) { }

  ngOnInit(): void {
    this.autorService.getAutores().subscribe(response => {
      this.Autores = response;
    });
  }

  public goToDetail(item: Autor) {
    this.router.navigate(["detail", item.id]);
  }
}
