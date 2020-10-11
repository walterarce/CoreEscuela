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
              var listaEvaluaciones = GetListaEvaluaciones();

              return (from ev in listaEvaluaciones
                        where ev.Nota >= 3.0f
                        select ev.Asignatura.Nombre).Distinct();
              
          }

          public Dictionary<string, IEnumerable<Evaluacion>> GetDiccEvaluacionesXAsignatura()
          {
              Dictionary<string, IEnumerable<Evaluacion>> dicRta =  new Dictionary<string, IEnumerable<Evaluacion>>();

              return dicRta;
          }
    }
}