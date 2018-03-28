package View;

import java.awt.Rectangle;
import javax.swing.JTextArea;
/**
 *
 * @author Jose Quiñonez
 */
public class LineaImp  implements ModeloLinea {
    private JTextArea mi_area;

    public LineaImp(JTextArea mi_area) {
        this.mi_area = mi_area;
    }
    

    @Override
    public int getNumeroLineas() {
        return mi_area.getLineCount();
    }

    @Override
    public Rectangle getRectanguloLinea(int linea) {
        try{
            return mi_area.modelToView(mi_area.getLineStartOffset(linea));
        }catch(Exception e){
            return new Rectangle();
        }
    }
    
}
