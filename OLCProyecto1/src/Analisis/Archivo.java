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


public class Archivo {
    
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
                System.out.println("Ruta no existe");//debug
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
