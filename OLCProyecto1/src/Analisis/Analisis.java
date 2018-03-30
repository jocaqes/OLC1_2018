package Analisis;
import Gramatica.Escaner;
import Gramatica.Parser;
import Estructuras.Nodo;
import java.io.BufferedReader;
import java.io.StringReader;
import Tabla.*;
import java.io.File;


public class Analisis {
    
    private Parser analisis;
    public TablaSimbolo tabla_simbolos;
    
    
    public Analisis(){
        analisis=null;
        tabla_simbolos=new TablaSimbolo();
    }
    
    
    public  boolean analizar(String ruta){
        Escaner aux = new Escaner(new BufferedReader(new StringReader(Archivo.leer(ruta))));//util para recuperar los comentarios
        analisis = new Parser(aux);
        try {
            analisis.parse();
            if(analisis.getRaiz()!=null){//nuevo
                tabla_simbolos.add(analisis.getRaiz());
                tabla_simbolos.addComentario(aux.getComentarios(), analisis.getClassId());
                tabla_simbolos.addClase(analisis.getMyself());//nuevo
            }
            return true;
        } catch (Exception ex) {
            System.out.println(ex.toString());
            return false;
        }
    }
    
    public void analizarFichero(String ruta){
        String []rutas = ruta.split(",");
        if(rutas.length<2)
            return;
        reset();//limpio la tabla de simbolos
        leerFichero(rutas[0]);
        leerFichero(rutas[1]);
    }
    
    public  Nodo getRaiz(){
        if(analisis==null)
            return null;
        return analisis.getRaiz();
    }
    
    public void generarJSON(){
        Archivo.generarJSON("D:\\Sistemas\\2018\\OLC\\proyecto_1\\result.json", tabla_simbolos.getJson());
    }
    
    public void reset(){
        tabla_simbolos.reset();
    }
    
    private void leerFichero(String ruta){
        if(ruta.contains("/")){
            ruta=ruta.replace("/", "\\");
        }
        File carpeta = new File(ruta);
        File[] archivos = carpeta.listFiles();
        if(archivos==null){//la ruta estaba mal
            return;
        }
        int limite = archivos.length;
        String nombre_archivo;
        for(int i=0;i<limite;i++){
            if(archivos[i].isDirectory()){//si hay mas carpetas las reviso
                leerFichero(archivos[i].getPath());
            }else if(archivos[i].isFile()){//si es un archivo
                nombre_archivo=archivos[i].getPath();
                if(nombre_archivo.endsWith(".java")){
                    analizar(nombre_archivo);
                }
            }
        }
    }
}
