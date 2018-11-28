/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

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
public class deuda {

    dataBaseQuery query = new dataBaseQuery();
    //public static usuarios us = new usuarios();
    General g = new General();
    usuarios user = login.us;

    public String insertaDeuda(String nombre, int diaCorte, int diaPago) throws SQLException {
        String resultado = "No se pudo generar un iddeuda";
        int iddeuda = generaId();
        if (generaId() != -1) {
            try {
                resultado = query.exQuery("insert into deudas.deudas (iddeuda, nombreDeuda, dia_corte, dia_limite_pago,fechaalta, horaalta, idusuario)"
                        + "values (" + iddeuda + ",'" + nombre + "', " + diaCorte + ", " + diaPago + ", curdate(), curtime(), " + user.getIdusuario() + ")");
            } catch (Exception e) {
                System.err.println("Ha ocurrido un error " + query.getLastQuery() + " ERROR: " + e.getMessage());
            } finally {
                System.out.print(query.getLastQuery());
            }
        }
        return resultado;
    }

    public String insertaDetalleDeuda(int iddeuda, double cantidad) throws SQLException {
        String resultado = "No se pudo registrar en detalle deuda";

        try {
            resultado = query.exQuery("insert into deudas.detalle_deuda (iddeuda, cantidad)"
                    + "values (" + iddeuda + "," + cantidad + ")");
        } catch (Exception e) {
            resultado = e.toString();
            System.err.println("Ha ocurrido un error " + query.getLastQuery() + " ERROR: " + e.getMessage());
        } finally {
            System.out.print(query.getLastQuery());
        }
        return resultado;
    }

    public List<deudaModelo> consultaDeuda() throws SQLException {
        List<Map> m = query.select("select * from deudas.deudas where estatus = 1 ", true);
        String resultado;
        List<deudaModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map deudas : m) {
                        deudaModelo d = new deudaModelo();
                        d.setIddeuda(Integer.parseInt(deudas.get("iddeuda").toString()));
                        d.setNombre(deudas.get("nombreDeuda").toString());
                        d.setDia_corte(Integer.parseInt(deudas.get("dia_corte").toString()));
                        d.setDia_limite_pago(Integer.parseInt(deudas.get("dia_limite_pago").toString()));
                        d.setEstatus(Integer.parseInt(deudas.get("estatus").toString()));
                        d.setFechaalta(deudas.get("fechaalta").toString());
                        d.setHoraalta(deudas.get("horaalta").toString());
                        d.setIdusuario(Integer.parseInt(deudas.get("idusuario").toString()));
                        dm.add(d);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }
    
     public List<deudaModelo> consultaDeudaComboDetalle() throws SQLException {
        List<Map> m = query.select("select * from deudas.deudas where estatus = 1 and iddeuda not in(select iddeuda from deudas.detalle_deuda)", true);
        String resultado;
        List<deudaModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map deudas : m) {
                        deudaModelo d = new deudaModelo();
                        d.setIddeuda(Integer.parseInt(deudas.get("iddeuda").toString()));
                        d.setNombre(deudas.get("nombreDeuda").toString());
                        d.setDia_corte(Integer.parseInt(deudas.get("dia_corte").toString()));
                        d.setDia_limite_pago(Integer.parseInt(deudas.get("dia_limite_pago").toString()));
                        d.setEstatus(Integer.parseInt(deudas.get("estatus").toString()));
                        d.setFechaalta(deudas.get("fechaalta").toString());
                        d.setHoraalta(deudas.get("horaalta").toString());
                        d.setIdusuario(Integer.parseInt(deudas.get("idusuario").toString()));
                        dm.add(d);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }
     
    public List<deudaModelo> consultaDeudaConAdeudo() throws SQLException {
        //List<Map> m = query.select("select * from deudas.deudas where estatus = 1 ", true);
        List<Map> m = query.select("SELECT d.* FROM deudas.deudas d "
                    + "INNER JOIN deudas.detalle_deuda dd ON d.iddeuda = dd.iddeuda AND dd.cantidad > 0 " +
                    "WHERE d.estatus = 1", true);
        String resultado;
        List<deudaModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map deudas : m) {
                        deudaModelo d = new deudaModelo();
                        d.setIddeuda(Integer.parseInt(deudas.get("iddeuda").toString()));
                        d.setNombre(deudas.get("nombreDeuda").toString());
                        d.setDia_corte(Integer.parseInt(deudas.get("dia_corte").toString()));
                        d.setDia_limite_pago(Integer.parseInt(deudas.get("dia_limite_pago").toString()));
                        d.setEstatus(Integer.parseInt(deudas.get("estatus").toString()));
                        d.setFechaalta(deudas.get("fechaalta").toString());
                        d.setHoraalta(deudas.get("horaalta").toString());
                        d.setIdusuario(Integer.parseInt(deudas.get("idusuario").toString()));
                        dm.add(d);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }
    
    public List<deudaModelo> consultaDeudaConTotal() throws SQLException {
        List<Map> m = query.select("select d.iddeuda as iddeuda,"
                + "d.nombreDeuda as nombreDeuda,"
                + "d.dia_corte as dia_corte,"
                + "d.dia_limite_pago as dia_limite_pago,"
                + "d.estatus as estatus,"
                + "d.fechaalta as fechaalta,"
                + "d.horaalta as horaalta,"
                + "d.idusuario,"
                + "dd.cantidad as cantidad "
                + " from deudas.deudas d inner join deudas.detalle_deuda dd "
                + " on d.iddeuda = dd.iddeuda ", true);
        String resultado;
        List<deudaModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map deudas : m) {
                        deudaModelo d = new deudaModelo();
                        d.setIddeuda(Integer.parseInt(deudas.get("iddeuda").toString()));
                        d.setNombre(deudas.get("nombreDeuda").toString());
                        d.setDia_corte(Integer.parseInt(deudas.get("dia_corte").toString()));
                        d.setDia_limite_pago(Integer.parseInt(deudas.get("dia_limite_pago").toString()));
                        d.setEstatus(Integer.parseInt(deudas.get("estatus").toString()));
                        d.setFechaalta(deudas.get("fechaalta").toString());
                        d.setHoraalta(deudas.get("horaalta").toString());
                        d.setIdusuario(Integer.parseInt(deudas.get("idusuario").toString()));
                        d.setTotal(Double.parseDouble(deudas.get("cantidad").toString()));
                        dm.add(d);
                    }
                }else{
                    
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;

    }
    
     public int generaId() throws SQLException {
        List<Map> m = query.select("select max(iddeuda) as iddeuda from deudas.deudas", true);
        String resultado;
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    if (m.get(0).get("iddeuda") != null) {
                        return Integer.parseInt(m.get(0).get("iddeuda").toString()) + 1;
                    } else {
                        return 1;
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return -1;
    }
    
    public double obtieneMonto(int iddeuda) throws SQLException {
        List<Map> m = query.select("select cantidad  from deudas.detalle_deuda where iddeuda = "+iddeuda, true);
        String resultado;
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                   return Double.parseDouble(m.get(0).get("cantidad").toString());
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return -1;
    }
    
    public double consultaDeudaSuma() throws SQLException {
        List<Map> m = query.select("select sum(cantidad) as cantidad from deudas.detalle_deuda", true);
        String resultado;
        double deuda = -1;
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        deuda= Double.parseDouble(ingresos.get("cantidad").toString());
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
            return deuda;
        }
        return deuda;
    }
}
