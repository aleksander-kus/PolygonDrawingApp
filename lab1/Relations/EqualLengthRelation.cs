using lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Relations
{
    public class EqualLengthRelation : Relation
    {
        public override Color Color => Color.Red;

        public override Edge Edge1 { get; set; }

        public override Edge Edge2 { get; set; }

        private void AdjustEdge(Edge toAdjust, Edge other)
        {
            Vector2 v = new(toAdjust.p2.X - toAdjust.p1.X, toAdjust.p2.Y - toAdjust.p1.Y);
            var v2 = other.Length * Vector2.Normalize(v);
            toAdjust.p2.Move(toAdjust.p1.X + (int)Math.Round(v2.X), toAdjust.p1.Y + (int)Math.Round(v2.Y), toAdjust.p1);
        }

        public override void Impose() => AdjustEdge(Edge2, Edge1);
        public override void Impose(Edge e1, Edge e2)
        {
            Edge1 = e1;
            Edge2 = e2;
            AdjustEdge(Edge2, Edge1);
        }

        public override void MovePoint(Shapes.Point clickedPoint, int dx, int dy)
        {
            if (clickedPoint == Edge1.p1 || clickedPoint == Edge1.p2)
                AdjustEdge(Edge2, Edge1);
            else
                AdjustEdge(Edge1, Edge2);
        }
    }
}
