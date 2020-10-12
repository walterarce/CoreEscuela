using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;
using System.Collections.Generic;
using System;


namespace CoreEscuela.App
{
    
    class Program
    {
        static void Main(string[] args)
        {

           // AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
        
            var engine = new EscuelaEngine();
            engine.Inicializar();
            
           Printer.DibujarTitulo("Bienvenidos a la Escuela");
          
           var reporteador = new Reporteador(engine.GetDiccionarioObjetos());

           var evalList=  reporteador.GetListaEvaluaciones();
           var listaasig = reporteador.GetListaAsignaturas();
           var listaevalxasig = reporteador.GetDiccEvaluacionesXAsignatura();
           var listaPromXAsig = reporteador.GetPromedioAlumnoPorAsignatura();
            var listatop5 = reporteador.GetPromedioTop(5);
          
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
           Printer.DibujarTitulo("Saliendo");
           Printer.Beep(3000,1000,3);
           WriteLine("Salio...");
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
