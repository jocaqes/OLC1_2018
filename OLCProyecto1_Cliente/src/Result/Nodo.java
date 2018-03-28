package Result;

import java.util.ArrayList;
import java.util.List;

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
        hijos = new ArrayList<>();
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
    
    public void childSteal(Nodo raiz){
        if(raiz!=null){
            if(raiz.token.equals("VALOR")){
                for(Nodo child:raiz.hijos){
                    add(child);
                }
            }else{
                add(raiz);
            }
        }
    }
    
    public boolean haveChild(){
        return hijos.size()>0;
    }

    
}
