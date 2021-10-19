using System.Drawing;
using System.Xml.Serialization;

namespace lab1.Shapes
{
    public class Circle
    {
        public Point Center { get; set; }

        [XmlAttribute(DataType = "int")]
        public int Radius { get; set; }
    }
}
