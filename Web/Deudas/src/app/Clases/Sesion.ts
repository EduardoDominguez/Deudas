import { User } from "./User";
import { Respuesta } from "./Respuesta";

export class Sesion extends Respuesta {
    public token: string;
    public user: User;
}