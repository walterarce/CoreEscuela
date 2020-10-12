using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;
namespace CoreEscuela.App
{
    public  class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
         public Reporteador (Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)        
          {
              if (dicObsEsc == null)
                 throw new ArgumentException(nameof(dicObsEsc));

            _diccionario = dicObsEsc;
          }

          public IEnumerable<Evaluacion> GetListaEvaluaciones()
          {

           
              if (_diccionario.TryGetValue(LlavesDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> lista ))
              {
                 return lista.Cast<Evaluacion>();
              }
              {
                  return new List<Evaluacion>();
              }

          }
          public IEnumerable<string> GetListaAsignaturas()
          {
              return GetListaAsignaturas( out var dummy);
          }
          public IEnumerable<string> GetListaAsignaturas(
              out IEnumerable<Evaluacion>  listaEvaluaciones)
          {
               listaEvaluaciones = GetListaEvaluaciones();

              return (from Evaluacion ev in listaEvaluaciones
                        select ev.Asignatura.Nombre).Distinct(); 
              
          }

          public Dictionary<string, IEnumerable<Evaluacion>> GetDiccEvaluacionesXAsignatura()
          {
              var dicRta =  new Dictionary<string, IEnumerable<Evaluacion>>();
              var listaAsig = GetListaAsignaturas(out var listaEval);
              foreach (var asig in listaAsig)
              {
                  var evalasig = from Evaluacion eval in listaEval
                                where eval.Asignatura.Nombre == asig && eval.Nota >= 4f
                                select eval;

                  dicRta.Add(asig,evalasig);
              }
              return dicRta;
          }
          public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromedioAlumnoPorAsignatura()
          {
              var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

              var DiccEvXAsignatura = GetDiccEvaluacionesXAsignatura();

              foreach (var asigConEval in DiccEvXAsignatura)
              {
                  var promediosAlumnos = from eval in asigConEval.Value
                  group eval by new  {eval.Alumno.UniqueId, Alunombre =  eval.Alumno.Nombre, eval.Nota}
                  into grupoEvalAlumno
                                select new AlumnoPromedio{

                                   alumnoid = grupoEvalAlumno.Key.UniqueId,
                                   alumnonombre = grupoEvalAlumno.Key.Alunombre,
                                   Promedio = grupoEvalAlumno.Average(evalu => evalu.Nota)
                                } ;

                            rta.Add(asigConEval.Key, promediosAlumnos);
              }
              return rta;
          }
 
          public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromedioTop(int ranking)
          {
              var resp = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
              var diccionarioPromedios = GetPromedioAlumnoPorAsignatura();
              
              foreach (var prom in diccionarioPromedios)
              {
               
              var dummy = (from ap in prom.Value
                            where ap.Promedio > 4.0f
                           group ap by new {ap.alumnoid, ap.alumnonombre, ap.Promedio}
                           into grupoEvalAlumno
                               select new AlumnoPromedio{
                                   alumnoid = grupoEvalAlumno.Key.alumnoid,
                                   alumnonombre = grupoEvalAlumno.Key.alumnonombre,
                                   Promedio = grupoEvalAlumno.Key.Promedio
                               }).Take(ranking);

                            resp.Add(prom.Key, dummy);
              }

              return resp;
          }
    }
}