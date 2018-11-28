/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.modelo;

/**
 *
 * @author mdominguez
 */
public class ingresosModelo {
    private int idingreso;
    private double cantidad_inicial;
    private double cantidad_actual;
    private String fecha;
    private int idusuario;
    private String nombre;

    public ingresosModelo(){
    }
    public ingresosModelo(String nombre, int idingreso){
        this.nombre = nombre;
        this.idingreso = idingreso;
    }
    public int getIdingreso() {
        return idingreso;
    }

    public void setIdingreso(int idingreso) {
        this.idingreso = idingreso;
    }

    public double getCantidad_inicial() {
        return cantidad_inicial;
    }

    public void setCantidad_inicial(double cantidad_inicial) {
        this.cantidad_inicial = cantidad_inicial;
    }

    public double getCantidad_actual() {
        return cantidad_actual;
    }

    public void setCantidad_actual(double cantidad_actual) {
        this.cantidad_actual = cantidad_actual;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public int getIdusuario() {
        return idusuario;
    }

    public void setIdusuario(int idusuario) {
        this.idusuario = idusuario;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    @Override
    public String toString(){
        return getNombre();
    }
}
