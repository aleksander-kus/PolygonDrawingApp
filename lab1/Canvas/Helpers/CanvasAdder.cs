namespace lab1.Canvas.Helpers
{
    /// <summary>
    /// A class containing methods to add points and shapes to the canvas
    /// </summary>
    public class CanvasAdder : CanvasHelper
    {
        public CanvasAdder(CanvasResources r) : base(r)
        {
        }


        public void StartAddingPolygon(Shapes.Point mousePosition)
        {
            resources.AddingPolygonVertices = new();
            resources.AddingPolygonVertices.Add(mousePosition);
        }

        public void StartAddingCircle(Shapes.Point mousePosition) => resources.AddingCircle = new Shapes.Circle { Center = mousePosition, Radius = 1 };

        public bool AddPointToPolygon(Shapes.Point mousePosition)
        {
            // if the first point was clicked, finish adding the new resources.polygon
            if (resources.AddingPolygonVertices.Count > 3 && GraphicsHelpers.IsPointClicked(resources.AddingPolygonVertices[0], mousePosition))
            {
                resources.AddingPolygonVertices.RemoveAt(resources.AddingPolygonVertices.Count - 1);
                resources.Polygons.Add(new Shapes.Polygon(resources.AddingPolygonVertices));
                resources.AddingPolygonVertices = null;
                return true;
            }
            // else add a new point to the resources.polygon
            else
                resources.AddingPolygonVertices.Add(mousePosition);
            return false;
        }

        public bool AddCircle(Shapes.Point mousePosition)
        {
            if (resources.Circle_anchored)
            {
                resources.AddingCircle.Radius = GraphicsHelpers.Distance(resources.AddingCircle.Center, mousePosition);
                resources.Circles.Add(resources.AddingCircle);
                resources.AddingCircle = null;
                resources.Circle_anchored = false;
                return true;
            }
            resources.AddingCircle.Center = mousePosition;
            resources.Circle_anchored = true;
            return false;
        }

        public void SplitEdge(int polygonID, int lowerVertexID)
        {
            Shapes.Point p1 = resources.GetPointByID(polygonID, lowerVertexID), p2 = resources.GetPointByID(polygonID, lowerVertexID + 1);
            Shapes.Point center = GraphicsHelpers.SegmentCenter(p1, p2);
            resources.Polygons[polygonID].VertexList.Insert(lowerVertexID + 1, center);
        }

        public bool AnchorCircle(int circleID)
        {
            Shapes.Circle circle = resources.Circles[circleID];
            if (circle.FixedRadius)
                return false;
            circle.Anchored = true;
            return true;
        }

        public bool SetFixedRadius(int circleID)
        {
            Shapes.Circle circle = resources.Circles[circleID];
            if (circle.Anchored)
                return false;
            circle.FixedRadius = true;
            return true;
        }

        public bool FinishAddingShape(Shapes.Point mousePosition)
        {
            if (resources.AddingPolygonVertices != null && resources.AddingPolygonVertices.Count > 3)
            {
                AddPointToPolygon(resources.AddingPolygonVertices[0]);
                return true;
            }
            if(resources.AddingCircle != null)
            {
                AddCircle(mousePosition);
                return true;
            }
            return false;
        }

        public void StopAddingShape()
        {
            resources.AddingPolygonVertices = null;
            resources.AddingCircle = null;
            resources.Circle_anchored = false;
            resources.AddingRelation = null;
        }
    }
}
