/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

import deudas.modelo.abonoModelo;
import deudas.modelo.deudaModelo;
import deudas.modelo.usuarios;
import deudas.persistencia.dataBaseQuery;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import util.General;

/**
 *
 * @author eduardo
 */
public class abonos {

    dataBaseQuery query = new dataBaseQuery();
    //public static usuarios us = new usuarios();
    General g = new General();
    usuarios user = login.us;

    public String insertaAbono(double abono, int iddeuda, int idingreso, double cantidad) throws SQLException {
        String resultado = "No se pudo registrar en detalle deuda";
        try {
            query.exQuery("START TRANSACTION");
            query.exQuery("BEGIN");
            if(evaluaResultado(query.exQuery("insert into deudas.abonos_deuda values (0," + iddeuda + "," + user.getIdusuario() + ", " + idingreso + ", " + abono + ", now())"))){
                if(evaluaResultado(query.exQuery("update deudas.detalle_deuda set cantidad = (cantidad - " + abono + ") where iddeuda =" + iddeuda))){
                    if(evaluaResultado(query.exQuery("update deudas.ingresos set cantidad_actual = (cantidad_actual - " + abono + ") where idingreso = " + idingreso))){
                        query.exQuery("COMMIT");
                        resultado = "ok";
                    }else{
                        query.exQuery("ROLLBACK");
                    }
                }else{
                    query.exQuery("ROLLBACK");
                }
            }else{
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
    
     public List<abonoModelo> consultaPagos() throws SQLException {
        List<Map> m;
        m = query.select("select ad.idabono idabono, ad.cantidad as cantidad, i.nombreIngreso as nombreIngreso,"
                + " d.nombreDeuda nombreDeuda, concat_ws(' ', u.nombre, u.appaterno, u.apmaterno) as usuario, ad.fechahora as fechahora"
                + " from deudas.abonos_deuda ad "
                + " inner join deudas.ingresos i on i.idingreso = ad.idingreso "
                + " inner join deudas.deudas d on d.iddeuda = ad.iddeuda "
                + " inner join deudas.usuarios u on u.idusuario = ad.idusuario"
                + " order by ad.fechahora DESC ", true);
        String resultado;
        List<abonoModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        abonoModelo im = new abonoModelo();
                        im.setIdabono(Integer.parseInt(ingresos.get("idabono").toString()));
                        im.setCantidadAbono(Double.parseDouble(ingresos.get("cantidad").toString()));
                        im.setNombreDeuda(ingresos.get("nombreDeuda").toString());
                        im.setNombreAbonador(ingresos.get("usuario").toString());
                        im.setFechaHora(ingresos.get("fechahora").toString());
                        im.setNombreIngreso(ingresos.get("nombreIngreso").toString());
                        dm.add(im);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }
}
