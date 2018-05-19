using CRLapp.Gramatica;
using System.Collections.Generic;

namespace CRLapp.Ejecucion
{
    class Metodo
    {
        private string nombre;
        private string id;
        private string tipo;
        private string ambito;
        private ParseNode raiz;
        public List<Simbolo> parametros;

        #region Constructores
        public Metodo(string nombre, string tipo, string ambito, ParseNode raiz)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.ambito = ambito;
            this.raiz = raiz;
            if (raiz.childNodes.Count > 2)
                generarId(raiz.childNodes[2]);
            else
            {
                id = "";
                parametros = null;
            }
        }

        public Metodo(ParseNode raiz, string ambito)
        {
            construirMetodo(raiz);
            this.ambito = ambito;
        }
        #endregion

        #region auxiliares
        private void construirMetodo(ParseNode raiz)
        {
            int no_hijos = raiz.childNodes.Count;
            if(no_hijos>2)
            {
                tipo = raiz.childNodes[0].ToString();
                nombre = raiz.childNodes[1].ToString();
                generarId(raiz.childNodes[2]);
            }
            else//ni parametros ni sentencia
            {
                tipo = raiz.childNodes[0].ToString();
                nombre = raiz.childNodes[1].ToString();
                id = "";
            }
            this.raiz = raiz;
        }

        private void generarId(ParseNode raiz)
        {
            id = "";
            if ("<PARAMETRO>".Equals(raiz.ToString()))//recupero los parametros tambien
            {
                parametros = new List<Simbolo>();
                int limite = raiz.childNodes.Count;
                string tipo_dato;
                string identificador;
                for (int i = 0; i < limite; i += 2)//los tipos estan en posiciones pares
                {
                    tipo_dato = raiz.childNodes[i].ToString();
                    identificador = raiz.childNodes[i + 1].ToString();
                    parametros.Add(new Simbolo(tipo_dato, identificador, nombre, raiz.Fila, raiz.Columna));
                    id += raiz.childNodes[i].ToString();
                }
            }
        }
        #endregion

        #region Getter y Setter
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Ambito
        {
            get
            {
                return ambito;
            }

            set
            {
                ambito = value;
            }
        }

        public ParseNode Raiz
        {
            get
            {
                return raiz;
            }

            set
            {
                raiz = value;
            }
        }
        public ParseNode Sentencia
        {
            get
            {
                foreach(ParseNode hijo in raiz.childNodes)
                {
                    if ("<SENTENCIA>".Equals(hijo.ToString()))
                        return hijo;
                }
                return null;
            }
        }
        #endregion

        public override string ToString()
        {
            return nombre + id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Metodo transformado = obj as Metodo;
            if (transformado == null) return false;
            return Equals(transformado);
        }
        private bool Equals(Metodo otro)
        {
            return ToString().Equals(otro.ToString());
        }
    }
}
