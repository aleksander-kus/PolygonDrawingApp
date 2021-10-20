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
            //clickedPoint.X += delta_x;
            //clickedPoint.Y += delta_y;

            //// the other point has only one relation (this one), no further actions required
            //if (other.R1 == null || other.R2 == null)
            //{
            //    other.X = other.X + delta_x;
            //    other.Y = other.Y + delta_y;
            //    return;
            //}
            //Relation otherRelation = other.R1 == this ? other.R2 : other.R1;
            //otherRelation.MovePoint(clickedPoint, new Shapes.Point(clickedPoint.X + delta_x, clickedPoint.Y + delta_y));
            //other.X += delta_x;
            //other.Y += delta_y;
            other.Move(other.X + delta_x, other.Y + delta_y, clickedPoint);
        }
    }
}
