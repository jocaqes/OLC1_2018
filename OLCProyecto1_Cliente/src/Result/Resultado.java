/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Result;
import java.util.List;
import java.util.ArrayList;


public class Resultado {
    
    private double Score;
    private final List<Variable> var;
    private final List<Funcion> func;
    private final List<Clase> cla_ss;
    private final List<Comentario> comm;
    public enum Peticion{NOMBRE,TIPO,FUNCION,CANTIDAD,TEXTO}

    /**
     *Genera un objeto resultado e inicializa
     * sus listas internas
     */
    public Resultado() {
        var=new ArrayList<>();
        func=new ArrayList<>();
        cla_ss=new ArrayList<>();
        comm=new ArrayList<>();
    }
    
    //<editor-fold defaultstate="collapsed" desc="Manejo de Variables">
    public String variables(){
        String salida="";
        for(Variable valor:var){
            salida+=valor.tipo+","+valor.nombre+","+valor.clase+","+valor.funcion+";";
        }
        return salida;
    }
    public String variables(Peticion atributo){
        switch(atributo){
            case NOMBRE:
                String salida="";
                for(Variable valor:var){
                    salida+=valor.nombre+";";
                }
                return salida;
            case CANTIDAD:
                return Integer.toString(var.size());
            default:
                return "0";
        }
    }
    public String variables(int index,Peticion atributo){
        if(index<0||index>=var.size())
            return null;
        switch(atributo){
            case NOMBRE:
                return var.get(index).nombre;
            case TIPO:
                return var.get(index).tipo;
            case FUNCION:
                return var.get(index).funcion;
            default:
                return "INVALIDO";            
        }
    }
    //</editor-fold>
    
    //<editor-fold defaultstate="collapsed" desc="Manejo de Metodos">
    public String metodos(){
        String salida="";
        for(Funcion valor:func){
            salida+=valor.tipo+","+valor.nombre+","+valor.parametros+";";
        }
        return salida;
    }
    public String metodos(Peticion atributo){
        switch(atributo){
            case NOMBRE:
                String salida="";
                for(Funcion valor:func){
                    salida+=valor.nombre+";";
                }
                return salida;
            case CANTIDAD:
                return Integer.toString(func.size());
            default:
                return "0";
        }
    }
    public String metodos(int index,Peticion atributo){
        if(index<0||index>=func.size())
            return null;
        switch(atributo){
            case NOMBRE:
                return func.get(index).nombre;
            case TIPO:
                return func.get(index).tipo;
            case FUNCION:
                return func.get(index).parametros;
            default:
                return "INVALIDO";            
        }
    }
    //</editor-fold>
    
    //<editor-fold defaultstate="collapsed" desc="Manejo de Clases">
    public String clases(){
        String salida="";
        for(Clase valor:cla_ss){
            salida+=valor.nombre+";";
        }
        return salida;
    }
    public String clases(Peticion atributo){
        switch(atributo){
            case NOMBRE:
                return clases();
            case CANTIDAD:
                return Integer.toString(cla_ss.size());
            default:
                return "0";
        }
    }
    public String clases(int index,Peticion atributo){
        if(index<0||index>=cla_ss.size())
            return null;
        switch(atributo){
            case NOMBRE:
                return cla_ss.get(index).nombre;
            default:
                return "INVALIDO";            
        }
    }
    //</editor-fold>
    
    //<editor-fold defaultstate="collapsed" desc="Manejo de Comentario">    
    public String comentarios(){
        String salida="";
        for(Comentario valor:comm){
            salida+=valor.texto+";";
        }
        return salida;
    }
    public String comentarios(Peticion atributo){
        switch(atributo){
            case TEXTO:
                return comentarios();
            case CANTIDAD:
                return Integer.toString(comm.size());
            default:
                return "0";
        }
    }
    public String comentarios(int index,Peticion atributo){
        if(index<0||index>=comm.size())
            return null;
        switch(atributo){
            case TEXTO:
                return comm.get(index).texto;
            default:
                return "INVALIDO";            
        }
    }
    //</editor-fold>
    
    
    public void add(Variable item){
        var.add(item);
    }
    public void add(Funcion item){
        func.add(item);
    }
    public void add(Clase item){
        cla_ss.add(item);
    }
    public void add(Comentario item){
        comm.add(item);
    }

    
    public double Score() {
        return Score;
    }

    public void Score(double Score) {
        this.Score = Score;
    }


    
    
    
}
