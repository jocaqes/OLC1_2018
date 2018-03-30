package Tabla;

import java.util.ArrayList;
import java.util.List;
import Estructuras.Nodo;


public class TablaSimbolo {
    private List<Clase> lista_clases;
    public List<Simbolo> lista_simbolos;
    public List<Funcion> lista_funciones;
    private List<Comentario> lista_comentarios;
    private int no_clases,no_variables,no_metodos,no_comentarios;
    private JSONmanager manager;
    

    public TablaSimbolo() {
        lista_clases = new ArrayList<>();
        lista_simbolos = new ArrayList<>();
        lista_funciones = new ArrayList<>();
        lista_comentarios = new ArrayList<>();
        manager=new JSONmanager();
        no_clases=no_variables=no_metodos=no_comentarios=0;
    }
    
    public void add(Nodo raiz){//metodo para agregar todo lo necesario a la tabla de simbolos
        add(raiz,"n/a","n/a");
    }
   
    private void add(Nodo raiz, String clase, String funcion){//metodo recursivo para revisar el arbol
        if(raiz==null)
            return;
        String nombre_clase="n/a";
        String nombre_funcion="n/a";
        for(Nodo son:raiz.hijos){
            if(son!=null){
                if(son.token=="Clase_id"){
                    nombre_clase=son.lexema;
                }else if(son.token=="CUERPO"){//me adentro en el arbol
                    add(son,nombre_clase,"n/a");
                }else if(son.token=="DECLARACION"){//aqui agrego cualquier simbolo, global o local(excepto si esta dentro de otra sentencia, solo dentro de metodos 
                    Simbolo nuevo=null;
                    int no_hijos = son.hijos.size();
                    int i;
                    Nodo hijo=null;
                    String tipo = "Object";
                    for(i=0;i<no_hijos;i++){
                        hijo=son.hijos.get(i);
                        switch(i){
                            case 0:
                                tipo=hijo.lexema;
                                break;
                            default:
                                nuevo = new Simbolo();
                                nuevo.setTipo(tipo);
                                nuevo.setAmbito(clase);
                                nuevo.setId(hijo.lexema);
                                nuevo.setFuncion(funcion);
                                if(check(nuevo)){
                                    no_variables++;//aumento la cuenta de variables
                                    break;
                                }else{
                                    no_variables++;//aumento la cuenta de variables
                                    lista_simbolos.add(nuevo);
                                }
                        }
                        
                    }
                }else if(son.token=="METODO"){
                    int hijos=son.hijos.size();
                    Funcion nuevo;
                    switch(hijos){//el switch agrega la funcion a la lista
                        case 3://no tiene parametros ni sentencias
                            nuevo =new Funcion(son.hijos.get(2).lexema,son.hijos.get(0).lexema,son.hijos.get(1).lexema,clase);
                            if(check(nuevo)){
                                break;
                            }else{
                                lista_funciones.add(nuevo);
                            }
                            break;
                        default://si tiene parametros(4 hijos) o si tiene sentencias
                            nuevo = new Funcion(son.hijos.get(2).lexema,son.hijos.get(0).lexema,son.hijos.get(1).lexema,clase,son.hijos.get(3));
                            if(check(nuevo)){
                                break;
                            }else{
                                lista_funciones.add(nuevo);
                            }
                    }
                    no_metodos++;//aumento la cuenta de funciones
                    add(son,clase,"n/a");//el add se adentra para revisar posibles variables dentro del metodo en SENTENCIA
                }else if(son.token=="SENTENCIA"){
                    add(son,clase,nombre_funcion);
                }
            }
        }
    }
    
    public void addComentario(List<Comentario> lista, String id_clase){
        no_comentarios+=lista.size();
        for(Comentario item:lista){
            item.setClase(id_clase);
            if(!check(item)){
                lista_comentarios.add(item);
            }
        }
    }
       
    public void addClase(Clase item){
        if(!check(item)){
            lista_clases.add(item);
        }
        no_clases++;
    }
    
    private boolean check(Simbolo nuevo){//debug
        for(Simbolo simbolo:lista_simbolos){
            /*if(simbolo.getAmbito().equals(nuevo.getAmbito())){
                continue;
            }*/
            if(simbolo.getId().equals(nuevo.getId())&&simbolo.getTipo().equals(nuevo.getTipo())){
                //manager.add(nuevo);
                manager.add(simbolo);
                return true;
            }
        }
        return false;
    }
    
    private boolean check(Funcion nuevo){//debug
        for(Funcion funcion:lista_funciones){
            /*if(funcion.getClase_padre().equals(nuevo.getClase_padre())){
                continue;
            }*/
            if(funcion.getId().equals(nuevo.getId())&&funcion.listarParametros().equals(nuevo.listarParametros())&&funcion.getNo_lineas()==nuevo.getNo_lineas()){
                //manager.add(nuevo);
                manager.add(funcion);
                return true;
            }
        }
        return false;
    }
    
    private boolean check(Comentario nuevo){
        for(Comentario comment:lista_comentarios){
           /* if(comment.getClase().equals(nuevo.getClase())){
                continue;
            }*/
            if(comment.getTexto().equals(nuevo.getTexto())){
                //manager.add(nuevo);
                manager.add(comment);
                return true;
            }
        }
        return false;
    }
    
    private boolean check(Clase nueva){
        for(Clase clase: lista_clases){
            if(clase.getId().equals(nueva.getId())&&clase.listarMetodos().equals(nueva.listarMetodos())){
                manager.add(nueva);
                manager.add(clase);
                return true;
            }
        }
        return false;
    }
    
 /*   */
    public void debugPrintItems(){
        if(lista_simbolos.size()==0)
            return;
        for(Simbolo item:lista_simbolos){
            System.out.println("Simbolo:"+item.getId()+" Tipo:"+item.getTipo()+" Funcion/Metodo:"+item.getFuncion()+" Ambito:"+item.getAmbito());
        }
    }
    
    public void debugPrintFunciones(){
        for(Funcion item:lista_funciones){
            System.out.println("Nombre_funcion:"+item.getId()+" Clase:"+item.getClase_padre()+" Cant_lineas:"+item.getNo_lineas()+" Parametros:"+item.listarParametros());
        }
    }
    
    public void debugPrintComentarios(){
        for(Comentario item:lista_comentarios){
            System.out.println("Comentario:"+item.getTexto()+" Clase:"+item.getClase());
        }
    }
   /*
    public void debugPrintCount(){
        System.out.println("Metodos:"+no_funciones+" Variables:"+no_variables+" Comentarios:"+no_comentarios);
    }*/
    
    public String getJson(){
        manager.add(no_clases, no_variables, no_metodos, no_comentarios);
        return manager.getJson();
    }
    
    public void reset(){
        lista_simbolos.clear();
        lista_funciones.clear();
        lista_comentarios.clear();
        no_clases=no_variables=no_metodos=no_comentarios=0;
        manager.reset();
    }
    

}
