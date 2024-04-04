import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { InterpreteService } from '../services/interprete.service';
import { Interprete } from '../model/Interprete';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  interpretes = null;

  constructor(private interpreteService: InterpreteService) {
  }
  ngOnInit(): void {
    this.interpreteService.getInterprete().subscribe(response => {
      this.interpretes = response as any;
    });
  }
}
