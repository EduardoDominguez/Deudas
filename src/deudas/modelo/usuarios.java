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
public class usuarios {

    private int idusuario;
    private String nombre;
    private String appaterno;
    private String apmaterno;
    private int idusuarioregistro;
    private String horaregistro;
    private String fecharegistro;
    private String correo;
    private String nick;
    private String contrasena;

    public usuarios() {

    }

    public usuarios(int idusuario, String nombre, String appaterno, String apmaterno, int idusuarioregistro, String horaregistro, String fecharegistro, String correo, String nick, String contrasena) {
        this.idusuario = idusuario;
        this.nombre = nombre;
        this.appaterno = appaterno;
        this.apmaterno = apmaterno;
        this.idusuarioregistro = idusuarioregistro;
        this.horaregistro = horaregistro;
        this.fecharegistro = fecharegistro;
        this.correo = correo;
        this.nick = nick;
        this.contrasena = contrasena;
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

    public String getAppaterno() {
        return appaterno;
    }

    public void setAppaterno(String appaterno) {
        this.appaterno = appaterno;
    }

    public String getApmaterno() {
        return apmaterno;
    }

    public void setApmaterno(String apmaterno) {
        this.apmaterno = apmaterno;
    }

    public int getIdusuarioregistro() {
        return idusuarioregistro;
    }

    public void setIdusuarioregistro(int idusuarioregistro) {
        this.idusuarioregistro = idusuarioregistro;
    }

    public String getHoraregistro() {
        return horaregistro;
    }

    public void setHoraregistro(String horaregistro) {
        this.horaregistro = horaregistro;
    }

    public String getFecharegistro() {
        return fecharegistro;
    }

    public void setFecharegistro(String fecharegistro) {
        this.fecharegistro = fecharegistro;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getNick() {
        return nick;
    }

    public void setNick(String nick) {
        this.nick = nick;
    }

    public String getContrasena() {
        return contrasena;
    }

    public void setContrasena(String contrasena) {
        this.contrasena = contrasena;
    }

}
