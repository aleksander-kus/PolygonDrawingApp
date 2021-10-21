using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Relations
{
    public abstract class Relation 
    {
        public abstract Color Color { get; }
        public abstract char Symbol { get; }

        public abstract Shapes.Edge Edge1 { get; set; }
        public abstract Shapes.Edge Edge2 { get; set; }
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
        public abstract void Remove();
        public abstract void Impose();
        public abstract void MovePoint(Shapes.Point clickedPoint, Vector2 vec);
    }
}
