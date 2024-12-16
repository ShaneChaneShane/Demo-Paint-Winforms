using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace paint_test_2_copy
{
    public partial class Form2 : Form
    {
        #region Variable

        bool mouseLeftDown = false;


        int brushTransparency;
        Color brushColor;
        Color brushColorArgb;
        string selectedTool;
        //int brushSize;
        //int eraserSize;

        ToolSize toolSize= new ToolSize();

        LayerManager layerManager = new LayerManager();
        LayerRenderer layerRenderer = new LayerRenderer();
        Layer? selectedLayer;
        Layer layer1;

        #endregion





        public Form2()
        {

            InitializeComponent();

            toolSize.eraserSize = brushSizeBar.Value;
            toolSize.brushSize = brushSizeBar.Value;
            selectedTool = "Brush";
            brushColor = Color.BlueViolet;
            brushTransparency = transparencyBar.Value;

            brushColorArgb = Color.FromArgb(brushTransparency, brushColor);

            layerManager.AddLayer(canvas.Width, canvas.Height, brushColorArgb, toolSize, selectedTool);
            layer1 = layerManager.Layers[0];
            selectedLayer = layer1;

            layerListView.Items[0].Selected = true;

            Invalidate();



        }


        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedLayer.visibility)
            {
                mouseLeftDown = true;
            }

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseLeftDown && selectedLayer.visibility)
            {
                if (selectedLayer.currentStroke.points.Count > 0)
                {
                    Stroke strokeCopy = (Stroke)selectedLayer.currentStroke.Clone();
                    selectedLayer.allStrokes.Add(strokeCopy); //I hate deep copy
                    Debug.WriteLine($"{selectedLayer.allStrokes[^1].penAttribute["Color"]} DEEP COPY");
                    Debug.WriteLine($"{selectedLayer.allStrokes[^1].penAttribute["Tool"]} DEEP COPY");
                }

                mouseLeftDown = false;
                selectedLayer.currentStroke.points.Clear();
                canvas.Invalidate();
            }

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {


            if (mouseLeftDown && selectedLayer.visibility)
            {
                if (selectedLayer.currentStroke.points.Count > 0 && distance(e.Location, selectedLayer.currentStroke.points[^1]) > (int)selectedLayer.currentStroke.penAttribute["Size"] / 2)
                {
                    selectedLayer.currentStroke.points.Add(e.Location);
                }
                else if (selectedLayer.currentStroke.points.Count == 0)
                {
                    selectedLayer.currentStroke.points.Add(e.Location);
                }

                canvas.Invalidate();

            }
        }

        private double distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }





        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Layer layer in layerManager.Layers)
            {
                if (layer.visibility)
                {
                    layerRenderer.RenderLayers(layer, canvas, e);
                }
            }

        }



        #region color and size control

        private void brushSizeBar_Scroll(object sender, EventArgs e)
        {

            sizeLabel.Text = $"{brushSizeBar.Value}";


            if (selectedTool == "Brush")
            { toolSize.brushSize = brushSizeBar.Value; }
            else if (selectedTool == "Eraser")
            { toolSize.eraserSize = brushSizeBar.Value; }

            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Size"] = brushSizeBar.Value;
            }

        }

        private void colorVioletTest_Click(object sender, EventArgs e)
        {
            brushColor = Color.BlueViolet;

            brushColorArgb = Color.FromArgb(brushTransparency, brushColor);

            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Color"] = brushColorArgb;
            }
        }

        private void colorRedTest_Click(object sender, EventArgs e)
        {
            brushColor = Color.Red;

            brushColorArgb = Color.FromArgb(brushTransparency, brushColor);

            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Color"] = brushColorArgb;
            }
        }

        private void transparencyBar_Scroll(object sender, EventArgs e)
        {
            brushTransparency = transparencyBar.Value;
            transparencyLabel.Text = $"{transparencyBar.Value}";
            brushColorArgb = Color.FromArgb(brushTransparency, brushColor);

            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Color"] = brushColorArgb;
            }

        }

        #endregion

        #region layer control

        private void layerListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerListView.SelectedItems.Count > 0)
            {
                selectedLayer = layerManager.FindLayer(layerListView.SelectedItems[0].Text);
                selectedLayerLabel.Text = $"selected layer : {layerListView.SelectedItems[0].Text}";


            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            String layerAddedName = layerManager.AddLayer(canvas.Width, canvas.Height, brushColorArgb, toolSize, selectedTool);
            layerListView.Items.Add(layerAddedName);

            ListViewItem? layerItem = layerListView.FindItemWithText(layerAddedName);
            if (layerItem != null)
            { layerItem.Checked = true; }

        }

        private void layerListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Layer? layer = layerManager.FindLayer(e.Item.Text);
            if (e.Item.Checked)
            { layer.visibility = true; }
            else
            { layer.visibility = false; }
            canvas.Refresh();
            //Debug.WriteLine("check");
        }

        #endregion

        private void brushTool_Click(object sender, EventArgs e)
        {
            selectedTool = "Brush";
            brushSizeBar.Value = (int)toolSize.selectedToolSize(selectedTool);
            sizeLabel.Text = $"{brushSizeBar.Value}";

            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Tool"] = selectedTool;
                layer.currentStroke.penAttribute["Size"] = brushSizeBar.Value;
            }
            selectedToolText.Text = $"selected\r\ntool:\r\n{selectedTool}";
        }

        private void eraserTool_Click(object sender, EventArgs e)
        {
            selectedTool = "Eraser";
            brushSizeBar.Value = (int)toolSize.selectedToolSize(selectedTool);
            sizeLabel.Text = $"{brushSizeBar.Value}";


            foreach (Layer layer in layerManager.Layers)
            {
                layer.currentStroke.penAttribute["Tool"] = selectedTool;
                layer.currentStroke.penAttribute["Size"] = brushSizeBar.Value;
            }
            //selectedToolText.Text = "selected\r\ntool:\r\nEraser";
            selectedToolText.Text = $"selected\r\ntool:\r\n{selectedTool}";
        }
    }
}
