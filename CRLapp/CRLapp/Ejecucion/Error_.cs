namespace CRLapp.Ejecucion
{
    class Error_
    {
        private int fila;
        private int columna;
        private string mensaje;
        private string tipo;

        public Error_(int fila, int columna, string mensaje, string tipo)
        {
            this.fila = fila;
            this.columna = columna;
            this.mensaje = mensaje;
            this.tipo = tipo;
        }


    }
}
