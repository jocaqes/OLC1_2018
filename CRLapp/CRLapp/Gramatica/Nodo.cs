namespace CRLapp.Gramatica
{
    class Nodo
    {
        private int fila;
        private int columna;
        private string valor;
        private string tipo;
        private string sub_tipo;//usado para return

        public Nodo(int fila, int columna, string valor, string tipo)
        {
            this.fila = fila;
            this.columna = columna;
            this.valor = valor;
            this.tipo = tipo;
        }

        public Nodo() { }//constructor defecto

        #region Getters y Setters
        public int Fila
        {
            get
            {
                return fila;
            }

            set
            {
                fila = value;
            }
        }

        public int Columna
        {
            get
            {
                return columna;
            }

            set
            {
                columna = value;
            }
        }

        public string Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
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
                tipo = changeTipo(value);
            }
        }

        public string Sub_tipo
        {
            get
            {
                return sub_tipo;
            }

            set
            {
                sub_tipo = value;
            }
        }
        #endregion

        private string changeTipo(string tipo)
        {
            switch (tipo)
            {
                case "(cadena)":
                    return "String";
                case "(char)":
                    return "Char";
                case "(tk_entero)":
                    return "Int";
                case "(tk_numero)":
                    return "Double";
                case "(Keyword)":
                    return "Bool";
                default:
                    return tipo;
            }
        }

        public override string ToString()
        {
            return valor;
        }

    }
}
