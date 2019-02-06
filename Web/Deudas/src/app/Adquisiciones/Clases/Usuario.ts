export class Usuario {
    public id: number;
    public cl_usuario: string;
    public nombre_completo: string;
    public correo: string;
    public rol: string;
    
    constructor(id : number, cl_usuario : string, nombre_completo:string, correo: string, rol: string){
        this.id = id;
        this.cl_usuario = cl_usuario;
        this.nombre_completo = nombre_completo;
        this.correo = correo;
        this.rol = rol;
    }
}