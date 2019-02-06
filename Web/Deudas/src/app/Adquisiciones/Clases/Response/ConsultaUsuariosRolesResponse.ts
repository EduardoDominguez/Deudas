import { Usuario } from "../Usuario";
import { Respuesta } from "../../../Clases/Respuesta";

export class ConsultaUsuariosRolesResponse extends Respuesta {
    public cogs: Usuario[];
}