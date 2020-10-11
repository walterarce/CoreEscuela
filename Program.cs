using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;
using System.Collections.Generic;

namespace CoreEscuela
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Printer.WelcomeMusic();
            var engine = new EscuelaEngine();
            engine.Inicializar();
            
           Printer.DibujarTitulo("Bienvenidos a la Escuela");
          
           Dictionary<int,string> diccionario = new Dictionary<int, string>();


            foreach (var keyValuePair in diccionario)
            {
                WriteLine($"Key:{keyValuePair.Key} valor:{keyValuePair.Value}");
            }

             var dictmp = engine.GetDiccionarioObjetos();

             engine.ImprimirDiccionario(dictmp,true);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.DibujarTitulo("Cursos de Escuela");
            WriteLine(escuela.Nombre);
            WriteLine(escuela.TipoEscuela);

           foreach (var curso in escuela.Cursos)
           {
               WriteLine($"Nombre del curso: {curso.Nombre}  , Jornada: {curso.Jornada} , Id: {curso.UniqueId}");
           }
        }
    }
}
