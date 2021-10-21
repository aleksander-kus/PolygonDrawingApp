using System;
using System.Drawing;

namespace lab1.Canvas
{
    /// <summary>
    /// This class groups methods for canvas modification and delegates each call to the proper canvas helper classes
    /// </summary>
    public class Canvas
    {
        private readonly CanvasResources resources;

        private readonly Helpers.CanvasDrawer drawer;
        private readonly Helpers.CanvasDetector detector;
        private readonly Helpers.CanvasAdder adder;
        private readonly Helpers.CanvasMover mover;
        private readonly Helpers.CanvasDeleter deleter;
        private readonly Helpers.CanvasRelationManager relationManager;
        private readonly Helpers.CanvasSerializer serializer;

        public Canvas(BufferedPanel panel)
        {
            resources = new CanvasResources();
            drawer = new Helpers.CanvasDrawer(panel, resources);
            detector = new Helpers.CanvasDetector(resources);
            adder = new Helpers.CanvasAdder(resources);
            mover = new Helpers.CanvasMover(resources);
            deleter = new Helpers.CanvasDeleter(resources);
            relationManager = new Helpers.CanvasRelationManager(resources);
            serializer = new Helpers.CanvasSerializer(resources);
        }

        // DRAWING

        public void Draw(Graphics g) => drawer.Draw(g);

        // ADDING SHAPES

        /// <summary>
        /// Start adding a new resources.polygon to the canvas
        /// </summary>
        /// <param name="location">Starting location of resources.polygon</param>
        public void StartAddingPolygon(Shapes.Point mousePosition) => adder.StartAddingPolygon(mousePosition);

        /// <summary>
        /// Add a new point to the resources.polygon
        /// </summary>
        /// <param name="location">The location</param>
        /// <returns>If drawing of the new resources.polygon is finished, return true</returns>
        public bool AddPointToPolygon(Shapes.Point mousePosition) =>
            RedrawAndReturn(adder.AddPointToPolygon, mousePosition);
        public void SplitEdge(int polygonID, int lowerVertexID)
        {
            relationManager.RemoveRelation(polygonID, lowerVertexID);
            adder.SplitEdge(polygonID, lowerVertexID);
            drawer.Redraw();
        }
        public void StartAddingCircle(Shapes.Point mousePosition) =>
            adder.StartAddingCircle(mousePosition);
        public bool AddCircle(Shapes.Point mousePosition) =>
            RedrawAndReturn(adder.AddCircle, mousePosition);
        public void StopAddingShape() => ExecuteAndRedraw(adder.StopAddingShape);

        // DETECTING CLICKS

        public int IsCircleCenterClicked(Shapes.Point mousePosition) =>
            detector.IsCircleCenterClicked(mousePosition);
        public int IsCircleEdgeClicked(Shapes.Point mousePosition) =>
            detector.IsCircleEdgeClicked(mousePosition);
        public (int polygonID, int vertexID) IsPolygonVertexClicked(Shapes.Point mousePosition) =>
            detector.IsPolygonVertexClicked(mousePosition);
        public int IsPolygonCenterClicked(Shapes.Point mousePosition) =>
            detector.IsPolygonCenterClicked(mousePosition);
        public (int polygonID, int lowerVertexID) IsPolygonEdgeClicked(Shapes.Point mousePosition) =>
            detector.IsPolygonEdgeClicked(mousePosition);

        // MOVING SHAPES

        public void MoveCircle(int circleID, Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MoveCircle, circleID, mousePosition);

        public void ResizeCircle(int circleID, Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.ResizeCircle, circleID, mousePosition);

        public void MovePolygonVertex(int polygonID, int vertexID, Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MovePolygonVertex, polygonID, vertexID, mousePosition);

        public void MovePolygon(int polygonID, Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MovePolygon, polygonID, mousePosition);

        public void MoveEdge(int polygonID, int lowerVertexID, Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MoveEdge, polygonID, lowerVertexID, mousePosition);

        public void MouseMoveWhileAddingPolygon(Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MouseMoveWhileAddingPolygon, mousePosition);

        public void MouseMoveWhileAddingCircle(Shapes.Point mousePosition) =>
            ExecuteAndRedraw(mover.MouseMoveWhileAddingCircle, mousePosition);

        // DELETING SHAPES

        public void DeleteVertex(int polygonID, int vertexID) =>
            ExecuteAndRedraw(deleter.DeleteVertex, polygonID, vertexID);

        public void DeletePolygon(int polygonID) =>
            ExecuteAndRedraw(deleter.DeletePolygon, polygonID);

        public void DeleteCircle(int circleID) =>
            ExecuteAndRedraw(deleter.DeleteCircle, circleID);

        public bool Export(string path) => serializer.Export(path);

        public bool Import(string path) =>
            RedrawAndReturn(serializer.Import, path);

        public bool ImportFromEmbedded(string path) =>
            RedrawAndReturn(serializer.ImportFromEmbedded, path);

        // RELATIONS

        public void StartAddingEqualLengthRelation() => 
            ExecuteAndRedraw(relationManager.StartAddingEqualLengthRelation);
        public void StartAddingParallelRelation() =>
            ExecuteAndRedraw(relationManager.StartAddingParallelRelation);
        public void StartAddingTangentRelation() =>
            ExecuteAndRedraw(relationManager.StartAddingTangentRelation);
        public void StopAddingRelation() =>
            ExecuteAndRedraw(relationManager.StopAddingRelation);
        public int AddFixedLengthRelation(int polygonID, int lowerVertexID) =>
            RedrawAndReturn(relationManager.AddFixedLengthRelation, polygonID, lowerVertexID);
        public int AddEdgeToRelation(int polygonID, int lowerVertexID) => 
            RedrawAndReturn(relationManager.AddEdgeToRelation, polygonID, lowerVertexID);
        public int AddCircleToRelation(int circleID) =>
            RedrawAndReturn(relationManager.AddCircleToRelation, circleID);
        public bool RemoveRelation(int polygonID, int vertexID) => 
            RedrawAndReturn(relationManager.RemoveRelation, polygonID, vertexID);
        public bool AnchorCircle(int circleID) =>
            RedrawAndReturn(adder.AnchorCircle, circleID);
        public bool SetFixedRadius(int circleID) =>
            RedrawAndReturn(adder.SetFixedRadius, circleID);

        // HELPERS

        private TResult RedrawAndReturn<T, TResult>(Func<T, TResult> func, T arg)
        {
            TResult temp = func(arg);
            drawer.Redraw();
            return temp;
        }
        private TResult RedrawAndReturn<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            TResult temp = func(arg1, arg2);
            drawer.Redraw();
            return temp;
        }
        private void ExecuteAndRedraw(Action action)
        {
            action();
            drawer.Redraw();
        }
        private void ExecuteAndRedraw<T1>(Action<T1> action, T1 arg)
        {
            action(arg);
            drawer.Redraw();
        }

        private void ExecuteAndRedraw<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            action(arg1, arg2);
            drawer.Redraw();
        }

        private void ExecuteAndRedraw<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            action(arg1, arg2, arg3);
            drawer.Redraw();
        }
    }
}
