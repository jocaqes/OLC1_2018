
package Gramatica;
import java_cup.runtime.Symbol;

//import analizador.*;
%%
%cupsym Json_sym
%class Json_Escaner
%cup
%public
%unicode
%line
%column
%char
%ignorecase

//------------------------------------------------------------------------
//EXPRESIONES REGULARES
//letra 			= [a-zA-ZÑñ]+
digito 			= [0-9]
entero 			= {digito}+
racional 		= {digito}+("."{digito}+)
cadena 			= [\"][^\"]*[\"]
//-------------------------------------------------------------------------

%{
	//Codigo de Java

%}

%%
//Nulo
"null"					{return new Symbol(Json_sym.nulo,yycolumn,yyline,yytext());}

//Booleanos
"true"					{return new Symbol(Json_sym.verdadero,yycolumn,yyline,yytext());}
"false"					{return new Symbol(Json_sym.falso,yycolumn,yyline,yytext());}
//Signos de puntuacion etc
","						{return new Symbol(Json_sym.coma,yycolumn,yyline,yytext());}
":"						{return new Symbol(Json_sym.d_puntos,yycolumn,yyline,yytext());}
"("						{return new Symbol(Json_sym.lParen,yycolumn,yyline,yytext());}
")"						{return new Symbol(Json_sym.rParen,yycolumn,yyline,yytext());}
"{"						{return new Symbol(Json_sym.lKey,yycolumn,yyline,Integer.toString(yyline));}
"}"						{return new Symbol(Json_sym.rKey,yycolumn,yyline,Integer.toString(yyline));}
"["						{return new Symbol(Json_sym.lBrack,yycolumn,yyline,yytext());}
"]"						{return new Symbol(Json_sym.rBrack,yycolumn,yyline,yytext());}

//Otros
"-"						{return new Symbol(Json_sym.menos,yycolumn,yyline,yytext());}
" "						{}
"\t"					{}
"\n"					{}
"EOF"					{}
"\r\n"					{}

//Datos
{entero}				{return new Symbol(Json_sym.tk_Entero,yycolumn,yyline,yytext());}
{racional}				{return new Symbol(Json_sym.tk_Racional,yycolumn,yyline,yytext());} 
{cadena}				{return new Symbol(Json_sym.tk_Cadena,yycolumn,yyline,yytext());} 





/* Cualquier Otro   ERROR LEXICO*/
[^]   {
       /* ErrorL e=new ErrorL("Error lexico",yytext(),yyline,yycolumn);
        Analizador.listaE.add(e);
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));*/
	System.out.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
			}


