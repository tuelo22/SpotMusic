export class Usuario {
  id?: String;
  nome?: String;
  senha?: String;
  email?: String;
  telefone?: String;
  dataNascimento?: Date;
  planoId?: String;
  cartao?: Cartao;
}

export class Cartao {
  id?: String;
  numero?: String;
  cVV?: String;
  estado?: String;
  cidade?: String;
  rua?: String;
  numeroEndereco?: String;
  cEP?: String;
  complemento?: String;
}
