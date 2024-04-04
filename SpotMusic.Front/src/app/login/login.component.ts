import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { UsuarioService } from '../services/usuario.service';
import { Router } from '@angular/router';
import { Usuario } from '../model/Usuario';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatCardModule, MatButtonModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Usuario;

  constructor(private usuarioService: UsuarioService, private router: Router, private _snackBar: MatSnackBar) { }
  ngOnInit(): void {
    if(this.usuarioService.IsLogado()){
      this.router.navigate(["/home"]);
    }
  }

  public login() {
    if (this.email.invalid || this.senha.invalid) {
      let snackBarRef = this._snackBar.open('Dados invalidos, por favor verificar.', 'Fechar');
      return;
    }

    let emailValue = this.email.getRawValue() as String;
    let senhaValue = this.senha.getRawValue() as String;

    this.usuarioService.autenticar(emailValue, senhaValue).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          sessionStorage.setItem("user", JSON.stringify(this.usuario));
          this.router.navigate(["/home"]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });
  }

  public Cadastrar() {
    this.router.navigate(["/novousuario"]);
  }
}
