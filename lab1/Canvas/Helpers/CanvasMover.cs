using System.Numerics;

namespace lab1.Canvas.Helpers
{
    public class CanvasMover : CanvasHelper
    {
        public CanvasMover(CanvasResources r) : base(r)
        {
        }

        public void MoveCircle(int circleID, Shapes.Point mousePosition) =>
            resources.Circles[circleID].Center.Move(mousePosition);

        public void ResizeCircle(int circleID, Shapes.Point mousePosition) =>
            resources.Circles[circleID].Radius = GraphicsHelpers.Distance(resources.Circles[circleID].Center, mousePosition);

        public void MovePolygonVertex(int polygonID, int vertexID, Shapes.Point mousePosition) =>
            resources.Polygons[polygonID].VertexList[vertexID].Move(mousePosition);

        public void MovePolygon(int polygonID, Shapes.Point mousePosition)
        {
            Shapes.Point center = resources.Polygons[polygonID].Center;
            int delta_x = mousePosition.X - center.X;
            int delta_y = mousePosition.Y - center.Y;
            for (int i = 0; i < resources.Polygons[polygonID].VertexList.Count; ++i)
            {
                // while moving the whole resources.polygon no resources.relations can change (except circle-edge resources.relations)
                Shapes.Point p = resources.Polygons[polygonID].VertexList[i];
                p.X += delta_x;
                p.Y += delta_y;
            }
        }

        public void MoveEdge(int polygonID, int lowerVertexID, Shapes.Point mousePosition)
        {
            Shapes.Point p1 = resources.Polygons[polygonID].VertexList[lowerVertexID], p2 = resources.Polygons[polygonID].VertexList[(lowerVertexID + 1) % resources.Polygons[polygonID].VertexList.Count];
            Shapes.Point center = GraphicsHelpers.SegmentCenter(p1, p2);
            Vector2 vec = new(mousePosition.X - center.X, mousePosition.Y - center.Y);

            (int x, int y) previous_p2 = (p2.X, p2.Y);
            p1.Move(vec);
            if ((p2.X, p2.Y) == previous_p2)
                p2.Move(vec);
        }

        public void MouseMoveWhileAddingPolygon(Shapes.Point mousePosition) =>
            resources.AddingPolygonVertices[^1] = mousePosition;

        public void MouseMoveWhileAddingCircle(Shapes.Point mousePosition)
        {
            if (resources.Circle_anchored)
                resources.AddingCircle.Radius = GraphicsHelpers.Distance(resources.AddingCircle.Center, mousePosition);
            else
                resources.AddingCircle.Center = mousePosition;
        }
    }
}
