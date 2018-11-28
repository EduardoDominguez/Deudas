/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

import deudas.modelo.deudaModelo;
import deudas.modelo.gastoModelo;
import deudas.modelo.usuarios;
import deudas.persistencia.dataBaseQuery;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;
import util.General;

/**
 *
 * @author Eduardo
 */
public class gasto {

    dataBaseQuery query = new dataBaseQuery();
    General g = new General();
    usuarios user = login.us;

    public String insertaGasto(double cargo, int idingreso, String nombreCargo, String observaciones) throws SQLException {
        String resultado = "No se pudo registrar el gasto";
        try {
            query.exQuery("START TRANSACTION");
            query.exQuery("BEGIN");
            if (evaluaResultado(query.exQuery("insert into deudas.gastos values (0," + idingreso + ", " + cargo + ", '" + nombreCargo + "', '" + observaciones + "', now())"))) {
                if (evaluaResultado(query.exQuery("update deudas.ingresos set cantidad_actual = (cantidad_actual - " + cargo + ") where idingreso =" + idingreso))) {
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

    public double consultaGastosMensualesSuma() throws SQLException {
        List<Map> m = query.select("SELECT SUM(cantidadGasto) as cantidadGasto FROM deudas.gastos WHERE MONTH(fechahoramod) = MONTH(CURDATE())", true);
        String resultado;
        double gasto = -1;
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        gasto = Double.parseDouble(ingresos.get("cantidadGasto").toString());
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
            return gasto;
        }
        return gasto;
    }

    public List<gastoModelo> consultaGastos(Date fechaInicial, Date fechaFinal) throws SQLException {
        SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd");
        List<Map> m = query.select("SELECT g.idgasto as idgasto, g.cantidadGasto AS cantidadGasto, "
                + "i.nombreIngreso AS nombreIngreso, g.nombreGasto AS nombreGasto, g.fechahoramod AS fechahoramod, g.observaciones AS observaciones "
                + "FROM deudas.gastos g "
                + "INNER JOIN deudas.ingresos i ON i.idingreso = g.idingreso "
                + "WHERE g.fechahoramod BETWEEN '" + formato.format(fechaInicial) + " 00:00:00' AND '" + formato.format(fechaFinal) + " 23:59:59' "
                + "order by g.fechahoramod asc", true);
        System.out.println("\n"+query.getLastQuery());
        String resultado;
        List<gastoModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map gasto : m) {
                        gastoModelo d = new gastoModelo();
                        d.setIdgasto(Integer.parseInt(gasto.get("idgasto").toString()));
                        d.setCantidadGasto(Double.parseDouble(gasto.get("cantidadGasto").toString()));
                        d.setNombreGasto(gasto.get("nombreGasto").toString());
                        d.setNombreIngreso(gasto.get("nombreIngreso").toString());
                        d.setFechahoramod(gasto.get("fechahoramod").toString());
                        d.setObservaciones(gasto.get("observaciones").toString());
                        dm.add(d);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage()+" \n"+query.getLastQuery());
        }
        return dm;
    }

    private boolean evaluaResultado(String consulta) {
        return "ok".equals(consulta);
    }

}
