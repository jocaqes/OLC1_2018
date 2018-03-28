package Result;


public class Variable {
    public String nombre;
    public String tipo;
    public String clase;
    public String funcion;

    public Variable(String nombre, String tipo, String funcion, String clase) {
        this.nombre = nombre;
        this.tipo = tipo;
        this.clase = clase;
        if(funcion==null)
        this.funcion = clase;
    }
        
}
