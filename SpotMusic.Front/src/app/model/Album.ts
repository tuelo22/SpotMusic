import { Autor } from "./Autor";
import { Interprete } from "./Interprete";

export interface Album {
  id?: string;
  nome?: string;
  capa?: string;
  idAutorPrincipal?: string,
  musicas?: Musica[];
}

export interface Musica {
  id?: string;
  nome?: string;
  letra?: string;
  idEstiloMusical?: string;
  nomeEstiloMusical?: string;
  favorito: boolean;
  autores: string;
}