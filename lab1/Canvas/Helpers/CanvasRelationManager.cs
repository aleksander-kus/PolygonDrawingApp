namespace lab1.Canvas.Helpers
{
    /// <summary>
    /// A class containing methods for adding and deleting relations
    /// </summary>
    public class CanvasRelationManager : CanvasHelper
    {
        public CanvasRelationManager(CanvasResources r) : base(r)
        {
        }

        public bool RemoveRelation(int shapeID, int vertexID)
        {
            Shapes.Point p1 = resources.GetPointByID(shapeID, vertexID), p2 = resources.GetPointByID(shapeID, vertexID + 1);
            Relations.Relation r = null;
            if (p1.R1 != null && (p1.R1 == p2.R1 || p1.R1 == p2.R2))
                r = p1.R1;
            else if (p1.R2 != null && (p1.R2 == p2.R1 || p1.R2 == p2.R2))
                r = p1.R2;
            if (r == null)
                return false;  // no relation on this edge
            r.Remove();
            resources.Relations.Remove(r);
            return true;
        }

        public bool RemoveCircleRelations(int circleID)
        {
            Shapes.Circle circle = resources.Circles[circleID];
            circle.Anchored = false;
            circle.FixedRadius = false;
            Relations.Relation r = circle.R1;
            if (r != null)
            {
                r.Remove();
                resources.Relations.Remove(r);
            }
            return true;
        }

        public void StartAddingEqualLengthRelation() =>
            resources.AddingRelation = new Relations.EqualLengthRelation();

        public void StartAddingParallelRelation() =>
            resources.AddingRelation = new Relations.ParallelRelation();

        public void StartAddingTangentRelation() =>
            resources.AddingRelation = new Relations.TangentRelation();

        public int AddEdgeToRelation(int polygonID, int lowerVertexID)
        {
            var newEdge = resources.GetEdgeByLowerPointID(polygonID, lowerVertexID);
            foreach (var relation in resources.Relations)
                if (relation.Edge1.p1 == newEdge.p1 && relation.Edge1.p2 == newEdge.p2 || relation.Edge2 != null && relation.Edge2.p1 == newEdge.p1 && relation.Edge2.p2 == newEdge.p2)
                    return -1;
            if (resources.AddingRelation.Edge1 == null)
            {
                resources.AddingRelation.Edge1 = newEdge;
                resources.AddingRelationPolygonID = polygonID;
                return 0;
            }
            else
            {
                if (resources.AddingRelation.Edge1.p1 == newEdge.p1 && resources.AddingRelation.Edge1.p2 == newEdge.p2)
                    return -1;
                if (resources.AddingRelationPolygonID != polygonID)
                    return -2;
                if (resources.AddingRelation is Relations.TangentRelation)
                    return -3;
                resources.AddingRelation.Edge2 = newEdge;
                resources.AddingRelation.Impose();
                resources.Relations.Add(resources.AddingRelation);
                resources.AddingRelation = null;
                return 1;
            }
        }

        public int AddCircleToRelation(int circleID)
        {
            if (resources.AddingRelation.Edge1 == null)
                return -2;
            if (resources.Circles[circleID].R1 != null)
                return -1;
            resources.AddingRelation.Circle = resources.Circles[circleID];
            resources.AddingRelation.Impose();
            resources.Relations.Add(resources.AddingRelation);
            resources.AddingRelation = null;
            return 1;
        }
        public int AddFixedLengthRelation(int polygonID, int lowerVertexID)
        {
            Shapes.Edge newEdge = resources.GetEdgeByLowerPointID(polygonID, lowerVertexID);
            foreach (var r in resources.Relations)
                if (r.Edge1.p1 == newEdge.p1 && r.Edge1.p2 == newEdge.p2 || r.Edge2 != null && r.Edge2.p1 == newEdge.p1 && r.Edge2.p2 == newEdge.p2)
                    return -1;
            if (newEdge.p1.R2 != null || newEdge.p2.R2 != null)
                return 0;
            Relations.FixedLengthRelation relation = new() { Edge1 = newEdge };
            relation.Impose();

            resources.Relations.Add(relation);
            return 1;
        }

        public void StopAddingRelation() => resources.AddingRelation = null;
    }
}
