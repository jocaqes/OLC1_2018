/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Tabla;

import java.util.ArrayList;
import java.util.List;


public class Clase {
    private String id;
    private List<String> metodos;

    public Clase() {
        metodos = new ArrayList<>();
    }
    
    public void add(String metodo){
        metodos.add(metodo);
    }
    
    public String listarMetodos(){
        String salida="";
        for(String metodo:metodos){
            salida+=metodo;
        }
        return salida;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }
    
    
    
    
}
