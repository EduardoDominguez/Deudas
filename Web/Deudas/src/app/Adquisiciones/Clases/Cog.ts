export class Cog {
    public id: number;
    public partida: string;
    public nombre: string;
    
    constructor(id : number, partida:string, nombre: string){
        this.id = id;
        this.partida = partida;
        this.nombre = nombre;
    }
}