using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab1
{
    public class Canvas
    {
        private readonly BufferedPanel panel;
        private const int ClickAccuracy = 10;

        // storing elements on the canvas
        private List<Shapes.Polygon> polygons = new();
        private List<Shapes.Circle> circles = new();

        // used when adding a new polygon
        private List<Shapes.Point> addingPolygonVertices;

        // used when adding a new circle
        private Shapes.Circle addingCircle;
        private bool circle_anchored = false;

        // used with relations
        private List<Relations.Relation> relations = new();

        public Canvas(BufferedPanel panel)
        {
            this.panel = panel;
        }

        /// <summary>
        /// Start adding a new polygon to the canvas
        /// </summary>
        /// <param name="location">Starting location of polygon</param>
        public void StartAddingPolygon(Shapes.Point mousePosition)
        {
            addingPolygonVertices = new();
            addingPolygonVertices.Add(mousePosition);
        }

        /// <summary>
        /// Add a new point to the polygon
        /// </summary>
        /// <param name="location">The location</param>
        /// <returns>If drawing of the new polygon is finished, return true</returns>
        public bool AddPointToPolygon(Shapes.Point mousePosition)
        {
            // if the first point was clicked, finish adding the new polygon
            if (addingPolygonVertices.Count > 3 && GraphicsHelpers.IsPointClicked(addingPolygonVertices[0], mousePosition))
            {
                addingPolygonVertices.RemoveAt(addingPolygonVertices.Count - 1);
                polygons.Add(new Shapes.Polygon(addingPolygonVertices));
                addingPolygonVertices = null;
                Redraw();
                return true;
            }
            // else add a new point to the polygon
            else
                addingPolygonVertices.Add(mousePosition);
            Redraw();
            return false;
        }

        public void StartAddingCircle(Shapes.Point mousePosition) => addingCircle = new Shapes.Circle { Center = mousePosition, Radius = 1 };

        public void StopAddingShape()
        {
            addingPolygonVertices = null;
            addingCircle = null;
            circle_anchored = false;
            Redraw();
        }

        public bool AddCircle(Shapes.Point mousePosition)
        {
            if (circle_anchored)
            {
                addingCircle.Radius = GraphicsHelpers.Distance(addingCircle.Center, mousePosition);
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

        public void MouseMoveWhileAddingPolygon(Shapes.Point mousePosition)
        {
            addingPolygonVertices[^1] = mousePosition;
            Redraw();
        }

        public void MouseMoveWhileAddingCircle(Shapes.Point mousePosition)
        {
            if (circle_anchored)
                addingCircle.Radius = GraphicsHelpers.Distance(addingCircle.Center, mousePosition);
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
            foreach (var polygon in polygons)
                DrawPolygon(g, polygon);
            foreach (var circle in circles)
                DrawCircle(g, circle);
            DrawEdgesWithRelations(g);
        }

        private void DrawVertice(Graphics g, Shapes.Point location, Color? color = null)
        {
            Brush b = new SolidBrush(color ?? Color.Green);
            Pen p = new Pen(Color.Black, 1);
            Rectangle r = new Rectangle { X = location.X - 3, Y = location.Y - 3, Height = 6, Width = 6 };
            g.FillEllipse(b, r);
            g.DrawEllipse(p, r);
        }

        private void DrawAddingPolygon(Graphics g)
        {
            Pen p = new Pen(Color.Black, 1);
            DrawVertice(g, addingPolygonVertices[0]);
            for (int i = 1; i < addingPolygonVertices.Count; ++i)
            {
                g.DrawLine(p, addingPolygonVertices[i - 1].ToStruct(), addingPolygonVertices[i].ToStruct());
                DrawVertice(g, addingPolygonVertices[i]);
            }
        }

        private void DrawPolygon(Graphics g, Shapes.Polygon polygon)
        {
            List<Shapes.Point> vertices = polygon.VertexList;
            for (int i = 0; i < vertices.Count; ++i)
            {
                g.DrawLineBresenham(Color.Black, vertices[i], vertices[(i + 1) % vertices.Count]);
                Shapes.Point center = GraphicsHelpers.SegmentCenter(vertices[i], vertices[(i + 1) % vertices.Count]);
                DrawVertice(g, center, Color.Yellow);
                DrawVertice(g, vertices[i]);
            }
            DrawVertice(g, vertices[0]);
            polygon.RecalculateMiddlePoint();
            DrawVertice(g, polygon.Center, Color.Red);
        }

        private void DrawCircle(Graphics g, Shapes.Circle circle)
        {
            Pen p = new Pen(Color.Black, 1);
            Rectangle r = new(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, 2 * circle.Radius, 2 * circle.Radius);
            g.DrawEllipse(p, r);
            DrawVertice(g, circle.Center, Color.Red);
        }

        private void DrawEdgesWithRelations(Graphics g)
        {
            foreach (var relation in relations)
            {
                g.DrawLineBresenham(relation.Color, relation.Edge1.p1, relation.Edge1.p2);
            }
        }

        /// <summary>
        /// Redraw the canvas after a change in contents
        /// </summary>
        public void Redraw() => panel.Invalidate();

        public int IsCircleCenterClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < circles.Count; ++i)
                if (GraphicsHelpers.IsPointClicked(circles[i].Center, mousePosition))
                    return i;
            return -1;
        }

        public void MoveCircle(int circleID, Shapes.Point mousePosition)
        {
            circles[circleID].Center.Move(mousePosition);
            Redraw();
        }

        public int IsCircleEdgeClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < circles.Count; ++i)
                if (Math.Abs(GraphicsHelpers.Distance(circles[i].Center, mousePosition) - circles[i].Radius) < ClickAccuracy)
                    return i;
            return -1;
        }

        public void ResizeCircle(int circleID, Shapes.Point mousePosition)
        {
            circles[circleID].Radius = GraphicsHelpers.Distance(circles[circleID].Center, mousePosition);
            Redraw();
        }

        public (int polygonID, int vertexID) IsPolygonVertexClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < polygons.Count; ++i)
                for (int j = 0; j < polygons[i].VertexList.Count; ++j)
                    if (GraphicsHelpers.IsPointClicked(polygons[i].VertexList[j], mousePosition))
                        return (i, j);
            return (-1, -1);
        }

        public void MovePolygonVertex(int polygonID, int vertexID, Shapes.Point mousePosition)
        {
            polygons[polygonID].VertexList[vertexID].Move(mousePosition);
            Redraw();
        }

        public int IsPolygonCenterClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < polygons.Count; ++i)
                if (GraphicsHelpers.IsPointClicked(polygons[i].Center, mousePosition))
                    return i;
            return -1;
        }

        public void MovePolygon(int polygonID, Point mousePosition)
        {
            Point center = polygons[polygonID].Center;
            int delta_x = mousePosition.X - center.X;
            int delta_y = mousePosition.Y - center.Y;
            for (int i = 0; i < polygons[polygonID].VertexList.Count; ++i)
            {
                Point p = polygons[polygonID].VertexList[i];
                polygons[polygonID].VertexList[i] = new Point(p.X + delta_x, p.Y + delta_y);
            }
            Redraw();
        }

        public (int polygonID, int lowerVertexID) IsPolygonEdgeClicked(Point mousePosition)
        {
            for (int i = 0; i < polygons.Count; ++i)
                for (int j = 0; j < polygons[i].VertexList.Count; ++j)
                    if (GraphicsHelpers.IsSegmentClicked(polygons[i].VertexList[j], polygons[i].VertexList[(j + 1) % polygons[i].VertexList.Count], mousePosition))
                    return (i, j);
            return (-1, -1);
        }

        public void MoveEdge(int polygonID, int lowerVertexID, Point mousePosition)
        {
            Point center = GraphicsHelpers.SegmentCenter(polygons[polygonID].VertexList[lowerVertexID], polygons[polygonID].VertexList[(lowerVertexID + 1) % polygons[polygonID].VertexList.Count]);
            int delta_x = mousePosition.X - center.X;
            int delta_y = mousePosition.Y - center.Y;
            for (int i = lowerVertexID; i <= lowerVertexID + 1; ++i)
            {
                Point p = polygons[polygonID].VertexList[i % polygons[polygonID].VertexList.Count];
                polygons[polygonID].VertexList[i % polygons[polygonID].VertexList.Count] = new Point(p.X + delta_x, p.Y + delta_y);
            }
            Redraw();
        }

        public void DeleteVertex(int polygonID, int vertexID)
        {
            if (polygons[polygonID].VertexList.Count > 3)
                polygons[polygonID].VertexList.RemoveAt(vertexID);
            Redraw();
        }

        public void SplitEdge(int polygonID, int lowerVertexID)
        {
            Shapes.Point center = GraphicsHelpers.SegmentCenter(polygons[polygonID].VertexList[lowerVertexID], polygons[polygonID].VertexList[(lowerVertexID + 1) % polygons[polygonID].VertexList.Count]);
            polygons[polygonID].VertexList.Insert(lowerVertexID + 1, center);
            Redraw();
        }

        public void DeletePolygon(int polygonID)
        {
            polygons.RemoveAt(polygonID);
            Redraw();
        }

        public void DeleteCircle(int circleID)
        {
            circles.RemoveAt(circleID);
            Redraw();
        }

        public Helpers.SerializedCanvas Export() => new() { PolygonList = new List<Shapes.Polygon>(polygons), CircleList = new List<Shapes.Circle>(circles) };

        public void Import(Helpers.SerializedCanvas sc)
        {
            polygons = new(sc.PolygonList);
            circles = new(sc.CircleList);
            Redraw();
        }

        public bool AddFixedLengthRelation(int polygonID, int lowerVertexID)
        {
            Shapes.Point p1 = polygons[polygonID].VertexList[lowerVertexID], p2 = polygons[polygonID].VertexList[(lowerVertexID + 1) % polygons[polygonID].VertexList.Count];
            if (p1.R2 != null && p2.R2 != null)
                return false;
            Relations.FixedLengthRelation relation = new();
            relation.Impose(new Shapes.Edge(p1, p2));
            if (p1.R1 == null) p1.R1 = relation;
            else if (p1.R2 == null) p1.R2 = relation;
            if (p2.R1 == null) p2.R1 = relation;
            else if (p2.R2 == null) p2.R2 = relation;
            relations.Add(relation);
            Redraw();
            return true;
        }
    }
}
