using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab1
{
    public class Canvas
    {
        private BufferedPanel panel;

        // storing elements on the canvas
        private List<Shapes.Polygon> polygons = new();
        private List<Shapes.Circle> circles = new();

        // used when adding a new polygon
        private List<Point> addingPolygonVertices;

        // used when adding a new circle
        private Shapes.Circle addingCircle;
        private bool circle_anchored = false;

        public Canvas(BufferedPanel panel)
        {
            this.panel = panel;
        }

        /// <summary>
        /// Start adding a new polygon to the canvas
        /// </summary>
        /// <param name="location">Starting location of polygon</param>
        public void StartAddingPolygon(Point mousePosition)
        {
            addingPolygonVertices = new();
            addingPolygonVertices.Add(mousePosition);
        }

        public void StartAddingCircle(Point mousePosition) => addingCircle = new Shapes.Circle { Center = mousePosition, Radius = 1 };
        /// <summary>
        /// Calculates distance between two points without the final root to avoid overhead
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>The squared distance between two points</returns>
        public int SquaredDistance(Point p1, Point p2) => (p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y);

        /// <summary>
        /// Returns if a point was clicked with 10 pixel toleration
        /// </summary>
        /// <param name="point">Questioned point</param>
        /// <param name="click_location">Mouse click location</param>
        /// <returns>If the point was clicked</returns>
        public bool IsPointClicked(Point point, Point click_location) => SquaredDistance(point, click_location) <= 100;

        /// <summary>
        /// Add a new point to the polygon
        /// </summary>
        /// <param name="location">The location</param>
        /// <returns>If drawing of the new polygon is finished, return true</returns>
        public bool AddPointToPolygon(Point mousePosition)
        {
            // if the first point was clicked, finish adding the new polygon
            if (addingPolygonVertices.Count > 3 && IsPointClicked(addingPolygonVertices[0], mousePosition))
            {
                addingPolygonVertices.RemoveAt(addingPolygonVertices.Count - 1);
                polygons.Add(new Shapes.Polygon(addingPolygonVertices));
                Redraw();
                return true;
            }
            // else add a new point to the polygon
            else
                addingPolygonVertices.Add(mousePosition);
            Redraw();
            return false;
        }

        public bool AddCircle(Point mousePosition)
        {
            if (circle_anchored)
            {
                addingCircle.Radius = (int)Math.Sqrt(SquaredDistance(addingCircle.Center, mousePosition));
                circles.Add(addingCircle);
                addingCircle = null;
                circle_anchored = false;
                Redraw();
                return true;
            }
            addingCircle.Center = mousePosition;
            circle_anchored = true;
            Redraw();
            return false;
        }

        public void MouseMoveWhileAddingPolygon(Point mousePosition)
        {
            addingPolygonVertices[^1] = mousePosition;
            Redraw();
        }

        public void MouseMoveWhileAddingCircle(Point mousePosition)
        {
            if (circle_anchored)
                addingCircle.Radius = (int)Math.Sqrt(SquaredDistance(addingCircle.Center, mousePosition));
            else
                addingCircle.Center = mousePosition;
            Redraw();
        }

        /// <summary>
        /// Draw the canvas and its contents
        /// </summary>
        /// <param name="g">Graphics used to draw</param>
        public void Draw(Graphics g)
        {
            if (addingPolygonVertices != null)
                DrawAddingPolygon(g);
            if (addingCircle != null)
                DrawCircle(g, addingCircle);
            foreach(var polygon in polygons)
                DrawPolygon(g, polygon);
            foreach (var circle in circles)
                DrawCircle(g, circle);
        }

        private void DrawVertice(Graphics g, Point location, Color? color = null)
        {
            Brush b = new SolidBrush(color ?? Color.Green);
            g.FillEllipse(b, new Rectangle { X = location.X - 3, Y = location.Y - 3, Height = 6, Width = 6 });
        }

        private void DrawAddingPolygon(Graphics g)
        {
            Pen p = new Pen(Color.Black, 1);
            DrawVertice(g, addingPolygonVertices[0]);
            for (int i = 1; i < addingPolygonVertices.Count; ++i)
            {
                g.DrawLine(p, addingPolygonVertices[i - 1], addingPolygonVertices[i]);
                DrawVertice(g, addingPolygonVertices[i]);
            }
        }

        private void DrawPolygon(Graphics g, Shapes.Polygon polygon)
        {
            Pen p = new Pen(Color.Black, 1);
            List<Point> vertices = polygon.VertexList;
            for (int i = 0; i < vertices.Count; ++i)
            {
                g.DrawLine(p, vertices[i], vertices[(i + 1) % vertices.Count]);
                DrawVertice(g, vertices[i]);
            }
            DrawVertice(g, vertices[0]);
            DrawVertice(g, polygon.MiddlePoint, Color.Red);
        }

        private void DrawCircle(Graphics g, Shapes.Circle circle)
        {
            Pen p = new Pen(Color.Black, 1);
            Rectangle r = new(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, 2 * circle.Radius, 2 * circle.Radius);
            g.DrawEllipse(p, r);
            DrawVertice(g, circle.Center, Color.Red);
        }

        /// <summary>
        /// Redraw the canvas after a change in contents
        /// </summary>
        public void Redraw() => panel.Invalidate();

        public int IsCircleCenterClicked(Point mousePosition)
        {
            for (int i = 0; i < circles.Count; ++i)
                if (IsPointClicked(circles[i].Center, mousePosition))
                    return i;
            return -1;
        }

        public void MoveCircle(int circleID, Point mousePosition)
        {
            circles[circleID].Center = mousePosition;
            Redraw();
        }
    }
}
