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

    }
}
