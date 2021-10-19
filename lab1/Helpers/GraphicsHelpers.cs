using System;
using System.Drawing;

namespace lab1
{
    public static class GraphicsHelpers
    {
        /// <summary>
        /// Calculates distance between two points without the final root to avoid overhead
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>The squared distance between two points</returns>
        public static int SquaredDistance(Point p1, Point p2) => (p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y);

        /// <summary>
        /// Returns if a point was clicked with 10 pixel toleration
        /// </summary>
        /// <param name="point">Questioned point</param>
        /// <param name="mousePosition">Mouse click location</param>
        /// <param name="epsilon">Precision in pixels</param>
        /// <returns>If the point was clicked</returns>
        public static bool IsPointClicked(Point point, Point mousePosition, int epsilon = 10) => SquaredDistance(point, mousePosition) <= epsilon * epsilon;

        /// <summary>
        /// Returns if the center of a segment between two points was clicked with 10 pixel toleration
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="mousePosition">Mouse click location</param>
        /// <param name="epsilon">Precision in pixels</param>
        /// <returns></returns>
        public static bool IsSegmentClicked(Point p1, Point p2, Point mousePosition, int epsilon = 10) => IsPointClicked(SegmentCenter(p1, p2), mousePosition, epsilon);

        public static Point SegmentCenter(Point p1, Point p2) => new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        /// <summary>
        /// Calculates distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Distance between two points rounded down</returns>
        public static int Distance(Point p1, Point p2) => (int)Math.Sqrt(SquaredDistance(p1, p2));

        public static void PutPixel(this Graphics g, Brush b, int x, int y) => g.FillRectangle(b, x, y, 1, 1);

        /// <summary>
        /// Draws a between specified points with Bresenham's Algorithm
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="p1">Starting point</param>
        /// <param name="p2">Ending point</param>
        public static void DrawLineBresenham(this Graphics g, Pen pen, Point p1, Point p2)
        {
            Brush b = new SolidBrush(pen.Color);
            int dx = Math.Abs(p2.X - p1.X), dy = Math.Abs(p2.Y - p1.Y);
            int x_increment = (p1.X < p2.X) ? 1 : p1.X == p2.X ? 0 : -1;
            int y_increment = (p1.Y < p2.Y) ? 1 : p1.Y == p2.Y ? 0 : -1;
            // first pixel
            int x = p1.X, y = p1.Y;
            g.PutPixel(b, x, y);
            // go along X-axis
            if (dx > dy)
            {
                int d = 2 * dy - dx;
                int across_increment = (dy - dx) * 2;
                int same_line_increment = 2 * dy;
                // pętla po kolejnych x
                while (x != p2.X)
                {
                    if (d < 0)  // remain in the same line
                    {
                        d += same_line_increment;
                        x += x_increment;
                    }
                    else  // go across
                    {
                        d += across_increment;
                        x += x_increment;
                        y += y_increment;
                    }
                    g.PutPixel(b, x, y);
                }
            }
            // go along Y-axis
            else
            {
                int d = 2 * dx  - dy;
                int across_increment = (dx - dy) * 2;
                int same_line_increment = 2 * dx;
                while (y != p2.Y)
                {
                    if (d < 0)  // remain in the same line
                    {
                        d += same_line_increment;
                        y += y_increment;
                    }
                    else  // go across
                    {
                        d += across_increment;
                        x += x_increment;
                        y += y_increment;
                    }
                    g.PutPixel(b, x, y);
                }
            }
        }
    }
}