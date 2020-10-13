using System;
using System.Threading;
using static System.Console;
namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamanio)
        {
            
            WriteLine("".PadLeft(tamanio,'='));    

        }

        public static void DibujarTitulo(string titulo)
        {
            DibujarLinea(titulo.Length + 4);
            WriteLine($"| {titulo} |");
            DibujarLinea(titulo.Length + 4);
            

        }
        public static void PresioneEnter()
        {
            WriteLine("Presione Enter Para Continuar...");
        }
        public static void Beep(int hz=2000, int tiempo=500, int cantidad = 1)
        {
            while (cantidad > 0)
            {
                Console.Beep(hz,tiempo);
                cantidad--;
            }
        }

        public static void WelcomeMusic()
        {
            var Solb = 185; var Lab = 207; var Sib = 233; var Reb = 277; var Mib =311 ; var Fa = 349; var La2 = 329;
            var negra = 250;
            var blanca = negra * 2;
            var corchea = negra /2;
            var dotblanca = blanca + negra;
            var dotnegra = negra + corchea;
            Console.Beep(Solb,dotnegra);
            Console.Beep(Fa,dotnegra);
            Console.Beep(Mib,dotnegra);
            Console.Beep(Mib,negra);
            Console.Beep(Reb,corchea);
            Thread.Sleep(negra);
            Console.Beep(Mib,dotnegra);
            Console.Beep(Mib,negra);
            Console.Beep(Fa,corchea);
            Console.Beep(Mib,negra);
            Console.Beep(Reb,corchea);
            Console.Beep(Sib,negra);
            Console.Beep(Lab,corchea);
            Thread.Sleep(negra);
            Console.Beep(Sib,dotnegra);
            Console.Beep(Fa,dotnegra);
            Console.Beep(Mib,dotnegra);
            Console.Beep(Mib,negra);
            Console.Beep(Reb,corchea);
            Thread.Sleep(negra);
            Console.Beep(Mib,dotnegra);
            Console.Beep(Mib,negra);
            Console.Beep(Fa,corchea);
            Console.Beep(Mib,negra);
            Console.Beep(Reb,corchea);
            Console.Beep(Sib,negra);
            Console.Beep(Lab,corchea);
            Thread.Sleep(negra);
            Console.Beep(Sib,dotnegra);
            Console.Beep(Reb,dotnegra);
            Console.Beep(La2,dotblanca);
            Console.Beep(Sib,dotnegra);
        }
    }
}