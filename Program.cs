using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;
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
          
           ImprimirCursosEscuela(engine.Escuela);
            int dummy = 0;
            var listaObjetos = engine.GetObjetoEscuela (out  int contadorEvaluaciones,
             out dummy,
             out dummy,
             out dummy);
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
