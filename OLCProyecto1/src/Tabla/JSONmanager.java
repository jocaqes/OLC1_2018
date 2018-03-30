package Tabla;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;


public class JSONmanager {
    private JSONObject main_object;
    private JSONArray score;
    private JSONArray clases;
    private JSONArray metodos;
    private JSONArray variables;
    private JSONArray comentarios;


    public JSONmanager() {
        main_object=new JSONObject();
        score=new JSONArray();
        clases=new JSONArray();
        metodos=new JSONArray();
        variables=new JSONArray();
        comentarios=new JSONArray();
    }
    
    public void add(Simbolo nuevo){
        JSONObject aux = new JSONObject();
        aux.put("Nombre", nuevo.getId());
        aux.put("Tipo", nuevo.getTipo());
        aux.put("Funcion", nuevo.getFuncion());
        aux.put("Clase", nuevo.getAmbito());
        variables.add(aux);
    }
    
    public void add(Funcion nuevo){
        JSONObject aux = new JSONObject();
        aux.put("Nombre", nuevo.getId());
        aux.put("Tipo", nuevo.getTipo());
        aux.put("Parametros",new Integer(nuevo.getParametros()));
        metodos.add(aux);
    }
    
    public void add(Comentario nuevo){
        JSONObject aux = new JSONObject();
        aux.put("Texto",nuevo.getTexto());
        comentarios.add(aux);
    }
    
    public void add(Clase nueva){
        JSONObject aux = new JSONObject();
        aux.put("Nombre", nueva.getId());
        clases.add(aux);
    }
    
    public void add(int no_clases, int no_variables, int no_metodos, int no_comentarios){
        double calculo_clases;
        double calculo_variables;
        double calculo_metodos;
        double calculo_comentarios;
        if(clases.size()==0){
            calculo_clases=0;
        }else{
            calculo_clases=(clases.size()/no_clases*0.25);
        }
        if(variables.size()==0){
            calculo_variables=0;
        }else{
            calculo_variables=(variables.size()*2.0/no_variables*0.25);
        }
        if(metodos.size()==0){
            calculo_metodos=0;
        }else{
            calculo_metodos=(metodos.size()*2.0/no_metodos*0.25);
        }
        if(comentarios.size()==0){
            calculo_comentarios=0;
        }else{
            calculo_comentarios=(comentarios.size()*2.0/no_comentarios*0.25);
        }
        double resultado = calculo_clases+calculo_variables+calculo_metodos+calculo_comentarios;
        score.add(new Double(String.format("%.3f", resultado)));
    }
    
    public String getJson(){
        main_object.put("score", score);
        main_object.put("Clases", clases);
        main_object.put("Variables", variables);
        main_object.put("Metodos", metodos);
        main_object.put("Comentarios",comentarios);
        String texto = main_object.toJSONString();
        reset();
        return texto;
    }
        
    public void reset(){
        main_object.clear();
        score.clear();
        clases.clear();
        metodos.clear();
        variables.clear();
        comentarios.clear();
    }
    
    
    
}
