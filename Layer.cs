using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_test_2_copy
{
    internal class Layer
    {

        public string name { get; set; }
        public Bitmap bitmap { get; set; }
        public Stroke currentStroke { get; set; }
        public List<Stroke> allStrokes { get; set; }
        public bool visibility { get; set; }
        


        public Layer(string name, Bitmap bitmap, Color color, ToolSize toolSize, string tool)
        {

            currentStroke = new Stroke();
            currentStroke.penAttribute["Color"] = color;
            currentStroke.penAttribute["Tool"] = tool;

            currentStroke.penAttribute["Size"] = toolSize.selectedToolSize(tool);

            allStrokes = new List<Stroke>();
            visibility = true;

            this.name = name;
            this.bitmap = bitmap;
            


        }
    }

 
}
