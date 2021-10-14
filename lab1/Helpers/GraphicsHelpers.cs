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
    }
}
