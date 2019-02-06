export class Periodo {
    public no_periodo: number;
    public cl_anio: number;

    public fe_alta_min: string;
    public fe_alta_max: string;
    
    public fe_cap_rec_min: string;
    public fe_cap_rec_max: string;

    public fe_ent_min: string;
    public fe_ent_max: string;

    public alta_recepcion_rango: string;
    public captura_recepcion_rango: string;
    public entrega_bienes_rango: string;
    
    public cl_usuario_crea: string;
    public nb_programa_crea: string;

    public fg_activo: boolean;
    /*constructor(no_periodo : number, cl_anio:number, altaBienes:string, capturaRecepcion: string, entregaBienes:string, ){
        this.no_periodo = no_periodo;
        this.altaBienes = altaBienes;
        this.capturaRecepcion = capturaRecepcion;
        this.entregaBienes = entregaBienes;
        this.cl_anio = cl_anio;
    }*/
}