using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab1.Helpers
{
    [XmlRoot("Canvas", Namespace = "http://example.org/ak/canvas")]
    [XmlInclude(typeof(Shapes.Polygon))]
    [XmlInclude(typeof(Shapes.Circle))]
    public class SerializedCanvas
    {
        [XmlArray("PolygonList")]
        public List<Shapes.Polygon> PolygonList { get; set; } = new();
        [XmlArray("CircleList")]
        public List<Shapes.Circle> CircleList { get; set; } = new();

    }
}
