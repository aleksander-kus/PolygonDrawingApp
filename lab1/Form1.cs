using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        private ApplicationMode mode = ApplicationMode.Default;
        private ApplicationMode Mode
        {
            get => mode;
            set
            {
                if (mode != ApplicationMode.Default)
                    ResetToDefaultMode();  // stop adding shapes and relations to canvas if the mode was changed
                mode = value;
            }
        }
        private Canvas.Canvas canvas;
        private int changingShapeID = -1;
        private int changingVertexID = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new(canvasPanel);
            // load test scene form the embedded file
            canvas.ImportFromEmbedded("lab1.Helpers.TestScene.xml");
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.AddingPolygon;
            canvas.StartAddingPolygon(new Shapes.Point(MousePosition));
        }

        private void addCircleButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.AddingCircle;
            canvas.StartAddingCircle(new Shapes.Point(MousePosition));
        }

        private void equalLengthButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.AddingEqualLengthRelation;
            canvas.StartAddingEqualLengthRelation();
        }

        private void parallelRelationButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.AddingParallelRelation;
            canvas.StartAddingParallelRelation();
        }

        private void tangentRelationButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.AddingTangentRelation;
            canvas.StartAddingTangentRelation();
        }

        private void ResetToDefaultMode()
        {
            canvas.StopAddingShape();
            canvas.StopAddingRelation();
        }

        // change the mode to default on moveobjectbutton click only if we are not adding a cricle or polygon
        private void moveObjectButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.Default;
        }

        private void deletePolygonButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.DeletingPolygon;

        private void deleteCircleButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.DeletingCircle;

        private void splitEdgeButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.SplittinEdge;

        private void deleteVertexButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.DeletingVertex;

        private void fixedLengthButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.AddingFixedLengthRelation;

        private void removeRelationButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.RemovingRelation;

        private void anchorCircleButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.AddingAnchor;

        private void fixedRadiusButton_Click(object sender, EventArgs e) => Mode = ApplicationMode.AddingFixedRadius;

        private void canvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Shapes.Point mouseLocation = new(e.X, e.Y);
            int shapeID, vertexID;
            switch (Mode)
            {
                // if we are in a mode other than default, determine if an object was clicked and then act accordingly to mode
                case ApplicationMode.DeletingPolygon:
                    if ((shapeID = canvas.IsPolygonCenterClicked(mouseLocation)) != -1)
                    {
                        canvas.DeletePolygon(shapeID);
                        Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.DeletingCircle:
                    if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        canvas.DeleteCircle(shapeID);
                        Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.DeletingVertex:
                    if (((shapeID, vertexID) = canvas.IsPolygonVertexClicked(mouseLocation)) != (-1, -1))
                    {
                        canvas.DeleteVertex(shapeID, vertexID);
                        Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingFixedRadius:
                    if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        if (canvas.SetFixedRadius(shapeID) == false)
                            ErrorBox("You cannot add more relations to this circle");
                        else
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingAnchor:
                    if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        if (canvas.AnchorCircle(shapeID) == false)
                            ErrorBox("You cannot add more relations to this circle");
                        else
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.SplittinEdge:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        canvas.SplitEdge(shapeID, vertexID);
                        Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingFixedLengthRelation:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        if (canvas.AddFixedLengthRelation(shapeID, vertexID) == -1)
                            ErrorBox("You cannot add more than one relation to an edge");
                        else
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingEqualLengthRelation:
                case ApplicationMode.AddingParallelRelation:
                case ApplicationMode.AddingTangentRelation:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        int returnValue = canvas.AddEdgeToRelation(shapeID, vertexID);
                        if (returnValue == 1)
                            Mode = ApplicationMode.Default;
                        else if (returnValue == -1)
                            ErrorBox("You cannot add more than one relation to an edge");
                        else if (returnValue == -2)
                            ErrorBox("You cannot add relations between edges in different polygons");
                        else if (returnValue == -3)
                            ErrorBox("You have to add a circle to this relation");
                    }
                    else if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        int returnValue = canvas.AddCircleToRelation(shapeID);
                        if (returnValue == 1)
                            Mode = ApplicationMode.Default;
                        else if (returnValue == -1)
                            ErrorBox("You cannot add more relations to this circle");
                        else if (returnValue == -2)
                            ErrorBox("Please select the edge first");
                    }
                    break;
                case ApplicationMode.RemovingRelation:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        if (canvas.RemoveRelation(shapeID, vertexID))
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingPolygon:
                    if (canvas.AddPointToPolygon(mouseLocation))
                        Mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.AddingCircle:
                    if (canvas.AddCircle(mouseLocation))
                        Mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.Default:
                    // if something was clicked in default mode, signalize that we want to move it
                    if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        changingShapeID = shapeID;
                        Mode = ApplicationMode.MovingCircleCenter;
                    }
                    else if ((shapeID = canvas.IsCircleEdgeClicked(mouseLocation)) != -1)
                    {
                        changingShapeID = shapeID;
                        Mode = ApplicationMode.ResizingCircle;
                    }
                    else if (((shapeID, vertexID) = canvas.IsPolygonVertexClicked(mouseLocation)) != (-1, -1))
                    {
                        changingShapeID = shapeID;
                        changingVertexID = vertexID;
                        Mode = ApplicationMode.MovingVertex;
                    }
                    else if ((shapeID = canvas.IsPolygonCenterClicked(mouseLocation)) != -1)
                    {
                        changingShapeID = shapeID;
                        Mode = ApplicationMode.MovingPolygonCenter;
                    }
                    else if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        changingShapeID = shapeID;
                        changingVertexID = vertexID;
                        Mode = ApplicationMode.MovingEdge;
                    }
                    break;
                default:
                    break;
            }
        }

        private void canvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Shapes.Point mouseLocation = new(e.X, e.Y);
            switch (Mode)
            {
                case ApplicationMode.AddingPolygon:
                    canvas.MouseMoveWhileAddingPolygon(mouseLocation);
                    break;
                case ApplicationMode.AddingCircle:
                    canvas.MouseMoveWhileAddingCircle(mouseLocation);
                    break;
                case ApplicationMode.MovingCircleCenter:
                    canvas.MoveCircle(changingShapeID, mouseLocation);
                    break;
                case ApplicationMode.ResizingCircle:
                    canvas.ResizeCircle(changingShapeID, mouseLocation);
                    break;
                case ApplicationMode.MovingVertex:
                    canvas.MovePolygonVertex(changingShapeID, changingVertexID, mouseLocation);
                    break;
                case ApplicationMode.MovingPolygonCenter:
                    canvas.MovePolygon(changingShapeID, mouseLocation);
                    break;
                case ApplicationMode.MovingEdge:
                    canvas.MoveEdge(changingShapeID, changingVertexID, mouseLocation);
                    break;
                case ApplicationMode.Default:
                default:
                    break;
            }
        }

        private void canvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                // stop moving the object if we were in a moving mode
                case ApplicationMode.MovingPolygonCenter:
                case ApplicationMode.MovingVertex:
                case ApplicationMode.MovingEdge:
                case ApplicationMode.MovingCircleCenter:
                case ApplicationMode.ResizingCircle:
                    changingShapeID = -1;
                    changingVertexID = -1;
                    Mode = ApplicationMode.Default;
                    break;
                default:
                    break;
            }
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e) => canvas.Draw(e.Graphics);

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new();
            sd.Filter = "Xml Files | *.xml";
            sd.DefaultExt = "xml";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (canvas.Export(sd.FileName) != true)
                    ErrorBox("There was an error writing to file");
            }
        }

        private void loadFromFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new();
            od.Filter = "Xml Files | *.xml";
            od.DefaultExt = "xml";
            if (od.ShowDialog() == DialogResult.OK)
            {
                if (canvas.Import(od.FileName) != true)
                    ErrorBox("There was an error reading from file");
            }
        }
        private void ErrorBox(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void resetCanvasButton_Click(object sender, EventArgs e)
        {
            Mode = ApplicationMode.Default;
            canvas = new Canvas.Canvas(canvasPanel);
            canvasPanel.Invalidate();
        }
    }
}
