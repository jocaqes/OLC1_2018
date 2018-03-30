
package Tabla;

public class Simbolo {
    private String id;
    private String tipo;
    private String ambito;
    private String funcion;

    public Simbolo() {
        ambito="n/a";
        funcion="n/a";
    }


    public String getId() {
        return id;
    }
    public void setId(String identificador) {
        this.id = identificador;
    }
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public String getAmbito() {
        return ambito;
    }
    public void setAmbito(String ambito) {
        this.ambito = ambito;
    }
    public String getFuncion() {
        return funcion;
    }
    public void setFuncion(String funcion) {
        this.funcion = funcion;
    }
    
}
