import { Component, OnInit } from '@angular/core';
import { Leilao } from '../models/leilao';
import { LeilaoService } from '../services/leilao.service';
import { environment } from 'src/environments/environment';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public leiloes: Leilao[];
  errorMessage: string;
  queryField = new FormControl();

  constructor(private LeilaoService: LeilaoService, private http: HttpClient) { }

  ngOnInit(): void {
    this.LeilaoService.obterTodos()
      .subscribe(
        leiloes => this.leiloes = leiloes,
        error => this.errorMessage);
  }

  onSearch() {
    let value = this.queryField.value;

    if (value && (value = value.trim()) !== '') {
      this.LeilaoService.ObterLeiloesPorNome(value)
        .subscribe(
          leiloes => this.leiloes = leiloes,
          error => this.errorMessage);
    }
  }
}
