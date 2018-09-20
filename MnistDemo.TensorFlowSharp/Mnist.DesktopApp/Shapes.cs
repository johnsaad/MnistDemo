using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mnist.DesktopApp
{
    public class Shape
    {
        public Point Location { get; set; }

        public float Width { get; set; }

        public Color Colour { get; set; }

        public int ShapeNumber { get; set; }

        public Shape(Point L, float W, Color C, int S)
        {
            Location = L;
            Width = W;
            Colour = C;
            ShapeNumber = S;
        }
    }
    
    public class Shapes
    {
        /// <summary>
        /// Stores all the shapes.
        /// </summary>
        private List<Shape> _shapes;

        public Shapes()
        {
            _shapes = new List<Shape>();
        }

        /// <summary>
        /// Returns the number of shapes being stored.
        /// </summary>
        /// <returns></returns>
        public int NumberOfShapes()
        {
            return _shapes.Count;
        }

        /// <summary>
        /// Add a shape to the database, recording its position, width, colour and shape relation information.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="W"></param>
        /// <param name="C"></param>
        /// <param name="S"></param>
        public void NewShape(Point L, float W, Color C, int S)
        {
            _shapes.Add(new Shape(L, W, C, S));
        }

        /// <summary>
        /// Returns a shape of the requested data.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Shape GetShape(int Index)
        {
            return _shapes[Index];
        }

        /// <summary>
        /// Removes any point data within a certain threshold of a point.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="threshold"></param>
        public void RemoveShape(Point L, float threshold)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                // Find if a point is within a certain distance of the point to remove.
                if ((Math.Abs(L.X - _shapes[i].Location.X) < threshold) && (Math.Abs(L.Y - _shapes[i].Location.Y) < threshold))
                {
                    //removes all data for that number
                    _shapes.RemoveAt(i);

                    // Go through the rest of the data and adds an extra 1 to defined them as a seprate shape and shuffles on the effect.
                    for (int n = i; n < _shapes.Count; n++) _shapes[n].ShapeNumber += 1;

                    // Go back a step so we dont miss a point.
                    i -= 1;
                }
            }
        }
    }
}
