package Analisis;
import Gramatica.Escaner;
import Gramatica.Parser;
import Gramatica.Json_Escaner;
import Gramatica.Json_parser;
//import Estructuras.Nodo;
import java.io.BufferedReader;
import java.io.StringReader;
//import Tabla.*;
//import java.io.File;


public class Analisis {
    
   // private  Parser analisis;
   // public TablaSimbolo tabla_simbolos;
    private static String codigo;
    private static int contador;
    
    public Analisis(){
        //tabla_simbolos=new TablaSimbolo();
    }
    
    
    public static String analizar(String texto){
        
        Escaner aux = new Escaner(new BufferedReader(new StringReader(texto)));//util para recuperar los comentarios
        Parser analisis = new Parser(aux);
        try {
            analisis.parse();
            if(analisis.hayFaltas()){
                return analisis.getFaltas();
            }
            return null;
        } catch (Exception ex) {
            System.out.println(ex.toString());
            return "Exception";
        }
    }
    
    public static Result.Resultado analizarJson(String texto){
        Json_Escaner aux = new Json_Escaner(new BufferedReader(new StringReader(texto)));//util para recuperar los comentarios
        Json_parser analisis = new Json_parser(aux);
        try {
            analisis.parse();
            return analisis.getResultado();
            //Result.Nodo raiz = analisis.getRaiz();
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
        return null;
    }
    

    //<editor-fold defaultstate="collapsed" desc="Codigo Debug">
    public static String imprimirArbol(Result.Nodo raiz){
        codigo = "digraph G{\n";
        if(raiz.lexema.isEmpty())
            codigo += "n0[label=\"" + raiz.token + "\"];\n";
        else
            codigo += "n0[label=\"" + raiz.lexema + "\"];\n";
        contador = 1;
        recorrerArbol("n0",raiz);
        codigo +="}";
        return codigo;
    }
    public static void recorrerArbol(String raiz, Result.Nodo padre){
        for(Result.Nodo hijo:padre.hijos){
            String nombre_hijo = "n"+contador;
            if(hijo.lexema.isEmpty()){
                codigo += nombre_hijo + "[label=\"" + hijo.token.replace("\"","&#34;") + "\"];\n";//replace es temporal
            }
            else
                codigo += nombre_hijo + "[label=\"" + hijo.lexema + "\"];\n";
            codigo += raiz + "->" + nombre_hijo + ";\n";
            contador++;
            recorrerArbol(nombre_hijo, hijo);
        }
    }
    //</editor-fold>

    
    public void reset(){
        //tabla_simbolos.reset();
    }
    

}
