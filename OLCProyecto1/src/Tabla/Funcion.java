/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Tabla;

import java.util.ArrayList;
import java.util.List;
import Estructuras.Nodo;


public class Funcion {
    private String id;
    private String tipo;
    private String clase_padre;
    private int no_lineas;
    private List<Parametro> mis_parametros;

    public Funcion() {
        mis_parametros=new ArrayList<>();
    }

    public Funcion(String id, String tipo, String no_lineas, String clase_padre) {
        this.id = id;
        this.tipo = tipo;
        this.clase_padre = clase_padre;
        this.no_lineas = Integer.parseInt(no_lineas);
        mis_parametros=new ArrayList<>();
    }

    public Funcion(String id, String tipo, String no_lineas,String clase_padre, Nodo raiz) {
        this.id = id;
        this.tipo = tipo;
        this.clase_padre=clase_padre;
        this.no_lineas = Integer.parseInt(no_lineas);
        mis_parametros=new ArrayList<>();
        addParametros(raiz);
    }

    private void addParametros(Nodo raiz){
        if(raiz==null)
            return;
        String tipo="";
        for(Nodo hijo:raiz.hijos){//siempre vienen en pares
            if(hijo.token=="TIPODATO"){
                tipo=hijo.lexema;
            }else{
                mis_parametros.add(new Parametro(tipo,hijo.lexema));
            }
        }
    }
 
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    
    public boolean tengoParametros(){
        return mis_parametros.size()>0;
    }
    
    public String listarParametros(){//debug
        String salida="";
        for(Parametro item:mis_parametros){
            salida+="Tipo:"+item.getTipo()+", Id:"+item.getId()+";";
        }
        return salida;
    }

    public int getNo_lineas() {
        return no_lineas;
    }

    public void setNo_lineas(int no_lineas) {
        this.no_lineas = no_lineas;
    }

    public String getClase_padre() {
        return clase_padre;
    }

    public void setClase_padre(String clase_padre) {
        this.clase_padre = clase_padre;
    }
    
    public int getParametros(){
        return mis_parametros.size();
    }
    
    
    
}
