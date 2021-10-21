
namespace lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.canvasPanel = new lab1.BufferedPanel();
            this.menuTable = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.deletePolygonButton = new System.Windows.Forms.Button();
            this.deleteVertexButton = new System.Windows.Forms.Button();
            this.splitEdgeButton = new System.Windows.Forms.Button();
            this.addPolygonButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button15 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.moveObjectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanel.SuspendLayout();
            this.menuTable.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.ColumnCount = 2;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.Controls.Add(this.canvasPanel, 0, 0);
            this.tablePanel.Controls.Add(this.menuTable, 1, 0);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 961F));
            this.tablePanel.Size = new System.Drawing.Size(1484, 961);
            this.tablePanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Margin = new System.Windows.Forms.Padding(0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(1187, 961);
            this.canvasPanel.TabIndex = 0;
            this.canvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPanel_Paint);
            this.canvasPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseDown);
            this.canvasPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseMove);
            this.canvasPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseUp);
            // 
            // menuTable
            // 
            this.menuTable.ColumnCount = 1;
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTable.Controls.Add(this.groupBox4, 0, 4);
            this.menuTable.Controls.Add(this.groupBox8, 0, 1);
            this.menuTable.Controls.Add(this.groupBox3, 0, 3);
            this.menuTable.Controls.Add(this.moveObjectButton, 0, 0);
            this.menuTable.Controls.Add(this.groupBox2, 0, 2);
            this.menuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTable.Location = new System.Drawing.Point(1190, 3);
            this.menuTable.Name = "menuTable";
            this.menuTable.RowCount = 17;
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.menuTable.Size = new System.Drawing.Size(291, 955);
            this.menuTable.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 494);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 96);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save and load";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.button14, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button13, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(279, 74);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Top;
            this.button14.Location = new System.Drawing.Point(3, 46);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(273, 23);
            this.button14.TabIndex = 11;
            this.button14.Text = "Load from file";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Top;
            this.button13.Location = new System.Drawing.Point(3, 10);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(273, 23);
            this.button13.TabIndex = 10;
            this.button13.Text = "Save to file";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanel1);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(3, 39);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(285, 169);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Polygons";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.deletePolygonButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.deleteVertexButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitEdgeButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.addPolygonButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // deletePolygonButton
            // 
            this.deletePolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletePolygonButton.Location = new System.Drawing.Point(3, 118);
            this.deletePolygonButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.deletePolygonButton.Name = "deletePolygonButton";
            this.deletePolygonButton.Size = new System.Drawing.Size(273, 23);
            this.deletePolygonButton.TabIndex = 19;
            this.deletePolygonButton.Text = "Delete polygon";
            this.deletePolygonButton.UseVisualStyleBackColor = true;
            this.deletePolygonButton.Click += new System.EventHandler(this.deletePolygonButton_Click);
            // 
            // deleteVertexButton
            // 
            this.deleteVertexButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteVertexButton.Location = new System.Drawing.Point(3, 82);
            this.deleteVertexButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.deleteVertexButton.Name = "deleteVertexButton";
            this.deleteVertexButton.Size = new System.Drawing.Size(273, 23);
            this.deleteVertexButton.TabIndex = 16;
            this.deleteVertexButton.Text = "Delete vertex";
            this.deleteVertexButton.UseVisualStyleBackColor = true;
            this.deleteVertexButton.Click += new System.EventHandler(this.deleteVertexButton_Click);
            // 
            // splitEdgeButton
            // 
            this.splitEdgeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitEdgeButton.Location = new System.Drawing.Point(3, 46);
            this.splitEdgeButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.splitEdgeButton.Name = "splitEdgeButton";
            this.splitEdgeButton.Size = new System.Drawing.Size(273, 23);
            this.splitEdgeButton.TabIndex = 14;
            this.splitEdgeButton.Text = "Split edge";
            this.splitEdgeButton.UseVisualStyleBackColor = true;
            this.splitEdgeButton.Click += new System.EventHandler(this.splitEdgeButton_Click);
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolygonButton.Location = new System.Drawing.Point(3, 10);
            this.addPolygonButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(273, 23);
            this.addPolygonButton.TabIndex = 13;
            this.addPolygonButton.Text = "Add polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            this.addPolygonButton.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 319);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 169);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Polygon relations";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.button15, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.button12, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.button11, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button10, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(279, 147);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Top;
            this.button15.Location = new System.Drawing.Point(3, 118);
            this.button15.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(273, 23);
            this.button15.TabIndex = 19;
            this.button15.Text = "Remove relation";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.removeRelationButton_Click);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.Location = new System.Drawing.Point(3, 82);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(273, 23);
            this.button12.TabIndex = 16;
            this.button12.Text = "Parallel relation";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.parallelRelationButton_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.Location = new System.Drawing.Point(3, 46);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(273, 23);
            this.button11.TabIndex = 14;
            this.button11.Text = "Equal length relation";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.equalLengthButton_Click);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Location = new System.Drawing.Point(3, 10);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(273, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Fixed length restriction";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.fixedLengthButton_Click);
            // 
            // moveObjectButton
            // 
            this.moveObjectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveObjectButton.Location = new System.Drawing.Point(3, 10);
            this.moveObjectButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.moveObjectButton.Name = "moveObjectButton";
            this.moveObjectButton.Size = new System.Drawing.Size(285, 23);
            this.moveObjectButton.TabIndex = 11;
            this.moveObjectButton.Text = "Move object";
            this.moveObjectButton.UseVisualStyleBackColor = true;
            this.moveObjectButton.Click += new System.EventHandler(this.moveObjectButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 99);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Circles";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 77);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Location = new System.Drawing.Point(3, 82);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(273, 23);
            this.button9.TabIndex = 19;
            this.button9.Text = "Fixed radius";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.Location = new System.Drawing.Point(3, 118);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(273, 7);
            this.button8.TabIndex = 18;
            this.button8.Text = "Anchor circle";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Location = new System.Drawing.Point(3, 46);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(273, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Delete circle";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Location = new System.Drawing.Point(3, 10);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(273, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Add circle";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.deleteCircleButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel6);
            this.groupBox6.Location = new System.Drawing.Point(3, 141);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(185, 169);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Polygon relations";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.button19, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.button20, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 6;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(179, 147);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // button19
            // 
            this.button19.Dock = System.Windows.Forms.DockStyle.Top;
            this.button19.Location = new System.Drawing.Point(3, 46);
            this.button19.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(173, 23);
            this.button19.TabIndex = 14;
            this.button19.Text = "Equal length relation";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Dock = System.Windows.Forms.DockStyle.Top;
            this.button20.Location = new System.Drawing.Point(3, 10);
            this.button20.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(173, 23);
            this.button20.TabIndex = 13;
            this.button20.Text = "Fixed length restriction";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 100);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.tablePanel);
            this.Name = "Form1";
            this.Text = "Shape editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tablePanel.ResumeLayout(false);
            this.menuTable.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private BufferedPanel canvasPanel;
        private System.Windows.Forms.TableLayoutPanel menuTable;
        private System.Windows.Forms.Button moveObjectButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button deletePolygonButton;
        private System.Windows.Forms.Button deleteVertexButton;
        private System.Windows.Forms.Button splitEdgeButton;
        private System.Windows.Forms.Button addPolygonButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    }
}

