import { Leilao } from './models/leilao';
import { FormGroup } from '@angular/forms';
import { ElementRef } from '@angular/core';

import { utilsBr } from 'js-brasil';

import { FormBaseComponent } from '../base-components/form-base.component';

export abstract class LeilaoBaseComponent extends FormBaseComponent {
    
    leilao: Leilao;
    errors: any[] = [];
    LeilaoForm: FormGroup;

    MASKS = utilsBr.MASKS;

    constructor() {
        super();

        this.validationMessages = {
            nome: {
                required: 'Informe o Nome',
                minlength: 'Mínimo de 2 caracteres',
                maxlength: 'Máximo de 200 caracteres'
            },            
            valorInicial: {
                required: 'Informe o Valor',
            },
            dataAbetura: {
                required: 'Informe o Valor',
            },
            dataFinalizacao: {
                required: 'Informe o Valor',
            }

        }

        super.configurarMensagensValidacaoBase(this.validationMessages);
    }

    protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormularioBase(formInputElements, this.LeilaoForm);
    }
}