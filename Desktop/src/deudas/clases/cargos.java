/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

import deudas.modelo.usuarios;
import deudas.persistencia.dataBaseQuery;
import java.sql.SQLException;
import util.General;

/**
 *
 * @author Eduardo
 */
public class cargos {

    dataBaseQuery query = new dataBaseQuery();
    //public static usuarios us = new usuarios();
    General g = new General();
    usuarios user = login.us;

    public String actialuzaCantidadDeuda(double cargo, int iddeuda) throws SQLException {
        String resultado = "No se pudo registrar el cargo";
        try {
            query.exQuery("START TRANSACTION");
            query.exQuery("BEGIN");
            if (evaluaResultado(query.exQuery("insert into deudas.cargos_deudas values (0," + iddeuda + "," + user.getIdusuario() + ", " + cargo + ", now())"))) {
                if (evaluaResultado(query.exQuery("update deudas.detalle_deuda set cantidad = (cantidad + " + cargo + ") where iddeuda =" + iddeuda))) {
                    query.exQuery("COMMIT");
                    resultado = "ok";
                } else {
                    query.exQuery("ROLLBACK");
                }
            } else {
                query.exQuery("ROLLBACK");
            }
        } catch (Exception e) {
            System.err.println("Ha ocurrido un error " + query.getLastQuery() + " ERROR: " + e.getMessage());
            query.exQuery("ROLLBACK");
        } finally {
            System.out.print(query.getLastQuery());
        }
        return resultado;
    }

    private boolean evaluaResultado(String consulta) {
        return "ok".equals(consulta);
    }

}
