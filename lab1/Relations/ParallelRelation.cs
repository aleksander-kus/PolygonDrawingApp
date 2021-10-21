using lab1.Shapes;
using System;
using System.Drawing;
using System.Numerics;

namespace lab1.Relations
{
    public class ParallelRelation : Relation
    {
        public override Color Color => Color.LightBlue;

        public override Edge Edge1 { get; set; }

        public override Edge Edge2 { get; set; }

        private void AdjustEdge(Edge toAdjust, Edge other, Shapes.Point movedPoint)
        {
            if (movedPoint == toAdjust.p2)
            {
                Vector2 v = new(other.p1.X - other.p2.X, other.p1.Y - other.p2.Y);
                var v2 = toAdjust.Length * Vector2.Normalize(v);
                toAdjust.p2.Move(toAdjust.p1.X + (int)Math.Round(v2.X), toAdjust.p1.Y + (int)Math.Round(v2.Y), toAdjust.p2);
            }
            else
            {
                Vector2 v = new(other.p2.X - other.p1.X, other.p2.Y - other.p1.Y);
                var v2 = toAdjust.Length * Vector2.Normalize(v);
                toAdjust.p1.Move(toAdjust.p2.X + (int)Math.Round(v2.X), toAdjust.p2.Y + (int)Math.Round(v2.Y), toAdjust.p1);
            }
        }

        private void AddRelationToEdgePoints(Edge edge)
        {
            if (edge.p1.R1 == null) edge.p1.R1 = this;
            else if (edge.p1.R2 == null) edge.p1.R2 = this;
            if (edge.p2.R1 == null) edge.p2.R1 = this;
            else if (edge.p2.R2 == null) edge.p2.R2 = this;
        }

        /// <summary>
        /// Change the edges so that the relation is fulfilled
        /// </summary>
        /// <remarks>Should be called after both edges are set, otherwise an exception is thrown</remarks>
        public override void Impose()
        {
            if (Edge1 == null || Edge2 == null)
                throw new NotSupportedException("Assign both edges of the relation before imposing it.");
            AddRelationToEdgePoints(Edge1);
            AddRelationToEdgePoints(Edge2);
            AdjustEdge(Edge2, Edge1, null);
            AdjustEdge(Edge1, Edge2, null);
        }

        public override void MovePoint(Shapes.Point clickedPoint, Vector2 vec)
        {
            if (clickedPoint == Edge1.p1 || clickedPoint == Edge1.p2)
                AdjustEdge(Edge2, Edge1, clickedPoint);
            else
                AdjustEdge(Edge1, Edge2, clickedPoint);
        }

        public override void Remove()
        {
            RemoveRelationFromEdgePoints(Edge1);
            RemoveRelationFromEdgePoints(Edge2);
        }
    }
}
