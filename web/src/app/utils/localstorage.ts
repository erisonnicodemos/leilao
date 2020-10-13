export class LocalStorageUtils {
    
    public obterUsuario() {
        return JSON.parse(localStorage.getItem('leilao.user'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.userToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('leilao.token');
        localStorage.removeItem('leilao.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('leilao.token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('leilao.token', token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('leilao.user', JSON.stringify(user));
    }

}