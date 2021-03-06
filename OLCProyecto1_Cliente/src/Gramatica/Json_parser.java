
//----------------------------------------------------
// The following code was generated by CUP v0.11b 20160615 (GIT 4ac7450)
//----------------------------------------------------

package Gramatica;

import java_cup.runtime.*;
import Result.*;
import java_cup.runtime.XMLElement;

/** CUP v0.11b 20160615 (GIT 4ac7450) generated parser.
  */
@SuppressWarnings({"rawtypes"})
public class Json_parser extends java_cup.runtime.lr_parser {

 public final Class getSymbolContainer() {
    return Json_sym.class;
}

  /** Default constructor. */
  @Deprecated
  public Json_parser() {super();}

  /** Constructor which sets the default scanner. */
  @Deprecated
  public Json_parser(java_cup.runtime.Scanner s) {super(s);}

  /** Constructor which sets the default scanner. */
  public Json_parser(java_cup.runtime.Scanner s, java_cup.runtime.SymbolFactory sf) {super(s,sf);}

  /** Production table. */
  protected static final short _production_table[][] = 
    unpackFromStrings(new String[] {
    "\000\031\000\002\002\004\000\002\002\003\000\002\003" +
    "\004\000\002\003\004\000\002\003\003\000\002\003\003" +
    "\000\002\004\005\000\002\004\004\000\002\006\005\000" +
    "\002\006\003\000\002\007\005\000\002\005\005\000\002" +
    "\005\004\000\002\011\005\000\002\011\003\000\002\010" +
    "\003\000\002\010\003\000\002\010\004\000\002\010\003" +
    "\000\002\010\004\000\002\010\003\000\002\010\003\000" +
    "\002\010\003\000\002\010\003\000\002\010\003" });

  /** Access to production table. */
  public short[][] production_table() {return _production_table;}

  /** Parse-action table. */
  protected static final short[][] _action_table = 
    unpackFromStrings(new String[] {
    "\000\044\000\006\012\004\014\006\001\002\000\026\004" +
    "\026\005\032\006\030\012\004\013\043\014\006\017\027" +
    "\020\035\021\025\022\031\001\002\000\004\002\040\001" +
    "\002\000\006\015\017\020\015\001\002\000\010\002\ufffd" +
    "\012\ufffd\014\ufffd\001\002\000\010\002\000\012\004\014" +
    "\006\001\002\000\010\002\ufffc\012\ufffc\014\ufffc\001\002" +
    "\000\010\002\uffff\012\uffff\014\uffff\001\002\000\010\002" +
    "\ufffe\012\ufffe\014\ufffe\001\002\000\006\011\ufff8\015\ufff8" +
    "\001\002\000\004\016\023\001\002\000\006\011\020\015" +
    "\021\001\002\000\016\002\ufffa\011\ufffa\012\ufffa\013\ufffa" +
    "\014\ufffa\015\ufffa\001\002\000\004\020\015\001\002\000" +
    "\016\002\ufffb\011\ufffb\012\ufffb\013\ufffb\014\ufffb\015\ufffb" +
    "\001\002\000\006\011\ufff9\015\ufff9\001\002\000\024\004" +
    "\026\005\032\006\030\012\004\014\006\017\027\020\035" +
    "\021\025\022\031\001\002\000\006\011\ufff7\015\ufff7\001" +
    "\002\000\010\011\ufff1\013\ufff1\015\ufff1\001\002\000\010" +
    "\011\uffe9\013\uffe9\015\uffe9\001\002\000\010\011\uffef\013" +
    "\uffef\015\uffef\001\002\000\010\011\uffea\013\uffea\015\uffea" +
    "\001\002\000\006\017\036\021\037\001\002\000\010\011" +
    "\uffeb\013\uffeb\015\uffeb\001\002\000\010\011\uffed\013\uffed" +
    "\015\uffed\001\002\000\010\011\uffec\013\uffec\015\uffec\001" +
    "\002\000\010\011\ufff2\013\ufff2\015\ufff2\001\002\000\010" +
    "\011\uffee\013\uffee\015\uffee\001\002\000\010\011\ufff0\013" +
    "\ufff0\015\ufff0\001\002\000\004\002\001\001\002\000\006" +
    "\011\ufff3\013\ufff3\001\002\000\006\011\044\013\045\001" +
    "\002\000\016\002\ufff5\011\ufff5\012\ufff5\013\ufff5\014\ufff5" +
    "\015\ufff5\001\002\000\024\004\026\005\032\006\030\012" +
    "\004\014\006\017\027\020\035\021\025\022\031\001\002" +
    "\000\016\002\ufff6\011\ufff6\012\ufff6\013\ufff6\014\ufff6\015" +
    "\ufff6\001\002\000\006\011\ufff4\013\ufff4\001\002" });

  /** Access to parse-action table. */
  public short[][] action_table() {return _action_table;}

  /** <code>reduce_goto</code> table. */
  protected static final short[][] _reduce_table = 
    unpackFromStrings(new String[] {
    "\000\044\000\012\002\004\003\007\004\006\005\010\001" +
    "\001\000\012\004\032\005\033\010\040\011\041\001\001" +
    "\000\002\001\001\000\006\006\015\007\013\001\001\000" +
    "\002\001\001\000\006\004\011\005\012\001\001\000\002" +
    "\001\001\000\002\001\001\000\002\001\001\000\002\001" +
    "\001\000\002\001\001\000\002\001\001\000\002\001\001" +
    "\000\004\007\021\001\001\000\002\001\001\000\002\001" +
    "\001\000\010\004\032\005\033\010\023\001\001\000\002" +
    "\001\001\000\002\001\001\000\002\001\001\000\002\001" +
    "\001\000\002\001\001\000\002\001\001\000\002\001\001" +
    "\000\002\001\001\000\002\001\001\000\002\001\001\000" +
    "\002\001\001\000\002\001\001\000\002\001\001\000\002" +
    "\001\001\000\002\001\001\000\002\001\001\000\010\004" +
    "\032\005\033\010\045\001\001\000\002\001\001\000\002" +
    "\001\001" });

  /** Access to <code>reduce_goto</code> table. */
  public short[][] reduce_table() {return _reduce_table;}

  /** Instance of action encapsulation class. */
  protected CUP$Json_parser$actions action_obj;

  /** Action encapsulation object initializer. */
  protected void init_actions()
    {
      action_obj = new CUP$Json_parser$actions(this);
    }

  /** Invoke a user supplied parse action. */
  public java_cup.runtime.Symbol do_action(
    int                        act_num,
    java_cup.runtime.lr_parser parser,
    java.util.Stack            stack,
    int                        top)
    throws java.lang.Exception
  {
    /* call code in generated class */
    return action_obj.CUP$Json_parser$do_action(act_num, parser, stack, top);
  }

  /** Indicates start state. */
  public int start_state() {return 0;}
  /** Indicates start production. */
  public int start_production() {return 0;}

  /** <code>EOF</code> Symbol index. */
  public int EOF_sym() {return 0;}

  /** <code>error</code> Symbol index. */
  public int error_sym() {return 1;}



	//public String nombre_clase="n/a";
    /**Metodo al que se llama automáticamente ante algún error sintactico.*/
	private Nodo raiz=null;
	private Resultado resultado_json = new Resultado();
	
    public void syntax_error(Symbol s){
        System.err.println("Error en la Línea " + (s.right+1) +" Columna "+(s.left+1)+ ". Identificador "
        +s.value + " no reconocido." );
    }

    /**Metodo al que se llama en el momento en que ya no es posible una recuperación de
    errores.*/
    public void unrecovered_syntax_error(Symbol s) throws java.lang.Exception{
        System.err.println("Error en la Línea " + (s.right+1)+ " Columna "+(s.left+1)+". Identificador " +
        s.value + " no reconocido.");
        System.out.println("Error sintactico:"+s);
    
    }
	
	public Nodo getRaiz(){
		return raiz;
	}
	public Resultado getResultado(){
		return resultado_json;
	}
	
	private void addToResult(String id, Nodo raiz){
		if(!raiz.haveChild()){
			return;
		}
		switch(id){
			case "\"Variables\"":
				addVariable(raiz);
				break;
			case "\"score\"":
				resultado_json.Score(Double.parseDouble(raiz.hijos.get(0).lexema));
				break;
			case "\"Metodos\"":
				addMetodo(raiz);
				break;
			case "\"Comentarios\"":
				addComentario(raiz);
				break;
			case "\"Clases\"":
				addClase(raiz);
				break;
			default:
				break;
		}
	}
	
	//<editor-fold defaultstate="collapsed" desc="Auxiliares">
	private void addVariable(Nodo raiz){
		String nombre;
		String tipo;
		String funcion;
		String clase;
		for(Nodo miembro:raiz.hijos){
			nombre=miembro.hijos.get(0).hijos.get(0).lexema;
			tipo=miembro.hijos.get(1).hijos.get(0).lexema;
			funcion=miembro.hijos.get(2).hijos.get(0).lexema;
			clase=miembro.hijos.get(3).hijos.get(0).lexema;
			if(funcion.equals("n/a")){
				funcion=null;
			}
			resultado_json.add(new Variable(nombre,tipo,funcion,clase));
		}
	}
	private void addMetodo(Nodo raiz){
		String nombre;
		String tipo;
		String parametros;
		for(Nodo miembro:raiz.hijos){
			nombre=miembro.hijos.get(0).hijos.get(0).lexema;
			tipo=miembro.hijos.get(1).hijos.get(0).lexema;
			parametros=miembro.hijos.get(2).hijos.get(0).lexema;
			resultado_json.add(new Funcion(nombre,tipo,parametros));
		}
	}
	private void addComentario(Nodo raiz){
		String texto;
		for(Nodo miembro:raiz.hijos){
			texto=miembro.hijos.get(0).hijos.get(0).lexema;
			resultado_json.add(new Comentario(texto));
		}
	}
	private void addClase(Nodo raiz){
		String nombre;
		for(Nodo miembro:raiz.hijos){
			nombre=miembro.hijos.get(0).hijos.get(0).lexema;
			resultado_json.add(new Clase(nombre));
		}		
	}
	//</editor-fold>
	
	
	


/** Cup generated class to encapsulate user supplied action code.*/
@SuppressWarnings({"rawtypes", "unchecked", "unused"})
class CUP$Json_parser$actions {


    //public Nodo raiz=null;
    //String clase_actual;
	

  private final Json_parser parser;

  /** Constructor */
  CUP$Json_parser$actions(Json_parser parser) {
    this.parser = parser;
  }

  /** Method 0 with the actual generated action code for actions 0 to 300. */
  public final java_cup.runtime.Symbol CUP$Json_parser$do_action_part00000000(
    int                        CUP$Json_parser$act_num,
    java_cup.runtime.lr_parser CUP$Json_parser$parser,
    java.util.Stack            CUP$Json_parser$stack,
    int                        CUP$Json_parser$top)
    throws java.lang.Exception
    {
      /* Symbol object for return from actions */
      java_cup.runtime.Symbol CUP$Json_parser$result;

      /* select the action based on the action number */
      switch (CUP$Json_parser$act_num)
        {
          /*. . . . . . . . . . . . . . . . . . . .*/
          case 0: // $START ::= S EOF 
            {
              Object RESULT =null;
		int start_valleft = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).left;
		int start_valright = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).right;
		Object start_val = (Object)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).value;
		RESULT = start_val;
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("$START",0, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          /* ACCEPT */
          CUP$Json_parser$parser.done_parsing();
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 1: // S ::= INICIO 
            {
              Object RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					raiz=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("S",0, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 2: // INICIO ::= INICIO OBJETO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).value;
		int v2left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v2right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v2 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					v1.add(v2);
					RESULT=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("INICIO",1, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 3: // INICIO ::= INICIO ARREGLO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).value;
		int v2left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v2right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v2 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					v1.add(v2);
					RESULT=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("INICIO",1, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 4: // INICIO ::= OBJETO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = new Nodo("","INICIO");
					padre.add(v1);
					RESULT=padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("INICIO",1, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 5: // INICIO ::= ARREGLO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = new Nodo("","INICIO");
					padre.add(v1);
					RESULT=padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("INICIO",1, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 6: // OBJETO ::= lKey MIEMBROS rKey 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).value;
		
					RESULT=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("OBJETO",2, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 7: // OBJETO ::= lKey rKey 
            {
              Nodo RESULT =null;

              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("OBJETO",2, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 8: // MIEMBROS ::= MIEMBROS coma PAR 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).value;
		int v2left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v2right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v2 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					v1.add(v2);
					RESULT=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("MIEMBROS",4, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 9: // MIEMBROS ::= PAR 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = new Nodo("","MIEMBROS");
					padre.add(v1);
					RESULT=padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("MIEMBROS",4, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 10: // PAR ::= tk_Cadena d_puntos VALOR 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).value;
		int v2left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v2right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v2 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = new Nodo(v1,"PAR");
					//padre.add(v2);
					padre.childSteal(v2);
					addToResult(v1,padre);//nuevo
					RESULT=padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("PAR",5, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 11: // ARREGLO ::= lBrack ELEMENTOS rBrack 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)).value;
		
					RESULT=v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("ARREGLO",3, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 12: // ARREGLO ::= lBrack rBrack 
            {
              Nodo RESULT =null;

              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("ARREGLO",3, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 13: // ELEMENTOS ::= ELEMENTOS coma VALOR 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)).value;
		int v2left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v2right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v2 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = v1;
					padre.add(v2);
					RESULT = padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("ELEMENTOS",7, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-2)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 14: // ELEMENTOS ::= VALOR 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					Nodo padre = new Nodo("","VALOR");
					padre.add(v1);
					RESULT = padre;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("ELEMENTOS",7, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 15: // VALOR ::= tk_Cadena 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"tk_Cadena");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 16: // VALOR ::= tk_Entero 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"tk_Entero");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 17: // VALOR ::= menos tk_Entero 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"tk_Entero");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 18: // VALOR ::= tk_Racional 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"tk_Racional");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 19: // VALOR ::= menos tk_Racional 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"tk_Racional");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.elementAt(CUP$Json_parser$top-1)), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 20: // VALOR ::= OBJETO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 21: // VALOR ::= ARREGLO 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		Nodo v1 = (Nodo)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = v1;
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 22: // VALOR ::= verdadero 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
			
					RESULT = new Nodo(v1,"Booleano");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 23: // VALOR ::= falso 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"Booleano");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 24: // VALOR ::= nulo 
            {
              Nodo RESULT =null;
		int v1left = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).left;
		int v1right = ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()).right;
		String v1 = (String)((java_cup.runtime.Symbol) CUP$Json_parser$stack.peek()).value;
		
					RESULT = new Nodo(v1,"Nulo");
				
              CUP$Json_parser$result = parser.getSymbolFactory().newSymbol("VALOR",6, ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), ((java_cup.runtime.Symbol)CUP$Json_parser$stack.peek()), RESULT);
            }
          return CUP$Json_parser$result;

          /* . . . . . .*/
          default:
            throw new Exception(
               "Invalid action number "+CUP$Json_parser$act_num+"found in internal parse table");

        }
    } /* end of method */

  /** Method splitting the generated action code into several parts. */
  public final java_cup.runtime.Symbol CUP$Json_parser$do_action(
    int                        CUP$Json_parser$act_num,
    java_cup.runtime.lr_parser CUP$Json_parser$parser,
    java.util.Stack            CUP$Json_parser$stack,
    int                        CUP$Json_parser$top)
    throws java.lang.Exception
    {
              return CUP$Json_parser$do_action_part00000000(
                               CUP$Json_parser$act_num,
                               CUP$Json_parser$parser,
                               CUP$Json_parser$stack,
                               CUP$Json_parser$top);
    }
}

}
