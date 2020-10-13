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
          Printer.DibujarTitulo("Captura de una evaluacion por Consola");
          var nuevaEvaluacion = new Evaluacion();
          string nombre, notastring;
          float nota;

         

          WriteLine ("Ingrese el nombre de la evaluacion");
          Printer.PresioneEnter();
           
          nombre = Console.ReadLine();
          WriteLine ("Ingrese la nota de la evaluacion");
          notastring = Console.ReadLine();
          if (string.IsNullOrEmpty(nombre))
          {
              throw new ArgumentException("El valor del nombre no puede ser vacio");
          }
          else{
              nuevaEvaluacion.Nombre=nombre.ToLower();
              WriteLine ("La evaluacion ingreso correctamente");
          }



           if (string.IsNullOrEmpty(notastring))
          {
              Printer.DibujarTitulo("El valor de la nota no puede ser vacio");
          }
          else
          {
              try
              {
                  nuevaEvaluacion.Nota = float.Parse(notastring);
                  if(nuevaEvaluacion.Nota<0 || nuevaEvaluacion.Nota > 5)
                  {
                      throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                  }
                   WriteLine ("La nota ingreso correctamente");
              }
              catch (ArgumentOutOfRangeException exarg)
              {
                  Printer.DibujarTitulo(exarg.Message);
              }
              catch (Exception ex)
              {
                  
                  Printer.DibujarTitulo("El valor de la nota no puede ser vacio"+ ex.Message);
                  WriteLine("Saliendo del programa");
              }
              finally
              {
                  Printer.DibujarTitulo("FINALLY");
                  Printer.Beep(2500,500,3);
              }
              
             
          }
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
