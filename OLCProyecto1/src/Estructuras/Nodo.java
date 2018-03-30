/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Estructuras;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author LUIS QUIÑONEZ
 */
public class Nodo {
    public String lexema;
    public String token;
    //public int fila, columna;
    public List<Nodo> hijos;

    public Nodo(String lexema,String token) {
        this.lexema = lexema;
        this.token = token;
        /*this.fila = fila;
        this.columna = columna;*/
        hijos = new ArrayList<Nodo>();
    }
    
    public Nodo(){
        //Constructor vacio, por costumbre
    }
    
    public void add(Nodo hijo){
        if(hijo==null){
            return;
        }
        hijos.add(hijo);
    }

    
}
