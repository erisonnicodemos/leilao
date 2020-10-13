import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeilaoService } from '../services/leilao.service';

import { ToastrService } from 'ngx-toastr';

import { Leilao } from '../models/leilao';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html'
})
export class ExcluirComponent  {

  imagens: string = environment.imagensUrl;
  leilao: Leilao;

  constructor(private LeilaoService: LeilaoService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService) {

    this.leilao = this.route.snapshot.data['leilao'];
  }

  public excluirLeilao() {
    this.LeilaoService.excluirLeilao(this.leilao.id)
      .subscribe(
      evento => { this.sucessoExclusao(evento) },
      ()     => { this.falha() }
      );
  }

  public sucessoExclusao(evento: any) {

    const toast = this.toastr.success('Leilao excluido com Sucesso!', 'Good bye :D');
    this.router.navigate(['/leiloes/listar-todos']);
  
  }

  public falha() {
    this.toastr.error('Houve um erro no processamento!', 'Ops! :(');
  }
}

