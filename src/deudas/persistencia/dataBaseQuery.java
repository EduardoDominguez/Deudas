/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.persistencia;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import util.General;

/**
 *
 * @author Eduardo Dominguez
 */
public class dataBaseQuery {

    private final static Conexion con = new Conexion();
    private Connection conexion = null;
    private Statement sentenciaSQL = null, sentenciaSQLaux = null;
    private final String servidor = "127.0.0.1:3306/deudas&root&root1234";
    public String lastQuery="";

    public String select(String query) throws SQLException {
        String retQuery = "[";
        ResultSet cdraux = null;
        Integer cont = 0;
        try {
            conexion = con.connect(servidor);
            if (conexion != null) {
                sentenciaSQLaux = conexion.createStatement();
                cdraux = sentenciaSQLaux.executeQuery(query);
                lastQuery = query;
                if (cdraux.first()) {
                    cdraux.beforeFirst();
                    while (cdraux.next()) {
                        Integer numColumnas = 0;
                        numColumnas = cdraux.getMetaData().getColumnCount();
                        retQuery += "{";
                        for (int i = 1; i <= numColumnas; i++) {
                            String column = cdraux.getMetaData().getColumnName(i);
                            String contenido_columna;
                            if (cdraux.getString(column) == null) {
                                contenido_columna = "";
                            } else {
                                contenido_columna = cdraux.getString(column);
                            }
                            retQuery += "\"" + column + "\": \"" + General.convertToUTF8(contenido_columna) + "\", ";
                        }
                        retQuery = retQuery.substring(0, retQuery.length() - 2);
                        retQuery += "}, ";
                    }
                    retQuery = retQuery.substring(0, retQuery.length() - 2);
                    retQuery += "]";
                } else {
                    retQuery = "fail";//La consulta no tiene datos
                }
            } else {
                retQuery = "fail.";//Falló la conexión 
            }
        } catch (SQLException e) {
            System.out.print("Ha ocurrido un error inesperado al intentar consultar " + e);
            retQuery = "fail..";//Error inesperado con la base de datos
        } finally {
            Conexion.close(conexion);
            Conexion.close(cdraux);
            Conexion.close(sentenciaSQLaux);
        }
        return retQuery;
    }

    public List<Map> select(String query, boolean select2) throws SQLException {
        Map ml;
        List<Map> lista = new ArrayList<Map>();
        ResultSet cdraux = null;
        try {
            conexion = con.connect(servidor);
            if (conexion != null) {
                sentenciaSQLaux = conexion.createStatement();
                cdraux = sentenciaSQLaux.executeQuery(query);
                lastQuery = query;
                if (cdraux.first()) {
                    cdraux.beforeFirst();
                    while (cdraux.next()) {
                        ml = new HashMap();
                        Integer numColumnas = 0;
                        numColumnas = cdraux.getMetaData().getColumnCount();
                        for (int i = 1; i <= numColumnas; i++) {
                            String column = cdraux.getMetaData().getColumnName(i);
                            ml.put(column, cdraux.getString(column));
                        }
                        lista.add(ml);
                    }
                } else {
                    ml = new HashMap();
                    ml.put("fail", "No se han encontrado registros");
                    lista.add(ml);
                }
            } else {
                ml = new HashMap();
                lista.clear();
                ml.put("fail.", "Fallo la conexión");
                lista.add(ml);
            }
        } catch (SQLException e) {
            lista.clear();
            ml = new HashMap();
            System.out.print("Ha ocurrido un error inesperado al intentar consultar " + e.getMessage());
            ml.put("fail..", "Ha ocurrido un error inesperado al intentar consultar " + e.getMessage());
            lista.add(ml);
        } finally {
            Conexion.close(conexion);
            Conexion.close(cdraux);
            Conexion.close(sentenciaSQLaux);
        }
        return lista;
    }

    public String delete(String val, String table, String colum) throws SQLException {
        return exQuery("Delete from " + table + " where " + colum + " = " + val);
    }

    public String exQuery(String query) {
        String ret = "fail";
        lastQuery = query;
        try {
            conexion = con.connect(servidor);
            if (conexion != null) {
                sentenciaSQL = conexion.prepareStatement(query);
                sentenciaSQL.executeUpdate(query);
                ret = "ok";
            }
        } catch (SQLException e) {
            ret = e.getMessage();
            System.out.println("Error: "+ret+" Consulta+"+getLastQuery());
        } finally {
            Conexion.close(conexion);
            Conexion.close(sentenciaSQL);
        }
        return ret;
    }
    
    public String getLastQuery(){
        return lastQuery;
    }

}
