namespace lab1
{
    /// <summary>
    /// Application mode used by the UI when determining what a click on the canvas should mean
    /// </summary>
    public enum ApplicationMode
    {
        Default = 0,
        AddingPolygon,
        AddingCircle,
        MovingPolygonCenter,
        MovingVertex,
        MovingEdge,
        MovingCircleCenter,
        ResizingCircle,
        DeletingPolygon,
        DeletingCircle,
        DeletingVertex,
        SplittinEdge,
        AddingFixedLengthRelation,
        AddingEqualLengthRelation,
        AddingParallelRelation,
        AddingFixedRadius,
        AddingAnchor,
        AddingTangentRelation,
        RemovingRelation
    }
}
