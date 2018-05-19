using CRLapp.Gramatica;
using CRLapp.ManejoArchivos;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;//usado para revisar las cadenas de mostrar

namespace CRLapp.Ejecucion
{
    class Ejecucion_
    {
        private List<Error_> lista_errores;//espera
        private List<Metodo> lista_metodos;//espera
        private TablaSimbolo tabla_global;
        private TablaSimbolo tabla_local;
        private Stack<string> pila_ambito;//espera
        private Stack<string> pila_subambito;
        private string ruta;//espera
        private double incerteza;//espera
        private RichTextBox consola;//espera

        public Ejecucion_(ParseNode raiz,RichTextBox consola,string ruta="D:/Sistemas/2018/OLC/proyecto_2/")
        {
            inicializarListas();//inicializa todas las listas, tablas, pilas
            //tabla_local = tabla_global;//debug
            incerteza = 0.0;//debug
            this.consola = consola;
            this.ruta = ruta;
            establecerVariables_Funciones_Iniciales(raiz);
            ParseNode main = establecerMain(raiz);
            pila_ambito.Push("principal");//espera
            
            ejecutar(main);
            //pila_ambito.Pop();//espera

        }

        #region Ejecucion
        public Nodo ejecutar(ParseNode raiz)//nodo es una clase padre de ParseNode, es mas simple y no puede tener childNodes
        {
            if (raiz == null)//importante revisar siempre por null
                return null;
            string sentencia = "";//el nombre de la sentencia a ejecutar
            //string tipo_dato;//el tipo de dato para alguna variable declarada
            //string id;//el identificador de alguna variable
            string ambito=pila_ambito.Peek();//el ambito actual?
            //Nodo resultado;//lo que retorno en caso de que haya alguna sentencia return, es null para un return solito
            Nodo retorno = null;
            foreach(ParseNode hijo in raiz.childNodes)//por cierto, ParseNode es una clase para simplificar el arbol que genera irony
            {
                sentencia = hijo.ToString();
                switch (sentencia)
                {
                    case "<DECLARACION>":
                        //ambito = pila_ambito.Peek();
                        //pila_ambito.Push(ambito);
                        declaracion(tabla_local, hijo, ambito);
                        break;
                    case "<ASIGNAR>":
                        //ambito = pila_ambito.Peek();
                        //pila_ambito.Push(ambito);
                        asignar(tabla_local, hijo, ambito);
                        break;
                    case "<LLAMADA>":
                        retorno = llamada(hijo);
                        break;
                    case "<IF>"://en cada sentencia de control, se revisa si tiene un return,un break,continue,etc
                        pila_subambito.Push("Si");
                        retorno = si(hijo);
                        if (retorno != null)
                        {
                            if ("<DETENER>".Equals(retorno.Tipo))
                            {
                                //pila_ambito.Pop();//nuevo
                                return retorno;
                            }
                            else if ("<CONTINUAR>".Equals(retorno.Tipo))
                            {
                                //pila_ambito.Pop();//nuevo
                                return retorno;
                            }else if ("<RETORNO>".Equals(retorno.Tipo))
                            {
                                return retorno;
                            }
                        }
                        break;
                    case "<WHILE>"://mientras //en cada sentencia de control, se revisa si tiene un return,un break,continue,etc
                        pila_subambito.Push("Si");
                        retorno = mientras_o_Hasta(hijo);
                        if ("<RETORNO>".Equals(retorno.Tipo))
                        {
                            return retorno;
                        }
                        break;
                    case "<DO>"://hasta //en cada sentencia de control, se revisa si tiene un return,un break,continue,etc
                        pila_subambito.Push("Si");
                        retorno = mientras_o_Hasta(hijo, false);//reciclo
                        if ("<RETORNO>".Equals(retorno.Tipo))
                        {
                            return retorno;
                        }
                        break;
                    case "<FOR>"://en cada sentencia de control, se revisa si tiene un return,un break,continue,etc
                        pila_subambito.Push("Si");
                        retorno = para(hijo, ambito);
                        if ("<RETORNO>".Equals(retorno.Tipo))
                        {
                            return retorno;
                        }
                        break;
                    case "<SWITCH>":
                        break;
                    case "<DETENER>":
                        return new Nodo(hijo.Fila, hijo.Columna, null, "<DETENER>");//Porque no poner simplemente return? porque podria ser un while/for/do con if anidados y dentro de ellos la sentencia detener/continue/etc se debe retornar hasta el padre
                    case "<RETORNO>":
                        //los hijos de retorno son de la forma res_Retorno <CONDICION>, donde <condicion> es opcional
                        if (hijo.der() == null)//si no tiene expresion para retornar
                        {
                            Nodo de_retorno = new Nodo(hijo.Fila, hijo.Columna, null, "<RETORNO>");
                            de_retorno.Sub_tipo = "Vacio";//solo se usa para el caso de retorno
                            return de_retorno;
                        }
                        else
                        {
                            Nodo de_retorno = new Nodo(hijo.Fila, hijo.Columna, null, "<RETORNO>");
                            Nodo resultado = calculo(hijo.der());//calculamos el valor de retorno
                            de_retorno.Sub_tipo =resultado.Tipo;//solo se usa para el caso de retorno
                            de_retorno.Valor = resultado.Valor;
                            return de_retorno;
                        }
                    case "<CONTINUAR>":
                        return new Nodo(hijo.Fila, hijo.Columna, null, "<CONTINUAR>");
                    case "<MOSTRAR>":
                        mostrar(hijo);
                        break;
                    case "<DIBUJAR>":
                        string sub_ambito="";
                        if (pila_subambito.Count>0)
                            sub_ambito = pila_subambito.Peek();
                        dibujar(hijo, ambito + "_" + sub_ambito);
                        break;
                }
            }
            pila_ambito.Pop();
            return retorno;
        }
        #endregion

        #region Funciones iniciales
        public void establecerIncertezaRuta(double incerteza,string ruta= "D:/Sistemas/2018/OLC/proyecto_2/")
        {
            this.incerteza = incerteza;
            this.ruta = ruta;
        }
        public void establecerVariables_Funciones_Iniciales(ParseNode raiz)
        {
            string etiqueta;
            string ambito;
            foreach(ParseNode hijo in raiz.childNodes)
            {
                etiqueta = hijo.ToString();
                switch (etiqueta)
                {
                    case "<DEFINES>":
                    case "<IMPORTS>"://por ahora no importan
                        break;
                    case "<CUERPO>":
                        establecerVariables_Funciones_Iniciales(hijo);
                        break;
                    case "<METODO>":
                        ambito = "global";
                        agregarFuncion(hijo, ambito);
                        break;
                    case "<DECLARACION>":
                        ambito = "global";
                        agregarSimbolo(hijo,ambito);
                        break;
                    case "<DIBUJAR>":
                        dibujarTS("global", tabla_global);
                        break;

                }
            }
        }
        #endregion

        #region Sentencias
        #region Mostrar
        private void mostrar(ParseNode raiz)
        {
            //Los hijos del nodo Mostrar tienen la forma:res_Mostrar texto <valores> donde valores es opcional
            //1.-recuperamos la base del texto
            string texto = raiz.der().ToString();
            //2.-Revisamos cuantos reemplazos debemos hacer
            int contador = 0;
            string patron = @"{\d+}";
            foreach (Match m in Regex.Matches(texto, patron))
                ++contador;
            //3.-Revisamos si tiene parametros que quiera reemplazar
            if (raiz.childNodes.Count == 3)//tiene parametros
            {
                Nodo resultado = null;
                Queue<string> valores_ = new Queue<string>();
                //4.-obtenemos todos los resultados de los valores provistos y los encolamos
                foreach (ParseNode valor in raiz.childNodes[2].childNodes)
                {
                    resultado = calculo(valor);
                    if (!"<error>".Equals(resultado.Tipo))
                        valores_.Enqueue(resultado.ToString());
                }
                //5.-Ahora reemplazamos, si hay menos valores que contador, los que hacen falta no se reemplazan, si hay mas se ignoran
                string sub_patron;
                for(int i = 0; i < contador; i++)
                {
                    sub_patron = "{" + i + "}";
                    if (valores_.Count > 0)
                        texto = texto.Replace(sub_patron, valores_.Dequeue());
                }
            }
            //6.-Si tiene algo para reemplazar pues se deja asi como viene
            consola.Text = consola.Text+string.Format(texto)+"\n";//porque uso format? porque eso de que cambie 2Y por 2017 solo lo hace string.format (y el aux no deberia poner algo como eso)
        }
        #endregion
        #region Dibujar
        private void dibujar(ParseNode raiz,string ambito)
        {
            //la sentencia dibujar puede ser de 3 tipos
            //1 Dibujar AST con hijos de la forma: DibujarAST nombre_funcion
            //2 Dibujar Exp con hijos de la fomra: DibujarEXP <CONDICION>
            //3 Dibujar Ts con solo un hijo de la forma:DibujarTS
            //1.-Revisamos el tipo de peticion
            string tipo_dibujo = raiz.izq().ToString();
            switch (tipo_dibujo)
            {
                case "DibujarAST":
                    foreach(Metodo metodito in lista_metodos)
                    {
                        if (raiz.der().ToString().Equals(metodito.Nombre))
                        {
                            dibujarAST(metodito.Sentencia, metodito.ToString(), metodito.Tipo);
                        }
                    }
                    break;
                case "DibujarEXP":
                    dibujarEXP(raiz.der());
                    break;
                case "DibujarTS":
                    dibujarTS(ambito, tabla_local);
                    break;
            }
        }
        private void dibujarAST(ParseNode raiz, string cabezera, string tipo)
        {
            //1.-Guardamos el dot
            Archivo.guardar(Analisis.dibujarFuncion(raiz, tipo+":"+cabezera), ruta + "AST_" + cabezera + ".dot");//obviamos lo que devuelve
        }
        private void dibujarTS(string ambito,TablaSimbolo tabla)
        {
            //1.-Guardamos el dot
            Archivo.guardar(tabla.graficaTabla(ambito), ruta + "TS_" + ambito + ".dot");//obviamos que devuelve, asumimos que todo funciona
            //2.-Llamamos el comando para generar la imagen
            Archivo.generarGrafica(ruta, "TS_" + ambito + ".dot");
        }
        private void dibujarEXP(ParseNode raiz)
        {
            //Las expresiones requieren un correlativo, asi que primero decidimos el nombre del dot verificando la existencia de archivos anteriores
            //1.-Determinar el nombre final del dot
            int correlativo=1;
            string path_dot = "EXP_";
            while (System.IO.File.Exists(System.IO.Path.Combine(ruta,path_dot+correlativo+".dot")))
            {
                correlativo++;
            }
            //2.-Generamos el nombre final del dot
            path_dot += correlativo + ".dot";
            //3.-Llamamos una funcion auxiliar para que nos de el codigo graphviz de la expresion
            string expresion=Analisis.dibujar(raiz,true);
            //4.-Guardamos el dot
            Archivo.guardar(expresion, ruta+path_dot);
            //5.-Llamamos el comando para generar la imagen
            Archivo.generarGrafica(ruta, path_dot);
        }
        #endregion
        #region Llamada
        private Nodo llamada(ParseNode raiz)
        {
            //los hijos de llamada tienen la forma: nombre_funcion <VALORES>
            //1.-recuperamos el nombre del metodo
            string id_metodo = raiz.izq().ToString();
            //2.-Verificamos si existe el metodo, en este punto todavia no vemos si el no. de parametros es correcto
            if (!existeMetodo(id_metodo))
                return null;
            //3.-Una vez que revisamos que existe el metodo revisamos si hay valores para recuperar el metodo
            Metodo funcion=null;
            Nodo retorno=null;
            if (raiz.der() == null)//no hay valores
            {
                funcion = getMetodo(id_metodo);
                //4.-Si no encontramos un metodo sin parametros, es error
                if (funcion == null)
                {
                    addError(new Nodo(raiz.Fila, raiz.Columna, "El metodo:" + id_metodo + " no existe", "<error>"));
                    return new Nodo(raiz.Fila, raiz.Columna, "1", "Int");//retornamos un entero por si acaso, para continuar con la ejecucion
                }
                //5.-Si no es null entonces ejecutamos el metodo sin parametros
                TablaSimbolo aux = tabla_local;//se guarda la tabla actual
                tabla_local = new TablaSimbolo();//pasamos a una tabla para if
                tabla_local.cambiarAmbito(aux);//pasamos los valores de aux a local
                pila_ambito.Push(id_metodo);//agregamos el nuevo ambito
                retorno = ejecutar(funcion.Sentencia);//llamamos la raiz de las sentencias de funcion y las mandamos a ejecutar
                //6.-Solo aqui sabemos el tipo de la funcion y el tipo de retorno, asi que revisamos y lanzamos un error de ser necesario

                tabla_local = aux;//recuperamos la tabla local
            }
            else//si hay valores
            {
                //4.-calculamos los valores y los metemos en una lista
                List<Nodo> valores = new List<Nodo>();
                Nodo resultado=null;
                foreach(ParseNode valor in raiz.der().childNodes)//llamada->valores
                {
                    resultado = calculo(valor);//calculo agrega cualquier error, no retorna null en ningun caso
                    valores.Add(resultado);
                }
                //5.-Teniendo los valores generamos el id extra
                string id_extra = "";
                foreach(Nodo val in valores)
                {
                    id_extra += val.Tipo;
                }
                //6.-Con el id extra buscamos otra vez a funcion pero con id_metodo+id_extra
                funcion = getMetodo(id_metodo + id_extra);
                //7.-Si no encontramos un metodo con esos parametros, es error, no se puede hacer typecasting para parametros, eso se haria con templates y no lo maneja nuestra gramatica
                if (funcion == null)
                {
                    addError(new Nodo(raiz.Fila, raiz.Columna, "El metodo:" + id_metodo + "con parametros:"+id_extra+" no existe", "<error>"));
                    pila_ambito.Pop();//nuevo
                    return new Nodo(raiz.Fila, raiz.Columna, "1", "Int");//retornamos un entero por si acaso, para continuar con la ejecucion
                }
                //8.-Si no es null ejecutamos el metodo, pero antes agregamos a su tabla, simbolos que corresponden a sus parametros
                //esta forma de agregar es distinda, pues si el metodo es recursivo y declara una variable, en lugar de intentar declararla otra vez, cambiamos su valor
                TablaSimbolo aux = tabla_local;//se guarda la tabla actual
                tabla_local = new TablaSimbolo();//pasamos a una tabla para if
                tabla_local.cambiarAmbito(aux);//pasamos los valores de aux a local
                pila_ambito.Push(id_metodo);//agregamos el nuevo ambito
                //8.1.-Aqui agregamos los parametros como simbolo
                int limite = valores.Count;
                Simbolo actual = null;
                Nodo valor_actual = null;
                for(int i = 0; i < limite; i++)
                {
                    actual = funcion.parametros[i];
                    valor_actual = valores[i];
                    actual.asignar(valor_actual);
                    tabla_local.replace(actual);//esta es la funcion que agrega o reemplaza cuando es requerido
                }
                //9.-ejecutamos
                retorno = ejecutar(funcion.Sentencia);//llamamos la raiz de las sentencias de funcion y las mandamos a ejecutar
                tabla_local = aux;//recuperamos la tabla local
            }
            if ("<RETORNO>".Equals(retorno.Tipo))
            {
                retorno.Tipo=retorno.Sub_tipo;
            }
            pila_ambito.Pop();
            return retorno;
        }
        #endregion
        #region Para-Mientras-Hasta
        private Nodo para(ParseNode raiz,string ambito)
        {
            if (raiz.childNodes.Count < 7)//no tiene sentencia
            {
                pila_subambito.Pop();//nuevo
                return null;
            }
            Nodo retorno = null;
            //los hijos de for son de la forma: para Double id E <condicion> <op> <sentenciaw>, sentencia es opcional
            string nombre = raiz.childNodes[2].ToString();//el nombre de la variable para la condicion
            Simbolo i = new Simbolo("Double", nombre, ambito, raiz.childNodes[2].Fila, raiz.childNodes[2].Columna);//genero un nuevo simbolo
            Nodo valor_i = calculo(raiz.childNodes[3]);
            if ("<error>".Equals(valor_i.Tipo) || "String".Equals(valor_i.Tipo))
            {
                pila_subambito.Pop();//nuevo
                return null;//si hay error dejo de revisar el for
            }
            i.asignar(valor_i);//no deberia haber problema con el type casting
            TablaSimbolo aux = tabla_local;//se guarda la tabla actual
            tabla_local = new TablaSimbolo();//pasamos a una tabla para if
            tabla_local.cambiarAmbito(aux);//pasamos los valores de aux a local
            if (!tabla_local.add(i))//si la variable de reconocimiento ya existe
            {
                pila_subambito.Pop();//nuevo
                addError(new Nodo(i.Fila, i.Columna, "La variable:" + i.Identificador + " ya fue definida en este ambito", "<error>"));
                return null;
            }
            Nodo resultado = calculo(raiz.childNodes[4]);//calculo la condicion
            if ("<error>".Equals(resultado.Tipo))//verifico que la condicion si sea un booleano
            {
                pila_subambito.Pop();//nuevo
                return null;//dejo de revisar
            }
            if (!"Bool".Equals(resultado.Tipo))
            {
                pila_subambito.Pop();//nuevo
                addError(new Nodo(raiz.Fila, raiz.Columna, "La condicion del mientras no retorna un booleano", "<error>"));
                return null;
            }
            while (MyMath.toBool(resultado.ToString()))
            {
                retorno = ejecutar(raiz.childNodes[6]);
                if (retorno != null)
                {
                    if ("<DETENER>".Equals(retorno.Tipo))
                        break;//detengo el while
                    if ("<CONTINUAR>".Equals(retorno.Tipo))
                        retorno = null;//ya adentro se encarga de saltar el resto de sentencias asi que solo regreso retorno a ser null
                    if ("<RETORNO>".Equals(retorno.Tipo))
                        break;
                }
                if ("+".Equals(raiz.childNodes[5].izq().ToString()))//++
                {
                    tabla_local.mas_menos(nombre, tabla_global, true);//funcion extra que hice para facilitar el ++/--
                }
                else//--
                {
                    tabla_local.mas_menos(nombre, tabla_global, false);
                }
                resultado = calculo(raiz.childNodes[4]);//recalculamos la condicion
            }
            tabla_local = aux;//recuperamos la tabla local
            if (retorno != null && "<DETENER>".Equals(retorno.Tipo))
                retorno = null;
            pila_subambito.Pop();//nuevo
            return retorno;
        }
        private Nodo mientras_o_Hasta(ParseNode raiz, bool mientras = true)
        {
            Nodo retorno = null;
            //los hijos de while son de la forma: mientras <condicion> <sentencia>, sentencia es opcional
            if (raiz.childNodes.Count <= 2)//si no hay sentencia, el while podria ser infinito
            {
                pila_subambito.Pop();//nuevo
                addError(new Nodo(raiz.Fila, raiz.Columna, "La funcion mientras no tiene forma de salir", "<error>"));
                return null;
            }
            Nodo resultado = calculo(raiz.der());
            if ("<error>".Equals(resultado.Tipo))
            {
                pila_subambito.Pop();//nuevo
                return null;//dejo de revisar
            }
            if (!"Bool".Equals(resultado.Tipo))
            {
                pila_subambito.Pop();//nuevo
                addError(new Nodo(raiz.Fila, raiz.Columna, "La condicion del mientras no retorna un booleano", "<error>"));
                return null;
            }
            TablaSimbolo aux = tabla_local;//se guarda la tabla actual
            tabla_local = new TablaSimbolo();//pasamos a una tabla para if
            tabla_local.cambiarAmbito(aux);//pasamos los valores de aux a local
            if (mientras)
            {
                while (MyMath.toBool(resultado.ToString()))
                {
                    retorno = ejecutar(raiz.childNodes[2]);
                    //Verificamos si no hay un continue/break/etc
                    if (retorno != null)
                    {
                        if ("<DETENER>".Equals(retorno.Tipo))
                            break;//detengo el while
                        if ("<CONTINUAR>".Equals(retorno.Tipo))
                            retorno = null;//ya adentro se encarga de saltar el resto de sentencias asi que solo regreso retorno a ser null
                        if ("<RETORNO>".Equals(retorno.Tipo))
                        {
                            break;
                        }
                    }
                    resultado = calculo(raiz.der());
                }
            }
            else
            {
                while (!MyMath.toBool(resultado.ToString()))
                {
                    retorno = ejecutar(raiz.childNodes[2]);
                    resultado = calculo(raiz.der());
                }
            }
            tabla_local = aux;//recuperamos la tabla local
            if (retorno!=null&&"<DETENER>".Equals(retorno.Tipo))
                retorno = null;//limpio el detener, si no se podria propagar a otras cosas
            pila_subambito.Pop();//nuevo
            return retorno;
        }
        #endregion
        #region Sentencia If
        private Nodo si(ParseNode raiz)
        {
            Nodo retorno = null;
            //los hijos de if son de la forma: Si <condicion> <sentencia> <else>, sentencia y else son opcionales
            if (raiz.childNodes.Count <= 2)
            {
                pila_subambito.Pop();//nuevo
                return null;//no hago nada, no tiene ni sentencia ni else
            }
            ParseNode si = null;
            ParseNode sino = null;
            foreach (ParseNode hijo_ in raiz.childNodes)//recupero las sentencias si,sino
            {
                if ("<SENTENCIAW>".Equals(hijo_.ToString()))
                    si = hijo_;
                else if ("<ELSE>".Equals(hijo_.ToString()))
                    sino = hijo_;
            }
            Nodo resultado = calculo(raiz.childNodes[1]);//calculo el valor de la condicion
            if ("<error>".Equals(resultado.Tipo))
            {
                pila_subambito.Pop();//nuevo
                return null;//dejo de revisar el if
            }
            if (!"Bool".Equals(resultado.Tipo))
            {
                pila_subambito.Pop();//nuevo
                addError(new Nodo(raiz.Fila, raiz.Columna, "La condicion del mientras no retorna un booleano", "<error>"));
                return null;
            }
            TablaSimbolo aux = tabla_local;//se guarda la tabla actual
            tabla_local = new TablaSimbolo();//pasamos a una tabla para if
            tabla_local.cambiarAmbito(aux);//pasamos los valores de aux a local
            if (MyMath.toBool(resultado.ToString()))
            {
                retorno = ejecutar(si);//si es null no hace nada
            }
            else
            {
                //los hijos de <else> tienen la forma: sino <sentencia>
                if (sino != null)
                {
                    retorno = ejecutar(sino.der());
                }
            }
            tabla_local = aux;//recuperamos la tabla local
            pila_subambito.Pop();//nuevo
            return retorno;
        }
        #endregion
        #region Declaracion Asignacion
        private void declaracion(TablaSimbolo tabla,ParseNode raiz,string ambito)
        {
            pila_ambito.Push(ambito);//nuevo
            string tipo_dato;
            tipo_dato = raiz.childNodes[0].ToString();
            Nodo resultado = null;
            if (raiz.childNodes.Count > 2)//de la forma <tipodato><id><asignacion>
            {
                //asignacion es de la forma <condicion> solo tiene un hijo
                resultado = calculo(raiz.childNodes[2].izq());//<declaracion>-><asignacion>-><condicion>
                if ("<error>".Equals(resultado.Tipo))//si hay un error semantico en el calculo
                {
                    resultado = null;//calculo ya se encarga de agregar el error
                }
            }
            //revisamos los ids para agregarlos
            ParseNode ids = raiz.childNodes[1];
            Simbolo nuevo;
            foreach (ParseNode hijo in ids.childNodes)
            {
                nuevo = new Simbolo(tipo_dato, hijo.ToString(), ambito, hijo.Fila, hijo.Columna);//genero un nuevo simbolo
                addError(nuevo.asignar(resultado));//si tuviese un error en la asignacion, lo agrega, si no hay no hace nada la funcion adderror
                if (!tabla.add(nuevo))//si no se logra agregar(por eso el !)
                {
                    addError(new ParseNode(nuevo.Fila, nuevo.Columna, "La variable:" + hijo.ToString() + " ya fue declarada", "<error>"));
                }
            }
        }
        private void asignar(TablaSimbolo tabla, ParseNode raiz, string ambito)
        {
            pila_ambito.Push(ambito);//nuevo
            //los hijos del nodo asignar son de la forma: id <asignacion>
            string id = raiz.izq().ToString();
            //el nodo <asignacion> solo tiene al hijo <condicion>
            ParseNode asignacion = raiz.der();
            Nodo resultado=calculo(asignacion.izq());//reitero, calculo ya se encarga de guardar errores
            if ("<error>".Equals(resultado.Tipo))//si es error no asigno nada
                return;
            addError(tabla.asignarValor(id, resultado, tabla_global));//si no hay error solo asigna el valor
        }
        #endregion
        #endregion

        #region Acciones
        private Metodo getMetodo(string id_completo)
        {
            foreach(Metodo actual in lista_metodos)
            {
                if (id_completo.Equals(actual.ToString()))//aqui ya se toman en cuenta los parametros de un metodo ademas de su nombre
                    return actual;
            }
            return null;
        }
        
        private bool existeMetodo(string id_metodo)
        {
            foreach(Metodo actual in lista_metodos)
            {
                if (id_metodo.Equals(actual.Nombre))
                    return true;
            }
            return false;
        }
        private bool existeMetodo(Metodo nuevo)
        {
            return lista_metodos.Contains(nuevo);
        }
        private void agregarFuncion(ParseNode raiz, string ambito)//espera
        {
            Metodo nuevo = new Metodo(raiz, ambito);
            int fila = raiz.childNodes[1].Fila;//fila del id
            int columna = raiz.childNodes[1].Columna;//columna del id
            if (!existeMetodo(nuevo))//si no existe
            {
                lista_metodos.Add(nuevo);
            }
            else
            {
                addError(new Nodo(fila, columna, "El metodo:" + nuevo.Nombre + " ya fue declarado", "<error>"));
            }
        }


        private void agregarSimbolo(ParseNode raiz,string ambito)
        {
            string tipo_dato;
            int no_hijos = raiz.childNodes.Count;
            if (no_hijos == 3)//declaracion y asignacion
            {
                tipo_dato = raiz.childNodes[0].ToString();
                Nodo resultado = calculo(raiz.childNodes[2].izq());
                if (resultado.Tipo.Equals("<error>"))
                    resultado = null;
                //Simbolo nuevo;
                ParseNode ids = raiz.childNodes[1];//el id o lista de ids
                add(ids, ambito, tipo_dato, resultado);//agrega los ids
            }
            else//no hay asignacion
            {
                tipo_dato = raiz.childNodes[0].ToString();
                //Simbolo nuevo;
                ParseNode ids = raiz.childNodes[1];//el id o lista de ids
                add(ids, ambito, tipo_dato, null);//agrega los ids
            }
        }



        private void add(ParseNode raiz,string ambito,string tipo_dato,Nodo resultado)
        {
            Simbolo nuevo;
            foreach(ParseNode hijo in raiz.childNodes)
            {
                nuevo = new Simbolo(tipo_dato, hijo.ToString(), ambito, hijo.Fila, hijo.Columna);//genero un nuevo simbolo
                addError(nuevo.asignar(resultado));//si tuviese un error en la asignacion, lo agrega, si no hay no hace nada la funcion adderror
                if (!tabla_global.add(nuevo))//si no se logra agregar(por eso el !)
                {
                    addError(new ParseNode(nuevo.Fila, nuevo.Columna, "La variable:" + hijo.ToString() + " ya fue declarada", "<error>"));
                }
            }
        }

        private ParseNode establecerMain(ParseNode raiz)//busca la funcion Principal y retorna el nodo de sentencias si existe
        {
            //los hijos de la raiz son de la forma <imports> <defines> <cuerpo> pero TODOS son opcionales
            //1.- revisamos los hijos en busca de cuerpo
            ParseNode cuerpo = null;
            foreach(ParseNode hijo in raiz.childNodes)//a lo sumo son 3 veces
            {
                if ("<CUERPO>".Equals(hijo.ToString()))
                {
                    cuerpo = hijo;
                }
            }
            if(cuerpo==null)//si no encuentra cuerpo, no hay nada que analizar pero aun asi no cuenta como error
                return null;
            //los hijos de cuerpo son de la forma <declaracion> <dibujar> <metodo> <main> repetidos n veces y en cualquier orden
            //2.-revisamos los hijos en busca del primer main
            ParseNode main = null;
            foreach(ParseNode hijo_2 in cuerpo.childNodes)
            {
                if ("<MAIN>".Equals(hijo_2.ToString()))
                {
                    main = hijo_2;
                    break;//solo el primer main es usado, los demas se ignoran
                }
            }
            if(main==null)
                return null;
            //los hijos de main son de la forma principal <sentencia>, solo nos interesa sentencia
            //3.-recuperamos sentencia si existe
            if(main.childNodes.Count<2)//solo viene con principal pero sin <sentencia> asi que no hay nada para ejecutar
                return null;
            return main.childNodes[1];//0 es principal, 1 es <sentencia>
        }
        #endregion

        #region Calculos
        private Nodo calculo(ParseNode raiz)
        {
            string operador = raiz.Valor;
            Nodo valor1 = null;
            Nodo valor2 = null;
            switch (operador)
            {
                case "&&":
                case "||":
                case "|&":
                    valor1 = calculo(raiz.izq());
                    if ("<error>".Equals(valor1.Tipo))
                    {
                        addError(valor1);//agrego el error
                        valor1 = new Nodo(valor1.Fila, valor1.Columna, "false", "Bool");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    valor2 = calculo(raiz.der());
                    if ("<error>".Equals(valor2.Tipo))
                    {
                        addError(valor2);//agrego el error
                        valor2 = new Nodo(valor2.Fila, valor2.Columna, "false", "Bool");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    return MyMath.logico(valor1, valor2, operador);
                case "!":
                    valor1 = calculo(raiz.izq());
                    if ("<error>".Equals(valor1.Tipo))
                    {
                        addError(valor1);//agrego el error
                        valor1 = new Nodo(valor1.Fila, valor1.Columna, "false", "Bool");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    return MyMath.logico(valor1, null, operador);
                case "<":
                case ">":
                case "<=":
                case ">=":
                case "==":
                case "!=":
                case "~":
                    valor1 = calculo(raiz.izq());
                    if ("<error>".Equals(valor1.Tipo))
                    {
                        addError(valor1);//agrego el error
                        valor1 = new Nodo(valor1.Fila, valor1.Columna, "false", "Bool");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    valor2 = calculo(raiz.der());
                    if ("<error>".Equals(valor2.Tipo))
                    {
                        addError(valor2);//agrego el error
                        valor2 = new Nodo(valor2.Fila, valor2.Columna, "false", "Bool");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    return MyMath.relacion(valor1, valor2, operador, incerteza);
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                case "^":
                    valor1 = calculo(raiz.izq());
                    if ("<error>".Equals(valor1.Tipo))
                    {
                        addError(valor1);//agrego el error
                        valor1 = new Nodo(valor1.Fila, valor1.Columna, "1", "Int");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    valor2 = calculo(raiz.der());
                    if ("<error>".Equals(valor1.Tipo))
                    {
                        addError(valor2);//agrego el error
                        valor2 = new Nodo(valor2.Fila, valor2.Columna, "false", "Int");//y lo cambio a un tipo adecuado para seguir el analisis
                    }
                    return MyMath.expresion(valor1,valor2,operador);
                default:
                    string tipo = raiz.Tipo;
                    switch (tipo)
                    {
                        case "Int":
                        case "Double":
                        case "Bool":
                        case "String":
                        case "Char":
                            return raiz;
                        default://aqui iria a buscar id, calcular funciones etc
                            if ("(tk_id)".Equals(tipo))
                            {
                                Nodo valor = tabla_local.getValor(raiz.ToString(), tabla_global);
                                if (valor == null)//no encontro la variable
                                {
                                    addError(new Nodo(raiz.Fila, raiz.Columna, "La variable:" + raiz.ToString() + " no existe", "<error>"));
                                    return new Nodo(0, 0, "0", "Int");//para seguir con la ejecucion
                                }
                                else if ("<error>".Equals(valor.Tipo))//la variable no tiene un valor asignado
                                {
                                    addError(valor);
                                    return new Nodo(0, 0, "0", "Int");//para seguir con la ejecucion
                                }
                                else
                                {
                                    return valor;//todo salio bien
                                }
                            }
                            else//deberia ser la llamada a una funcion
                            {
                                if ("<LLAMADA>".Equals(tipo))
                                {
                                    Nodo valor = llamada(raiz);
                                    if(valor==null)
                                    {
                                        addError(new Nodo(raiz.Fila, raiz.Columna, "La funcion:" + raiz.izq().ToString() + " no retorna ningun valor", "<error>"));
                                        return new Nodo(0, 0, "0", "Int");
                                    }
                                    else
                                    {
                                        if ("Vacio".Equals(valor.Tipo))
                                        {
                                            addError(new Nodo(raiz.Fila, raiz.Columna, "La funcion:" + raiz.izq().ToString() + " no retorna ningun valor", "<error>"));
                                            return new Nodo(0, 0, "0", "Int");
                                        }
                                    }
                                    return valor;
                                }
                                else
                                    return new Nodo(0, 0, "0", "Int");//debug
                            }
                            
                    }
            }
        }
        #endregion

        #region Extras
        public void addError(Nodo nodo_error, string tipo="")
        {
            if (nodo_error == null)
                return;
            if ("<error>".Equals(nodo_error.Tipo))
            {
                string tipo_;
                if (string.IsNullOrEmpty(tipo)) tipo_ = "Semantico";
                else tipo_ = tipo;

                lista_errores.Add(new Error_(nodo_error.Fila, nodo_error.Columna, nodo_error.ToString(), tipo_));
            }
        }
        private void inicializarListas()
        {
            lista_errores = new List<Error_>();
            lista_metodos = new List<Metodo>();
            pila_ambito = new Stack<string>();
            tabla_global = new TablaSimbolo();
            tabla_local = new TablaSimbolo();
            pila_subambito = new Stack<string>();//nuevo
        }
        #endregion

    }
}
