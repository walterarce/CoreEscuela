using System;

namespace CoreEscuela.Entidades
{
    public abstract class  ObjetoEscuelaBase
    {
           string nombre;
        
        public string UniqueId { get; private set; } 
         public string Nombre { get {return nombre;} set {nombre = value.ToUpper();} }
        public ObjetoEscuelaBase()
        {
                UniqueId  = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}