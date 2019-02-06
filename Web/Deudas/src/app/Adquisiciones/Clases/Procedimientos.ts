export class Procedimiento {
    public id: number;
    public tipo_procedimiento: string;
    public rango_minimo: number;
    public rango_maximo: number;
    
    constructor(id : number, tipo_procedimiento : string, rango_minimo:number, rango_maximo: number){
        this.id = id;
        this.tipo_procedimiento = tipo_procedimiento;
        this.rango_minimo = rango_minimo;
        this.rango_maximo = rango_maximo;
    }
}