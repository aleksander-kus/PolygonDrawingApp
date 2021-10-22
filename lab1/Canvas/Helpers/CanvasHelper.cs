namespace lab1.Canvas.Helpers
{
    /// <summary>
    /// A base class for all canvas helper classes
    /// </summary>
    public abstract class CanvasHelper
    {
        protected readonly CanvasResources resources;

        public CanvasHelper(CanvasResources r)
        {
            resources = r;
        }
    }
}
