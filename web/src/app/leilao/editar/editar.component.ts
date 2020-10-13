import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { LeilaoService } from '../services/leilao.service';
import { environment } from 'src/environments/environment';
import { CurrencyUtils } from 'src/app/utils/currency-utils';
import { LeilaoBaseComponent } from '../leilao-form.base.component';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html'
})
export class EditarComponent extends LeilaoBaseComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private fb: FormBuilder,
    private LeilaoService: LeilaoService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService) {

    super();
    this.leilao = this.route.snapshot.data['leilao'];
  }

  ngOnInit(): void {
    this.LeilaoForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      valorInicial: ['', [Validators.required]],
      condicao: ['', [Validators.required]],
      dataAbetura: ['', [Validators.required]],
      dataFinalizacao: ['', [Validators.required]],
      ativo: [0]
    });


    this.LeilaoForm.patchValue({
      id: this.leilao.id,
      nome: this.leilao.nome,
      valorInicial: CurrencyUtils.DecimalParaString(this.leilao.valorInicial),
      condicao: this.leilao.condicao.toString(),
      dataAbetura: this.leilao.dataAbetura,
      dataFinalizacao: this.leilao.dataFinalizacao,
      ativo: this.leilao.ativo
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  editarLeilao() {
    if (this.LeilaoForm.dirty && this.LeilaoForm.valid) {
      this.leilao = Object.assign({}, this.leilao, this.LeilaoForm.value);

      this.leilao.valorInicial = CurrencyUtils.StringParaDecimal(this.leilao.valorInicial);

      this.LeilaoService.atualizarLeilao(this.leilao)
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

    this.toastr.success('Leilão Editado com sucesso!', 'Sucesso!');
    this.router.navigate(['/leiloes/listar-todos']);

  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

  upload(file: any) {
    var reader = new FileReader();
    reader.onload = this.manipularReader.bind(this);
    reader.readAsBinaryString(file[0]);
  }

  manipularReader(readerEvt: any) {
    var binaryString = readerEvt.target.result;
  }
}

