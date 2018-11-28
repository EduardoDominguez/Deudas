/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Random;
import javax.imageio.ImageIO;
import sun.misc.BASE64Decoder;

/**
 *
 * @author ROGEPC
 */
public class General {

    public static String convertFromUTF8(String s) {
        String out = null;
        try {
            out = new String(s.getBytes("ISO-8859-1"), "UTF-8");
        } catch (java.io.UnsupportedEncodingException e) {
            return null;
        }
        return out;
    }

    public static String convertToUTF8(String s) {
        String out = null;
        try {
            out = new String(s.getBytes("UTF-8"), "ISO-8859-1");
        } catch (java.io.UnsupportedEncodingException e) {
            return null;
        }
        return out;
    }

    /*
     *Método que verifica el resultado de una consulta
     *@param List<map> con el resultado de la consulta
     *En caso de encontrar un error en la consulta regresará fail
     *De otro modo devolver ok
     */
    public String estatusConsulta(List<Map> consulta) {
        if (consulta.get(0).containsKey("fail")) {
            return consulta.get(0).get("fail").toString();
        } else if (consulta.get(0).containsKey("fail.")) {
            return consulta.get(0).get("fail.").toString();
        } else if (consulta.get(0).containsKey("fail..")) {
            return consulta.get(0).get("fail..").toString();
        } else {
            return "ok";
        }
    }

    /*
     *Método que convierte a entero una cadena
     *@param String 
     *Devuelve un entero
     */
    public int toInt(String x) {
        try {
            return Integer.parseInt(x);
        } catch (Exception e) {
            return -1;
        }
    }

    public String getDateToday() {
        String ret = "";
        try {
            DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            Date date = new Date();
            ret = dateFormat.format(date);
        } catch (Exception e) {
            ret = "0000-00-00 00:00:00";
        }
        return ret;
    }

    /*
     *Método que convierte a entero una cadena
     *@param String 
     *Devuelve un tipo Date
     */
    public String formato_fecha(String fecha_p) {
        String res = "0000-00-00";
        String[] fecha;
        try {
            fecha = fecha_p.split("/");
            res = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        } catch (Exception e) {
            return res;
        }
        return res;
    }

    public String genera_codigo_activacion() {
        String codigo = "";
        int cont = 0, rand;
        String[] letras = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        do {
            rand = (int) Math.round(Math.random() * 26);
            codigo += letras[rand];
            cont++;
        } while (cont < 6);
        return codigo;
    }

    public String retRandomName() {
        String ret = "";
        try {
            String date = getDateToday();
            date = date.replace("/", "");
            date = date.replace("-", "");
            date = date.replace(" ", "");
            date = date.replace(":", "");
            date = date.replace("-", "");
            Random rand = new Random();
            int n = 9999 - 0 + 1;
            int i = rand.nextInt() % n;
            int randnumber = 0 + i;
            date += randnumber;
            ret = date;
        } catch (Exception e) {
            ret = "";
        }
        return ret;
    }

    public String base64ToImg(String base64, String path, String name) {
        String ret = "";
        try {
            byte[] btDataFile = new sun.misc.BASE64Decoder().decodeBuffer(base64);
            File of = new File(path+"\\img\\upload\\"+ name);
            FileOutputStream osf = new FileOutputStream(of);
            osf.write(btDataFile);
            osf.flush();
            osf.close();
            ret = "ok";
        } catch (Exception e) {
            ret = e.toString();
        }
        return ret;
    }
}
