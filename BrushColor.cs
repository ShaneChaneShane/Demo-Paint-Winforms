using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_test_2_copy
{
    internal class BrushColor : ICloneable
    {
        public Color currentSelectedColor;

        public Color selectedColor()
        {
            return currentSelectedColor;
        }
        public object Clone()
        {
            BrushColor clone = new BrushColor();
            clone.currentSelectedColor = this.currentSelectedColor;
            return clone;
        }
    }
}
