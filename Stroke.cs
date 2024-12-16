using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_test_2_copy
{
    internal class Stroke : ICloneable
    {


        public object Clone()
        {
            Stroke clone = new Stroke();

            // Deep copy points list
            clone.points = new List<Point>(this.points);
            clone.penAttribute = new Dictionary<string, object>();

            foreach (var entry in this.penAttribute)
            {
                // For int values, shallow copy
                if (entry.Value is int || entry.Value is string)
                {
                    clone.penAttribute.Add(entry.Key, entry.Value);
                }
                // For Color values, create a new instance with the same ARGB values
                else if (entry.Value is Color)
                {
                    Color originalColor = (Color)entry.Value;
                    clone.penAttribute.Add(entry.Key, originalColor);
                }
            }


            return clone;
        }

        public List<Point> points;
        public Dictionary<string, object> penAttribute { get; set; }
        
        public Stroke()
        {

            penAttribute = new Dictionary<string, object>();
            penAttribute.Add("Color", default(Color));
            penAttribute.Add("Size", default(int));
            penAttribute.Add("Tool", default(string));

            points = new List<Point>();

        }

    }
}
