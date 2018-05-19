using System;
using System.Windows.Forms;
using CRLapp.Gramatica;
using CRLapp.Ejecucion;
using CRLapp.ManejoArchivos;
using Irony.Parsing;
using System.Collections.Generic;
//using System.Text.RegularExpressions;

namespace CRLapp
{
    public partial class Form1 : Form
    {
        private Ejecucion_ execute_manager;
        public Form1()
        {
            InitializeComponent();
        }

        //private void boton_analizar_Click(object sender, EventArgs e)//todo es debug
        //{
        //  addTab("hola mundo");
        /*

        if (string.IsNullOrEmpty(tbox_debug.Text))
            status_cursor.Text = "Texto vacio";
        ParseNode raiz=null;
        raiz = Analisis.analizar(tbox_debug.Text);
        if (raiz == null)
            status_cursor.Text = "Error en analisis";
        else
        {
            status_cursor.Text = "Analisis correcto raiz:" + raiz.ToString();//debug
            //Analisis.graficarArbol(raiz);//debug
            ejecutar(raiz);//debug
            //ejecutarDebug(raiz);

        }*/
        //}


        /*
    private void ejecutar(ParseNode raiz)//debug
    {
        //ActiveControl.Text = "hola mundo";
        Ejecucion_ nuevo = new Ejecucion_(raiz, tbox_consola1);
        tbox_consola2.Text = "Todo salio bien";
    }*/

        private void debug()
        {
            /*int contador=0;
            string patron = @"{\d+}";
            string cadena = "esta cadena es {0} una cadena para {1} contar laves con {2} numeros dentro{a}";
            foreach(Match m in Regex.Matches(cadena, patron))
            {
                ++contador;
            }
            tbox_consola2.Text = "Coincidencias:" + contador;*/
        }

        #region Ejecucion
        private void ejecutar()
        {
            //0.-Limpiamos la consola de salida y de errores
            tbox_consola1.Clear();
            tbox_consola2.Clear();
            string texto = currentTextBox().Text;
            //1.-revisamos que no este vacio el textbox
            if (string.IsNullOrEmpty(texto)) {
                MessageBox.Show("Por favor, elija un documento que no este vacio", "Advertencia");
                return;
            }
            //2.-Analizamos el texto y obtenemos su raiz
            ParseNode raiz = null;//raiz modificada
            ParseTree arbol = Analisis.analizar(texto);
            //raiz = Analisis.analizar(texto);
            /*
            //3.-Generamos un manager pero no inicia a ejecutar aun
            //antes debemos recuperar imports, ruta de guardado y los otros archivos
            raiz = new ParseNode(0, 0, "<S>");
            Analisis.miAST(arbol.Root, raiz);
            execute_manager = new Ejecucion_(raiz, tbox_consola1);
            status_label_ejecucion.Text = raiz.ToString();
            */
            //3.-Si la raiz es nula, hay errores sintacticos y lexicos
            if (arbol.Root == null || arbol.ParserMessages.Count > 0)
            {
                //agregamos un mensaje de errores en cosola 2 pendiente
                //tbox_consola2.Text = "Hubo errores lexicos/sintacticos en su programa";//debug
               // agregarErroresLS(execute_manager, arbol);//agregamos los errores a execute_manager
                /*int limite = arbol.ParserMessages.Count;
                string error = "";
                for (int i = 0; i < limite; i++)
                {
                    error = arbol.ParserMessages[i].ToString() + " en Linea:" + arbol.ParserMessages[i].Location.Line + " en Columna:" + arbol.ParserMessages[i].Location.Column;
                    addErrorText(error);
                }*/
                return;
            }

            
            //4.-Ejecutamos la raiz
            //antes debemos recuperar imports, ruta de guardado y los otros archivos
            raiz = new ParseNode(0, 0, "<S>");
            Analisis.miAST(arbol.Root, raiz);
            execute_manager = new Ejecucion_(raiz, tbox_consola1);
            status_label_ejecucion.Text = raiz.ToString();
        }
        //private void setParametrosIniciales()
        #endregion
        #region Auxiliar a Ejecucion
        private void definesImports(ParseNode raiz, Ejecucion_ manager)
        {
            double incerteza = 0;
            string ruta_album = null;
            List<string> imports = new List<string>();
            //1.-busco en la raiz sus imports y su incerteza
            foreach (ParseNode hijo in raiz.childNodes)
            {
                if ("<IMPORTS>".Equals(hijo.ToString()))
                {
                    //cada import que tenga, agrego a la lista
                    foreach (ParseNode import in hijo.childNodes)
                    {
                        imports.Add(import.ToString() + ".clr");
                    }
                } else if ("<DEFINES>".Equals(hijo.ToString()))
                {
                    //cada define que tenga agrego a la lista
                    foreach (ParseNode define in hijo.childNodes)
                    {
                        if ("Cadena".Equals(hijo.Tipo) && ruta_album == null)
                        {
                            ruta_album = hijo.ToString();
                        } else if ("Double".Equals(hijo.Tipo) && incerteza == 0)
                        {
                            incerteza = double.Parse(hijo.ToString());
                        }
                    }
                }
            }
            //2.-Agregamos los parametros de incerteza y ruta a manager
            manager.establecerIncertezaRuta(incerteza, ruta_album);
            //3.-Una vez tenga la incerteza, la ruta album y los imports, procedo a analizar las otras 
            //clases recursivamente(porque pueden tener imports por su cuenta) y a setear los parametros en
            //manager
        }
        private void importsPrincipal(string ruta, string nombre, Ejecucion_ manager)
        {
            //1.-Reviso si existe el archivo
            if (!System.IO.File.Exists(System.IO.Path.Combine(ruta, nombre)))
                return;
            //2.-Si existe analizo el archivo
            string texto_analizar = Archivo.abrir(ruta);
            //3.-Primero reviso que el archivo si dio algo
            if (string.IsNullOrEmpty(texto_analizar))
            {
                manager.addError(new Nodo(0, 0, "No se pudo importar:" + nombre + ", el archivo no existe", "<error>"));
                return;
            }
            ParseTree arbol = Analisis.analizar(texto_analizar);
            //4.-Reviso si el analisis fue exitoso
            if (arbol == null)
            {
                //5.-agrego los errores a manager

                //manager.addError(new Nodo(0, 0, "No se pudo importar:" + nombre + ", el archivo no existe", "<error>"));
                return;
            }
            //4.-Si el analisis fue exitoso transformo la raiz y agrego a manager las nuevas variables y funciones
            
        }
        private void agregarErroresLS(Ejecucion_ manager,ParseTree arbol)
        {
            int limite = arbol.ParserMessages.Count;
            Irony.LogMessage actual;
            for (int i = 0; i < limite; i++)
            {
                actual = arbol.ParserMessages[i];
                manager.addError(new Nodo(actual.Location.Line,actual.Location.Column,actual.ToString(),"<error>"));
            }
        }
        #endregion

        #region Abrir
        private void abrirArchivo()
        {
            string ruta = "";
            ruta = Archivo.openDialog();
            if (!string.IsNullOrEmpty(ruta))
            {
                //1.-abrimos una nueva pestaña
                addTab("nuevo");
                //2.-agregamos ruta como tooltip a la pestaña
                tab_main.SelectedTab.ToolTipText = ruta;
                //3.-cambiamos el nombre de la pestaña
                string[] sub_ruta = ruta.Split('\\');
                tab_main.SelectedTab.Text = sub_ruta[sub_ruta.Length - 1];
                currentTextBoxText(Archivo.abrir(ruta));
            }
        }
        #endregion
        #region Nuevo
        private void addTab(string titulo)
        {
            RichTextBox nuevo = new RichTextBox();
            nuevo.Dock = (DockStyle.Fill);
            nuevo.TextChanged += new EventHandler(Nuevo_CursorChanged);
            nuevo.AcceptsTab = true;

            TabPage nueva = new TabPage(titulo);
            nueva.Controls.Add(nuevo);
            tab_main.TabPages.Add(nueva);
            tab_main.SelectedTab = nueva;
        }
        #endregion
        #region Guardar y Guardar Como
        private void guardar()
        {
            string ruta;
            ruta = tab_main.SelectedTab.ToolTipText;
            if (string.IsNullOrEmpty(ruta))
            {
                guardarComo();
            }
            else
            {
                if(Archivo.guardar(currentTextBox().Text, ruta))
                    MessageBox.Show("Su documento ha sido guardado", "Info");
                else
                    MessageBox.Show("Error al guardar su documento", "Info");
            }
        }
        private void guardarComo()
        {
            string ruta = Archivo.saveDialog();
            if (string.IsNullOrEmpty(ruta))
                return;
            if (Archivo.guardar(currentTextBox().Text, ruta))
            {
                tab_main.SelectedTab.ToolTipText = ruta;
                string[] sub_ruta = ruta.Split('\\');
                tab_main.SelectedTab.Text = sub_ruta[sub_ruta.Length - 1];
                MessageBox.Show("Su documento ha sido guardado", "Info");
            }
            else
            {
                MessageBox.Show("Error al guardar su documento", "Info");
            }
        }
        #endregion
        #region Informacion y Otros
        private void cursorPosition(object sender)
        {
            RichTextBox actual = (RichTextBox)sender;
            int posicion = actual.SelectionStart;
            int line = actual.GetLineFromCharIndex(posicion);
            int columna = posicion - actual.GetFirstCharIndexOfCurrentLine();
            status_cursor.Text = "Fila: " + line + " Columna :" + columna;
        }

        private RichTextBox currentTextBox()
        {
            return (RichTextBox)tab_main.SelectedTab.Controls[0];
        }

        private void currentTextBoxText(string texto)
        {
            currentTextBox().Text = texto;
        }
        private void addErrorText(string texto)
        {
            tbox_consola2.Text = tbox_consola2.Text + texto + "\n";
        }
        #endregion


        #region Eventos
        private void Nuevo_CursorChanged(object sender, EventArgs e)
        {
            cursorPosition(sender);
        }
        private void boton_nuevo_Click(object sender, EventArgs e)
        {
            addTab("Nuevo.clr");
        }
        private void boton_abrir_Click(object sender, EventArgs e)
        {
            abrirArchivo();
        }
        private void boton_guardar_Click(object sender, EventArgs e)
        {
            if (tab_main.TabCount > 0)
                guardar();
        }
        private void boton_guardar_como_Click(object sender, EventArgs e)
        {
            if (tab_main.TabCount > 0)
                guardarComo();
        }
        private void boton_ejecutar_Click(object sender, EventArgs e)
        {
            if (tab_main.TabCount > 0)
                ejecutar();//pendiente
            //debug();

        }
        #endregion


    }
}
