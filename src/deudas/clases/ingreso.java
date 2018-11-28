/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.clases;

import deudas.modelo.ingresosModelo;
import deudas.modelo.usuarios;
import deudas.persistencia.dataBaseQuery;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import util.General;

/**
 *
 * @author mdominguez
 */
public class ingreso {

    dataBaseQuery query = new dataBaseQuery();
    //public static usuarios us = new usuarios();
    General g = new General();
    usuarios user = login.us;

    public String insertaIngreso(String fecha, double cantidad, String nombreIngreso) throws SQLException {
        String resultado = "No se pudo registrar el ingreso";
        try {
            resultado = query.exQuery("insert into deudas.ingresos (idingreso, cantidad_inicial, cantidad_actual, fecha, idusuario, nombreIngreso)"
                    + "values ('0'," + cantidad + ", " + cantidad + ", '" + fecha + "', " + user.getIdusuario() + ", '" + nombreIngreso + "')"
            );
        } catch (Exception e) {
            System.err.println("Ha ocurrido un error " + query.getLastQuery() + " ERROR: " + e.getMessage());
        } finally {
            System.out.print(query.getLastQuery());
        }
        return resultado;
    }

    public List<ingresosModelo> consultaIngresos() throws SQLException {
        List<Map> m = query.select("select * from deudas.ingresos where cantidad_actual > 0", true);
        String resultado;
        List<ingresosModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        ingresosModelo im = new ingresosModelo();
                        im.setIdingreso(Integer.parseInt(ingresos.get("idingreso").toString()));
                        im.setNombre(ingresos.get("nombreIngreso").toString());
                        im.setCantidad_actual(Double.parseDouble(ingresos.get("cantidad_actual").toString()));
                        im.setCantidad_inicial(Double.parseDouble(ingresos.get("cantidad_inicial").toString()));
                        im.setFecha(ingresos.get("fecha").toString());
                        im.setIdusuario(Integer.parseInt(ingresos.get("idusuario").toString()));
                        dm.add(im);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }

    public List<ingresosModelo> consultaIngresosPorID(int idingreso) throws SQLException {
        List<Map> m = query.select("select * from deudas.ingresos where idingreso = " + idingreso, true);
        String resultado;
        List<ingresosModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        ingresosModelo im = new ingresosModelo();
                        im.setIdingreso(Integer.parseInt(ingresos.get("idingreso").toString()));
                        im.setNombre(ingresos.get("nombreIngreso").toString());
                        im.setCantidad_actual(Double.parseDouble(ingresos.get("cantidad_actual").toString()));
                        im.setCantidad_inicial(Double.parseDouble(ingresos.get("cantidad_inicial").toString()));
                        im.setFecha(ingresos.get("fecha").toString());
                        im.setIdusuario(Integer.parseInt(ingresos.get("idusuario").toString()));
                        dm.add(im);
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
        }
        return dm;
    }

    public double consultaIngresosSuma() throws SQLException {
        List<Map> m = query.select("select sum(cantidad_actual) as cantidad_actual from deudas.ingresos", true);
        String resultado;
        double ingreso = -1;
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        ingreso = Double.parseDouble(ingresos.get("cantidad_actual").toString());
                    }
                }
            }
        } catch (Exception ex) {
            System.err.println("Error: " + ex.getMessage());
            return ingreso;
        }
        return ingreso;
    }
    
      public List<ingresosModelo> consultaIngresosReporte() throws SQLException {
        List<Map> m = query.select("select * from deudas.ingresos", true);
        String resultado;
        List<ingresosModelo> dm = new ArrayList<>();
        try {
            if (!m.isEmpty()) {
                resultado = g.estatusConsulta(m);
                if ("ok".equals(resultado)) {
                    for (Map ingresos : m) {
                        ingresosModelo im = new ingresosModelo();
                        im.setIdingreso(Integer.parseInt(ingresos.get("idingreso").toString()));
                        im.setNombre(ingresos.get("nombreIngreso").toString());
                        im.setCantidad_actual(Double.parseDouble(ingresos.get("cantidad_actual").toString()));
                        im.setCantidad_inicial(Double.parseDouble(ingresos.get("cantidad_inicial").toString()));
                        im.setFecha(ingresos.get("fecha").toString());
                        im.setIdusuario(Integer.parseInt(ingresos.get("idusuario").toString()));
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
