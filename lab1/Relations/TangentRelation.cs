using lab1.Shapes;
using System;
using System.Drawing;
using System.Numerics;

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
            Vector2 vec = new(Edge1.p2.X - Edge1.p1.X, Edge1.p2.Y - Edge1.p1.Y);
            Vector2 v2 = new(vec.Y, -vec.X);
            Vector2 v3 = (Circle.Radius - DistanceFromPointToEdgeLine(Circle.Center)) * Vector2.Normalize(v2);
            Edge1.p2.Move(v3);
            Edge1.p1.Move(v3);
        }

        private void MakeCircleTangent()
        {
            Vector2 vec = new(Edge1.p2.X - Edge1.p1.X, Edge1.p2.Y - Edge1.p1.Y);
            Vector2 v2 = new(-vec.Y, vec.X);
            Vector2 v3 = (Circle.Radius - DistanceFromPointToEdgeLine(Circle.Center)) * Vector2.Normalize(v2);
            Circle.Center.Move(v3);
        }

        private int DistanceFromPointToEdgeLine(Shapes.Point point)
        {
            int distance = (int)Math.Round(Math.Abs((Edge1.p2.X - Edge1.p1.X) * (Edge1.p1.Y - point.Y) - (Edge1.p1.X - point.X) * (Edge1.p2.Y - Edge1.p1.Y)) / (double)GraphicsHelpers.Distance(Edge1.p1, Edge1.p2));
            return distance;
        }

        private void Adjust(Shapes.Point clickedPoint)
        {
            if (Circle.FixedRadius)
            {
                if (clickedPoint == Circle.Center)
                    MakeEdgeTangent();
                else
                    MakeCircleTangent();
            }
            else
                Circle.Radius = DistanceFromPointToEdgeLine(Circle.Center);
        }

        private void AddRelationToEdgePoints(Edge edge)
        {
            if (edge.p1.R1 == null) edge.p1.R1 = this;
            else if (edge.p1.R2 == null) edge.p1.R2 = this;
            if (edge.p2.R1 == null) edge.p2.R1 = this;
            else if (edge.p2.R2 == null) edge.p2.R2 = this;
        }

        public override void Impose()
        {
            Circle.R1 = this;
            AddRelationToEdgePoints(Edge1);
            Adjust(Circle.Center);
            Adjust(Circle.Center);
        }

        public override void FixRelation(Shapes.Point clickedPoint, Vector2 vec)
        {
            if (clickedPoint == Circle.Center && vec == Vector2.Zero)
                MakeEdgeTangent();
            else
                Adjust(clickedPoint);
        }

        public override void Remove()
        {
            RemoveRelationFromEdgePoints(Edge1);
            Circle.R1 = null;
        }
    }
}
