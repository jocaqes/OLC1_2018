
package Gramatica;
import java_cup.runtime.Symbol;
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
Multi   		= "</" [^/] ~"/>" | "</" "/"+ ">"
Simple		    = "->"[^\r\n]* [^\r\n]
letra 			= [a-zA-ZÑñ]+
numero 			= [0-9]
entero 			= {numero}+
racional 		= {numero}+("."{numero}+)
caracter 		= [\'][^\'][\']
cadena 			= [\"][^\"]*[\"]
id 				= ({letra}|"_")({letra}|{numero}|"_")*
//-------------------------------------------------------------------------

%{
    //codigo de java
    String nombre;
    public void imprimir(String dato,String cadena){
    	//System.out.println(dato+" : "+cadena);
    }
    public void imprimir(String cadena){
    	//System.out.println(cadena+" soy reservada");
    }
%}

%%
//Comentarios
{Comment}				{}

//HTML
	//Etiquetas de apertura
"<html>"				{return new Symbol(sym.op_Html,yycolumn,yyline,yytext());}
"<head"					{return new Symbol(sym.op_Head,yycolumn,yyline,yytext());}
"<body"					{return new Symbol(sym.op_Body,yycolumn,yyline,yytext());}
"<h"{numero}			{return new Symbol(sym.op_Hnumber,yycolumn,yyline,yytext());}
"<title"				{return new Symbol(sym.op_Title,yycolumn,yyline,yytext());}
"<table"				{return new Symbol(sym.op_Table,yycolumn,yyline,yytext());}
"<th"					{return new Symbol(sym.op_Th,yycolumn,yyline,yytext());}
"<td"					{return new Symbol(sym.op_Td,yycolumn,yyline,yytext());}
"<tr"					{return new Symbol(sym.op_Tr,yycolumn,yyline,yytext());}
"<div"					{return new Symbol(sym.op_Div,yycolumn,yyline,yytext());}
"<p"					{return new Symbol(sym.op_P,yycolumn,yyline,yytext());}
	//Etiquetas de cierre
"</html>"				{return new Symbol(sym.cl_Html,yycolumn,yyline,yytext());}
"</head>"				{return new Symbol(sym.cl_Head,yycolumn,yyline,yytext());}
"</body>"				{return new Symbol(sym.cl_Body,yycolumn,yyline,yytext());}
"</h"{numero}">"		{return new Symbol(sym.cl_Hnumber,yycolumn,yyline,yytext());}
"</title>"				{return new Symbol(sym.cl_Title,yycolumn,yyline,yytext());}
"</table>"				{return new Symbol(sym.cl_Table,yycolumn,yyline,yytext());}
"</th>"					{return new Symbol(sym.cl_Th,yycolumn,yyline,yytext());}
"</td>"					{return new Symbol(sym.cl_Td,yycolumn,yyline,yytext());}
"</tr>"					{return new Symbol(sym.cl_Tr,yycolumn,yyline,yytext());}
"</div>"				{return new Symbol(sym.cl_Div,yycolumn,yyline,yytext());}
"</p>"					{return new Symbol(sym.cl_P,yycolumn,yyline,yytext());}
"<hr/>"					{return new Symbol(sym.cl_Hr,yycolumn,yyline,yytext());}
"<br/>"					{return new Symbol(sym.cl_Br,yycolumn,yyline,yytext());}
	//Reservadas Atributos
"color"					{return new Symbol(sym.atributo_Color,yycolumn,yyline,yytext());}
"textcolor"				{return new Symbol(sym.atributo_TextColor,yycolumn,yyline,yytext());}
"align"					{return new Symbol(sym.atributo_Align,yycolumn,yyline,yytext());}
"font"					{return new Symbol(sym.atributo_Font,yycolumn,yyline,yytext());}
//Fin HTLM



//CPR Report
//RESERVADA
"Print"					{return new Symbol(sym.res_Print,yycolumn,yyline,yytext());}
"$$"					{return new Symbol(sym.res_Llave,yycolumn,yyline,yytext());}	
	//Tipos de dato
"int"					{return new Symbol(sym.tipo_Int,yycolumn,yyline,yytext());}
"boolean"				{return new Symbol(sym.tipo_Bool,yycolumn,yyline,yytext());}
"String"				{return new Symbol(sym.tipo_String,yycolumn,yyline,yytext());}
"char"					{return new Symbol(sym.tipo_Char,yycolumn,yyline,yytext());}
"double"				{return new Symbol(sym.tipo_Double,yycolumn,yyline,yytext());}


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
"+"						{return new Symbol(sym.mas,yycolumn,yyline,yytext());}
"-"						{return new Symbol(sym.menos,yycolumn,yyline,yytext());}
"*"						{return new Symbol(sym.por,yycolumn,yyline,yytext());}
"/"						{return new Symbol(sym.dividido,yycolumn,yyline,yytext());}
"="						{return new Symbol(sym.igual,yycolumn,yyline,yytext());}
"%"						{return new Symbol(sym.modulo,yycolumn,yyline,yytext());}

//AGRUPACION Y PUNTUACION
";"						{return new Symbol(sym.p_coma,yycolumn,yyline,yytext());}//util en html
","						{return new Symbol(sym.coma,yycolumn,yyline,yytext());}
"("						{return new Symbol(sym.lParen,yycolumn,yyline,yytext());}
")"						{return new Symbol(sym.rParen,yycolumn,yyline,yytext());}


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


