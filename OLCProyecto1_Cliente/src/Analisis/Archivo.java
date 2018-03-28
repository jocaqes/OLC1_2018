/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analisis;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.PrintWriter;
import javax.swing.JFileChooser;
import javax.swing.JFrame;


public class Archivo extends JFrame{
    
    public static String abrir(){//solo regresa la ruta
        String salida = "";
        File archivo = null;

        try{
            JFileChooser ventana_abrir = new JFileChooser("D:\\");
            ventana_abrir.setApproveButtonText("Abrir");
            ventana_abrir.setDialogTitle("Abrir");
            ventana_abrir.showOpenDialog(null);
            archivo = ventana_abrir.getSelectedFile();
            salida=archivo.getAbsolutePath();//nuevo
        }catch (Exception e){
            salida = "error";
        }
        return salida;
    }
    
    public static String guardar(String texto){
        File archivo = null;
        String ruta;
        try{
            JFileChooser ventana_guardar = new JFileChooser("D:\\");
            ventana_guardar.setApproveButtonText("Guardar");
            ventana_guardar.setDialogTitle("Guardar");
            ventana_guardar.setApproveButtonToolTipText("Guardar el documento");
            ventana_guardar.showOpenDialog(null);
            archivo = ventana_guardar.getSelectedFile();
            ruta = archivo.getAbsolutePath();
            if(!ruta.endsWith(".cp")){//en caso de que no se ponga el .cp que en teoria es a proposito el no ponerlo para ahorrar trabajo
                ruta+=".cp";
            }
            escribir(ruta,texto);
            return ruta;
        }catch(Exception e){
            return "error";
        }
    }
    
    public static boolean eliminar(){
        File archivo = null;
        String ruta;
        try{
            JFileChooser ventana_eliminar = new JFileChooser("D:\\");
            ventana_eliminar.setApproveButtonText("Eliminar");
            ventana_eliminar.setDialogTitle("Eliminar");
            ventana_eliminar.setApproveButtonToolTipText("Eliminar el archivo .cp seleccionado");
            ventana_eliminar.showOpenDialog(null);
            archivo=ventana_eliminar.getSelectedFile();
            ruta=archivo.getAbsolutePath();
            if(ruta.endsWith(".cp")){
                archivo.delete();
                return true;
            }else{
                return false;
            }
        }catch(Exception e){
            return false;
        }
    }
    
    
    
    public static String leer(String ruta){
        if(ruta.contains("/")){
            ruta.replace("/", "\\");
        }
        String salida="";
        String cadena;
        try{
            FileReader f = new FileReader(ruta);
            BufferedReader b = new BufferedReader(f);
            while((cadena = b.readLine())!=null) {
                salida+=cadena+"\n";
            }
            b.close();
        }catch(Exception e){
            System.out.println("Error al leer el archivo");//debug
        }
        //System.out.println("Texto del doc:"+salida);
        return salida; 
    }
    
    public static void escribir(String ruta, String texto){
        FileWriter archivo=null;
        PrintWriter pw=null;
        try{
            archivo=new FileWriter(ruta);
            pw = new PrintWriter(archivo);
            pw.print(texto);
            archivo.close();
            System.out.println("Archivo guardado");//debug
        }catch(Exception e){
            System.out.println("Error en la ruta, detalle:"+e.toString());//debug
        }
    }
    
        
    public static void generarJSON(String ruta, String texto){
        if(ruta.contains("/")){
            ruta=ruta.replace("/", "\\");
        }
        if(!ruta.endsWith(".json")){
            ruta=ruta+".json";
        }
        texto=texto.replace(",", ",\n");
        escribir(ruta,texto);
    }
        

        
}
