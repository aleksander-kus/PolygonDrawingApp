using lab1.Shapes;
using System.Drawing;

namespace lab1.Relations
{
    public class FixedLengthRelation : Relation
    {
        private Edge edge;
        public override Color Color { get; } = Color.Green;

        public override Edge Edge1 => edge;

        public override Edge Edge2 => null;

        public override void Impose(Edge e1, Edge e2 = null)
        {
            edge = e1;
        }

        public override void MovePoint(Shapes.Point clickedPoint, int delta_x, int delta_y)
        {
            Shapes.Point other = edge.p1 == clickedPoint ? edge.p2 : edge.p1;
            other.Move(other.X + delta_x, other.Y + delta_y, clickedPoint);
        }
    }
}
