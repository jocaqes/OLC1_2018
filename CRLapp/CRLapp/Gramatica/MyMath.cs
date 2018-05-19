namespace CRLapp.Gramatica
{
    static class MyMath
    {

        //tk_id
        //tk_entero->Int
        //tk_numero->Double
        //cadena->String
        //Keyword->Bool
        //char->Char
        #region Expresion
        public static Nodo expresion(Nodo a, Nodo b, string operador)
        {
            switch (operador)
            {
                case "+":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        double suma = double.Parse(boolToNumero(a.Valor)) + double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(),"Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double suma = double.Parse(boolToNumero(a.Valor)) + double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        int suma = int.Parse(boolToNumero(a.Valor)) + int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Int");//int
                    }
                    else if("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede sumar un boleano con un caracter:" + a.Valor + "+" + b.Valor, "<error>");//error
                    }
                    else if("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double suma = double.Parse(a.Valor) + double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double suma = double.Parse(a.Valor) + double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double suma;
                        if ("Char".Equals(a.Tipo))
                        {
                            suma = int.Parse(a.ToString()) + double.Parse(b.Valor);
                            //suma = int.Parse(a.ToString()) + double.Parse(b.Valor);
                        }
                        else
                        {
                            suma = int.Parse(b.ToString()) + double.Parse(a.Valor);
                            //suma = int.Parse(b.ToString()) + double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int suma = int.Parse(a.Valor) + int.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Int");//int
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int
                    {
                        int suma;
                        if ("Char".Equals(a.Tipo))
                        {
                            suma = int.Parse(a.ToString()) + int.Parse(b.Valor);
                            //suma = int.Parse(a.ToString()) + int.Parse(b.Valor);//el valor en cero es '
                        }
                        else
                        {
                            suma = int.Parse(b.ToString()) + int.Parse(a.Valor);
                            //suma = int.Parse(b.ToString()) + int.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Int");//int
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))
                    {
                        int suma = int.Parse(a.ToString()) + int.Parse(b.ToString());
                        //int suma = int.Parse(a.ToString()) + int.Parse(b.ToString());//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, suma.ToString(), "Int");//int
                    }
                    else if("String".Equals(a.Tipo)|| "String".Equals(b.Tipo))//cadena
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, a.ToString() + b.ToString(), "String");//cadena
                    }
                    break;
                case "-":
                    if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double resta = double.Parse(boolToNumero(a.Valor)) - double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        int resta = int.Parse(boolToNumero(a.Valor)) - int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Int");//int
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double resta = double.Parse(a.Valor) - double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double resta = double.Parse(a.Valor) - double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double resta;
                        if ("Char".Equals(a.Tipo))
                        {
                            resta = double.Parse(a.ToString()) - double.Parse(b.Valor);
                            //resta = int.Parse(a.ToString()) - double.Parse(b.Valor);
                        }
                        else
                        {
                            resta = double.Parse(a.Valor) - double.Parse(b.ToString());
                            //resta = int.Parse(b.ToString()) - double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int resta = int.Parse(a.Valor) - int.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Int");//int
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int
                    {
                        int resta;
                        if ("Char".Equals(a.Tipo))
                        {
                            resta = int.Parse(a.ToString()) - int.Parse(b.Valor);
                            //resta = int.Parse(a.ToString()) - int.Parse(b.Valor);//el valor en cero es '
                        }
                        else
                        {
                            resta = int.Parse(a.Valor) - int.Parse(b.ToString());
                            //resta = int.Parse(b.ToString()) - int.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Int");//int
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int resta = int.Parse(a.ToString()) - int.Parse(b.ToString());
                        //int resta = int.Parse(a.ToString()) - int.Parse(b.ToString());//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resta.ToString(), "Int");//int
                    }else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede restar un "+a.Tipo+" con un "+b.Tipo, "<error>");//error
                    }
                case "*":
                    if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double multiplicacion = double.Parse(boolToNumero(a.Valor)) * double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        int multiplicacion = int.Parse(boolToNumero(a.Valor)) * int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Int");//int
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double multiplicacion = double.Parse(a.Valor) * double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double multiplicacion = double.Parse(a.Valor) * double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double multiplicacion;
                        if ("Char".Equals(a.Tipo))
                        {
                            multiplicacion=double.Parse(a.ToString()) * double.Parse(b.Valor);
                            //multiplicacion = int.Parse(a.ToString()) * double.Parse(b.Valor);
                        }
                        else
                        {
                            multiplicacion = double.Parse(b.ToString()) * double.Parse(a.Valor);
                            //multiplicacion = int.Parse(b.ToString()) * double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int multiplicacion = int.Parse(a.Valor) * int.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Int");//int
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int
                    {
                        int multiplicacion;
                        if ("Char".Equals(a.Tipo))
                        {
                            multiplicacion=int.Parse(a.ToString()) * int.Parse(b.Valor);
                            //multiplicacion = int.Parse(a.ToString()) * int.Parse(b.Valor);//el valor en cero es '
                        }
                        else
                        {
                            multiplicacion=int.Parse(b.ToString()) * int.Parse(a.Valor);
                            //multiplicacion = int.Parse(b.ToString()) * int.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Int");//int
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int multiplicacion = int.Parse(a.ToString()) * int.Parse(b.ToString());
                        //int multiplicacion = int.Parse(a.ToString()) * int.Parse(b.ToString());//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, multiplicacion.ToString(), "Int");//int
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede multiplicar un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
                case "/":
                    if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double division = double.Parse(boolToNumero(a.Valor)) / double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        double division = double.Parse(boolToNumero(a.Valor)) / double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double division = double.Parse(a.Valor) / double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double division = double.Parse(a.Valor) / double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double division;
                        if ("Char".Equals(a.Tipo))
                        {
                            division = double.Parse(a.ToString()) / double.Parse(b.Valor);
                            //division = int.Parse(a.ToString()) / double.Parse(b.Valor);
                        }
                        else
                        {
                            division = double.Parse(a.Valor) / double.Parse(b.ToString());
                            //division = int.Parse(b.ToString()) / double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        double division = double.Parse(a.Valor) / double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int
                    {
                        double division;
                        if ("Char".Equals(a.Tipo))
                        {
                            division = double.Parse(a.ToString()) / double.Parse(b.Valor);
                            //division = int.Parse(a.ToString()) / double.Parse(b.Valor);//el valor en cero es '
                        }
                        else
                        {
                            division = double.Parse(a.Valor) / double.Parse(b.ToString());
                            //division = int.Parse(b.ToString()) / double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        double division = double.Parse(a.ToString()) / double.Parse(b.ToString());
                        //double division = int.Parse(a.ToString()) / int.Parse(b.ToString());//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, division.ToString(), "Double");//double
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede dividir un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
                case "%":
                    if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double modulo = double.Parse(boolToNumero(a.Valor)) % double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        double modulo = double.Parse(boolToNumero(a.Valor)) % double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double modulo = double.Parse(a.Valor) % double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double modulo = double.Parse(a.Valor) % double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double modulo;
                        if ("Char".Equals(a.Tipo))
                        {
                            modulo = double.Parse(a.ToString()) % double.Parse(b.Valor);
                            //modulo = int.Parse(a.ToString()) % double.Parse(b.Valor);
                        }
                        else
                        {
                            modulo = double.Parse(a.Valor) % double.Parse(b.ToString());
                            //modulo = int.Parse(b.ToString()) % double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        double modulo = double.Parse(a.Valor) % double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int
                    {
                        double modulo;
                        if ("Char".Equals(a.Tipo))
                        {
                            modulo = double.Parse(a.ToString()) % double.Parse(b.Valor);
                            modulo = int.Parse(a.ToString()) % double.Parse(b.Valor);//el valor en cero es '
                        }
                        else
                        {
                            modulo = double.Parse(a.Valor) % double.Parse(b.ToString());
                            //modulo = int.Parse(b.ToString()) % double.Parse(a.Valor);
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        double modulo = double.Parse(a.ToString()) % double.Parse(b.ToString());
                        //double modulo = int.Parse(a.ToString()) % int.Parse(b.ToString());//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, modulo.ToString(), "Double");//double
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede obtener el modulo de un " + a.Tipo + " por un " + b.Tipo, "<error>");//error
                    }
                case "^":
                    if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool
                    {
                        double potencia = System.Math.Pow(double.Parse(boolToNumero(a.Valor)), double.Parse(boolToNumero(b.Valor)));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool
                    {
                        double potencia = System.Math.Pow(double.Parse(boolToNumero(a.Valor)), double.Parse(boolToNumero(b.Valor)));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double potencia = System.Math.Pow(double.Parse(a.Valor), double.Parse(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double
                    {
                        double potencia = System.Math.Pow(double.Parse(a.Valor), double.Parse(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double
                    {
                        double potencia;
                        if ("Char".Equals(a.Tipo))
                        {
                            potencia = System.Math.Pow(double.Parse(a.ToString()), double.Parse(b.Valor));
                            //potencia = System.Math.Pow(int.Parse(a.ToString()) , double.Parse(b.Valor));
                        }
                        else
                        {
                            potencia = System.Math.Pow(double.Parse(a.Valor), double.Parse(b.ToString()));
                            //potencia = System.Math.Pow(int.Parse(b.ToString()) , double.Parse(a.Valor));
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        double potencia = System.Math.Pow(double.Parse(a.Valor), double.Parse(b.Valor));
                        int potencia_ = (int)potencia;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia_.ToString(), "Int");//int
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo))//int char
                    {
                        double potencia = System.Math.Pow(double.Parse(a.Valor), double.Parse(b.ToString()));
                        //double potencia = System.Math.Pow(int.Parse(a.ToString()) , double.Parse(b.Valor));//el valor en cero es '
                        int potencia_ = (int)potencia;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia_.ToString(), "Int");//int
                    }
                    else if ("Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//char int
                    {
                        double potencia = System.Math.Pow(double.Parse(a.ToString()), double.Parse(b.Valor));
                        //double potencia = System.Math.Pow(int.Parse(a.ToString()), int.Parse(b.ToString()));//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        double potencia = System.Math.Pow(double.Parse(a.ToString()), double.Parse(b.ToString()));
                        //double potencia = System.Math.Pow(int.Parse(a.ToString()) , int.Parse(b.ToString()));//el valor en cero es '
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, potencia.ToString(), "Double");//double
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede obtener la potencia de un " + a.Tipo + " por un " + b.Tipo, "<error>");//error
                    }
                default:
                    return null;
            }
            return null;
        }
        #endregion

        #region Relacional
        public static Nodo relacion(Nodo a, Nodo b, string relacional, double incerteza=0.0)
        {
            switch (relacional)
            {
                case "<":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 < val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2= double.Parse(b.Valor);
                        bool resultado = val1 < val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 < val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());
                        int val2 = int.Parse(b.ToString());
                        //int val1 = int.Parse(a.ToString());//el valor en cero es '
                        //int val2 = int.Parse(b.ToString());
                        bool resultado = val1 < val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = a.Valor.Length < b.Valor.Length;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) < double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) < int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) < int.Parse(boolToNumero(b.Valor));
                            //resultado = int.Parse(a.ToString()) < int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) < int.Parse(b.ToString());
                            //resultado = int.Parse(boolToNumero(a.Valor)) < int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) < double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado=double.Parse(a.ToString()) < double.Parse(boolToNumero(b.Valor));
                            //resultado = int.Parse(a.ToString()) < double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) < double.Parse(b.ToString());
                            //resultado = double.Parse(boolToNumero(a.Valor)) < int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) < int.Parse(boolToNumero(b.Valor));
                            //resultado = int.Parse(a.ToString()) < int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) < int.Parse(b.ToString());
                            //resultado = int.Parse(boolToNumero(a.Valor)) < int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es menor que un " + b.Tipo, "<error>");//error
                    }
                case ">":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 > val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = val1 > val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 > val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());
                        int val2 = int.Parse(b.ToString());
                        //int val1 = int.Parse(a.ToString());//el valor en cero es '
                        //int val2 = int.Parse(b.ToString());
                        bool resultado = val1 > val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = a.Valor.Length > b.Valor.Length;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) > double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) > int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) > int.Parse(boolToNumero(b.Valor));
                            //resultado = int.Parse(a.ToString()) > int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) > int.Parse(b.ToString());
                            //resultado = int.Parse(boolToNumero(a.Valor)) > int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) > double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) > double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) > int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) > int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) > int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es mayor que un " + b.Tipo, "<error>");//error
                    }
                case "==":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 == val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = val1 == val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 == val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());//el valor en cero es '
                        int val2 = int.Parse(b.ToString());
                        bool resultado = val1 == val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = a.Valor.Equals(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) == double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) == int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) == int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) == int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) == double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) == double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) == int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) == int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) == int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es igual que un " + b.Tipo, "<error>");//error
                    }
                case ">=":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 >= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = val1 >= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 >= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());//el valor en cero es '
                        int val2 = int.Parse(b.ToString());
                        bool resultado = val1 >= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = a.Valor.Equals(b.Valor)|| a.Valor.Length > b.Valor.Length;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) >= double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) >= int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) >= int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) >= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) >= double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) >= double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) >= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//double
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) >= int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) >= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es mayor o igual que un " + b.Tipo, "<error>");//error
                    }
                case "<=":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 <= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = val1 <= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 <= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());//el valor en cero es '
                        int val2 = int.Parse(b.ToString());
                        bool resultado = val1 <= val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = a.Valor.Equals(b.Valor) || a.Valor.Length < b.Valor.Length;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) <= double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) <= int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) <= int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) <= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) <= double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) <= double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) <= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) <= int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) <= int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es menor o igual que un " + b.Tipo, "<error>");//error
                    }
                case "!=":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        int val1 = int.Parse(boolToNumero(a.Valor));
                        int val2 = int.Parse(boolToNumero(b.Valor));
                        bool resultado = val1 != val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = val1 != val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        int val1 = int.Parse(a.Valor);
                        int val2 = int.Parse(b.Valor);
                        bool resultado = val1 != val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Char".Equals(a.Tipo) && "Char".Equals(b.Tipo))//char char
                    {
                        int val1 = int.Parse(a.ToString());//el valor en cero es '
                        int val2 = int.Parse(b.ToString());
                        bool resultado = val1 != val2;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        bool resultado = !a.Valor.Equals(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = double.Parse(boolToNumero(a.Valor)) != double.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = int.Parse(boolToNumero(a.Valor)) != int.Parse(boolToNumero(b.Valor));
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) != int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) != int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = double.Parse(a.Valor) != double.Parse(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) != double.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = double.Parse(boolToNumero(a.Valor)) != int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = int.Parse(a.ToString()) != int.Parse(boolToNumero(b.Valor));
                        }
                        else
                        {
                            resultado = int.Parse(boolToNumero(a.Valor)) != int.Parse(b.ToString());
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es diferente que un " + b.Tipo, "<error>");//error
                    }
                case "~":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        double val1 = double.Parse(boolToNumero(a.Valor));
                        double val2 = double.Parse(boolToNumero(b.Valor));
                        bool resultado = System.Math.Abs(val1 - val2) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Double".Equals(b.Tipo))//double double
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = System.Math.Abs(val1 - val2) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Int".Equals(b.Tipo))//int int
                    {
                        double val1 = double.Parse(a.Valor);
                        double val2 = double.Parse(b.Valor);
                        bool resultado = System.Math.Abs(val1 - val2) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("String".Equals(a.Tipo) && "String".Equals(b.Tipo))//cadena cadena
                    {
                        string var1 = a.Valor.ToLower().Trim();
                        string var2 = b.Valor.ToLower().Trim();
                        bool resultado = a.Valor.Equals(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #region nuevo
                    else if ("Bool".Equals(a.Tipo) && "Double".Equals(b.Tipo) || "Double".Equals(a.Tipo) && "Bool".Equals(a.Tipo))//Bool double/double Bool //nuevo
                    {
                        bool resultado = System.Math.Abs(double.Parse(boolToNumero(a.Valor)) - double.Parse(boolToNumero(b.Valor))) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Int".Equals(a.Tipo))//bool int/int bool //nuevo
                    {
                        bool resultado = System.Math.Abs(int.Parse(boolToNumero(a.Valor)) - int.Parse(boolToNumero(b.Valor))) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Bool".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Bool".Equals(b.Tipo) && "Char".Equals(a.Tipo))//bool char/char bool //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = System.Math.Abs(int.Parse(a.ToString()) - int.Parse(boolToNumero(b.Valor))) < incerteza;
                        }
                        else
                        {
                            resultado = System.Math.Abs(int.Parse(boolToNumero(a.Valor)) - int.Parse(b.ToString())) < incerteza;
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Int".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Int".Equals(a.Tipo))//double int/int double//nuevo
                    {
                        bool resultado = System.Math.Abs(double.Parse(a.Valor) - double.Parse(b.Valor)) < incerteza;
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Double".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Double".Equals(b.Tipo) && "Char".Equals(a.Tipo))//double char/char double//nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = System.Math.Abs(int.Parse(a.ToString()) - double.Parse(boolToNumero(b.Valor))) < incerteza;
                        }
                        else
                        {
                            resultado = System.Math.Abs(double.Parse(boolToNumero(a.Valor)) - int.Parse(b.ToString())) < incerteza;
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else if ("Int".Equals(a.Tipo) && "Char".Equals(b.Tipo) || "Int".Equals(b.Tipo) && "Char".Equals(a.Tipo))//int char/char int //nuevo
                    {
                        bool resultado;
                        if ("Char".Equals(a.Tipo))
                        {
                            resultado = System.Math.Abs(int.Parse(a.ToString()) - int.Parse(boolToNumero(b.Valor))) < incerteza;
                        }
                        else
                        {
                            resultado = System.Math.Abs(int.Parse(boolToNumero(a.Valor)) - int.Parse(b.ToString())) < incerteza;
                        }
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    #endregion
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede verificar si un " + a.Tipo + " es semegante a un " + b.Tipo, "<error>");//error
                    }
            }
            return null;
        }
        #endregion

        #region Logico
        public static Nodo logico(Nodo a, Nodo b, string logic)
        {
            switch (logic)
            {
                case "&&":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        bool resultado = boolToBool(a.Valor)&&boolToBool(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede comparar un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
                case "||":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        bool resultado = boolToBool(a.Valor) || boolToBool(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede comparar un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
                case "!&":
                    if ("Bool".Equals(a.Tipo) && "Bool".Equals(b.Tipo))//Bool y Bool
                    {
                        bool resultado = boolToBool(a.Valor) != boolToBool(b.Valor);
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, resultado.ToString(), "Bool");//bool
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede comparar un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
                case "!":
                    if ("Bool".Equals(a.Tipo))//Bool y Bool
                    {
                        bool resultado = !boolToBool(a.Valor);
                        return new Nodo(a.Fila, a.Columna, resultado.ToString(), "Bool");//bool
                    }
                    else
                    {
                        return new Nodo((a.Fila + b.Fila) / 2, (a.Columna + b.Columna) / 2, "No se puede comparar un " + a.Tipo + " con un " + b.Tipo, "<error>");//error
                    }
            }
            return null;
        }
        #endregion

        #region Privados
        private static string boolToNumero(string valor)
        {
            if ("true".Equals(valor.ToLower()))
                return 1.ToString();
            else if ("false".Equals(valor.ToLower()))
            {
                return 0.ToString();
            }
            return valor;
        }

        private static bool boolToBool(string valor)
        {
            if ("true".Equals(valor.ToLower()))
                return true;
            return false;
        }
        #endregion

        #region auxiliares
        public static bool toBool(string valor)
        {
            if ("true".Equals(valor.ToLower()))
                return true;
            return false;
        }
        #endregion

    }
}
