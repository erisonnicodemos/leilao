import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Leilao } from '../models/leilao';
import { LeilaoService } from './leilao.service';

@Injectable()
export class LeilaoResolve implements Resolve<Leilao> {

    constructor(private LeilaoService: LeilaoService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.LeilaoService.obterPorId(route.params['id']);
    }
}