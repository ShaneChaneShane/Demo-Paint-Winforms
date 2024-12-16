namespace paint_test_2_copy
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("Layer1");
            canvas = new PictureBox();
            brushSizeBar = new TrackBar();
            addButton = new Button();
            layerListView = new ListView();
            visable = new ColumnHeader();
            layer = new ColumnHeader();
            colorRedTest = new PictureBox();
            colorVioletTest = new PictureBox();
            transparencyBar = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            sizeLabel = new Label();
            transparencyLabel = new Label();
            selectedLayerLabel = new Label();
            brushTool = new PictureBox();
            eraserTool = new PictureBox();
            selectedToolText = new Label();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brushSizeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorRedTest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorVioletTest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transparencyBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brushTool).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eraserTool).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Location = new Point(62, 127);
            canvas.Name = "canvas";
            canvas.Size = new Size(808, 449);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // brushSizeBar
            // 
            brushSizeBar.Location = new Point(37, 19);
            brushSizeBar.Maximum = 80;
            brushSizeBar.Minimum = 10;
            brushSizeBar.Name = "brushSizeBar";
            brushSizeBar.Size = new Size(333, 45);
            brushSizeBar.TabIndex = 1;
            brushSizeBar.Value = 10;
            brushSizeBar.Scroll += brushSizeBar_Scroll;
            // 
            // addButton
            // 
            addButton.Location = new Point(566, 12);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 3;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // layerListView
            // 
            layerListView.CheckBoxes = true;
            layerListView.Columns.AddRange(new ColumnHeader[] { visable, layer });
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            layerListView.Items.AddRange(new ListViewItem[] { listViewItem1 });
            layerListView.Location = new Point(647, 12);
            layerListView.MultiSelect = false;
            layerListView.Name = "layerListView";
            layerListView.Size = new Size(198, 97);
            layerListView.TabIndex = 6;
            layerListView.UseCompatibleStateImageBehavior = false;
            layerListView.View = View.List;
            layerListView.ItemChecked += layerListView_ItemChecked;
            layerListView.SelectedIndexChanged += layerListView_SelectedIndexChanged;
            // 
            // colorRedTest
            // 
            colorRedTest.BackColor = Color.Red;
            colorRedTest.Location = new Point(37, 59);
            colorRedTest.Name = "colorRedTest";
            colorRedTest.Size = new Size(42, 50);
            colorRedTest.TabIndex = 7;
            colorRedTest.TabStop = false;
            colorRedTest.Click += colorRedTest_Click;
            // 
            // colorVioletTest
            // 
            colorVioletTest.BackColor = Color.BlueViolet;
            colorVioletTest.Location = new Point(85, 59);
            colorVioletTest.Name = "colorVioletTest";
            colorVioletTest.Size = new Size(42, 50);
            colorVioletTest.TabIndex = 8;
            colorVioletTest.TabStop = false;
            colorVioletTest.Click += colorVioletTest_Click;
            // 
            // transparencyBar
            // 
            transparencyBar.Location = new Point(150, 64);
            transparencyBar.Maximum = 255;
            transparencyBar.Name = "transparencyBar";
            transparencyBar.Size = new Size(272, 45);
            transparencyBar.TabIndex = 9;
            transparencyBar.Value = 150;
            transparencyBar.Scroll += transparencyBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(428, 64);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 10;
            label1.Text = "Opacity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 20);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 11;
            label2.Text = "Size";
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(376, 35);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(19, 15);
            sizeLabel.TabIndex = 12;
            sizeLabel.Text = "10";
            // 
            // transparencyLabel
            // 
            transparencyLabel.AutoSize = true;
            transparencyLabel.Location = new Point(428, 79);
            transparencyLabel.Name = "transparencyLabel";
            transparencyLabel.Size = new Size(26, 15);
            transparencyLabel.TabIndex = 13;
            transparencyLabel.Text = "150";
            // 
            // selectedLayerLabel
            // 
            selectedLayerLabel.AutoSize = true;
            selectedLayerLabel.Location = new Point(647, 109);
            selectedLayerLabel.Name = "selectedLayerLabel";
            selectedLayerLabel.Size = new Size(120, 15);
            selectedLayerLabel.TabIndex = 14;
            selectedLayerLabel.Text = "selected layer : Layer1";
            // 
            // brushTool
            // 
            brushTool.BackColor = SystemColors.ActiveCaption;
            brushTool.Location = new Point(12, 216);
            brushTool.Name = "brushTool";
            brushTool.Size = new Size(44, 50);
            brushTool.TabIndex = 15;
            brushTool.TabStop = false;
            brushTool.Click += brushTool_Click;
            // 
            // eraserTool
            // 
            eraserTool.BackColor = SystemColors.ActiveCaption;
            eraserTool.Location = new Point(12, 272);
            eraserTool.Name = "eraserTool";
            eraserTool.Size = new Size(44, 50);
            eraserTool.TabIndex = 16;
            eraserTool.TabStop = false;
            eraserTool.Click += eraserTool_Click;
            // 
            // selectedToolText
            // 
            selectedToolText.AutoSize = true;
            selectedToolText.Location = new Point(6, 163);
            selectedToolText.Name = "selectedToolText";
            selectedToolText.Size = new Size(50, 45);
            selectedToolText.TabIndex = 17;
            selectedToolText.Text = "selected\r\ntool:\r\nBrush\r\n";
            selectedToolText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 598);
            Controls.Add(selectedToolText);
            Controls.Add(eraserTool);
            Controls.Add(brushTool);
            Controls.Add(selectedLayerLabel);
            Controls.Add(transparencyLabel);
            Controls.Add(sizeLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(transparencyBar);
            Controls.Add(colorVioletTest);
            Controls.Add(colorRedTest);
            Controls.Add(layerListView);
            Controls.Add(addButton);
            Controls.Add(brushSizeBar);
            Controls.Add(canvas);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form2";
            Text = "Form2";
            //Load += this.Form2_Load;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)brushSizeBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorRedTest).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorVioletTest).EndInit();
            ((System.ComponentModel.ISupportInitialize)transparencyBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)brushTool).EndInit();
            ((System.ComponentModel.ISupportInitialize)eraserTool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvas;
        private TrackBar brushSizeBar;
        private Button addButton;
        private ListView layerListView;
        private ColumnHeader visable;
        private ColumnHeader layer;
        private PictureBox colorRedTest;
        private PictureBox colorVioletTest;
        private TrackBar transparencyBar;
        private Label label1;
        private Label label2;
        private Label sizeLabel;
        private Label transparencyLabel;
        private Label selectedLayerLabel;
        private PictureBox brushTool;
        private PictureBox eraserTool;
        private Label selectedToolText;
    }
}