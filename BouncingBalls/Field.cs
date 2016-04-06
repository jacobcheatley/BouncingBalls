using System;
using System.Collections.Generic;

namespace BouncingBalls
{
    class Field
    {
        private readonly int _width;
        private readonly int _height;

        private readonly List<Ball> _balls;

        public Field(int width, int height)
        {
            _balls = new List<Ball>();
            Console.BufferWidth = Console.WindowWidth = _width = Math.Min(width, Console.LargestWindowWidth);
            Console.BufferHeight = Console.WindowHeight = _height = Math.Min(height, Console.LargestWindowHeight);
            // Stops flickering
            Console.WindowWidth++;
            Console.WindowHeight++;
            Console.CursorVisible = false;
        }

        public void SpawnBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public void Update()
        {
            foreach (Ball ball in _balls)
            {
                Point nextPos = ball.NextPos;
                if (nextPos.X == 0 || nextPos.X == _width - 1)
                    ball.Velocity *= new Point(-1, 1);
                if (nextPos.Y == 0 || nextPos.Y == _height - 1)
                    ball.Velocity *= new Point(1, -1);
                ball.Position = nextPos;
            }
        }

        public void Draw()
        {
            Console.Clear();
            //Trails
            foreach (Ball ball in _balls)
            {
                Console.ForegroundColor = ball.TrailColor;
                for (int i = 0; i < ball.PreviousPositions.Length; i++)
                {
                    Point position = ball.PreviousPositions[i];
                    if (position == null)
                        break;
                    Console.SetCursorPosition(position.X, position.Y);
                    Console.WriteLine(ball.Trail[i]);
                }
            }
            //Balls
            foreach (Ball ball in _balls)
            {
                Console.ForegroundColor = ball.BallColor;
                Console.SetCursorPosition(ball.Position.X, ball.Position.Y);
                Console.Write(ball.Shape);
            }
        }
    }
}
