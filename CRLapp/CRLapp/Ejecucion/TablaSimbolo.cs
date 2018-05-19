using System.Collections.Generic;
using CRLapp.Gramatica;

namespace CRLapp.Ejecucion
{
    class TablaSimbolo
    {
        private List<Simbolo> simbolos;

        public TablaSimbolo()
        {
            simbolos = new List<Simbolo>();
        }


        #region Add
        public bool add(string tipo, string identificador, string ambito, int fila, int columna)
        {
            Simbolo nuevo = new Simbolo(tipo, identificador, ambito, fila, columna);
            if (simbolos.Contains(nuevo))
            {
                return false;//falso si no se logra agregar, que significa que la variable ya existe
            }
            simbolos.Add(nuevo);
            return true;//verdadero si se logra agregar
        }

        public bool add(Simbolo nuevo)
        {
            if (simbolos.Contains(nuevo))
                return false;//falso si no lo logra agregar
            simbolos.Add(nuevo);
            return true;//true si no hay problema
        }
        public void replace(Simbolo nuevo)
        {
            if (simbolos.Contains(nuevo))//si lo contiene lo reemplaza
            {
                Simbolo viejo = getSimbolo(nuevo.Identificador);
                viejo.asignar(nuevo.Valor);//solo reemplaza su valor
            }
            else//si no lo agrega
            {
                simbolos.Add(nuevo);
            }
        }
        #endregion

        #region Obtener valor
        public Nodo getValor(string identificador,TablaSimbolo global)//tomado como base el ejemplo
        {
            Simbolo aux = getSimbolo(identificador);//busca en esta tabla
            if (aux == null)//si el simbolo no esta en esta tabla
                aux = global.getSimbolo(identificador);//busca en la tabla global
            if (aux == null)//si aun asi no lo encuentra
                return null;//<error> la variable no existe
            return aux.Valor;//si el simbolo no tuviese un valor asignado, el se encarga de mandarme un ParseNode con mensaje de error
        }

        private Simbolo getSimbolo(string identificador)//busca aqui, en esta tabla
        {
            return simbolos.Find(x => x.Identificador.Equals(identificador));//funcion nativa de List
        }
        #endregion

        #region Modificar valor
        public Nodo asignarValor(string identificador,Nodo valor,TablaSimbolo global)
        {
            Simbolo aux = getSimbolo(identificador);//busca en esta tabla
            if (aux == null)//si el simbolo no esta en esta tabla
                aux = global.getSimbolo(identificador);//busca en la tabla global
            if (aux == null)
                return new Nodo(0,0,"La variable:"+identificador+" no existe","<error>");
            return aux.asignar(valor);//se retorna null si todo salio bien
        }
        public void mas_menos(string identificador,TablaSimbolo global,bool mas)
        {
            Simbolo aux = getSimbolo(identificador);//busca en esta tabla
            if (aux == null)//si el simbolo no esta en esta tabla
                aux = global.getSimbolo(identificador);//busca en la tabla global
            if (aux == null)
                return;
            double valor = double.Parse(aux.Valor.ToString());
            if (mas)
                valor++;
            else
                valor--;
            aux.asignar(new Nodo(0,0,valor.ToString(),"Double"));
        }
        #endregion

        #region Pasar a otra tabla
        public void cambiarAmbito(TablaSimbolo general/*List<Error> errores*/)
        {
            foreach (Simbolo simbolo in general.simbolos)
                simbolos.Add(simbolo);
        }
        #endregion

        #region Grafica
        public string graficaTabla(string ambito)
        {
            string salida = "";
            salida += "digraph G{\n"
                    +"node[shape=plaintext];\n"
                    +"tabla[label=<<TABLE border=\"0\" cellspacing=\"0\" cellborder=\"1\">\n]"
                    +"<TR>\n"
                    +"<TD>Ambito</TD><TD>"+ambito+"</TD>\n"
                    +"</TR>";
            foreach(Simbolo variable in simbolos)
            {
                salida += "<TR>\n";
                salida += "<TD>Variable: " + variable.Identificador + "</TD>";
                if(variable.Val==null)
                    salida += "<TD width=\"500\" fixedsize=\"true\">No tiene valor asignado</TD>\n";
                else
                    salida += "<TD width=\"500\" fixedsize=\"true\">" + variable.Val + "</TD>\n";
                salida += "</TR>\n";
            }
            salida += "</TABLE>>];\n"
                    +"}";
            return salida;
        }
        #endregion
        /*public ParseNode Valor(string identificador, string ambito1, string ambito2)//retorna el valor de la variable que busco
        {
            ParseNode valor = null;
            Simbolo aux = simbolos.Find(x => x.Identificador.Equals(identificador) && x.Ambito.Equals(ambito1));//busco en su ambito
            if (aux == null)
            {
                aux= simbolos.Find(x => x.Identificador.Equals(identificador) && x.Ambito.Equals(ambito2));//busco en ambito 2 que normalmente seria el global
            }
            if (aux != null)//encontre algo
            {
                valor = aux.Valor;
            }
            return valor;//si no encuentra nada esto seria null
        }*/

        /*public ParseNode asignar(ParseNode valor, string identificador, string ambito1, string ambito2)//asigna un valor a la variable indicada
        {
            Simbolo aux = simbolos.Find(x => x.Identificador.Equals(identificador) && x.Ambito.Equals(ambito1));//busco en su ambito
            if (aux == null)
            {
                aux = simbolos.Find(x => x.Identificador.Equals(identificador) && x.Ambito.Equals(ambito2));//busco en ambito 2 que normalmente seria el global
            }
            if (aux != null)//si encontre la variable
            {
                return aux.asignar(valor);//si hay error de type cast retorna un ParseNode, si no hay error retorna null
            }
            return new ParseNode(0,0,"No existe la variable:"+identificador,"<error>");//si no encuentra la variable retorno un ParseNode de error
        }
        */
    }
}
