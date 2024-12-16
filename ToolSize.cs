using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_test_2_copy
{
    internal class ToolSize : ICloneable
    {
        public int brushSize;
        public int eraserSize;
        public int? selectedToolSize(string selectedTool)
        {
            if (selectedTool == "Brush") { return brushSize; }
            else if (selectedTool == "Eraser") { return eraserSize; }
            else { return null; }

        }
        public object Clone()
        {
            ToolSize clone = new ToolSize();
            return clone;
        }
    }
}

