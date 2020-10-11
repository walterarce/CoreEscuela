
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Util;

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
            CargarEvaluaciones();
            
            
        }

        public void ImprimirDiccionario(Dictionary<LlavesDiccionario,IEnumerable<ObjetoEscuelaBase>> dic,
        bool imprimirEval=false)
        {
            foreach (var obj in dic)
            {
                Printer.DibujarTitulo(obj.Key.ToString());
                
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlavesDiccionario.Evaluaciones:
                          if(imprimirEval)
                            Console.WriteLine("Escuela:"+val);
                        break;
                        case LlavesDiccionario.Alumnos:
                            Console.WriteLine("Alumno:"+val.Nombre);
                        break;
                         case LlavesDiccionario.Cursos:
                         var cursotmp = val as Curso;
                         if(cursotmp != null)
                            {
                                int count = ((Curso)val).Alumnos.Count;
                                Console.WriteLine("Curso:"+ val.Nombre + "Cantidad Alumnos:"+ count);
                            }
                          
                        break;
                        default:
                             Console.WriteLine(val);
                        break;
                    }

                   
                }
                
            }
        }
        public Dictionary<LlavesDiccionario,IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            
            var diccionario=new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlavesDiccionario.Escuela,new[] {Escuela});
            diccionario.Add(LlavesDiccionario.Cursos, 
                   Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listatmp = new List<Evaluacion>();
            var listatmpas = new List<Asignatura>();
            var listatmpal = new List<Alumno>();
            foreach (var cur in Escuela.Cursos)
            {
                
                listatmpas.AddRange(cur.Asignaturas);

                listatmpal.AddRange(cur.Alumnos);
      
                    
                        foreach (var alum in cur.Alumnos)
                        {
                            listatmp.AddRange(alum.Evaluaciones);
                        }
                         
                
                
            }
             diccionario.Add(LlavesDiccionario.Evaluaciones, 
                                listatmp.Cast<ObjetoEscuelaBase>());
             diccionario.Add(LlavesDiccionario.Asignaturas, 
                                listatmpas.Cast<ObjetoEscuelaBase>());
             diccionario.Add(LlavesDiccionario.Alumnos, 
                                listatmpal.Cast<ObjetoEscuelaBase>());                   

            return diccionario;
        }
#region Metodos de carga
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
                                Nota = MathF.Round((float)(5 * rnd.NextDouble()),2),
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

       public IReadOnlyCollection<ObjetoEscuelaBase>  GetObjetoEscuela(
            bool traeEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
            {
                return GetObjetoEscuela(out int dummy, out dummy , out dummy ,out dummy);
            }
        public IReadOnlyCollection<ObjetoEscuelaBase>  GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
            {
                return GetObjetoEscuela(out conteoEvaluaciones);
            }
        public IReadOnlyCollection<ObjetoEscuelaBase>  GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
            {
                return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos);
            }
        public IReadOnlyCollection<ObjetoEscuelaBase>  GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
            {
                return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas);
            }
        public IReadOnlyCollection<ObjetoEscuelaBase>  GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
        {
             conteoEvaluaciones=0;
             
             conteoAsignaturas=conteoCursos=conteoAlumnos=0;
          
            var listaobj=new List<ObjetoEscuelaBase>();
                listaobj.Add(Escuela);
              if(traerCursos)
              {
                listaobj.AddRange(Escuela.Cursos);
                conteoCursos =Escuela.Cursos.Count;
              }
                foreach (var curso in Escuela.Cursos)
                {
                   
                    if(traerAsignaturas)
                    {
                        conteoAsignaturas += curso.Asignaturas.Count;                        
                        listaobj.AddRange(curso.Asignaturas);
                    }
                    if(traerAlumnos)
                    {
                       conteoAlumnos += curso.Alumnos.Count;
                       listaobj.AddRange(curso.Alumnos);
                    }

                    if(traeEvaluaciones)
                    {
                        foreach (var alumno in curso.Alumnos)
                        {
                            listaobj.AddRange(alumno.Evaluaciones);
                            conteoEvaluaciones += alumno.Evaluaciones.Count;
                        }
                    }
                }
            return listaobj.AsReadOnly();
        }
    
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso> {
                        new Curso()  {Nombre="101", Jornada = TiposJornada.Mañana},
                        new Curso()  {Nombre="202", Jornada = TiposJornada.Mañana},
                        new Curso()  {Nombre="303", Jornada = TiposJornada.Tarde},
                        new Curso()  {Nombre="401", Jornada = TiposJornada.Mañana},
                        new Curso()  {Nombre="501", Jornada = TiposJornada.Mañana},
                        new Curso()  {Nombre="601" , Jornada= TiposJornada.Tarde} ,
                        new Curso()  {Nombre="701" , Jornada= TiposJornada.Tarde} };
            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantidadcurso = rnd.Next(5,20);
                curso.Alumnos = GenerarAlumnosRamdon(cantidadcurso);
            }
        }
    }
    #endregion
}