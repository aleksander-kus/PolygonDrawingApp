using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        private ApplicationMode mode = ApplicationMode.Default;
        private Canvas canvas;
        private int changingShapeID = -1;
        private int changingVertexID = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new(canvasPanel);
            // load the test scene form the embedded file
            canvas.Import(Helpers.XMLHelper.ReadFromXMLEmbedded<Helpers.SerializedCanvas>("lab1.Helpers.TestScene.xml"));
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            if (mode != ApplicationMode.Default)
                return;
            mode = ApplicationMode.AddingPolygon;
            canvas.StartAddingPolygon(MousePosition);
        }

        private void addCircleButton_Click(object sender, EventArgs e)
        {
            if (mode != ApplicationMode.Default)
                return;
            mode = ApplicationMode.AddingCircle;
            canvas.StartAddingCircle(MousePosition);
        }

        // change the mode to default on moveobjectbutton click only if we are not adding a cricle or polygon
        private void moveObjectButton_Click(object sender, EventArgs e) => 
            mode = (mode != ApplicationMode.AddingPolygon && mode != ApplicationMode.AddingCircle) ? ApplicationMode.Default : mode;

        private void deletePolygonButton_Click(object sender, EventArgs e) => mode = ApplicationMode.DeletingPolygon;

        private void deleteCircleButton_Click(object sender, EventArgs e) => mode = ApplicationMode.DeletingCircle;

        private void splitEdgeButton_Click(object sender, EventArgs e) => mode = ApplicationMode.SplittinEdge;

        private void deleteVertexButton_Click(object sender, EventArgs e) => mode = ApplicationMode.DeletingVertex;

        private void canvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int shapeID, vertexID;
            switch (mode)
            {
                case ApplicationMode.DeletingPolygon:
                    if ((shapeID = canvas.IsPolygonCenterClicked(e.Location)) != -1)
                    {
                        canvas.DeletePolygon(shapeID);
                        mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.DeletingCircle:
                    if ((shapeID = canvas.IsCircleCenterClicked(e.Location)) != -1)
                    {
                        canvas.DeleteCircle(shapeID);
                        mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.DeletingVertex:
                    if (((shapeID, vertexID) = canvas.IsPolygonVertexClicked(e.Location)) != (-1, -1))
                    {
                        canvas.DeleteVertex(shapeID, vertexID);
                        mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.SplittinEdge:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(e.Location)) != (-1, -1))
                    {
                        canvas.SplitEdge(shapeID, vertexID);
                        mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingPolygon:
                    if (canvas.AddPointToPolygon(e.Location))
                        mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.AddingCircle:
                    if (canvas.AddCircle(e.Location))
                        mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.Default:
                    if ((shapeID = canvas.IsCircleCenterClicked(e.Location)) != -1)
                    {
                        changingShapeID = shapeID;
                        mode = ApplicationMode.MovingCircleCenter;
                    }
                    else if ((shapeID = canvas.IsCircleEdgeClicked(e.Location)) != -1)
                    {
                        changingShapeID = shapeID;
                        mode = ApplicationMode.ResizingCircle;
                    }
                    else if (((shapeID, vertexID) = canvas.IsPolygonVertexClicked(e.Location)) != (-1, -1))
                    {
                        changingShapeID = shapeID;
                        changingVertexID = vertexID;
                        mode = ApplicationMode.MovingVertex;
                    }
                    else if ((shapeID = canvas.IsPolygonCenterClicked(e.Location)) != -1)
                    {
                        changingShapeID = shapeID;
                        mode = ApplicationMode.MovingPolygonCenter;
                    }
                    else if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(e.Location)) != (-1, -1))
                    {
                        changingShapeID = shapeID;
                        changingVertexID = vertexID;
                        mode = ApplicationMode.MovingEdge;
                    }
                    break;
                default:
                    break;
            }
        }

        private void canvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case ApplicationMode.AddingPolygon:
                    canvas.MouseMoveWhileAddingPolygon(e.Location);
                    break;
                case ApplicationMode.AddingCircle:
                    canvas.MouseMoveWhileAddingCircle(e.Location);
                    break;
                case ApplicationMode.MovingCircleCenter:
                    canvas.MoveCircle(changingShapeID, e.Location);
                    break;
                case ApplicationMode.ResizingCircle:
                    canvas.ResizeCircle(changingShapeID, e.Location);
                    break;
                case ApplicationMode.MovingVertex:
                    canvas.MovePolygonVertex(changingShapeID, changingVertexID, e.Location);
                    break;
                case ApplicationMode.MovingPolygonCenter:
                    canvas.MovePolygon(changingShapeID, e.Location);
                    break;
                case ApplicationMode.MovingEdge:
                    canvas.MoveEdge(changingShapeID, changingVertexID, e.Location);
                    break;
                case ApplicationMode.Default:
                default:
                    break;
            }
        }

        private void canvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case ApplicationMode.MovingPolygonCenter:
                case ApplicationMode.MovingVertex:
                case ApplicationMode.MovingEdge:
                case ApplicationMode.MovingCircleCenter:
                case ApplicationMode.ResizingCircle:
                    changingShapeID = -1;
                    changingVertexID = -1;
                    mode = ApplicationMode.Default;
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
                var sc = canvas.Export();
                if (Helpers.XMLHelper.WriteToXML(sd.FileName, sc) != true)
                    MessageBox.Show("There was an error writing to file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadFromFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new();
            od.Filter = "Xml Files | *.xml";
            od.DefaultExt = "xml";
            if (od.ShowDialog() == DialogResult.OK)
            {
                var sc = Helpers.XMLHelper.ReadFromXML<Helpers.SerializedCanvas>(od.FileName);
                if (sc == null)
                    MessageBox.Show("There was an error reading from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    canvas.Import(sc);
            }
        }
    }
}
