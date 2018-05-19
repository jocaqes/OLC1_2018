using System;
using System.IO;
using System.Windows.Forms;

namespace CRLapp.ManejoArchivos
{
    static class Archivo
    {
        public static bool guardar(string texto, string direccion)//codigo basico para guardar un archivo
        {
            try
            {
                StreamWriter sw = new StreamWriter(direccion);
                sw.Write(texto);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static string abrir(string direccion)
        {
            string texto = "";
            try
            {
                StreamReader sr = new StreamReader(@direccion);
                string concat = "";
                while (concat != null)
                {
                    concat = sr.ReadLine();
                    texto += concat + "\n";
                }
                sr.Close();
            }catch(Exception e)
            {
                texto = e.ToString();
            }
            return texto;
        }

        public static bool generarGrafica(string path,string nombre_dot)
        {
            try
            {
                string comando = "dot -Tpng " + Path.Combine(path, nombre_dot) + " -o " + Path.Combine(path, nombre_dot.Replace(".dot", ".png"));
                System.Diagnostics.ProcessStartInfo proceso = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = proceso;
                proc.Start();
                proc.WaitForExit();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public static string openDialog()
        {
            string respuesta = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos clr (*.clr)|*.clr";
            if (open.ShowDialog() == DialogResult.OK)
            {
                respuesta = open.FileName;
            }
            return respuesta;
        }

        public static string saveDialog()
        {
            string respuesta = "";
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".clr";
            save.Filter = "Archivos clr (*.clr)|*.clr";
            if (save.ShowDialog() == DialogResult.OK)
            {
                respuesta = save.FileName;
            }
            return respuesta;
        }
    }
}
