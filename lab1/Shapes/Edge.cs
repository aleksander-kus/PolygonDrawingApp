using System;

namespace lab1.Shapes
{
    public class Edge
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }

        private Edge()  // a private contructor for deserializing
        {
        }

        public Edge(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public int Length => (int)Math.Round(Math.Sqrt(GraphicsHelpers.SquaredDistance(p1, p2)));
        public Point Center => GraphicsHelpers.SegmentCenter(p1, p2);
    }
}
