using System;

namespace Cars
{
    class Game
    {
        public void Launch()
        {
            double speed = 100.0;
            double acceleration = 0.5;
            int playfieldWidth = 5;
            int livesCount = 5;
            bool keepPlaying = true;
            Console.Clear();
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 30;
            Object objectCar = new Object();
            objectCar.x = 2;
            objectCar.y = Console.WindowHeight - 1;
            objectCar.c = '@';
            objectCar.color = ConsoleColor.Yellow;
            Random randomGenerator = new Random();
            List<Object> objects = new List<Object>();
            while (keepPlaying)
            {
                speed += acceleration;
                if (speed > 400)
                {
                    speed = 400;
                }

                bool hitted = false;
                {
                    int chance = randomGenerator.Next(0, 100);
                    if (chance < 10)
                    {
                        Object newObject = new Object();
                        newObject.color = ConsoleColor.Green;
                        newObject.c = '-';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    else if (chance < 20)
                    {
                        Object newObject = new Object();
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = '*';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    else
                    {
                        Object newCar = new Object();
                        newCar.color = ConsoleColor.Gray;
                        newCar.x = randomGenerator.Next(0, playfieldWidth);
                        newCar.y = 0;
                        newCar.c = '#';
                        objects.Add(newCar);
                    }
                }

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    //while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (objectCar.x - 1 >= 0)
                        {
                            objectCar.x = objectCar.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (objectCar.x + 1 < playfieldWidth)
                        {
                            objectCar.x = objectCar.x + 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        keepPlaying = false;
                        Welcome welcome = new Welcome();
                        welcome.Launch();
                    }
                }
                List<Object> newList = new List<Object>();
                for (int i = 0; i < objects.Count; i++)
                {
                    Object oldCar = objects[i];
                    Object newObject = new Object();
                    newObject.x = oldCar.x;
                    newObject.y = oldCar.y + 1;
                    newObject.c = oldCar.c;
                    newObject.color = oldCar.color;
                    if (newObject.c == '*' && newObject.y == objectCar.y && newObject.x == objectCar.x)
                    {
                        speed -= 20;
                    }
                    if (newObject.c == '-' && newObject.y == objectCar.y && newObject.x == objectCar.x)
                    {
                        livesCount++;
                    }
                    if (newObject.c == '#' && newObject.y == objectCar.y && newObject.x == objectCar.x)
                    {
                        livesCount--;
                        hitted = true;
                        speed += 50;
                        if (speed > 400)
                        {
                            speed = 400;
                        }
                        if (livesCount <= 0)
                        {
                            PrtStringOnPosition.PrintStringOnPosition(8, 10, "¡¡¡FIN DE PARTIDA!!!", ConsoleColor.Red);
                            PrtStringOnPosition.PrintStringOnPosition(8, 12, "Presiona [enter] para salir", ConsoleColor.Red);
                            Console.ReadLine();
                            keepPlaying = false;
                            Welcome welcome = new Welcome();
                            welcome.Launch();
                        }
                    }
                    if (newObject.y < Console.WindowHeight)
                    {
                        newList.Add(newObject);
                    }
                }
                objects = newList;
                Console.Clear();
                if (hitted)
                {
                    objects.Clear();

                    PrtOnPosition.PrintOnPosition(objectCar.x, objectCar.y, 'X', ConsoleColor.Red);
                }
                else
                {
                    PrtOnPosition.PrintOnPosition(objectCar.x, objectCar.y, objectCar.c, objectCar.color);
                }
                foreach (Object car in objects)
                {
                    PrtOnPosition.PrintOnPosition(car.x, car.y, car.c, car.color);
                }

                // Draw info
                PrtStringOnPosition.PrintStringOnPosition(8, 4, "Vidas: " + livesCount, ConsoleColor.White);
                PrtStringOnPosition.PrintStringOnPosition(8, 5, "Velocidad: " + speed, ConsoleColor.White);
                PrtStringOnPosition.PrintStringOnPosition(8, 6, "Acceleración: " + acceleration, ConsoleColor.White);
                //Console.Beep();
                Thread.Sleep((int)(600 - speed));
            }
            }
    }
}
