using System;

namespace Cars
{
    class Rules
    {
        public void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Reglas CARS.");
            Console.WriteLine("Moverse con ← y →.");
            Console.WriteLine("Las - te dan una vida");
            Console.WriteLine("Los * te reducen la velocidad");
            Console.WriteLine("Los # te quitan una vida");
            Console.WriteLine("Mueres si tu vida llega a 0");
            Console.WriteLine("Pulsa Escape para salir");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Welcome welcome = new Welcome();
                        welcome.Launch();
                    }
                }
            }
        }
    }
}
