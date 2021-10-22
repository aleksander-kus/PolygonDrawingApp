using System.Drawing;
using System.Numerics;

namespace lab1.Relations
{
    public abstract class Relation
    {
        /// <summary>
        /// Color used to represent relation on canvas.
        /// </summary>
        public abstract Color Color { get; }
        /// <summary>
        /// Sumbol used to represent relation on canvas.
        /// </summary>
        public abstract char Symbol { get; }

        /// <summary>
        /// First edge the relation applies to.
        /// </summary>
        public abstract Shapes.Edge Edge1 { get; set; }
        /// <summary>
        /// Second edge the relation applies to.
        /// </summary>
        /// <remarks>May be null depending on the relation type.</remarks>
        public abstract Shapes.Edge Edge2 { get; set; }
        /// <summary>
        /// Circle the relation applies to
        /// </summary>
        /// <remarks>May be null depending on the relation type.</remarks>
        public abstract Shapes.Circle Circle { get; set; }

        protected void RemoveRelationFromEdgePoints(Shapes.Edge edge)
        {
            if (edge.p1.R1 == this)
                edge.p1.R1 = edge.p1.R2;
            edge.p1.R2 = null;

            if (edge.p2.R1 == this)
                edge.p2.R1 = edge.p2.R2;
            edge.p2.R2 = null;
        }
        /// <summary>
        /// Removes the relation from points in edges and from circle.
        /// </summary>
        public abstract void Remove();
        /// <summary>
        /// Adds relation to points in edges and in circle and applies the relation.
        /// </summary>
        public abstract void Impose();
        /// <summary>
        /// After moving a point or circle that has a reference to this relation, this function should be called.
        /// The function will fix the relation after the point has moved.
        /// </summary>
        /// <param name="clickedPoint"></param>
        /// <param name="vec"></param>
        public abstract void MovePoint(Shapes.Point clickedPoint, Vector2 vec);
    }
}
