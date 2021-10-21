using System;
using System.Drawing;
using System.Numerics;
using System.Xml.Serialization;

namespace lab1.Shapes
{
    public class Circle
    {
        public Point Center { get; set; }

        [XmlAttribute(DataType = "bool")]
        public bool Anchored { get; set; } = false;

        [XmlAttribute(DataType = "bool")]
        public bool FixedRadius { get; set; } = false;

        [XmlAttribute(DataType = "int")]
        public int Radius { get; set; }

        public void ResizeOrMove(Point mouseLocation)
        {
            if (!FixedRadius)
                Radius = GraphicsHelpers.Distance(mouseLocation, Center);
            else
            {
                Vector2 vec = new(mouseLocation.X - Center.X, mouseLocation.Y - Center.Y);
                Vector2 v2 = (GraphicsHelpers.Distance(mouseLocation, Center) - Radius) * Vector2.Normalize(vec);
                Center.Move(v2);
            }
        }

        public void MoveCenter(Point mouseLocation)
        {
            if (!Anchored)
                Center.Move(mouseLocation);
        }
    }
}
