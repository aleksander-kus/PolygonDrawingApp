using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace lab1.Shapes
{
    public class Polygon
    {
        [XmlArray("VertexList")]
        public List<Point> VertexList { get; private set; }

        [XmlIgnore]
        public Point Center { get; private set; } = new Point(0, 0);

        // A private default constructor for deserializing
        private Polygon()
        {
            VertexList = new();
        }

        public Polygon(List<Point> vertices = null)
        {
            VertexList = new(vertices);
        }

        public void RecalculateMiddlePoint()
        {
            // the center point has coordinates equal to the average coords of all points
            Center.Move(VertexList.Select(p => p.X).Aggregate((p1, p2) => p1 + p2) / VertexList.Count,
                VertexList.Select(p => p.Y).Aggregate((p1, p2) => p1 + p2) / VertexList.Count);
        }
    }
}
