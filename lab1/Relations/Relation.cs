using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Relations
{
    public abstract class Relation
    {
        public abstract Color Color { get; }

        public abstract Shapes.Edge Edge1 { get; }
        public abstract Shapes.Edge Edge2 { get; }

        public abstract void Impose(Shapes.Edge e1, Shapes.Edge e2);
        public abstract void MovePoint(Shapes.Point clickedPoint, int dx, int dy);
    }
}
