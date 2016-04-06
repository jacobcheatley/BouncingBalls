using System;
using System.Collections.Generic;

namespace BouncingBalls
{
    class Ball
    {
        public Point[] PreviousPositions { get; set; }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set
            {
                UpdatePreviousPositions();
                _position = value;
            }
        }

        public Point Velocity { get; set; }
        public Point NextPos => Position + Velocity;

        public char Shape { get; }
        public char[] Trail { get; }

        public ConsoleColor BallColor { get; }
        public ConsoleColor TrailColor { get; }

        public Ball(Point position, Point velocity, char shape, char[] trail, ConsoleColor ballColor, ConsoleColor trailColor)
        {
            Position = position;
            Velocity = velocity;
            Shape = shape;
            Trail = trail;
            PreviousPositions = new Point[Trail.Length];
            BallColor = ballColor;
            TrailColor = trailColor;
        }

        public void UpdatePreviousPositions()
        {
            if (PreviousPositions == null)
                return;

            for (int i = 1; i < PreviousPositions.Length; i++)
                PreviousPositions[i] = PreviousPositions[i - 1];
            PreviousPositions[0] = _position;
        }

        public static Ball InBounds(int maxWidth, int maxHeight, System.Random random)
        {
            Point position = new Point(random.Next(1, maxWidth - 1), random.Next(1, maxHeight - 1));
            Point velocity = new Point(new []{ -1, 1 } [random.Next(0, 2)], new []{ -1, 1 }[random.Next(0, 2)]);
            Array colors = Enum.GetValues(typeof (ConsoleColor));
            ConsoleColor ball = (ConsoleColor)colors.GetValue(random.Next(colors.Length));
            ConsoleColor trail = (ConsoleColor)colors.GetValue(random.Next(colors.Length));
            return new Ball(position, velocity, '0', new []{ 'O', 'o', '.', '.' }, ball, trail);
        }
    }
}
