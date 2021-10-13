
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
            this.addCircleButton = new System.Windows.Forms.Button();
            this.addPolygonButton = new System.Windows.Forms.Button();
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
            this.tablePanel.Size = new System.Drawing.Size(800, 450);
            this.tablePanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Margin = new System.Windows.Forms.Padding(0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(640, 450);
            this.canvasPanel.TabIndex = 0;
            // 
            // menuTable
            // 
            this.menuTable.ColumnCount = 1;
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTable.Controls.Add(this.addCircleButton, 0, 2);
            this.menuTable.Controls.Add(this.addPolygonButton, 0, 0);
            this.menuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTable.Location = new System.Drawing.Point(643, 3);
            this.menuTable.Name = "menuTable";
            this.menuTable.RowCount = 6;
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.menuTable.Size = new System.Drawing.Size(154, 444);
            this.menuTable.TabIndex = 1;
            // 
            // addCircleButton
            // 
            this.addCircleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addCircleButton.Location = new System.Drawing.Point(3, 46);
            this.addCircleButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addCircleButton.Name = "addCircleButton";
            this.addCircleButton.Size = new System.Drawing.Size(148, 23);
            this.addCircleButton.TabIndex = 2;
            this.addCircleButton.Text = "Add circle";
            this.addCircleButton.UseVisualStyleBackColor = true;
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolygonButton.Location = new System.Drawing.Point(3, 10);
            this.addPolygonButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(148, 23);
            this.addPolygonButton.TabIndex = 0;
            this.addPolygonButton.Text = "Add polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tablePanel);
            this.Name = "Form1";
            this.Text = "Shape editor";
            this.TopMost = true;
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
        private System.Windows.Forms.Button addCircleButton;
    }
}

