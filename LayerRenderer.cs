using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_test_2_copy
{
    internal class LayerRenderer
    {
        public void RenderLayers(Layer layer, PictureBox canvas, PaintEventArgs e)
        {

            
            Graphics layerGraphics = Graphics.FromImage(layer.bitmap);
            layerGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            if (layer.allStrokes.Count != 0)
            {
                foreach (Stroke eachStroke in layer.allStrokes)
                {
                    if (eachStroke.penAttribute["Tool"] == "Brush")
                    {

                        Debug.WriteLine(eachStroke.penAttribute["Size"]);
                        Color color = (Color)eachStroke.penAttribute["Color"];
                        int size = (int)eachStroke.penAttribute["Size"];

                        Pen pen = new Pen(color, size);
                        pen.EndCap = pen.StartCap = LineCap.Round;

                        // Do 1 point = circle too //
                        if (eachStroke.points.Count > 1)
                        { layerGraphics.DrawCurve(pen, eachStroke.points.ToArray(), 0.05f); }


                        pen.Dispose();
                    }

                    else if (eachStroke.penAttribute["Tool"] == "Eraser")
                    {
                        layerGraphics.CompositingMode = CompositingMode.SourceCopy;

                        Color color = Color.Transparent;
                        int size = (int)eachStroke.penAttribute["Size"];

                        Pen pen = new Pen(color, size);
                        pen.EndCap = pen.StartCap = LineCap.Round;


                        if (eachStroke.points.Count > 1)
                        { layerGraphics.DrawCurve(pen, eachStroke.points.ToArray(), 0.05f); }


                        pen.Dispose();
                        layerGraphics.CompositingMode = CompositingMode.SourceOver;
                    }
                }
            }

            if (layer.currentStroke.points.Count > 1)
            {
                if (layer.currentStroke.penAttribute["Tool"] == "Brush")
                {

                    Debug.WriteLine(layer.currentStroke.penAttribute["Tool"]);
                    Color color = (Color)layer.currentStroke.penAttribute["Color"];
                    int size = (int)layer.currentStroke.penAttribute["Size"];

                    Pen pen = new Pen(color, size);
                    pen.EndCap = pen.StartCap = LineCap.Round;
                    layerGraphics.DrawCurve(pen, layer.currentStroke.points.ToArray(), 0.05f);
                    pen.Dispose();
                }
                else if (layer.currentStroke.penAttribute["Tool"] == "Eraser")
                {
                    layerGraphics.CompositingMode = CompositingMode.SourceCopy;
                    Color color = Color.Transparent;
                    int size = (int)layer.currentStroke.penAttribute["Size"];

                    Pen pen = new Pen(color, size);
                    pen.EndCap = pen.StartCap = LineCap.Round;
                    layerGraphics.DrawCurve(pen, layer.currentStroke.points.ToArray(), 0.05f);
                    pen.Dispose();

                    layerGraphics.CompositingMode = CompositingMode.SourceOver;
                }
            }




            e.Graphics.DrawImage(layer.bitmap, new Point(0, 0));
            layerGraphics.Dispose();
            layer.bitmap.Dispose();
            Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            layer.bitmap = bitmap;

        }
        
    }
}
