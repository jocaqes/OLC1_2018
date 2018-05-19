using CRLapp.Gramatica;

namespace CRLapp.Ejecucion
{
    class Simbolo
    {
        private string tipo;
        private string identificador;
        private string ambito;
        private int fila;
        private int columna;
        private string valor;

        public Simbolo(string tipo, string identificador, string ambito, int fila, int columna)
        {
            this.tipo = tipo;
            this.identificador = identificador;
            this.ambito = ambito;
            this.fila = fila;
            this.columna = columna;
        }


        #region Asignacion y casting
        public Nodo asignar(Nodo val)
        {
            if (val == null)
                return null;
            Nodo respuesta=null;
            string comparador=val.Tipo;//el tipo del valor de entrada
            switch (tipo)//el tipo de esta variable
            {
                #region De x a cadena
                case "String":
                    switch (comparador)
                    {
                        case "String":
                            valor = val.ToString();//solo agrego el valor
                            break;
                        case "Int":
                        case "Double":
                        case "Char":
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                        case "Bool"://bool
                            if ("true".Equals(val.Valor))
                            {
                                val.Tipo = tipo;
                                val.Valor = "1";
                                valor = val.ToString();
                            }
                            else
                            {
                                val.Tipo = tipo;
                                val.Valor = "0";
                                valor = val.ToString();
                            }
                            break;
                    }
                    break;
                #endregion
                #region De x a Entero
                case "Int":
                    switch (comparador)
                    {
                        case "String":
                            respuesta = new Nodo(val.Fila, val.Columna, "No se puede transformar de string a entero", "<error>");
                            break;
                        case "Int":
                            valor = val.ToString();//solo agrego el valor
                            break;
                        case "Double":
                            int nvo_val = (int)double.Parse(val.Valor);
                            val.Valor = nvo_val.ToString();
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                        case "Char":
                            int nvo_val_2 = int.Parse(val.Valor);
                            val.Valor = nvo_val_2.ToString();
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                        case "Bool"://bool
                            if ("true".Equals(val.Valor))
                            {
                                val.Tipo = tipo;
                                val.Valor = "1";
                                valor = val.ToString();
                            }
                            else
                            {
                                val.Tipo = tipo;
                                val.Valor = "0";
                                valor = val.ToString();
                            }
                            break;
                    }
                    break;
                #endregion
                #region De x a Dobule
                case "Double":
                    switch (comparador)
                    {
                        case "String":
                            respuesta = new Nodo(val.Fila, val.Columna, "No se puede transformar de string a double", "<error>");
                            break;
                        case "Int":
                            val.Valor = val.Valor+".0";
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                        case "Double":
                            valor = val.ToString();//solo agrego el valor
                            break;
                        case "Char":
                            double nvo_val_2 = int.Parse(val.Valor);
                            val.Valor = nvo_val_2.ToString();
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                        case "Bool"://bool
                            if ("true".Equals(val.Valor))
                            {
                                val.Tipo = tipo;
                                val.Valor = "1";
                                valor = val.ToString();
                            }
                            else
                            {
                                val.Tipo = tipo;
                                val.Valor = "0";
                                valor = val.ToString();
                            }
                            break;
                    }
                    break;
                #endregion
                #region De x a Char
                case "Char":
                    switch (comparador)
                    {
                        case "String":
                        case "Double":
                        case "Bool"://bool
                            respuesta = new Nodo(val.Fila, val.Columna, "No se puede transformar de "+val.Tipo+" a char", "<error>");
                            break;
                        case "Char":
                            valor = val.ToString();
                            break;//nada
                        case "Int":
                            int val_aux = val.Valor.ToCharArray()[1];
                            char val_real = (char)val_aux;
                            val.Valor = "\'"+val_real+"\'";//necesito las comillas simples
                            val.Tipo = tipo;
                            valor = val.ToString();
                            break;
                    }
                    break;
                #endregion
                #region De x a Bool
                case "Bool"://bool
                    if ("Bool".Equals(val.Tipo))
                    {
                        valor = val.ToString();
                    }//nada
                    else
                    {
                        respuesta = new Nodo(val.Fila, val.Columna, "No se puede transformar de " + val.Tipo + " a bool", "<error>");
                    }
                    break;
                 #endregion
            }
            return respuesta;//si todo sale bien retorna null
        }
        #endregion

        public override bool Equals(object obj)//permite comparar simbolos con la funcion find de la Lista generiga interna de c#
        {
            if (obj == null) return false;
            Simbolo transformado = obj as Simbolo;
            if (transformado == null) return false;
            return Equals(transformado);
        }
        public override int GetHashCode()//solo porque si no me alega de que no he implementado el hashcode porque use equals
        {
            return fila % columna;
        }
        public bool Equals(Simbolo otro)
        {
            if (otro == null) return false;
            return identificador.Equals(otro.identificador) && ambito.Equals(otro.ambito);
        }

        #region Getter y Setter
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

        public string Identificador
        {
            get
            {
                return identificador;
            }

            set
            {
                identificador = value;
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

        public Nodo Valor
        {
            get
            { 
                if(valor==null)//si no tiene un valor asignado
                    return new Nodo(Fila,Columna,"La variable "+Identificador+" no tiene un valor asignado","<error>");
                return new Nodo(Fila, Columna, valor, Tipo); ;
            }
        }

        public string Val
        {
            get
            {
                return valor;
            }
        }
        #endregion

    }
}
