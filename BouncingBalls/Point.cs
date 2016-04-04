namespace BouncingBalls
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set;  }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator *(Point p1, Point p2)
        {
            return new Point(p1.X * p2.X, p1.Y * p2.Y);
        }
    }
}
