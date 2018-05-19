using Irony.Parsing;

namespace CRLapp.Gramatica
{
    class Gramatica:Grammar
    {
        public Gramatica() : base(caseSensitive: true)
        {
            #region Expresiones_Regulares
            IdentifierTerminal tk_Id           = new IdentifierTerminal("tk_id", "_", "");
            RegexBasedTerminal tk_Entero       = new RegexBasedTerminal("tk_entero", "[-][0-9]+|[0-9]+");
            RegexBasedTerminal tk_Numero       = new RegexBasedTerminal("tk_numero", "[-][0-9]+([.][0-9]+)|[0-9]+([.][0-9]+)");
            StringLiteral tk_Cadena            = new StringLiteral("cadena", "\"");
            RegexBasedTerminal tk_Caracter     = new RegexBasedTerminal("char", "'([a-zA-Z0-9]|[ ]|)'");
            CommentTerminal comentario_linea = new CommentTerminal("comentario_linea", "!!", "\n", "\r\n");
            CommentTerminal comentario_bloque = new CommentTerminal("comentario_bloque", "<<", ">>");
            /*KeyTerm Lparen = new KeyTerm("(", "parentesis_abre");
            KeyTerm Rparen = new KeyTerm(")", "parentesis_cierra");
            KeyTerm Lkey = new KeyTerm("{", "llave_abre");
            KeyTerm Rkey = new KeyTerm("}", "llave_cierra");*/
            #endregion

            #region Terminales
            //Reservadas
            var res_Importar            = ToTerm("Importar");
            var res_Definir             = ToTerm("Definir");
            var res_Mostrar             = ToTerm("Mostrar");
            var res_DibujarAst          = ToTerm("DibujarAST");
            var res_DibujarExp          = ToTerm("DibujarEXP");
            var res_DibujarTs           = ToTerm("DibujarTS");
            var res_CLR                 = ToTerm("clr");
            var res_Principal           = ToTerm("Principal");
            //Tipo Dato
            var tipo_Int                = ToTerm("Int");
            var tipo_String             = ToTerm("String");
            var tipo_Bool               = ToTerm("Bool");
            var tipo_Char               = ToTerm("Char");
            var tipo_Double             = ToTerm("Double");
            var tipo_Vacio              = ToTerm("Vacio");
            //Matematicos
            var igual                   = ToTerm("=");
            var mas                     = ToTerm("+");
            var menos                   = ToTerm("-");
            var dividido                = ToTerm("/");
            var por                     = ToTerm("*");
            var modulo                  = ToTerm("%");
            var elevado                 = ToTerm("^");
            //Relacionales
            var relacional_Diferente    = ToTerm("!=");
            var relacional_MenorIgual   = ToTerm("<=");
            var relacional_MayorIgual   = ToTerm(">=");
            var relacional_Menor        = ToTerm("<");
            var relacional_Mayor        = ToTerm(">");
            var relacional_Diferencia   = ToTerm("~");
            var relacional_Igual        = ToTerm("==");
            //Logicos
            var logico_And              = ToTerm("&&");
            var logico_Or               = ToTerm("||");
            var logico_Xor              = ToTerm("|&");
            var logico_Not              = ToTerm("!");
            //Boleanos
            var verdadero               = ToTerm("true");
            var falso                   = ToTerm("false");
            //Agrupacion y Puntuacion
            var lParen                  = ToTerm("(");
            var rParen                  = ToTerm(")");
            var p_coma                  = ToTerm(";");
            var coma                    = ToTerm(",");
            var lKey                    = ToTerm("{");
            var rKey                    = ToTerm("}");
            var punto                   = ToTerm(".");
            var d_puntos                = ToTerm(":");
            //Sentencias
            var sentencia_Si            = ToTerm("Si");
            var sentencia_Sino          = ToTerm("Sino");
            var sentencia_Selecciona    = ToTerm("Selecciona");
            var sentencia_Defecto       = ToTerm("Defecto");
            var sentencia_Para          = ToTerm("Para");
            var sentencia_Detener       = ToTerm("Detener");
            var sentencia_Continuar     = ToTerm("Continuar");
            var sentencia_Hasta         = ToTerm("Hasta");
            var sentencia_Mientras      = ToTerm("Mientras");
            var res_Retorno             = ToTerm("Retorno");
            #endregion

            #region No Terminales
            NonTerminal
                S =             new NonTerminal("<S>"),
                INICIO=         new NonTerminal("<INICIO>"),
                CUERPO=         new NonTerminal("<CUERPO>"),
                CUERPOS=        new NonTerminal("<CUERPOS>"),//nuevo
                IMPORTS=        new NonTerminal("<IMPORTS>"),
                IMPORT=         new NonTerminal("<IMPORT>"),//nuevo
                DEFINES=        new NonTerminal("<DEFINES>"),
                DEFINE=         new NonTerminal("<DEFINE>"),//nuevo
                DECLARACION=    new NonTerminal("<DECLARACION>"),
                ID=             new NonTerminal("<ID>"),
                TIPODATO=       new NonTerminal("<TIPODADO>"),
                ASIGNACION=     new NonTerminal("<ASIGNACION>"),
                ASIGNAR=        new NonTerminal("<ASIGNAR>"),//nuevo
                VALORES=        new NonTerminal("<VALORES>"),
                LLAMADA=        new NonTerminal("<LLAMADA>"),
                E=              new NonTerminal("<E>"),
                CONDICION=      new NonTerminal("<CONDICION>"),
                COMPARACION=    new NonTerminal("<COMPARACION>"),
                IF=             new NonTerminal("<IF>"),
                ELSE=           new NonTerminal("<ELSE>"),
                WHILE=          new NonTerminal("<WHILE>"),
                FOR=            new NonTerminal("<FOR>"),
                OP=             new NonTerminal("<OP>"),
                DO=             new NonTerminal("<DO>"),
                SWITCH=         new NonTerminal("<SWITCH>"),
                CASE=           new NonTerminal("<CASE>"),
                CASES=          new NonTerminal("<CASES>"),
                DEFAULT=        new NonTerminal("<DEFAULT>"),
                SENTENCIA=      new NonTerminal("<SENTENCIA>"),
                SENTENCIAS=     new NonTerminal("<SENTENCIAS>"),//nuevo
                SENTENCIAW=     new NonTerminal("<SENTENCIAW>"),
                SENTENCIAWS =   new NonTerminal("<SENTENCIAWS>"),//nuevo
                PARAMETRO =     new NonTerminal("<PARAMETRO>"),
                PARAMETROS=     new NonTerminal("<PARAMETROS>"),//nuevo
                METODO=         new NonTerminal("<METODO>"),
                RETORNO=        new NonTerminal("<RETORNO>"),//nuevo
                CONTINUAR=      new NonTerminal("<CONTINUAR>"),//nuevo
                DETENER=        new NonTerminal("<DETENER>"),//nuevo
                MOSTRAR=        new NonTerminal("<MOSTRAR>"),//nuevo
                DIBUJAR=        new NonTerminal("<DIBUJAR>"),//nuevo
                MAIN =          new NonTerminal("<MAIN>")
                ;
            #endregion

            #region Producciones
            S.Rule              = INICIO
                                ;

            INICIO.Rule         = IMPORTS + DEFINES + CUERPO
                                |DEFINES + CUERPO
                                |IMPORTS + DEFINES
                                |IMPORTS + CUERPO
                                |DEFINES
                                |CUERPO
                                ;


            CUERPO.Rule         = MakePlusRule(CUERPO, CUERPOS);

            CUERPOS.Rule        = DECLARACION
                                | METODO
                                | MAIN
                                | DIBUJAR
                                ;
            /*CUERPO.Rule         = CUERPO + DECLARACION
                                |CUERPO + METODO
                                |CUERPO + MAIN
                                |DECLARACION
                                |METODO
                                |MAIN
                                ;*/

            IMPORTS.Rule        = MakePlusRule(IMPORTS, IMPORT)
                                ;

            IMPORT.Rule         //= IMPORT + res_Importar + tk_Id + punto + res_CLR + p_coma
                                = res_Importar + tk_Id + punto + res_CLR + p_coma
                                ;

            DEFINES.Rule        = MakePlusRule(DEFINES, DEFINE)
                                ;

            DEFINE.Rule         /*= DEFINES + res_Definir + tk_Numero + p_coma
                                | DEFINES + res_Definir + tk_Cadena + p_coma*/
                                = res_Definir + tk_Numero + p_coma
                                | res_Definir + tk_Cadena + p_coma
                                ;

            DECLARACION.Rule    = TIPODATO + ID + ASIGNACION + p_coma//TIPODADO es nuevo
                                | TIPODATO + ID + p_coma
                                ;

            ID.Rule             = MakePlusRule(ID, coma, tk_Id);

            /*ID.Rule             = ID + coma + tk_Id
                                |TIPODATO + tk_Id
                                ;*/

            TIPODATO.Rule       = tipo_Bool
                                | tipo_Char
                                | tipo_Double
                                | tipo_Int
                                | tipo_String
                                | tipo_Vacio
                                ;


            ASIGNACION.Rule     = igual + CONDICION
                                ;

            ASIGNAR.Rule        = tk_Id + ASIGNACION + p_coma
                                ;

            VALORES.Rule        = MakePlusRule(VALORES, coma, CONDICION)
                                ;

            /*VALORES.Rule        = VALORES + coma + CONDICION
                                | CONDICION
                                ;*/

            LLAMADA.Rule        = tk_Id + lParen + rParen
                                | tk_Id + lParen + VALORES + rParen
                                ;

            E.Rule              = E + mas + E
                                | E + menos + E
                                | E + por + E
                                | E + dividido + E
                                | E + modulo + E
                                | E + elevado + E
                                | tk_Numero
                                //| menos + tk_Numero //el menos esta en la expresion regular
                                | tk_Entero
                                //| menos + tk_Entero
                                | lParen + CONDICION + rParen//nuevo
                                | tk_Id
                                | LLAMADA
                                | tk_Cadena
                                | tk_Caracter
                                | verdadero
                                | falso
                                ;

            CONDICION.Rule      = CONDICION + logico_Or + CONDICION
                                | CONDICION + logico_Xor + CONDICION
                                | CONDICION + logico_And + CONDICION
                                | logico_Not + CONDICION
                                | COMPARACION
                                ;

            COMPARACION.Rule    = E + relacional_Diferente + E
                                | E + relacional_Mayor + E
                                | E + relacional_MayorIgual + E
                                | E + relacional_Menor + E
                                | E + relacional_MenorIgual + E
                                | E + relacional_Diferencia + E
                                | E + relacional_Igual + E
                                | E
                                ;

            IF.Rule             = sentencia_Si + lParen + CONDICION + rParen + lKey + SENTENCIAW + rKey + ELSE
                                | sentencia_Si + lParen + CONDICION + rParen + lKey + SENTENCIAW + rKey
                                | sentencia_Si + lParen + CONDICION + rParen + lKey + rKey + ELSE
                                | sentencia_Si + lParen + CONDICION + rParen + lKey + rKey
                                ;

            ELSE.Rule           = sentencia_Sino + lKey + SENTENCIAW + rKey
                                | sentencia_Sino + lKey + rKey
                                ;

            WHILE.Rule          = sentencia_Mientras + lParen + CONDICION + rParen + lKey + SENTENCIAW + rKey
                                | sentencia_Mientras + lParen + CONDICION + rParen + lKey + rKey
                                ;

            FOR.Rule            = sentencia_Para + lParen + tipo_Double + tk_Id + igual + E + p_coma + CONDICION + p_coma + OP + rParen + lKey + SENTENCIAW + rKey
                                | sentencia_Para + lParen + tipo_Double + tk_Id + igual + E + p_coma + CONDICION + p_coma + OP + rParen + lKey + rKey
                                ;

            OP.Rule             = mas + mas
                                | menos + menos
                                ;

            DO.Rule             = sentencia_Hasta + lParen + CONDICION + rParen + lKey + SENTENCIAW + rKey
                                | sentencia_Hasta + lParen + CONDICION + rParen + lKey + rKey
                                ;

            SWITCH.Rule         = sentencia_Selecciona + lParen + E + rParen + lKey + CASE + DEFAULT + rKey
                                | sentencia_Selecciona + lParen + E + rParen + lKey + CASE + rKey
                                ;

            CASE.Rule           = MakePlusRule(CASE, CASES);

            CASES.Rule           = /*CASE + tk_Entero + d_puntos + SENTENCIA + sentencia_Detener + p_coma
                                | CASE + tk_Cadena + d_puntos + SENTENCIA + sentencia_Detener + p_coma
                                | CASE + tk_Entero + d_puntos + sentencia_Detener + p_coma
                                | CASE + tk_Cadena + d_puntos + sentencia_Detener + p_coma
                                | CASE + tk_Entero + d_puntos + SENTENCIA
                                | CASE + tk_Cadena + d_puntos + SENTENCIA*/
                                //| CASE + tk_Numero + d_puntos + p_coma
                                //| CASE + tk_Cadena + d_puntos + p_coma
                                 tk_Entero + d_puntos + SENTENCIA + sentencia_Detener + p_coma
                                | tk_Cadena + d_puntos + SENTENCIA + sentencia_Detener + p_coma
                                | tk_Entero + d_puntos + sentencia_Detener + p_coma
                                | tk_Cadena + d_puntos + sentencia_Detener + p_coma
                                | tk_Entero + d_puntos + SENTENCIA
                                | tk_Cadena + d_puntos + SENTENCIA
                                //| tk_Numero + d_puntos + p_coma
                                //| tk_Cadena + d_puntos + p_coma
                                ;

            DEFAULT.Rule        = sentencia_Defecto + d_puntos + SENTENCIA + sentencia_Detener + p_coma
                                | sentencia_Defecto + d_puntos + SENTENCIA
                                | sentencia_Defecto + d_puntos + sentencia_Detener + p_coma
                                //| sentencia_Defecto + d_puntos + p_coma
                                ;

            SENTENCIA.Rule      = MakePlusRule(SENTENCIA, SENTENCIAS);//ahora sentencia solo l o usa switch porque si no tiene conflicto con break

            SENTENCIAS.Rule       /*SENTENCIAS + IF
                                | SENTENCIAS + WHILE
                                | SENTENCIAS + FOR
                                | SENTENCIAS + DO
                                | SENTENCIAS + SWITCH
                                | SENTENCIAS + DECLARACION
                                | SENTENCIAS + tk_Id + ASIGNACION + p_coma
                                | SENTENCIAS + LLAMADA + p_coma
                                | SENTENCIAS + res_Retorno + CONDICION + p_coma
                                | SENTENCIAS + res_Retorno + p_coma
                                | SENTENCIAS + res_Mostrar + lParen + tk_Cadena + coma + VALORES + rParen + p_coma
                                | SENTENCIAS + res_Mostrar + lParen + tk_Cadena + rParen + p_coma
                                | SENTENCIAS + res_DibujarAst + lParen + tk_Id + rParen + p_coma
                                | SENTENCIAS + res_DibujarExp + lParen + CONDICION + rParen + p_coma
                                | SENTENCIAS + res_DibujarTs + lParen + rParen + p_coma*/
                                =   IF
                                | WHILE
                                | FOR
                                | DO
                                | SWITCH
                                | DECLARACION
                                | ASIGNAR
                                | LLAMADA + p_coma
                                | RETORNO
                                | MOSTRAR
                                | DIBUJAR
                                ;
            SENTENCIAS.ErrorRule = SyntaxError + p_coma;

            SENTENCIAW.Rule     = MakePlusRule(SENTENCIAW, SENTENCIAWS);

            SENTENCIAWS.Rule   /* = SENTENCIAWS + IF
                                | SENTENCIAWS + WHILE
                                | SENTENCIAWS + FOR
                                | SENTENCIAWS + DO
                                | SENTENCIAWS + SWITCH
                                | SENTENCIAWS + DECLARACION
                                | SENTENCIAWS + tk_Id + ASIGNACION + p_coma
                                | SENTENCIAWS + LLAMADA + p_coma
                                | SENTENCIAWS + res_Retorno + CONDICION + p_coma
                                | SENTENCIAWS + res_Retorno + p_coma
                                | SENTENCIAWS + sentencia_Continuar + p_coma
                                | SENTENCIAWS + sentencia_Detener + p_coma
                                | SENTENCIAWS + res_Mostrar + lParen + tk_Cadena + coma + VALORES + rParen + p_coma
                                | SENTENCIAWS + res_Mostrar + lParen + tk_Cadena + rParen + p_coma
                                | SENTENCIAWS + res_DibujarAst + lParen + tk_Id + rParen + p_coma
                                | SENTENCIAWS + res_DibujarExp + lParen + CONDICION + rParen + p_coma
                                | SENTENCIAWS + res_DibujarTs + lParen + rParen + p_coma*/
                                = IF
                                | WHILE
                                | FOR
                                | DO
                                | SWITCH
                                | DECLARACION//*
                                | ASIGNAR
                                | LLAMADA + p_coma
                                | RETORNO//*
                                | CONTINUAR//*
                                | DETENER//*
                                | MOSTRAR
                                | DIBUJAR
                                ;
            SENTENCIAWS.ErrorRule = SyntaxError + p_coma;

            RETORNO.Rule        = res_Retorno + p_coma
                                | res_Retorno + CONDICION + p_coma
                                ;

            CONTINUAR.Rule      = sentencia_Continuar + p_coma
                                ;
            DETENER.Rule        = sentencia_Detener + p_coma
                                ;
            MOSTRAR.Rule        = res_Mostrar + lParen + tk_Cadena + coma + VALORES + rParen + p_coma
                                | res_Mostrar + lParen + tk_Cadena + rParen + p_coma
                                ;
            DIBUJAR.Rule         = res_DibujarAst + lParen + tk_Id + rParen + p_coma
                                | res_DibujarExp + lParen + CONDICION + rParen + p_coma
                                | res_DibujarTs + lParen + rParen + p_coma
                                ;

            //RETORTNO
            //CONTINUAR
            //DETENER
            //MOSTRAR
            //DIBUJARAST
            //DIBUJAREXP
            //DIBUJARTS



            METODO.Rule         = TIPODATO + tk_Id + lParen + PARAMETRO + rParen + lKey + SENTENCIA + rKey
                                | TIPODATO + tk_Id + lParen + PARAMETRO + rParen + lKey + rKey
                                | TIPODATO + tk_Id + lParen + rParen + lKey + SENTENCIA + rKey
                                | TIPODATO + tk_Id + lParen + rParen + lKey + rKey
                                ;


            MAIN.Rule           = res_Principal + lParen + rParen + lKey + SENTENCIA + rKey
                                | res_Principal + lParen + rParen + lKey + rKey
                                ;

            PARAMETRO.Rule     = MakePlusRule(PARAMETRO, coma, PARAMETROS);
            PARAMETROS.Rule      = TIPODATO + tk_Id;

/*
            PARAMETRO.Rule      = PARAMETRO + coma + TIPODATO + tk_Id
                                | TIPODATO + tk_Id
                                ;*/

            #endregion

            #region Preferencias
            Root = S;
            //Comentarios
            NonGrammarTerminals.Add(comentario_linea);
            NonGrammarTerminals.Add(comentario_bloque);
            //Precedencia
            RegisterOperators(10, Associativity.Left, logico_Or, logico_Xor);
            RegisterOperators(20,Associativity.Left, logico_And);
            RegisterOperators(30,Associativity.Right, logico_Not);
            RegisterOperators(40,Associativity.Left, relacional_Diferencia, relacional_Diferente, relacional_Mayor, relacional_MayorIgual, relacional_Menor, relacional_MenorIgual);
            RegisterOperators(50,Associativity.Left, mas, menos);
            RegisterOperators(60,Associativity.Left, por, dividido, modulo);
            RegisterOperators(70, Associativity.Right, elevado);
            MarkTransient(TIPODATO,CUERPOS,IMPORT,DEFINE);
            //Reservadas
            MarkReservedWords("Importar", "Definir", "Mostrar", "DibujarAST", "DibujarEXP", "DibujarTS", "clr",
                "String", "Bool", "Int", "Double", "Char", "true", "false", "Si", "Sino", "Selecciona",
                "Defecto", "Para", "Detener", "Continuar", "Hasta", "Mientras", "Retorno","Principal"
                );
            //Puntuacion
            MarkPunctuation(lParen, rParen, lKey, rKey, coma, p_coma, d_puntos, punto, res_Importar,res_CLR
                ,res_Definir,igual);
            #endregion
        }
    }
}
