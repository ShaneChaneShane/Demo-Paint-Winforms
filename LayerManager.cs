using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static paint_test_2_copy.Form2;

namespace paint_test_2_copy
{
    internal class LayerManager
    {
        public List<Layer> Layers { get; set; }
        private int layerCounter = 0;



        public LayerManager()
        {
            Layers = new List<Layer>();
        }
        public string AddLayer(int canvasWidth, int canvasHeight, Color color, ToolSize toolSize, string tool)
        {
            layerCounter++;

            Bitmap bitmap = new Bitmap(canvasWidth, canvasHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            string name = $"Layer{layerCounter}";
            Layer newLayer = new Layer(name, bitmap, color, toolSize, tool);
            Layers.Add(newLayer);
            return newLayer.name;
        }

        public void RemoveLayer(Layer layer)
        {
            Layers.Remove(layer);
        }

        public Layer? FindLayer(string searchName)
        {
            Layer? foundLayer = Layers.Find(layer => layer.name == searchName);
            if (foundLayer != null) { return foundLayer; }
            else { return null; }
        }


    }
}
