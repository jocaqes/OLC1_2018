package View;
import java.awt.Rectangle;

public interface ModeloLinea {
    
    /**
     *Retorna el numero de lineas del componente especificado
     * @return
     * Numero de lineas
     */
    public int getNumeroLineas();
    
    /**
     *
     * @param linea
     * @return 
     * El rectangulo que representa la linea actual
     * o uno nuevo en caso de que no haya linea actual.
     */
    public Rectangle getRectanguloLinea(int linea);
}
