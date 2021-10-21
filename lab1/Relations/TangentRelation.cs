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
    public class TangentRelation : Relation
    {
        public override Color Color => Color.Orange;

        public override char Symbol => 'T';

        public override Edge Edge1 { get; set; }
        public override Edge Edge2 { get; set; } = null;
        public override Circle Circle { get; set; }

        private void MakeEdgeTangent()
        {

        }

        private int DistanceFromPointToEdgeLine(Shapes.Point point)
        {
            int distance = (int)Math.Round(Math.Abs((Edge1.p2.X - Edge1.p1.X) * (Edge1.p1.Y - point.Y) - (Edge1.p1.X - point.X) * (Edge1.p2.Y - Edge1.p1.Y)) / (double)GraphicsHelpers.Distance(Edge1.p1, Edge1.p2));
            return distance;
        }

        private void Adjust(Shapes.Point clickedPoint)
        {
            if(clickedPoint == Circle.Center)
            {
                if(Circle.FixedRadius)
                {
                    Vector2 vec = new(Edge1.p2.X - Edge1.p1.X, Edge1.p2.Y - Edge1.p1.Y);
                    Vector2 v2 = new(vec.Y, -vec.X);
                    Vector2 v3 = (Circle.Radius - DistanceFromPointToEdgeLine(clickedPoint)) * Vector2.Normalize(v2);
                    Edge1.p2.Move(v3);
                    Edge1.p1.Move(v3);
                }
            }
            else
            {

            }
        }

        public override void Impose()
        {
            Circle.R1 = this;
            Adjust(Circle.Center);
            Adjust(Circle.Center);
        }

        public override void MovePoint(Shapes.Point clickedPoint, Vector2 vec)
        {
            
            Adjust(clickedPoint);
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
