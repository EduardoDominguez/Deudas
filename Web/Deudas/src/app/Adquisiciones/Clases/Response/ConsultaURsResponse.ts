import { UR } from "../URs";
import { Respuesta } from "../../../Clases/Respuesta";

export class ConsultaUrsResponse extends Respuesta {
    public urs: UR[];
}