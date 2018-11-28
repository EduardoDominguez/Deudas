/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

import deudas.modelo.usuarios;
import deudas.persistencia.dataBaseQuery;
import java.sql.SQLException;
import java.util.List;
import java.util.Map;
import util.General;

/**
 *
 * @author eduardo
 */
public class login {

    dataBaseQuery query = new dataBaseQuery();
    public static usuarios us = new usuarios();
    General g = new General();

    public String iniciaSesion(String p_nick, String p_pass) throws SQLException {
        List<Map> m = query.select("select * from deudas.usuarios where nick = '" + p_nick + "' and contrasena = '" + p_pass + "'", true);
        String resultado = "";
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map d : m) {
                        us.setIdusuario(Integer.parseInt(d.get("idusuario").toString()));
                        us.setNombre((String) d.get("nombre"));
                        us.setAppaterno((String) d.get("appaterno"));
                        us.setApmaterno((String) d.get("apmaterno"));
                        us.setFecharegistro((String) d.get("fecharegistro"));
                        us.setHoraregistro((String) d.get("horaregistro"));
                        us.setContrasena((String) d.get("contrasena"));
                        us.setCorreo((String) d.get("correo"));
                        us.setIdusuarioregistro(Integer.parseInt(d.get("idusuarioregistro").toString()));
                        us.setNick((String) d.get("nick"));
                    }
                }
            } else {
                resultado = " Ha ocurrido un error inesperado";
            }
        } catch (Exception e) {
            System.err.println("Ha ocurrido un error " + query.getLastQuery() + " ERROR: " + e.getMessage());
        } finally {
            System.out.print(query.getLastQuery());
        }
        return resultado;
    }
}
