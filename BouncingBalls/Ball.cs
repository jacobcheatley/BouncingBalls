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

        public Ball(Point position, Point velocity, char shape, char[] trail)
        {
            Position = position;
            Velocity = velocity;
            Shape = shape;
            Trail = trail;
            PreviousPositions = new Point[Trail.Length];
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
            Point position = new Point(random.Next(1, maxWidth), random.Next(1, maxHeight));
            Point velocity = new Point(new []{ -1, 1 } [random.Next(0, 2)], new []{ -1, 1 }[random.Next(0, 2)]);
            return new Ball(position, velocity, '0', new []{ 'O', 'o', '.', '.' });
        }
    }
}
