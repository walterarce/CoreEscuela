using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {

      
      
   
         public TiposEscuela TipoEscuela {get; set;}
        public List<Curso> Cursos {get; set;}
        public int AnioCreacion { get; set; }
        
        public string Pais { get; set; }

        public string Ciudad { get; set; }
        public string Direccion { get ; set ; }

        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre,anio);

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {
           Printer.DibujarLinea(10);
           Console.WriteLine("Limpiando Escuela...");
         
           foreach (var curso in Cursos)
           {
               curso.LimpiarLugar();
           }
           Console.WriteLine($"Escuela:{Nombre} Limpio");
             Printer.WelcomeMusic();
        }
    }
}