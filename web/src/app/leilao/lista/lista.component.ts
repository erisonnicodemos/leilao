import { Component, OnInit } from '@angular/core';
import { Leilao } from '../models/leilao';
import { LeilaoService } from '../services/leilao.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public leiloes: Leilao[];
  errorMessage: string;

  constructor(private LeilaoService: LeilaoService) { }

  ngOnInit(): void {
    this.LeilaoService.obterTodos()
      .subscribe(
        leiloes => this.leiloes = leiloes,
        error => this.errorMessage);
  }
}
