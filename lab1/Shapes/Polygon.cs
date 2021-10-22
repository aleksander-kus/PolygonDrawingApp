using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace lab1.Shapes
{
    public class Polygon
    {
        [XmlArray("VertexList")]
        public List<Point> VertexList { get; private set; }

        [XmlIgnore]  // ignored by the serializer because it is calculated on drawing anyways
        public Point Center { get; private set; } = new Point(0, 0);

        private Polygon()  // A private default constructor for deserializing
        {
            VertexList = new();
        }

        public Polygon(List<Point> vertices = null)
        {
            VertexList = new(vertices);
        }

        public void RecalculateCenterPoint()
        {
            // the center point has coordinates equal to the average coords of all points
            Center.Move(VertexList.Select(p => p.X).Aggregate((p1, p2) => p1 + p2) / VertexList.Count,
                VertexList.Select(p => p.Y).Aggregate((p1, p2) => p1 + p2) / VertexList.Count);
        }
    }
}
