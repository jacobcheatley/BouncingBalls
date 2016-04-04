using System;

namespace BouncingBalls
{
    class Program
    {
        private const int Width = 80;
        private const int Height = 40;
        private const int Balls = 3;

        static void Main(string[] args)
        {
            Field field = new Field(Width, Height);
            Random random = new Random();
            for (int i = 0; i < Balls; i++)
                field.SpawnBall(Ball.InBounds(Width, Height, random));

            while (true)
            {
                field.Update();
                field.Draw();
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
