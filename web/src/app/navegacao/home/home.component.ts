import { Component } from '@angular/core';
import { Leilao } from 'src/app/leilao/models/leilao';
import { LeilaoService } from '../../leilao/services/leilao.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
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
