using System.Collections.Generic;

namespace lab1.Canvas
{
    /// <summary>
    /// A class shared between all canvas classes containing all object that are on the canvas
    /// </summary>
    public class CanvasResources
    {
        public static int ClickAccuracy => 10;

        // storing elements on the canvas
        public List<Shapes.Polygon> Polygons { get; set; } = new();
        public List<Shapes.Circle> Circles { get; set; } = new();

        // used when adding a new polygon
        public List<Shapes.Point> AddingPolygonVertices { get; set; }

        // used when adding a new circle
        public Shapes.Circle AddingCircle { get; set; }
        public bool Circle_anchored { get; set; } = false;

        // used with relations
        public List<Relations.Relation> Relations { get; set; } = new();
        public Relations.Relation AddingRelation { get; set; }
        public int AddingRelationPolygonID { get; set; } = 0;

        public CanvasResources()
        {

        }

        public Shapes.Point GetPointByID(int polygonID, int vertexID) => Polygons[polygonID].VertexList[vertexID % Polygons[polygonID].VertexList.Count];

        public Shapes.Edge GetEdgeByLowerPointID(int polygonID, int lowerVertexID)
        {
            Shapes.Point p1 = GetPointByID(polygonID, lowerVertexID), p2 = GetPointByID(polygonID, lowerVertexID + 1);
            return new Shapes.Edge(p1, p2);
        }

    }
}
