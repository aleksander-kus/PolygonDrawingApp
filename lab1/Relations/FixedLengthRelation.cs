using lab1.Shapes;
using System;
using System.Drawing;
using System.Numerics;

namespace lab1.Relations
{
    public class FixedLengthRelation : Relation
    {
        public override Color Color { get; } = Color.LightGreen;

        public override char Symbol => 'F';

        private Shapes.Point first = null;
        public override Edge Edge1 { get; set; }

        public override Edge Edge2 { get; set; } = null;

        /// <summary>
        /// Change the edges so that the relation is fulfilled
        /// </summary>
        /// <remarks>Should be called after the first edge is assigned, otherwise an exception is thrown</remarks>
        public override void Impose()
        {
            if (Edge1 == null)
                throw new NotSupportedException("Assign first edge of the relation before imposing it.");
            AddRelationToEdgePoints(Edge1);
        }

        private void AddRelationToEdgePoints(Edge edge)
        {
            if (edge.p1.R1 == null) edge.p1.R1 = this;
            else if (edge.p1.R2 == null) edge.p1.R2 = this;
            if (edge.p2.R1 == null) edge.p2.R1 = this;
            else if (edge.p2.R2 == null) edge.p2.R2 = this;
        }

        public override void MovePoint(Shapes.Point clickedPoint, Vector2 vec)
        {
            if(clickedPoint == first)
            {
                first = null;
                clickedPoint.Move(-vec, clickedPoint);
                return;
            }
            if (first == null)
                first = clickedPoint;
            Shapes.Point other = Edge1.p1 == clickedPoint ? Edge1.p2 : Edge1.p1;
            other.Move(vec, clickedPoint);
            first = null;
        }

        public override void Remove()
        {
            RemoveRelationFromEdgePoints(Edge1);
        }
    }
}
