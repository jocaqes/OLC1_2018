
package Gramatica;
import java_cup.runtime.Symbol;
import java.util.List;//nuevo
import java.util.ArrayList;//nuevo
import Tabla.Comentario;//nuevo
//import analizador.*;
%%
%cupsym sym
%class Escaner
%cup
%public
%unicode
%line
%column
%char
%ignorecase

//------------------------------------------------------------------------
//EXPRESIONES REGULARES
Comment 		= {Multi} | {Simple}
Multi   		= "/*" [^*] ~"*/" | "/*" "*"+ "/"
Simple		    = "//"[^\r\n]* [^\r\n]
letra 			= [a-zA-ZÑñ]+
numero 			= [0-9]
entero 			= {numero}+
racional 		= {numero}+("."{numero}+)
caracter 		= [\'][^\'][\']
cadena 			= [\"][^\"]*[\"]
id 				= {letra}({letra}|{numero}|"_")*
//-------------------------------------------------------------------------

%{
    //codigo de java
    String nombre;
	private List<Comentario> lista_comentarios=new ArrayList<>();//nuevo
    public void imprimir(String dato,String cadena){
    	//System.out.println(dato+" : "+cadena);
    }
    public void imprimir(String cadena){
    	//System.out.println(cadena+" soy reservada");
    }
	private void addComentario(String texto){//nuevo
		lista_comentarios.add(new Comentario(texto));
	}
	public List<Comentario> getComentarios(){//nuevo
		return lista_comentarios;
	}
%}

%%
//Comentarios
{Comment}				{addComentario(yytext().trim());}

//RESERVADAS
	//Visibilidad
"private"				{return new Symbol(sym.vis_Private,yycolumn,yyline,yytext());}
"public"				{return new Symbol(sym.vis_Public,yycolumn,yyline,yytext());}
"protected"				{return new Symbol(sym.vis_Protected,yycolumn,yyline,yytext());}
"final"					{return new Symbol(sym.vis_Final,yycolumn,yyline,yytext());}


	//De la Clase
"Import"				{return new Symbol(sym.res_Import,yycolumn,yyline,yytext());}
"class"					{return new Symbol(sym.res_Class,yycolumn,yyline,yytext());}
"new"					{return new Symbol(sym.res_New,yycolumn,yyline,yytext());}

	//Tipos de dato
"int"					{return new Symbol(sym.tipo_Int,yycolumn,yyline,yytext());}
"boolean"				{return new Symbol(sym.tipo_Bool,yycolumn,yyline,yytext());}
"String"				{return new Symbol(sym.tipo_String,yycolumn,yyline,yytext());}
"char"					{return new Symbol(sym.tipo_Char,yycolumn,yyline,yytext());}
"double"				{return new Symbol(sym.tipo_Double,yycolumn,yyline,yytext());}
"void"					{return new Symbol(sym.tipo_Void,yycolumn,yyline,yytext());}
//objeto, como es un id no lo meto aqui

	//Sentencias de Control
"if"					{return new Symbol(sym.sentencia_If,yycolumn,yyline,yytext());}
"else"					{return new Symbol(sym.sentencia_Else,yycolumn,yyline,yytext());}
"for"					{return new Symbol(sym.sentencia_For,yycolumn,yyline,yytext());}
"while"					{return new Symbol(sym.sentencia_While,yycolumn,yyline,yytext());}
"switch"				{return new Symbol(sym.sentencia_Switch,yycolumn,yyline,yytext());}
"case"					{return new Symbol(sym.sentencia_Case,yycolumn,yyline,yytext());}
"default"				{return new Symbol(sym.sentencia_Default,yycolumn,yyline,yytext());}
"do"					{return new Symbol(sym.sentencia_Do,yycolumn,yyline,yytext());}

	//Sentencias de salida
"Break"					{return new Symbol(sym.res_Break,yycolumn,yyline,yytext());}
"Return"				{return new Symbol(sym.res_Return,yycolumn,yyline,yytext());}	

//Relacionales
"!="					{return new Symbol(sym.relacional_Diferente,yycolumn,yyline,yytext());} 
"<="					{return new Symbol(sym.relacional_MenorIgual,yycolumn,yyline,yytext());} 
">="					{return new Symbol(sym.relacional_MayorIgual,yycolumn,yyline,yytext());} 
"<"						{return new Symbol(sym.relacional_Menor,yycolumn,yyline,yytext());} 
">"						{return new Symbol(sym.relacional_Mayor,yycolumn,yyline,yytext());} 
//"=="					{return new Symbol(sym.relacional_Igual,yycolumn,yyline,yytext());} 	

//Logicos
"&&"					{return new Symbol(sym.logico_And,yycolumn,yyline,yytext());}
"||"					{return new Symbol(sym.logico_Or,yycolumn,yyline,yytext());}
"!"						{return new Symbol(sym.logico_Not,yycolumn,yyline,yytext());}

//Incremento o decremento
//"++"					{return new Symbol(sym.aumentar,yycolumn,yyline,yytext());}
//"--"					{return new Symbol(sym.disminuir,yycolumn,yyline,yytext());}
//Booleanos
"true"					{return new Symbol(sym.verdadero,yycolumn,yyline,yytext());}
"false"					{return new Symbol(sym.falso,yycolumn,yyline,yytext());}

//MATEMATICOS
"+"					{return new Symbol(sym.mas,yycolumn,yyline,yytext());}
"-"					{return new Symbol(sym.menos,yycolumn,yyline,yytext());}
"*"					{return new Symbol(sym.por,yycolumn,yyline,yytext());}
"/"					{return new Symbol(sym.dividido,yycolumn,yyline,yytext());}
"="					{return new Symbol(sym.igual,yycolumn,yyline,yytext());}
//AGRUPACION Y PUNTUACION
"."					{return new Symbol(sym.punto,yycolumn,yyline,yytext());}
","					{return new Symbol(sym.coma,yycolumn,yyline,yytext());}
";"					{return new Symbol(sym.p_coma,yycolumn,yyline,yytext());}
":"					{return new Symbol(sym.d_puntos,yycolumn,yyline,yytext());}
"("					{return new Symbol(sym.lParen,yycolumn,yyline,yytext());}
")"					{return new Symbol(sym.rParen,yycolumn,yyline,yytext());}
"{"					{return new Symbol(sym.lKey,yycolumn,yyline,Integer.toString(yyline));}
"}"					{return new Symbol(sym.rKey,yycolumn,yyline,Integer.toString(yyline));}

//Otros
" "						{}
"\t"					{}
"\n"					{}
"EOF"					{}
"\r\n"					{}

//Otros otros
{id}					{return new Symbol(sym.tk_Id,yycolumn,yyline,yytext());} 
{caracter}				{return new Symbol(sym.tk_Caracter,yycolumn,yyline,yytext());} 
{entero}				{return new Symbol(sym.tk_Entero,yycolumn,yyline,yytext());}
{racional}				{return new Symbol(sym.tk_Numero,yycolumn,yyline,yytext());} 
{cadena}				{return new Symbol(sym.tk_Cadena,yycolumn,yyline,yytext());} 





/* Cualquier Otro   ERROR LEXICO*/
[^]   {
       /* ErrorL e=new ErrorL("Error lexico",yytext(),yyline,yycolumn);
        Analizador.listaE.add(e);
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));*/
	System.out.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
			}


