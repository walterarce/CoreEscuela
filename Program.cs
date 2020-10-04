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

            var listaObjetos = engine.GetObjetoEscuela();

            var listaILugar = from obj in listaObjetos
            where obj is ILugar
                select (ILugar) obj;
           //engine.Escuela.LimpiarLugar();
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
