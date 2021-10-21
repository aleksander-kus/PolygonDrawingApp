namespace lab1.Canvas.Helpers
{
    public class CanvasDeleter : CanvasHelper
    {
        public CanvasDeleter(CanvasResources r) : base(r)
        {
        }

        private void RemovePointRelations(Shapes.Point point)
        {
            if (point.R2 != null)
            {
                Relations.Relation r = point.R2;
                r.Remove();
                resources.Relations.Remove(r);
            }
            if (point.R1 != null)
            {
                Relations.Relation r = point.R1;
                r.Remove();
                resources.Relations.Remove(r);
            }
        }

        public void DeleteVertex(int polygonID, int vertexID)
        {
            if (resources.Polygons[polygonID].VertexList.Count > 3)
            {
                RemovePointRelations(resources.GetPointByID(polygonID, vertexID));
                resources.Polygons[polygonID].VertexList.RemoveAt(vertexID);
            }
        }

        public void DeletePolygon(int polygonID)
        {
            foreach(var point in resources.Polygons[polygonID].VertexList)
                RemovePointRelations(point);
            
            resources.Polygons.RemoveAt(polygonID);
        }

        public void DeleteCircle(int circleID)
        {
            resources.Circles.RemoveAt(circleID);
        }
    }
}
