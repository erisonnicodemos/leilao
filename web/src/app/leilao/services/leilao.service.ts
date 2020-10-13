import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";

import { BaseService } from 'src/app/services/base.service';
import { Leilao } from '../models/leilao';

@Injectable()
export class LeilaoService extends BaseService {

    constructor(private http: HttpClient) { super() }

    obterTodos(): Observable<Leilao[]> {
        return this.http
            .get<Leilao[]>(this.UrlServiceV1 + "leiloes", super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterPorId(id: string): Observable<Leilao> {
        return this.http
            .get<Leilao>(this.UrlServiceV1 + "leiloes/" + id, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    novoLeilao(leilao: Leilao): Observable<Leilao> {
        return this.http
            .post(this.UrlServiceV1 + "leiloes", leilao, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    atualizarLeilao(leilao: Leilao): Observable<Leilao> {
        return this.http
            .put(this.UrlServiceV1 + "leiloes/" + leilao.id, leilao, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    excluirLeilao(id: string): Observable<Leilao> {
        return this.http
            .delete(this.UrlServiceV1 + "leiloes/" + id, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }    

    
}
