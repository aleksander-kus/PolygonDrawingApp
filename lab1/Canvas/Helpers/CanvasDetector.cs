using System;

namespace lab1.Canvas.Helpers
{
    /// <summary>
    /// A class containing methods to check if a certain object was clicked and return its ID
    /// </summary>
    public class CanvasDetector : CanvasHelper
    {
        public CanvasDetector(CanvasResources r): base(r)
        {
        }

        public int IsCircleCenterClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < resources.Circles.Count; ++i)
                if (GraphicsHelpers.IsPointClicked(resources.Circles[i].Center, mousePosition))
                    return i;
            return -1;
        }

        public int IsCircleEdgeClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < resources.Circles.Count; ++i)
                if (Math.Abs(GraphicsHelpers.Distance(resources.Circles[i].Center, mousePosition) - resources.Circles[i].Radius) < CanvasResources.ClickAccuracy)
                    return i;
            return -1;
        }

        public (int polygonID, int vertexID) IsPolygonVertexClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < resources.Polygons.Count; ++i)
                for (int j = 0; j < resources.Polygons[i].VertexList.Count; ++j)
                    if (GraphicsHelpers.IsPointClicked(resources.Polygons[i].VertexList[j], mousePosition))
                        return (i, j);
            return (-1, -1);
        }

        public int IsPolygonCenterClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < resources.Polygons.Count; ++i)
                if (GraphicsHelpers.IsPointClicked(resources.Polygons[i].Center, mousePosition))
                    return i;
            return -1;
        }

        public (int polygonID, int lowerVertexID) IsPolygonEdgeClicked(Shapes.Point mousePosition)
        {
            for (int i = 0; i < resources.Polygons.Count; ++i)
                for (int j = 0; j < resources.Polygons[i].VertexList.Count; ++j)
                    if (GraphicsHelpers.IsSegmentClicked(resources.Polygons[i].VertexList[j], resources.Polygons[i].VertexList[(j + 1) % resources.Polygons[i].VertexList.Count], mousePosition))
                        return (i, j);
            return (-1, -1);
        }

        public bool IsStartingPointClicked(Shapes.Point mousePosition) => GraphicsHelpers.IsPointClicked(resources.AddingPolygonVertices[0], mousePosition);
    }
}
