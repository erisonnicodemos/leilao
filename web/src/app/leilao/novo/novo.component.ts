import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { LeilaoService } from '../services/leilao.service';
import { CurrencyUtils } from 'src/app/utils/currency-utils';
import { LeilaoBaseComponent } from '../leilao-form.base.component';
import { LocalStorageUtils } from 'src/app/utils/localstorage';


@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html'
})
export class NovoComponent extends LeilaoBaseComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private fb: FormBuilder,
    private LeilaoService: LeilaoService,
    private router: Router,
    private toastr: ToastrService) { super(); }
  localStorageUtils = new LocalStorageUtils();
  user: any;
  id: string = "";


  ngOnInit(): void {
    this.LeilaoForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      valorInicial: ['', [Validators.required]],
      condicao: ['', [Validators.required]],
      dataAbetura: ['', [Validators.required]],
      dataFinalizacao: ['', [Validators.required]],
      ativo: [0]
    });

  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  adicionarLeilao() {
    if (this.LeilaoForm.dirty && this.LeilaoForm.valid) {
      this.leilao = Object.assign({}, this.leilao, this.LeilaoForm.value);

      this.leilao.valorInicial = CurrencyUtils.StringParaDecimal(this.leilao.valorInicial);

      this.user = this.localStorageUtils.obterUsuario();
      this.leilao.userId = this.user.id;
      
      this.LeilaoService.novoLeilao(this.leilao)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.LeilaoForm.reset();
    this.errors = [];

    this.toastr.success('Leilão cadastrado com sucesso!', 'Sucesso!');
    this.router.navigate(['/leiloes/listar-todos']);
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}

