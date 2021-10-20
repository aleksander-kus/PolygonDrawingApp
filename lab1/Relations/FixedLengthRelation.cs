using lab1.Shapes;
using System.Drawing;

namespace lab1.Relations
{
    public class FixedLengthRelation : Relation
    {
        public override Color Color { get; } = Color.LightGreen;

        public override Edge Edge1 { get; set; }

        public override Edge Edge2 { get; set; } = null;

        public override void Impose()
        { 
        }
        
        public override void Impose(Edge e1, Edge e2 = null)
        {
            Edge1 = e1;
        }

        public override void MovePoint(Shapes.Point clickedPoint, int delta_x, int delta_y)
        {
            Shapes.Point other = Edge1.p1 == clickedPoint ? Edge1.p2 : Edge1.p1;
            other.Move(other.X + delta_x, other.Y + delta_y, clickedPoint);
        }
    }
}
