/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.modelo;

/**
 *
 * @author Eduardo
 */
public class abonoModelo {
    private int idabono;
    private String nombreDeuda;
    private String nombreAbonador;
    private String fechaHora;
    private String nombreIngreso;
    private double cantidadAbono;

    public abonoModelo() {
    }

    public int getIdabono() {
        return idabono;
    }

    public void setIdabono(int idabono) {
        this.idabono = idabono;
    }

    public String getNombreDeuda() {
        return nombreDeuda;
    }

    public void setNombreDeuda(String nombreDeuda) {
        this.nombreDeuda = nombreDeuda;
    }

    public String getNombreAbonador() {
        return nombreAbonador;
    }

    public void setNombreAbonador(String nombreAbonador) {
        this.nombreAbonador = nombreAbonador;
    }

    public String getFechaHora() {
        return fechaHora;
    }

    public void setFechaHora(String fechaHora) {
        this.fechaHora = fechaHora;
    }

    public String getNombreIngreso() {
        return nombreIngreso;
    }

    public void setNombreIngreso(String nombreIngreso) {
        this.nombreIngreso = nombreIngreso;
    }

    public double getCantidadAbono() {
        return cantidadAbono;
    }

    public void setCantidadAbono(double cantidadAbono) {
        this.cantidadAbono = cantidadAbono;
    }

   
}
