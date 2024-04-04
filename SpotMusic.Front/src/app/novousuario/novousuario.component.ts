import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatListModule, MatSelectionList } from '@angular/material/list';
import { Cartao, Usuario } from '../model/Usuario';
import { Plano } from '../model/Plano';
import { UsuarioService } from '../services/usuario.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { PlanoService } from '../services/plano.service';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';

@Component({
  selector: 'app-novousuario',
  standalone: true,
  imports: [NgxMaskDirective, NgxMaskPipe, MatFormFieldModule, MatInputModule, MatCardModule, MatButtonModule,
    FormsModule, ReactiveFormsModule, CommonModule, MatListModule],
  templateUrl: './novousuario.component.html',
  styleUrl: './novousuario.component.css'
})
export class NovousuarioComponent implements OnInit {
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  nome = new FormControl('', [Validators.required]);
  telefone = new FormControl('', [Validators.required])
  dataNascimento = new FormControl('', [Validators.required]);
  numeroCartao = new FormControl('', [Validators.required]);
  numeroCVV = new FormControl('', [Validators.required]);
  estado = new FormControl('', [Validators.required]);
  cidade = new FormControl('', [Validators.required]);
  rua = new FormControl('', [Validators.required]);
  numeroEndereco = new FormControl('', [Validators.required]);
  CEP = new FormControl('', [Validators.required]);
  complemento = new FormControl('');
  errorMessage = '';
  Planos: Plano[] = [];

  @ViewChild('tiposDePlano') tiposDePlano!: MatSelectionList;

  constructor(private usuarioService: UsuarioService, private planoService: PlanoService, private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    if (this.usuarioService.IsLogado()) {
      this.router.navigate(["/home"]);
    } else {
      this.planoService.getPlanos().subscribe(response => {
        this.Planos = response;
      });
    }
  }

  public voltar() {
    this.router.navigate([""]);
  }
  public limpar() {
    this.nome.reset();
    this.senha.reset();
    this.email.reset();
    this.telefone.reset();
    this.dataNascimento.reset();
    this.numeroCartao.reset();
    this.numeroCVV.reset();
    this.estado.reset();
    this.cidade.reset();
    this.rua.reset();
    this.numeroEndereco.reset();
    this.CEP.reset();
    this.complemento.reset();
  }
  public cadastrar() {
    if (this.nome.invalid || this.email.invalid || this.senha.invalid || this.telefone.invalid ||
      this.dataNascimento.invalid || this.numeroCartao.invalid || this.numeroCVV.invalid || this.estado.invalid ||
      this.cidade.invalid || this.rua.invalid || this.numeroEndereco.invalid || this.CEP.invalid || this.complemento.invalid) {
      let snackBarRef = this._snackBar.open('Dados invalidos, por favor verificar.', 'Fechar');
      return
    };

    let usuario: Usuario = new Usuario;
    usuario.nome = this.nome.getRawValue() as String;
    usuario.senha = this.senha.getRawValue() as String;
    usuario.email = this.email.getRawValue() as String;
    usuario.telefone = this.telefone.getRawValue() as String;
    usuario.dataNascimento = new Date(this.dataNascimento.getRawValue() as string);

    if (this.tiposDePlano.selectedOptions.selected.length > 0) {
      usuario.planoId = this.tiposDePlano.selectedOptions.selected[0].value as String;
    }

    let cartao: Cartao = new Cartao;
    cartao.numero = this.numeroCartao.getRawValue() as String;
    cartao.cVV = this.numeroCVV.getRawValue() as String;
    cartao.estado = this.estado.getRawValue() as String;
    cartao.cidade = this.cidade.getRawValue() as String;
    cartao.rua = this.rua.getRawValue() as String;
    cartao.numeroEndereco = this.numeroEndereco.getRawValue() as String;
    cartao.cEP = this.CEP.getRawValue() as String;
    cartao.complemento = this.complemento.getRawValue() as String;
    usuario.cartao = cartao;

    this.usuarioService.Cadastrar(usuario).subscribe(
      {
        next: () => {
          this.limpar();
          let snackBarRef = this._snackBar.open('Usuário cadastrado com sucesso!', 'Fechar');
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = 'Falha ao cadastrar cliente.' + e.message;
          }
        }
      });
  }
}
