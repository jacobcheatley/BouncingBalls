using System;
using System.Threading;

namespace BouncingBalls
{
    class Program
    {
        private const int Width = 120;
        private const int Height = 80;
        private const int Balls = 1;

        private static Field field;
        private static Random random;

        static void Main(string[] args)
        {
            field = new Field(Width, Height);
            random = new Random();
            for (int i = 0; i < Balls; i++)
                field.SpawnBall(Ball.InBounds(Width, Height, random));
            
            Thread consoleKeyListener = new Thread(ListenerKeyboardEvent);

            consoleKeyListener.Start();

            while (true)
            {
                field.Update();
                field.Draw();
                Thread.Sleep(50);
            }
        }

        static void ListenerKeyboardEvent()
        {
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    field.SpawnBall(Ball.InBounds(Width, Height, random));
            }
        }
    }
}
