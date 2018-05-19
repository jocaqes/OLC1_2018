using Irony.Parsing;
using System.Collections.Generic;

namespace CRLapp.Gramatica
{
    class ParseNode:Nodo
    {
        /*private int fila;
        private int columna;
        private string valor;
        private string tipo;*/
        public List<ParseNode> childNodes;


        #region Constructores
        public ParseNode(Token item)
        {
            if (item != null)
            {
                //item.Category.ToString();
                Fila = item.Location.Line;
                Columna = item.Location.Column;
                int lparen = item.Text.LastIndexOf('(');
                int limite = item.Text.Length;
                if (lparen > 0)
                {
                    Valor = item.Text.Substring(0, lparen-1);
                    Tipo = item.Text.Substring(lparen, limite - 1);
                }else
                {
                    Valor = item.Text;
                    Tipo = item.Text;
                }
                /*string[] aux=item.Text.Split(' ');
                valor = aux[0];
                if (aux.Length > 1)
                    Tipo = item.Category.ToString();
                //Tipo = aux[1];
                else
                    Tipo = valor;*/
                //valor = item.Text;
            }
            else
            {
                Valor = "<ERROR>";
            }
            childNodes = new List<ParseNode>();
        }

        public ParseNode(int fila, int columna, string valor)
        {
            Fila = fila;
            Columna = columna;
            int lparen = valor.LastIndexOf('(');
            int limite = valor.Length;
            if (lparen > 0)
            {
                Valor = valor.Substring(0, lparen - 1);
                Tipo = valor.Substring(lparen, limite-lparen);
            }
            else
            {
                Valor = valor;
                Tipo = valor;
            }
            /*string[] aux = valor.Split(' ');
            this.valor = aux[0];
             if (aux.Length > 1)
                 Tipo = aux[aux.Length-1];
             else
                 Tipo = valor;*/
            //this.valor = valor;
            childNodes = new List<ParseNode>();
        }

        public ParseNode(int fila, int columna, string valor, string tipo):base(fila,columna,valor,tipo)
        {
            //en este caso que es solo para operar, no necesito que tenga childNodes
            childNodes = null;
        }
        #endregion

        #region Agregar Hijo
        public void add(int fila, int columna, string valor)
        {
            childNodes.Add(new ParseNode(fila, columna, valor));
        }
        public void add(int fila, int columna, string valor,string tipo)
        {
            childNodes.Add(new ParseNode(fila, columna, valor,tipo));
        }

        public void add(ParseNode nuevo)
        {
            if (nuevo != null)
            {
                childNodes.Add(nuevo);
            }
        }
        #endregion

        #region Hijo derecho e izquierdo
        public ParseNode izq()
        {
            if (childNodes != null)
            {
                if (childNodes.Count > 0)
                {
                    return childNodes[0];
                }
            }
            return null;
        }
        public ParseNode der()
        {
            if (childNodes != null)
            {
                if (childNodes.Count > 1)
                {
                    return childNodes[1];
                }
            }
            return null;
        }
        #endregion


        public override string ToString()
        {
            string salida = Valor;
            if (salida.Contains("'"))
            {
                salida = salida.Replace("'","");
            }
            return salida;
        }
    }
}
