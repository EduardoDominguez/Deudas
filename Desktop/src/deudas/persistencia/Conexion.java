/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.persistencia;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Properties;
import java.util.logging.Level;


/**
 *
 * @author Eduardo Dominguez
 */

/**
 * Crea una connexion a un una BD
 */
public class Conexion {

    private Connection connection = null;

    /**
     * Crea y retorna una conexión.<p>
     * El parametros server, debe tener el formato servidor$user&password de la
     * base de datos.<p>
     * Ejemplo:
     * <p>
     * <code>Server13$usuario1$pass1</code>
     *
     * @param server identicador del servidor de base de datos
     * @return sql.Connection
     */
     
    public Connection connect(String server) {
        try {
            String[] parametros = server.split("&");
            String host = "jdbc:mysql://" + parametros[0];
            Properties p = new Properties();
            p.put("user", parametros[1]);
            if(parametros.length == 3)
                p.put("password", parametros[2]);
            p.put("jdbcCompliantTruncation", "false");
            p.put("zeroDateTimeBehavior", "convertToNull");
            Class.forName("com.mysql.jdbc.Driver").newInstance();
            connection = DriverManager.getConnection(host, p);
            return connection;
        } catch (Exception e) {
            System.out.println("Error al establecer la conexión a la BD error " + e);
            return null;
        }
    }
    
   

    /**
     * Cierra un <code>ResultSet</code>, evita cerrarlo si es nulo.
     *
     * @param rs ResultSet a cerrar.
     * @throws SQLException si ocurre un error al acceder a la base de datos.
     */
    public static void close(ResultSet rs) {
        try {
            if (rs != null) {
                rs.close();
            }
        } catch (SQLException e) {
            // ignorar
        }
    }

    /**
     * Cierra un <code>Connection</code>, evita cerrarlo si es nulo.
     *
     * @param con Connection a cerrar.
     * @throws SQLException si ocurre un error al acceder a la base de datos.
     */
    public static void close(Connection con) {
        try {
            if (con != null) {
                con.close();
            }
        } catch (SQLException e) {
            // ignorar
        }
    }

    /**
     * Cierra un <code>Statement</code>, evita cerrarlo si es nulo.
     *
     * @param stmt Statement a cerrar.
     * @throws SQLException si ocurre un error al acceder a la base de datos.
     */
    public static void close(Statement stmt) {

        try {
            if (stmt != null) {
                stmt.close();
            }
        } catch (SQLException e) {
            // ignorar
        }
    }

    /**
     * Cierra un <code>Statement</code> y un <code>ResultSet</code>, evita
     * cerrarlo si es nulo.
     *
     * @param stmt
     * @param rs
     */
    public static void close(Statement stmt, ResultSet rs) {
        close(rs);
        close(stmt);
    }

    /**
     * Cierra un <code>Statement</code>, <code>Connection</code> y un
     * <code>ResultSet</code>, evita cerrarlo si es nulo.
     *
     * @param stmt
     * @param rs
     */
    public static void close(Statement stmt, ResultSet rs, Connection con) {
        close(rs);
        close(stmt);
        close(con);
    }

}
