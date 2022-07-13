using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cars
{
    public class Welcome
    {
        public void Launch()
        {
            Game partida = new Game();
            Rules reglas = new Rules();
            //Mostramos el menú
            Console.Clear();
            Console.ResetColor();
            
            Console.WriteLine(".CARS.");
            
            Console.WriteLine("1) Jugar partida");
            
            Console.WriteLine("2) Reglas del juego");
            
            Console.WriteLine("3) Salir");
            
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    partida.Launch();
                    break;
                case "2":
                    reglas.ShowRules();
                    break;
                case "3": break;
                default:
                    Console.WriteLine("'{0}' NO ES UNA OPCIÓN VÁLIDA.", opcion);
                    break;
            }
        }
    }
}