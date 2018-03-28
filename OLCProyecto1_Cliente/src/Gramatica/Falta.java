
package Gramatica;


public class Falta {
    private int fila;
    private int columna;
    private String lexema;
    private String token_esperado;
    public enum Tipo{LEXICO,SINTACTICO,SEMANTICO};
    private Tipo tipo;

    public Falta(int fila, int columna, String lexema, String token_esperado, Tipo tipo) {
        this.fila = fila;
        this.columna = columna;
        this.lexema = lexema;
        this.token_esperado = token_esperado;
        this.tipo = tipo;
    }

    
    public String errMsj(){
        return "Error "+tipo.name()+": se esperaba "+token_esperado+"; Se obtuvo: "+lexema+" en linea:"+fila+" y columna:"+columna;
    }
    
    public int getFila() {
        return fila;
    }

    public void setFila(int fila) {
        this.fila = fila;
    }

    public int getColumna() {
        return columna;
    }

    public void setColumna(int columna) {
        this.columna = columna;
    }

    public String getLexema() {
        return lexema;
    }

    public void setLexema(String lexema) {
        this.lexema = lexema;
    }

    public String getToken_esperado() {
        return token_esperado;
    }

    public void setToken_esperado(String token_esperado) {
        this.token_esperado = token_esperado;
    }

    public Tipo getTipo() {
        return tipo;
    }

    public void setTipo(Tipo tipo) {
        this.tipo = tipo;
    }
    
    
    
    
    
    
    
    
}
