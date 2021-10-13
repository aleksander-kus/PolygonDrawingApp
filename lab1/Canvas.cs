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

    }
}
