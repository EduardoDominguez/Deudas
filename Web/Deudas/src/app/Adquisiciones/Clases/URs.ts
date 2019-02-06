export class UR {
    public id: number;
    public clave_ur: number;
    public nombre: string;
    public coordinador_administrativo: string;
    public director: string;
    
    constructor(id : number, clave_ur : number, nombre:string, coordinador_administrativo: string, director: string){
        this.id = id;
        this.clave_ur = clave_ur;
        this.nombre = nombre;
        this.coordinador_administrativo = coordinador_administrativo;
        this.director = director;
    }
}