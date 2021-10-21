﻿using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        private ApplicationMode mode = ApplicationMode.Default;
        private ApplicationMode Mode { get => mode; 
            set
            {
                if(mode != ApplicationMode.Default)
                    ResetToDefaultMode();
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
                            MessageBox.Show("You cannot add more relations to this circle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingAnchor:
                    if ((shapeID = canvas.IsCircleCenterClicked(mouseLocation)) != -1)
                    {
                        if (canvas.AnchorCircle(shapeID) == false)
                            MessageBox.Show("You cannot add more relations to this circle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("You cannot add more than one relation to an edge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            Mode = ApplicationMode.Default;
                    }
                    break;
                case ApplicationMode.AddingEqualLengthRelation:
                case ApplicationMode.AddingParallelRelation:
                    if (((shapeID, vertexID) = canvas.IsPolygonEdgeClicked(mouseLocation)) != (-1, -1))
                    {
                        int returnValue = canvas.AddEdgeToRelation(shapeID, vertexID);
                        if (returnValue == 1)
                            Mode = ApplicationMode.Default;
                        else if (returnValue == -1)
                            MessageBox.Show("You cannot add more than one relation to an edge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (returnValue == -2)
                            MessageBox.Show("You cannot add relations between edges in different polygons", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (canvas.Import(od.FileName) != true)
                    MessageBox.Show("There was an error reading from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
