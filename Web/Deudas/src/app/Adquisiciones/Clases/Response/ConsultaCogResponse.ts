import { Cog } from "../Cog";
import { Respuesta } from "../../../Clases/Respuesta";

export class ConsultaCogResponse extends Respuesta {
    public cogs: Cog[];
}