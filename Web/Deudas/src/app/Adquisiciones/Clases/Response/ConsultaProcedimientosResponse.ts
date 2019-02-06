import { Procedimiento } from "../Procedimientos";
import { Respuesta } from "../../../Clases/Respuesta";

export class ConsultaProcedimientosResponse extends Respuesta {
    public procedimientos: Procedimiento[];
}