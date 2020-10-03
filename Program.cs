using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Printer.WelcomeMusic();
            var engine = new EscuelaEngine();
            engine.Inicializar();
            
           var alumnoTest = new Alumno{Nombre="Claire Underwood"};
            ImprimirCursosEscuela(engine.Escuela);
            Printer.DibujarTitulo("Alumno");
            WriteLine($"Alumno:{alumnoTest.Nombre}");
            WriteLine($"Unique:{alumnoTest.UniqueId}");
            WriteLine($"Tipo:{alumnoTest.GetType()}");
            ObjetoEscuelaBase ob = alumnoTest;

            Printer.DibujarTitulo("ObjetoEscuela");
            WriteLine($"Alumno:{ob.Nombre}");
            WriteLine($"Unique:{ob.UniqueId}");
            WriteLine($"Tipo:{ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() {Nombre="Frank Underwood"};
            Printer.DibujarTitulo("ObjetoEscuelaBase");
            WriteLine($"Alumno:{objDummy.Nombre}");
            WriteLine($"Unique:{objDummy.UniqueId}");
            WriteLine($"Tipo:{objDummy.GetType()}");

            var evaluacion = new Evaluacion(){Nombre="Evaluacion de matematica", Nota=4.5f};
            Printer.DibujarTitulo("Evaluacion");
            WriteLine($"Evaluacion:{evaluacion.Nombre}");
            WriteLine($"Evaluacion:{evaluacion.UniqueId}");
            WriteLine($"Evaluacion:{evaluacion.Nota}");
            WriteLine($"Evaluacion:{evaluacion.GetType()}");

            //ob = evaluacion;
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno) ob;
            }

            Alumno alumnoRecuperado2 =  ob as Alumno; //esto es recomendado

            var listaobjetos = engine.GetObjetoEscuela();

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
