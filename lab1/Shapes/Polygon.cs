using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace lab1.Shapes
{
    public class Polygon
    {
        public ObservableCollection<Point> VertexList { get; private set; }
        public Point Center { get; private set; }

        public Polygon(List<Point> vertices)
        {
            VertexList = new(vertices);
            VertexList.CollectionChanged += VertexList_CollectionChanged;
            VertexList_CollectionChanged(null, null);  // artifically call the method to draw the middle point on creation
        }

        /// <summary>
        /// A method to automatically update center point position when VertexList changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VertexList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Center = new Point(VertexList.Select(p => p.X).Aggregate((p1, p2) => p1 + p2) / VertexList.Count,
                VertexList.Select(p => p.Y).Aggregate((p1, p2) => p1 + p2) / VertexList.Count);
        }
    }
}
