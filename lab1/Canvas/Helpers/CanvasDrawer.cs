using System.Collections.Generic;
using System.Drawing;

namespace lab1.Canvas.Helpers
{
    /// <summary>
    /// A class to draw the canvas and its contents
    /// </summary>
    public class CanvasDrawer : CanvasHelper
    {
        private readonly BufferedPanel panel;

        public CanvasDrawer(BufferedPanel p, CanvasResources r) : base(r)
        {
            panel = p;
        }

        /// <summary>
        /// Draw the canvas and its contents
        /// </summary>
        /// <param name="g">Graphics used to draw</param>
        public void Draw(Graphics g)
        {
            if (resources.AddingPolygonVertices != null)
                DrawAddingPolygon(g);
            if (resources.AddingCircle != null)
                DrawCircle(g, resources.AddingCircle);
            foreach (var polygon in resources.Polygons)
                DrawPolygonEdges(g, polygon);
            foreach (var circle in resources.Circles)
                DrawCircle(g, circle);
            foreach (var relation in resources.Relations)
                DrawEdgesWithRelation(g, relation);
            if (resources.AddingRelation != null)
                DrawEdgesWithRelation(g, resources.AddingRelation);
            foreach (var polygon in resources.Polygons)
                DrawPolygonVertices(g, polygon);
        }

        private void DrawVertice(Graphics g, Shapes.Point location, Color? color = null)
        {
            using Brush b = new SolidBrush(color ?? Color.Green);
            using Pen p = new(Color.Black, 1);
            Rectangle r = new() { X = location.X - 3, Y = location.Y - 3, Height = 6, Width = 6 };
            g.FillEllipse(b, r);
            g.DrawEllipse(p, r);
        }

        private void DrawAddingPolygon(Graphics g)
        {
            using Pen p = new(Color.Black, 1);
            DrawVertice(g, resources.AddingPolygonVertices[0]);
            for (int i = 1; i < resources.AddingPolygonVertices.Count; ++i)
            {
                g.DrawLine(p, resources.AddingPolygonVertices[i - 1].ToStruct(), resources.AddingPolygonVertices[i].ToStruct());
                DrawVertice(g, resources.AddingPolygonVertices[i]);
            }
        }

        private void DrawPolygonEdges(Graphics g, Shapes.Polygon polygon)
        {
            List<Shapes.Point> vertices = polygon.VertexList;
            for (int i = 0; i < vertices.Count; ++i)
            {
                g.DrawLineBresenham(Color.Black, vertices[i], vertices[(i + 1) % vertices.Count]);
            }
        }

        private void DrawPolygonVertices(Graphics g, Shapes.Polygon polygon)
        {
            List<Shapes.Point> vertices = polygon.VertexList;
            for (int i = 0; i < vertices.Count; ++i)
            {
                Shapes.Point center = GraphicsHelpers.SegmentCenter(vertices[i], vertices[(i + 1) % vertices.Count]);
                DrawVertice(g, center, Color.Yellow);
                DrawVertice(g, vertices[i]);
            }
            DrawVertice(g, vertices[0]);
            polygon.RecalculateCenterPoint();
            DrawVertice(g, polygon.Center, Color.Red);
        }

        private void DrawCircle(Graphics g, Shapes.Circle circle, Color? color = null)
        {
            Pen p = new(color ?? Color.Black, 1);
            Rectangle r = new(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, 2 * circle.Radius, 2 * circle.Radius);
            g.DrawEllipse(p, r);
            if (circle.FixedRadius)
                p.Color = Color.Blue;
            g.DrawLine(p, circle.Center.ToStruct(), new Point(circle.Center.X + circle.Radius, circle.Center.Y));
            DrawVertice(g, circle.Center, circle.Anchored ? Color.Brown : Color.Red);
            p.Dispose();
        }

        private void DrawEdgesWithRelation(Graphics g, Relations.Relation relation)
        {
            void DrawEdge(Shapes.Edge edge)
            {
                g.DrawLineBresenham(relation.Color, edge.p1, edge.p2);
                using Brush b = new SolidBrush(relation.Color);
                using Font f = new("Arial", 15f);
                int index = resources.Relations.IndexOf(relation);
                g.DrawString($"{relation.Symbol}{ (index == -1 ? string.Empty : index.ToString()) }", f, b, edge.Center.ToStruct());
            }
            if (relation.Edge1 != null)
            {
                DrawEdge(relation.Edge1);
            }
            if (relation.Edge2 != null)
            {
                DrawEdge(relation.Edge2);
            }
            if (relation.Circle != null)
            {
                DrawCircle(g, relation.Circle, relation.Color);
                using Brush b = new SolidBrush(relation.Color);
                using Font f = new("Arial", 15f);
                int index = resources.Relations.IndexOf(relation);
                g.DrawString($"{relation.Symbol}{ (index == -1 ? string.Empty : index.ToString()) }", f, b, relation.Circle.Center.ToStruct());
            }
        }

        /// <summary>
        /// Redraw the canvas after a change in contents
        /// </summary>
        public void Redraw() => panel.Invalidate();
    }
}
