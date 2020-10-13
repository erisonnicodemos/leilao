import { Component } from '@angular/core';
import { Leilao } from '../models/leilao';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html'
})
export class DetalhesComponent {

  leilao: Leilao;

  constructor(private route: ActivatedRoute) {

    this.leilao = this.route.snapshot.data['leilao'];
  }

}
