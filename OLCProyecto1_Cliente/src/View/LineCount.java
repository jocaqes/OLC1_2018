package View;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.RenderingHints;
import javax.swing.JComponent;
import javax.swing.JTextArea;

/**
 *Componente basado en un ejemplo en linea para colocar el numero
 * de lineas dentro de un JScrollPane
 * @author Jose Quiñonez
 */
public class LineCount extends JComponent {

    private ModeloLinea mi_modelo;
    
    /**
     *Llama al constructor por defecto de JComponent
     */
    public LineCount() {
        super();
    }

    /**
     *Llama al constructor por defecto de JComponent
     * y setea el ModeloLinea
     * @param mi_modelo
     */
    public LineCount(ModeloLinea mi_modelo) {
        this();
        this.mi_modelo = mi_modelo;
    }
    
    public void setModeloLinea(ModeloLinea mi_modelo){
        this.mi_modelo=mi_modelo;
        if(mi_modelo!=null){
            actualizar();
        }
        repaint();
    }

    
    
    public void actualizar(){
        int limite=mi_modelo.getNumeroLineas();
        if(getGraphics()==null)
            return;
        int ancho = getGraphics().getFontMetrics().stringWidth(String.valueOf(limite))+2;
        JComponent c = (JComponent)getParent();
        if(c==null)//si no esta dentro de un contenedor
            return;
        Dimension dimension = c.getPreferredSize();
        if(c instanceof javax.swing.JViewport){//conseguir el JScrollPane view principal
            javax.swing.JViewport vista = (javax.swing.JViewport)c;
            java.awt.Component padre = vista.getParent();
            if(padre!=null&&padre instanceof javax.swing.JScrollPane){
                javax.swing.JScrollPane scroll = (javax.swing.JScrollPane)vista.getParent();
                dimension = scroll.getViewport().getView().getPreferredSize();
            }
        }
        if(ancho>getPreferredSize().width||ancho<getPreferredSize().width){
            setPreferredSize(new Dimension(ancho+2,dimension.height));
            revalidate();
            repaint();
        }
        
        
    }
    
    @Override
    public void paintComponent(Graphics g){
        super.paintComponent(g);
        if(mi_modelo==null){
            return;
        }
        Graphics2D d2 =  (Graphics2D)g;
        d2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g.setColor(getBackground());
        d2.fillRect(0, 0, getWidth(), getHeight());
        g.setColor(getForeground());
        int no_lineas = mi_modelo.getNumeroLineas();
        for(int i=0;i<no_lineas;i++){
            Rectangle aux = mi_modelo.getRectanguloLinea(i);
            String no_linea = String.valueOf(i+1);
            int y=aux.y+aux.height-3;
            int x=1;
            d2.drawString(no_linea, x, y);
        }
    }
    
   
    
     
    
}
