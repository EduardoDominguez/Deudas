/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.modelo;

/**
 *
 * @author Mario Dominguez
 */
public class gastoModelo {
    
    private String nombreIngreso;
    private String nombreGasto;
    private double cantidadGasto;
    private String fechahoramod;
    private int idgasto;
    private String observaciones;

    public gastoModelo() {
    }
    public gastoModelo(String nombreIngreso, String nombreGasto, double cantidadGasto, String fechahoramod, int idgasto) {
        this.nombreIngreso = nombreIngreso;
        this.nombreGasto = nombreGasto;
        this.cantidadGasto = cantidadGasto;
        this.fechahoramod = fechahoramod;
        this.idgasto = idgasto;
    }

    public String getNombreIngreso() {
        return nombreIngreso;
    }

    public void setNombreIngreso(String nombreIngreso) {
        this.nombreIngreso = nombreIngreso;
    }

    public String getNombreGasto() {
        return nombreGasto;
    }

    public void setNombreGasto(String nombreGasto) {
        this.nombreGasto = nombreGasto;
    }

    public double getCantidadGasto() {
        return cantidadGasto;
    }

    public void setCantidadGasto(double cantidadGasto) {
        this.cantidadGasto = cantidadGasto;
    }

    public String getFechahoramod() {
        return fechahoramod;
    }

    public void setFechahoramod(String fechahoramod) {
        this.fechahoramod = fechahoramod;
    }

    public int getIdgasto() {
        return idgasto;
    }

    public void setIdgasto(int idgasto) {
        this.idgasto = idgasto;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }
}
