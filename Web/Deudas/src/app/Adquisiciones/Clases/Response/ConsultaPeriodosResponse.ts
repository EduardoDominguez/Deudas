import { Periodo } from "../Periodos";
import { Respuesta } from "../../../Clases/Respuesta";

export class ConsultaPeriodosResponse extends Respuesta {
    public urs: Periodo[];
}