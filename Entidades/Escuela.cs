using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {

      
         string direccion;
        public string Direccion { get { return direccion;} set{ direccion=value;} }
         public TiposEscuela TipoEscuela {get; set;}
        public List<Curso> Cursos {get; set;}
        public int AnioCreacion { get; set; }
        
        public string Pais { get; set; }

        public string Ciudad { get; set; }

       
        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre,anio);

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {
           Printer.DibujarLinea(10);
           Console.WriteLine("Limpiando....");
           foreach (var curso in Cursos)
           {
               curso.LimpiarLugar();
           }
           Printer.Beep(15000,cantidad:3);
           Printer.DibujarTitulo($"Escuela {Nombre} Limpia");
        }
    }
}