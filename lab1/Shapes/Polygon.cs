using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab1.Shapes
{
    public class Polygon
    {
        public List<Point> VertexList { get; private set; }
        public Point MiddlePoint { get; private set; }

        public Polygon(List<Point> vertices)
        {
            VertexList = vertices;
            MiddlePoint = new Point(VertexList.Select(p => p.X).Aggregate((p1, p2) => p1 + p2) / VertexList.Count,
                VertexList.Select(p => p.Y).Aggregate((p1, p2) => p1 + p2) / VertexList.Count);
        }
    }
}
