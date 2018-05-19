using Irony.Parsing;
using CRLapp.ManejoArchivos;
using System.Collections.Generic;

namespace CRLapp.Gramatica
{
    static class Analisis
    {
        private static int contador = 0;
        private static string grafo = "";
        private static ParseNode raiz;//nuevo
        private static Stack<string> nodos = new Stack<string>();//nuevo

        public static ParseTree analizar(string entrada)
        {
            LanguageData lenguaje = new LanguageData(new Gramatica());
            Parser parse = new Parser(lenguaje);
            ParseTree arbol = parse.Parse(entrada);
            return arbol;
            //if (arbol.Root == null)
            //    return null;
            //raiz = new ParseNode(0,0,"<S>");//nuevo
            //miAST(arbol.Root, raiz);
            //generarAST(arbol.Root);
            //return raiz;
        }

        public static bool graficarArbol(ParseNode raiz)
        {
            return Archivo.guardar(dibujar(raiz), @"D:/Sistemas/2018/OLC/proyecto_2/arbol_prueba.dot");
        }

        #region Dibujar Arbol
        public static string dibujar(ParseNode raiz,bool expresion=false)
        {
            grafo = "digraph G{\n";
            if (expresion)
            {
                grafo += "node[shape=Mrecord];\n";
                recorrerExpresion(raiz, "");
            }
            else
                recorrerArbol(raiz, "");
            grafo += "}";
            return grafo;
        }

        private static void recorrerArbol(ParseNode actual, string padre)
        {
            string nombre_actual = "n" + contador;
            grafo += nombre_actual + "[label=\"" + actual.ToString() + "\"];\n";//genero el nodo
            if (!string.IsNullOrEmpty(padre))
            {
                grafo += padre + "->" + nombre_actual + ";\n";//padre apunta a actual
            }
            foreach (ParseNode hijo in actual.childNodes)
            {
                contador++;
                recorrerArbol(hijo, nombre_actual);
            }
        }

        #region Expresion
        private static void recorrerExpresion(ParseNode actual, string padre)
        {
            //1.-verificamos el nombre del nodo
            string nombre_actual = "n" + contador;
            string valor=actual.ToString();
            string nombre_nodo = "";
            switch (valor)
            {
                case "&&":
                case "||":
                case "|&":
                case "!":
                    nombre_nodo = "Logico|" + actual.ToString();
                    break;
                case "<":
                case "<=":
                    nombre_nodo = "Relac|" + actual.ToString().Replace("<","&#60;");
                    break;
                case ">":
                case ">=":
                    nombre_nodo = "Relac|" + actual.ToString().Replace(">","&#62;");
                    break;
                case "==":
                case "!=":
                case "~":
                    nombre_nodo = "Relac|" + actual.ToString();
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                case "^":
                    nombre_nodo = "Aritm|" + actual.ToString();
                    break;
                default:
                    string tipo = actual.Tipo;
                    switch (tipo)
                    {
                        case "Int":
                        case "Double":
                            nombre_nodo = "Number|" + actual.ToString();
                            break;
                        case "Bool":
                            nombre_nodo = "Bool|" + actual.ToString();
                            break;
                        case "String":
                            nombre_nodo = "String|" + actual.ToString();
                            break;
                        case "Char":
                            nombre_nodo = "Char|" + actual.ToString();
                            break;
                        case "(tk_id)":
                            nombre_nodo = "Variable|" + actual.ToString();
                            break;
                        case "<LLAMADA>":
                            nombre_nodo = "Funcion|" + actual.izq().ToString();
                            break;
                        default:
                            nombre_nodo = actual.ToString();
                            break;
                    }
                    break;
            }
            
            grafo += nombre_actual + "[label=\"" + nombre_nodo + "\"];\n";//genero el nodo
            if (!string.IsNullOrEmpty(padre))
            {
                grafo += padre + "->" + nombre_actual + ";\n";//padre apunta a actual
            }
            if ("<LLAMADA>".Equals(actual.ToString()))
            {
                contador++;
                return;//para no revisar que tiene llamada y meterlo accidentalmente en el dibujo
            }
            foreach (ParseNode hijo in actual.childNodes)
            {
                contador++;
                recorrerExpresion(hijo, nombre_actual);
            }
        }
        #endregion

        #region Funcion
        public static string dibujarFuncion(ParseNode raiz,string cabezera)
        {
            grafo = "digraph g{\n"
                    +"splines=ortho;\n"
                    +"node[shape=box,concentrate=true];\n"
                    +"nodo_raiz[label=\""+cabezera+"\"];\n";
            nodos.Push("nodo_raiz");
            recorrerFuncion(raiz);
            grafo += "}";
            return grafo;
        }
        private static void recorrerFuncion(ParseNode actual)
        {
            //0.-Recorro los hijos de actual y declaro puntos y nodos
            string nodo_actual;
            string punto_actual;
            string padre;
            foreach (ParseNode hijo in actual.childNodes)
            {
                //1.-Nombre del nodo y su punto ayudante
                nodo_actual = "n" + contador;
                punto_actual = "punto_" + contador;
                //2.-Declaracion de los nodos en graphviz
                grafo += "{rank=same;\n"
                        + punto_actual + "[shape=point];\n"
                        + nodo_actual + "[label=\"" + hijo.ToString() + "\"];}\n";
                //3.-Saco el tope de la pila nodos para que apunte a el punto actual
                padre = nodos.Pop();
                //4.-Pongo los respectivos "punteros"
                grafo += padre + "->" + punto_actual + "[arrowhead=none];\n"
                        + punto_actual + "->" + nodo_actual + ";\n";
                contador++;
                nodos.Push(punto_actual);
                if (hijo.izq() != null)
                {
                    //nodos.Push(punto_actual);
                    nodos.Push(nodo_actual);
                    //recorrerFuncion(hijo);
                    string tipo = hijo.Tipo;
                    switch (tipo)
                    {
                        case "<RETORNO>":
                            if (hijo.der() != null)
                            {
                                hijo.childNodes.Clear();
                                hijo.add(0, 0, "<COND>");
                            }
                            break;
                        case "<DECLARACION>":
                            hijo.childNodes.RemoveAt(0);
                            break;
                        case "<ID>":
                            hijo.childNodes.Clear();
                            break;
                        case "<ASIGNACION>":
                            hijo.childNodes.Clear();
                            hijo.add(0, 0, "<COND>");
                            break;
                        case "<IF>":
                            hijo.childNodes.RemoveAt(0);
                            hijo.izq().childNodes.Clear();
                            hijo.izq().Valor = "<COND>";
                            break;
                        case "<ELSE>":
                            hijo.childNodes.RemoveAt(0);
                            break;

                    }
                    recorrerFuncion(hijo);
                }
                //nodos.Pop();              
            }
            nodos.Pop();
        }
        #endregion
        #endregion

        #region AST fallidos
        private static void generarAST(ParseTreeNode padre, ParseTreeNode abuelo = null)
        {
            int limite_superior = padre.ChildNodes.Count;
            ParseTreeNode hijo;
            for (int i = 0; i < limite_superior; i++)
            {
                hijo = padre.ChildNodes[i];
                int limite;
                string referencia = padre.ToString();
                switch (referencia)
                {
                    case "<S>":
                        //abuelo=null
                        generarAST(hijo, padre);
                        break;
                    case "<INICIO>":
                        //abuelo=<S>
                        generarAST(hijo, padre);
                        break;
                    case "<CUERPO>":
                        //abuelo=<INICIO>
                        generarAST(hijo, padre);
                        break;
                    case "<DECLARACION>":
                        //abuelo=<CUERPO>
                        generarAST(hijo, padre);
                        break;
                    case "<ASIGNACION>":
                        //abuelo=<DECLARACION>
                        generarAST(hijo, padre);
                        if ("<CONDICION>".Equals(hijo.ToString()))
                        {
                            limite = hijo.ChildNodes.Count;
                            if (limite == 1)//<CONDICION>->valor
                            {
                                padre.ChildNodes[i] = hijo.ChildNodes[0];
                            }
                            else if (limite == 3)//<CONDICION>->valor <CONDICION>->relacional <CONDICION>->valor
                            {
                                ParseTreeNode logico = hijo.ChildNodes[1];//el operador
                                logico.ChildNodes.Add(hijo.ChildNodes[0]);//el valor izq
                                logico.ChildNodes.Add(hijo.ChildNodes[2]);//el valor der
                                padre.ChildNodes[i] = logico;
                            }
                        }
                        break;
                    case "<CONDICION>":
                        //abuelo=<ASIGNACION>
                        generarAST(hijo, padre);
                        if ("<CONDICION>".Equals(hijo.ToString())) {
                            limite = hijo.ChildNodes.Count;
                            if (limite == 1)//<CONDICON>->valor
                            {
                                padre.ChildNodes[i] = hijo.ChildNodes[0];
                            }
                            else if (limite == 2)//<CONDICION>->!  <CONDICION>->valor
                            {
                                ParseTreeNode not = hijo.ChildNodes[0];//el operador
                                not.ChildNodes.Add(hijo.ChildNodes[1]);//el valor der
                                padre.ChildNodes[i] = not;
                            }
                            else if (limite == 3)//<CONDICION>->valor <CONDICION>->logico <CONDICION>->valor
                            {
                                ParseTreeNode logico = hijo.ChildNodes[1];//el operador
                                logico.ChildNodes.Add(hijo.ChildNodes[0]);//el valor izq
                                logico.ChildNodes.Add(hijo.ChildNodes[2]);//el valor der
                                padre.ChildNodes[i] = logico;
                            }
                        }
                        else if ("<COMPARACION>".Equals(hijo.ToString()))
                        {
                            limite = hijo.ChildNodes.Count;
                            if (limite == 1)//<COMPARACION>->valor
                            {
                                padre.ChildNodes[i] = hijo.ChildNodes[0];
                            }
                            else if (limite == 3)//<E>->valor <COMPARACION>->relacional <E>->valor
                            {
                                ParseTreeNode relacional = hijo.ChildNodes[1];//el operador
                                relacional.ChildNodes.Add(hijo.ChildNodes[0]);//el valor izq
                                relacional.ChildNodes.Add(hijo.ChildNodes[2]);//el valor der
                                padre.ChildNodes[i] = relacional;
                            }
                        }
                        break;
                    case "<COMPARACION>":
                        //abuelo=<CONDICION>
                        //padre=<COMPARACION>
                        generarAST(hijo, padre);
                        //hijo=<E>
                        if ("<E>".Equals(hijo.ToString()))
                        {
                            limite = hijo.ChildNodes.Count;
                            if (limite == 1)//<E>->valor
                            {
                                padre.ChildNodes[i] = hijo.ChildNodes[0];
                            }
                            else if (limite == 3)//<E>->valor <E>->operador <E>->valor
                            {
                                ParseTreeNode operador = hijo.ChildNodes[1];//el operador
                                operador.ChildNodes.Add(hijo.ChildNodes[0]);//el valor izq
                                operador.ChildNodes.Add(hijo.ChildNodes[2]);//el valor der
                                padre.ChildNodes[i] = operador;
                            }
                        }
                        break;
                    case "<E>"://Completo
                        //abuelo=<COMPARACION>
                        //padre=<E>
                        //limite = hijo.ChildNodes.Count;
                        if ("<E>".Equals(hijo.ToString()))
                        {
                            limite = hijo.ChildNodes.Count;
                            if (limite == 1)//<E>->valor
                            {
                                padre.ChildNodes[i] = hijo.ChildNodes[0];
                            }
                            else if (limite == 3)//<E>->valor <E>->operador <E>->valor
                            {
                                generarAST(hijo, padre);//me adentro para arreglar los hijos
                                ParseTreeNode operador = hijo.ChildNodes[1];//el operador
                                operador.ChildNodes.Add(hijo.ChildNodes[0]);//el valor izq
                                operador.ChildNodes.Add(hijo.ChildNodes[2]);//el valor der
                                padre.ChildNodes[i] = operador;
                            }
                        }
                        break;
                    case "<METODO>":
                    case "<SENTENCIA>":
                    case "<SENTENCIAS>":
                    case "<SENTENCIAW>":
                    case "<SENTENCIAWS>":
                    case "<IF>":
                    case "<FOR>":
                    case "<SWITCH>":
                    case "<WHILE>":
                    case "<TILL>":
                    case "<LLAMADA>":
                    case "<VALORES>":
                    case "<MAIN>":
                        generarAST(hijo, padre);
                        break;

                }
            }
        }
        #endregion

        #region AST mejorado
        public static void miAST(ParseTreeNode raiz, ParseNode actual)
        {

            int fila=0;
            int columna=0;
            int limite;
            ParseNode nuevo = null;
            foreach(ParseTreeNode hijo in raiz.ChildNodes)
            {
                string valor = hijo.ToString();
                if (hijo.Token != null)
                {
                    fila = hijo.Token.Location.Line;
                    columna = hijo.Token.Location.Column;
                }
                switch (valor)
                {
                    case "<INICIO>":
                    case "<SENTENCIAS>"://NUEVO 
                    case "<SENTENCIAWS>"://NUEVO
                        miAST(hijo, actual);
                        break;
                    case "<IMPORTS>":
                    case "<DEFINES>":
                    case "<CUERPO>":
                    case "<DECLARACION>":
                    case "<ASIGNACION>":
                    case "<ASIGNAR>":
                    case "<ID>":
                    case "<METODO>":
                    case "<PARAMETRO>":
                    case "<SENTENCIA>":
                    //case "<SENTENCIAS>":
                    case "<VALORES>":
                    case "<LLAMADA>":
                    case "<MAIN>":
                    case "<IF>":
                    case "<FOR>":
                    case "<OP>":
                    case "<SWITCH>":
                    case "<CASE>":
                    case "<CASES>":
                    case "<DEFAULT>":
                    case "<ELSE>":
                    case "<WHILE>":
                    case "<DO>":
                    case "<SENTENCIAW>":
                    case "<RETORNO>":
                    case "<MOSTRAR>":
                    case "<DIBUJAR>":
                    //case "<SENTENCIAWS>":
                        nuevo = new ParseNode(fila, columna, valor);
                        miAST(hijo, nuevo);
                        actual.add(nuevo);
                        break;
                    case "<PARAMETROS>":
                    //case "<ASIGNACION>"://simplemente agregan sus hijos al padre
                        miAST(hijo, actual);
                        break;
                    case "<CONDICION>":
                        /*if ("<ASIGNACION>".Equals(raiz.ToString())||"<VALORES>".Equals(raiz.ToString()))
                        {
                            miAST(hijo, actual);
                        }*/
                        if("<CONDICION>".Equals(raiz.ToString()))
                        {
                            limite = raiz.ChildNodes.Count;//hijos de <CONDICION>
                            if (limite == 1)
                            {
                                miAST(hijo, actual);
                            }
                            else if (limite == 2)//NOT
                            {
                                nuevo = new ParseNode(raiz.ChildNodes[0].Token);
                                miAST(raiz.ChildNodes[1], nuevo);//agrego valor der
                                actual.add(nuevo);
                                return;
                            }
                            else if (limite == 3)
                            {
                                nuevo = new ParseNode(raiz.ChildNodes[1].Token);
                                miAST(raiz.ChildNodes[0], nuevo);//agrego valor izq
                                miAST(raiz.ChildNodes[2], nuevo);//agrego valor der
                                actual.add(nuevo);
                                return;
                            }
                        }else
                        {
                            miAST(hijo, actual);
                        }
                        break;
                    case "<COMPARACION>":
                        limite = hijo.ChildNodes.Count;
                        if (limite == 1)
                        {
                            miAST(hijo, actual);
                        }
                        else if (limite == 3)
                        {
                            nuevo = new ParseNode(hijo.ChildNodes[1].Token);
                            miAST(hijo.ChildNodes[0], nuevo);//agrego valor izq
                            miAST(hijo.ChildNodes[2], nuevo);//agrego valor der
                            actual.add(nuevo);
                        }
                        break;
                    case "<E>":
                        if ("<COMPARACION>".Equals(raiz.ToString())||"<FOR>".Equals(raiz.ToString()))
                            miAST(hijo, actual);
                        else
                        {
                            limite = raiz.ChildNodes.Count;//hijos de <E>
                            if (limite == 1)
                            {
                                fila = hijo.ChildNodes[0].Token.Location.Line;
                                columna = hijo.ChildNodes[0].Token.Location.Column;
                                string val = hijo.ChildNodes[0].ToString();
                                actual.add(fila, columna, val);
                            }
                            else if (limite == 3)
                            {
                                nuevo = new ParseNode(raiz.ChildNodes[1].Token);
                                miAST(raiz.ChildNodes[0], nuevo);//agrego valor izq
                                miAST(raiz.ChildNodes[2], nuevo);//agrego valor der
                                actual.add(nuevo);
                                return;
                            }
                        }
                        break;
                    case "<CONTINUAR>":
                    case "<DETENER>":
                        nuevo = new ParseNode(fila, columna, valor);
                        actual.add(nuevo);//solo agrego la directiva
                        break;
                    default:
                        if (!"<CONDICION>".Equals(raiz.ToString()))
                        {
                            actual.add(fila, columna, valor);
                        }
                        break;
                }
            }
        }
        #endregion




    }
}

