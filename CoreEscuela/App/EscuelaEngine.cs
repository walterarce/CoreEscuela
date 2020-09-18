
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela.Entidades
{
    public sealed class EscuelaEngine
    {   

        public Escuela Escuela { get; set; }


        public EscuelaEngine()
        {
           
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Juana Manso", 2012) { Pais = "Argentina", Ciudad = "CABA", Direccion = "Emilio Lamarca", TipoEscuela = TiposEscuela.Secundaria };

            CargarCursos();
            CargarAsignaturas();
             
             foreach (var curso in Escuela.Cursos)
             {
                 curso.Alumnos.AddRange(GenerarAlumnosRamdon(20));
             }
             
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
           foreach (var curso in Escuela.Cursos)
           {
                foreach (var asignatura in curso.Asignaturas)
                {

                    foreach (var alumno in curso.Alumnos)
                    {
                     var rnd = new Random(System.Environment.TickCount)   ;
                     for (int i = 0; i < 5; i++)
                     {
                         var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno= alumno
                            };
                            alumno.Evaluaciones.Add(ev)  ;
                           
                     }
                    }
                }    
           }
        }

      
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){Nombre="Matematica"},
                    new Asignatura(){Nombre="Educacion Fisica"},
                    new Asignatura(){Nombre="Castellano"},
                    new Asignatura(){Nombre="Ciencias Naturales"}   
                };
                curso.Asignaturas =listaAsignaturas;
               
            }
        }

        private List<Alumno> GenerarAlumnosRamdon(int cantidad)
        {
           string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
           string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
           string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

           var listaAlumnos = from n1 in nombre1
                              from n2 in nombre2
                              from a1 in apellido1
                              select new Alumno{ Nombre=$"{n1} {n2} {a1}"};
              
                return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuela()
        {
            var listaobj=new List<ObjetoEscuelaBase>();
                listaobj.Add(Escuela);
                listaobj.AddRange(Escuela.Cursos);
                foreach (var curso in Escuela.Cursos)
                {
                    listaobj.AddRange(curso.Asignaturas);
                    listaobj.AddRange(curso.Alumnos);

                    foreach (var alumno in curso.Alumnos)
                    {
                        listaobj.AddRange(alumno.Evaluaciones);
                    }
                }
            return listaobj;
        }

        private void CargarCursos()
        {
            Random rnd = new Random();

            
            
            Escuela.Cursos = new List<Curso> {
            new Curso()
            {Nombre="101", Jornada = TiposJornada.Mañana},
            new Curso()
            {Nombre="202", Jornada = TiposJornada.Mañana},
            new Curso()
            {Nombre="303", Jornada = TiposJornada.Tarde},
            new Curso()
            {Nombre="401", Jornada = TiposJornada.Mañana},
            new Curso()
            {Nombre="501", Jornada = TiposJornada.Mañana},
            new Curso()
            {Nombre="501" , Jornada= TiposJornada.Tarde} };

            foreach (var curso in Escuela.Cursos)
            {
                int cantidadcurso = rnd.Next(5,20);
                curso.Alumnos = GenerarAlumnosRamdon(cantidadcurso);
            }
        }
    }
}