using System.Xml.Serialization;

namespace lab1.Shapes
{
    public class Point
    {
        [XmlAttribute("X", DataType = "int")]
        public int X { get; set; }

        [XmlAttribute("Y", DataType = "int")]
        public int Y { get; set; }

        public Relations.Relation R1 { get; set; }
        public Relations.Relation R2 { get; set; }

        // A private default constructor for deserializing
        private Point()
        {

        }

        public Point(int x, int y) => Move(x, y);

        public Point(System.Drawing.Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public System.Drawing.Point ToStruct() => new(X, Y);

        public void Move(Point point) => Move(point.X, point.Y);
        public void Move(int x, int y, Point ignoreRelationWith = null)
        {
            int delta_x = x - X;
            int delta_y = y - Y;
            bool isR1Ignored = R1 == null || ignoreRelationWith != null && (R1.Edge1.p1 == ignoreRelationWith || R1.Edge1.p2 == ignoreRelationWith);
            bool isR2Ignored = R2 == null || ignoreRelationWith != null && (R2.Edge1.p1 == ignoreRelationWith || R2.Edge1.p2 == ignoreRelationWith);
            X += delta_x;
            Y += delta_y;
            if (!isR2Ignored)
            {
                R2.MovePoint(this, delta_x, delta_y);
            }
            if (!isR1Ignored)
            {
                R1.MovePoint(this, delta_x, delta_y);
            }
        }
    }
}
