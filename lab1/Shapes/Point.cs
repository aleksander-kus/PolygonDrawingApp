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

        [XmlIgnore]  // relations have to be ignored by the serializer to prevent loops
        public Relations.Relation R1 { get; set; }
        [XmlIgnore]
        public Relations.Relation R2 { get; set; }

        private bool preventInfiniteLoop = false;  // used when working with relations

        private Point()  // A private default constructor for deserializing
        {

        }

        public Point(int x, int y) => Move(x, y);

        public Point(System.Drawing.Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public System.Drawing.Point ToStruct() => new(X, Y);

        public bool Equals(Point p) => p.X == X && p.Y == Y;

        /// <summary>
        /// Move point to destination point
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="ignoreRelationWith"></param>
        public void Move(Point destination, Point ignoreRelationWith = null) => Move(destination.X, destination.Y, ignoreRelationWith);
        /// <summary>
        /// Move point to destination point denoted by two coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ignoreRelationWith"></param>
        public void Move(int x, int y, Point ignoreRelationWith = null) => Move(new Vector2(x - X, y - Y), ignoreRelationWith);
        /// <summary>
        /// Move point by a given vector
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="ignoreRelationWith"></param>
        public void Move(Vector2 vec, Point ignoreRelationWith = null, bool ignoreNonTangent = false)
        {
            X += (int)Math.Round(vec.X);
            Y += (int)Math.Round(vec.Y);

            bool isR1Ignored = R1 == null || (R1.Circle == null && ignoreNonTangent) || ignoreRelationWith != null && (R1.Edge1.p1 == ignoreRelationWith || R1.Edge1.p2 == ignoreRelationWith || R1.Edge2?.p1 == ignoreRelationWith || R1.Edge2?.p2 == ignoreRelationWith);
            bool isR2Ignored = R2 == null || (R2.Circle == null && ignoreNonTangent) || ignoreRelationWith != null && (R2.Edge1.p1 == ignoreRelationWith || R2.Edge1.p2 == ignoreRelationWith || R2.Edge2?.p1 == ignoreRelationWith || R2.Edge2?.p2 == ignoreRelationWith);
            if (isR1Ignored && isR2Ignored) return;
            if (!isR2Ignored)
            {
                (int x, int y) prev = (X, Y);
                R2.MovePoint(this, vec);
                if ((X, Y) != prev)  // if a point was moved while moving other points, it means we have a relation loop
                {
                    preventInfiniteLoop = true;
                    return;
                }
            }
            if (preventInfiniteLoop)  // dont try fixing other relation if we have a loop
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
