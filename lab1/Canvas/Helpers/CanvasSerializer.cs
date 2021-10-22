using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab1.Canvas.Helpers
{
    public class CanvasSerializer : CanvasHelper
    {
        [XmlRoot("Canvas", Namespace = "http://example.org/ak/canvas")]
        [XmlInclude(typeof(Shapes.Polygon))]
        [XmlInclude(typeof(Shapes.Circle))]
        public class SerializedCanvas
        {
            [XmlArray("PolygonList")]
            public List<Shapes.Polygon> PolygonList { get; set; } = new();

            [XmlArray("CircleList")]
            public List<Shapes.Circle> CircleList { get; set; } = new();

            [XmlArray("RelationList")]
            [XmlArrayItem("EqualLengthRelation", typeof(Relations.EqualLengthRelation))]
            [XmlArrayItem("ParallelRelation", typeof(Relations.ParallelRelation))]
            [XmlArrayItem("FixedLengthRelation", typeof(Relations.FixedLengthRelation))]
            [XmlArrayItem("TangentRelation", typeof(Relations.TangentRelation))]
            public List<Relations.Relation> RelationList { get; set; } = new();
        }

        public CanvasSerializer(CanvasResources r) : base(r)
        {
        }

        public bool Export(string path)
        {
            SerializedCanvas sc = new() { PolygonList = new List<Shapes.Polygon>(resources.Polygons), CircleList = new List<Shapes.Circle>(resources.Circles),
            RelationList = new List<Relations.Relation>(resources.Relations)};

            return lab1.Helpers.XMLHelper.WriteToXML(path, sc);
        }



        public bool Import(string path)
        {
            SerializedCanvas sc = lab1.Helpers.XMLHelper.ReadFromXML<SerializedCanvas>(path);
            if (sc == null)
                return false;
            ImportFromSerializedCanvas(sc);
            return true;
        }

        public bool ImportFromEmbedded(string path)
        {
            SerializedCanvas sc = lab1.Helpers.XMLHelper.ReadFromXMLEmbedded<SerializedCanvas>(path);
            if (sc == null)
                return false;
            ImportFromSerializedCanvas(sc);
            return true;
        }

        private Shapes.Point FindVertex(Shapes.Point p)
        {
            foreach (var poly in resources.Polygons)
                for (int i = 0; i < poly.VertexList.Count; ++i)
                    if (p.Equals(poly.VertexList[i]))
                        return poly.VertexList[i];
            return null;
        }

        private Shapes.Circle FindCircle(Shapes.Circle c)
        {
            foreach (var circle in resources.Circles)
                if (c.Equals(circle))
                    return circle;
            return null;
        }

        private void ImportFromSerializedCanvas(SerializedCanvas sc)
        {
            resources.Polygons = new(sc.PolygonList);
            resources.Circles = new(sc.CircleList);
            resources.Relations = new(sc.RelationList);
            foreach (var relation in resources.Relations)
            {
                Shapes.Edge e = relation.Edge1;
                Shapes.Edge newEdge = new(FindVertex(e.p1), FindVertex(e.p2));
                relation.Edge1 = newEdge;
                if (relation.Edge2 != null)
                {
                    e = relation.Edge2;
                    newEdge = new(FindVertex(e.p1), FindVertex(e.p2));
                    relation.Edge2 = newEdge;
                }
                if(relation.Circle != null)
                {
                    Shapes.Circle c = relation.Circle;
                    relation.Circle = FindCircle(c);
                }
                relation.Impose();
            }
        }
    }
}
