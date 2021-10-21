using System;
using System.Numerics;
using System.Xml.Serialization;

namespace lab1.Shapes
{
    public class Point
    {
        [XmlAttribute("X", DataType = "int")]
        public int X { get; set; }

        [XmlAttribute("Y", DataType = "int")]
        public int Y { get; set; }

        [XmlIgnore]
        public Relations.Relation R1 { get; set; }
        [XmlIgnore]
        public Relations.Relation R2 { get; set; }

        private bool preventInfiniteLoop = false;
        
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

        public bool Equals(Point p)
        {
            return p.X == X && p.Y == Y;
        }
        public void Move(Point destination, Point ignoreRelationWith = null) => Move(destination.X, destination.Y, ignoreRelationWith);
        public void Move(int x, int y, Point ignoreRelationWith = null) => Move(new Vector2(x - X, y - Y), ignoreRelationWith);
        public void Move(Vector2 vec, Point ignoreRelationWith = null)
        {
            X += (int)Math.Round(vec.X);
            Y += (int)Math.Round(vec.Y);

            bool isR1Ignored = R1 == null || ignoreRelationWith != null && (R1.Edge1.p1 == ignoreRelationWith || R1.Edge1.p2 == ignoreRelationWith || R1.Edge2?.p1 == ignoreRelationWith || R1.Edge2?.p2 == ignoreRelationWith);
            bool isR2Ignored = R2 == null || ignoreRelationWith != null && (R2.Edge1.p1 == ignoreRelationWith || R2.Edge1.p2 == ignoreRelationWith || R2.Edge2?.p1 == ignoreRelationWith || R2.Edge2?.p2 == ignoreRelationWith);
            if (isR1Ignored && isR2Ignored) return;
            if (!isR2Ignored)
            {
                (int x, int y) prev = (X, Y);
                R2.MovePoint(this, vec);
                if ((X, Y) != prev)
                {
                    preventInfiniteLoop = true;
                    return;
                }
            }
            if(preventInfiniteLoop)
            {
                preventInfiniteLoop = false;
                return;
            }
            if (!isR1Ignored)
            {
                R1.MovePoint(this, vec);
            }
        }
    }
}
