
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
            this.equalLengthButton = new System.Windows.Forms.Button();
            this.fixedLengthButton = new System.Windows.Forms.Button();
            this.loadFromFileButton = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.deleteVertexButton = new System.Windows.Forms.Button();
            this.splitEdgeButton = new System.Windows.Forms.Button();
            this.deleteCircleButton = new System.Windows.Forms.Button();
            this.deletePolygonButton = new System.Windows.Forms.Button();
            this.addCircleButton = new System.Windows.Forms.Button();
            this.addPolygonButton = new System.Windows.Forms.Button();
            this.moveObjectButton = new System.Windows.Forms.Button();
            this.parallelRelationButton = new System.Windows.Forms.Button();
            this.removeRelationButton = new System.Windows.Forms.Button();
            this.tablePanel.SuspendLayout();
            this.menuTable.SuspendLayout();
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
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tablePanel.Size = new System.Drawing.Size(984, 561);
            this.tablePanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Margin = new System.Windows.Forms.Padding(0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(787, 561);
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
            this.menuTable.Controls.Add(this.removeRelationButton, 0, 13);
            this.menuTable.Controls.Add(this.parallelRelationButton, 0, 12);
            this.menuTable.Controls.Add(this.equalLengthButton, 0, 10);
            this.menuTable.Controls.Add(this.fixedLengthButton, 0, 9);
            this.menuTable.Controls.Add(this.loadFromFileButton, 0, 8);
            this.menuTable.Controls.Add(this.saveToFileButton, 0, 7);
            this.menuTable.Controls.Add(this.deleteVertexButton, 0, 6);
            this.menuTable.Controls.Add(this.splitEdgeButton, 0, 6);
            this.menuTable.Controls.Add(this.deleteCircleButton, 0, 5);
            this.menuTable.Controls.Add(this.deletePolygonButton, 0, 4);
            this.menuTable.Controls.Add(this.addCircleButton, 0, 3);
            this.menuTable.Controls.Add(this.addPolygonButton, 0, 1);
            this.menuTable.Controls.Add(this.moveObjectButton, 0, 0);
            this.menuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTable.Location = new System.Drawing.Point(790, 3);
            this.menuTable.Name = "menuTable";
            this.menuTable.RowCount = 14;
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
            this.menuTable.Size = new System.Drawing.Size(191, 555);
            this.menuTable.TabIndex = 1;
            // 
            // equalLengthButton
            // 
            this.equalLengthButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.equalLengthButton.Location = new System.Drawing.Point(3, 370);
            this.equalLengthButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.equalLengthButton.Name = "equalLengthButton";
            this.equalLengthButton.Size = new System.Drawing.Size(185, 23);
            this.equalLengthButton.TabIndex = 13;
            this.equalLengthButton.Text = "Equal length relation";
            this.equalLengthButton.UseVisualStyleBackColor = true;
            this.equalLengthButton.Click += new System.EventHandler(this.equalLengthButton_Click);
            // 
            // fixedLengthButton
            // 
            this.fixedLengthButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.fixedLengthButton.Location = new System.Drawing.Point(3, 334);
            this.fixedLengthButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.fixedLengthButton.Name = "fixedLengthButton";
            this.fixedLengthButton.Size = new System.Drawing.Size(185, 23);
            this.fixedLengthButton.TabIndex = 12;
            this.fixedLengthButton.Text = "Fixed length restriction";
            this.fixedLengthButton.UseVisualStyleBackColor = true;
            this.fixedLengthButton.Click += new System.EventHandler(this.fixedLengthButton_Click);
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadFromFileButton.Location = new System.Drawing.Point(3, 298);
            this.loadFromFileButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(185, 23);
            this.loadFromFileButton.TabIndex = 10;
            this.loadFromFileButton.Text = "Load from file";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveToFileButton.Location = new System.Drawing.Point(3, 262);
            this.saveToFileButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(185, 23);
            this.saveToFileButton.TabIndex = 9;
            this.saveToFileButton.Text = "Save to file";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // deleteVertexButton
            // 
            this.deleteVertexButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteVertexButton.Location = new System.Drawing.Point(3, 226);
            this.deleteVertexButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.deleteVertexButton.Name = "deleteVertexButton";
            this.deleteVertexButton.Size = new System.Drawing.Size(185, 23);
            this.deleteVertexButton.TabIndex = 8;
            this.deleteVertexButton.Text = "Delete vertex";
            this.deleteVertexButton.UseVisualStyleBackColor = true;
            this.deleteVertexButton.Click += new System.EventHandler(this.deleteVertexButton_Click);
            // 
            // splitEdgeButton
            // 
            this.splitEdgeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitEdgeButton.Location = new System.Drawing.Point(3, 190);
            this.splitEdgeButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.splitEdgeButton.Name = "splitEdgeButton";
            this.splitEdgeButton.Size = new System.Drawing.Size(185, 23);
            this.splitEdgeButton.TabIndex = 7;
            this.splitEdgeButton.Text = "Split edge";
            this.splitEdgeButton.UseVisualStyleBackColor = true;
            this.splitEdgeButton.Click += new System.EventHandler(this.splitEdgeButton_Click);
            // 
            // deleteCircleButton
            // 
            this.deleteCircleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteCircleButton.Location = new System.Drawing.Point(3, 154);
            this.deleteCircleButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.deleteCircleButton.Name = "deleteCircleButton";
            this.deleteCircleButton.Size = new System.Drawing.Size(185, 23);
            this.deleteCircleButton.TabIndex = 6;
            this.deleteCircleButton.Text = "Delete circle";
            this.deleteCircleButton.UseVisualStyleBackColor = true;
            this.deleteCircleButton.Click += new System.EventHandler(this.deleteCircleButton_Click);
            // 
            // deletePolygonButton
            // 
            this.deletePolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletePolygonButton.Location = new System.Drawing.Point(3, 118);
            this.deletePolygonButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.deletePolygonButton.Name = "deletePolygonButton";
            this.deletePolygonButton.Size = new System.Drawing.Size(185, 23);
            this.deletePolygonButton.TabIndex = 4;
            this.deletePolygonButton.Text = "Delete polygon";
            this.deletePolygonButton.UseVisualStyleBackColor = true;
            this.deletePolygonButton.Click += new System.EventHandler(this.deletePolygonButton_Click);
            // 
            // addCircleButton
            // 
            this.addCircleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addCircleButton.Location = new System.Drawing.Point(3, 82);
            this.addCircleButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addCircleButton.Name = "addCircleButton";
            this.addCircleButton.Size = new System.Drawing.Size(185, 23);
            this.addCircleButton.TabIndex = 2;
            this.addCircleButton.Text = "Add circle";
            this.addCircleButton.UseVisualStyleBackColor = true;
            this.addCircleButton.Click += new System.EventHandler(this.addCircleButton_Click);
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolygonButton.Location = new System.Drawing.Point(3, 46);
            this.addPolygonButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(185, 23);
            this.addPolygonButton.TabIndex = 0;
            this.addPolygonButton.Text = "Add polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            this.addPolygonButton.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // moveObjectButton
            // 
            this.moveObjectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveObjectButton.Location = new System.Drawing.Point(3, 10);
            this.moveObjectButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.moveObjectButton.Name = "moveObjectButton";
            this.moveObjectButton.Size = new System.Drawing.Size(185, 23);
            this.moveObjectButton.TabIndex = 11;
            this.moveObjectButton.Text = "Move object";
            this.moveObjectButton.UseVisualStyleBackColor = true;
            this.moveObjectButton.Click += new System.EventHandler(this.moveObjectButton_Click);
            // 
            // parallelRelationButton
            // 
            this.parallelRelationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.parallelRelationButton.Location = new System.Drawing.Point(3, 406);
            this.parallelRelationButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.parallelRelationButton.Name = "parallelRelationButton";
            this.parallelRelationButton.Size = new System.Drawing.Size(185, 23);
            this.parallelRelationButton.TabIndex = 15;
            this.parallelRelationButton.Text = "Parallel relation";
            this.parallelRelationButton.UseVisualStyleBackColor = true;
            this.parallelRelationButton.Click += new System.EventHandler(this.parallelRelationButton_Click);
            // 
            // removeRelationButton
            // 
            this.removeRelationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeRelationButton.Location = new System.Drawing.Point(3, 442);
            this.removeRelationButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.removeRelationButton.Name = "removeRelationButton";
            this.removeRelationButton.Size = new System.Drawing.Size(185, 23);
            this.removeRelationButton.TabIndex = 16;
            this.removeRelationButton.Text = "Remove relation";
            this.removeRelationButton.UseVisualStyleBackColor = true;
            this.removeRelationButton.Click += new System.EventHandler(this.removeRelationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tablePanel);
            this.Name = "Form1";
            this.Text = "Shape editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tablePanel.ResumeLayout(false);
            this.menuTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private BufferedPanel canvasPanel;
        private System.Windows.Forms.TableLayoutPanel menuTable;
        private System.Windows.Forms.Button addPolygonButton;
        private System.Windows.Forms.Button deleteCircleButton;
        private System.Windows.Forms.Button deletePolygonButton;
        private System.Windows.Forms.Button splitEdgeButton;
        private System.Windows.Forms.Button addCircleButton;
        private System.Windows.Forms.Button deleteVertexButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.Button moveObjectButton;
        private System.Windows.Forms.Button fixedLengthButton;
        private System.Windows.Forms.Button equalLengthButton;
        private System.Windows.Forms.Button removeRelationButton;
        private System.Windows.Forms.Button parallelRelationButton;
    }
}

