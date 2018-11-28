/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package deudas.modelo;

/**
 *
 * @author eduardo
 */
public class deudaModelo {
    
    private int iddeuda;
    private String nombre;
    private int estatus;
    private int dia_corte;
    private int dia_limite_pago;
    private String fechaalta;
    private String horaalta;
    private int idusuario;
    private double total;

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }
    
    public deudaModelo(String nombre, int iddeuda){
        this.nombre = nombre;
        this.iddeuda = iddeuda;
    }
    
    public deudaModelo(int iddeuda, String nombre, int estatus, int dia_corte, int dia_limite_pago, String fechaalta, String horaalta, int idusuario) {
        this.iddeuda = iddeuda;
        this.nombre = nombre;
        this.estatus = estatus;
        this.dia_corte = dia_corte;
        this.dia_limite_pago = dia_limite_pago;
        this.fechaalta = fechaalta;
        this.horaalta = horaalta;
        this.idusuario = idusuario;
    }
    
    public deudaModelo(){
    }

    public int getIddeuda() {
        return iddeuda;
    }

    public void setIddeuda(int iddeuda) {
        this.iddeuda = iddeuda;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEstatus() {
        return estatus;
    }

    public void setEstatus(int estatus) {
        this.estatus = estatus;
    }

    public int getDia_corte() {
        return dia_corte;
    }

    public void setDia_corte(int dia_corte) {
        this.dia_corte = dia_corte;
    }

    public int getDia_limite_pago() {
        return dia_limite_pago;
    }

    public void setDia_limite_pago(int dia_limite_pago) {
        this.dia_limite_pago = dia_limite_pago;
    }

    public String getFechaalta() {
        return fechaalta;
    }

    public void setFechaalta(String fechaalta) {
        this.fechaalta = fechaalta;
    }

    public String getHoraalta() {
        return horaalta;
    }

    public void setHoraalta(String horaalta) {
        this.horaalta = horaalta;
    }

    public int getIdusuario() {
        return idusuario;
    }

    public void setIdusuario(int idusuario) {
        this.idusuario = idusuario;
    }
    
    
    @Override
    public String toString(){
        return getNombre();
    }
}
