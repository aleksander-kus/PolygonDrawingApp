using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void canvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int shapeID, vertexID;
            switch (mode)
            {
                case ApplicationMode.AddingPolygon:
                    if(canvas.AddPointToPolygon(e.Location))
                        mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.AddingCircle:
                    if(canvas.AddCircle(e.Location))
                        mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.Default:
                    if((shapeID = canvas.IsCircleCenterClicked(e.Location)) != -1)
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
                case ApplicationMode.Default:
                default:
                    break;
            }
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e) => canvas.Draw(e.Graphics);

        private void canvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case ApplicationMode.MovingPolygonCenter:
                case ApplicationMode.MovingVertex:
                case ApplicationMode.MovingCircleCenter:
                case ApplicationMode.ResizingCircle:
                    changingShapeID = -1;
                    changingVertexID = -1;
                    mode = ApplicationMode.Default;
                    break;
                case ApplicationMode.Default:
                case ApplicationMode.AddingPolygon:
                case ApplicationMode.AddingCircle:
                default:
                    break;
            }

        }
    }
}
