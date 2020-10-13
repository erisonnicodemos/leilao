import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeilaoAppComponent } from './leilao.app.component';
import { ListaComponent } from './lista/lista.component';
import { NovoComponent } from './novo/novo.component';
import { EditarComponent } from './editar/editar.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { LeilaoResolve } from './services/leilao.resolve';
import { LeilaoGuard } from './services/leilao.guard';

const LeilaoRouterConfig: Routes = [
    {
        path: '', component: LeilaoAppComponent,
        children: [
            { path: 'listar-todos', component: ListaComponent },
            {
                path: 'adicionar-novo', component: NovoComponent,
                canDeactivate: [LeilaoGuard],
                canActivate: [LeilaoGuard],
                data: [{ claim: { nome: 'Leilao', valor: 'Adicionar' } }],
            },
            {
                path: 'editar/:id', component: EditarComponent,
                canActivate: [LeilaoGuard],
                data: [{ claim: { nome: 'Leilao', valor: 'Atualizar' } }],
                resolve: {
                    leilao: LeilaoResolve
                }
            },
            {
                path: 'detalhes/:id', component: DetalhesComponent,
                resolve: {
                    leilao: LeilaoResolve
                }
            },
            {
                path: 'excluir/:id', component: ExcluirComponent,
                canActivate: [LeilaoGuard],
                data: [{ claim: { nome: 'Leilao', valor: 'Excluir' } }],
                resolve: {
                    leilao: LeilaoResolve
                }
            },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(LeilaoRouterConfig)
    ],
    exports: [RouterModule]
})
export class LeilaoRoutingModule { }