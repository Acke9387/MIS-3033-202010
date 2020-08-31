using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFilesDateTime
{
    public class Rectangle
    {
        public int width { get; set; }
        public int height { get; set; }

        public DateTime creationDate { get; set; }


        /// <summary>
        /// This is the default / empty constructor
        /// </summary>
        public Rectangle()
        {
            width = 0;
            height = 0;
            creationDate = DateTime.Now;
        }

        /// <summary>
        /// Overloaded constructor for the Rectangle Class
        /// </summary>
        /// <param name="width">An integer representing the width of the Rectangle</param>
        /// <param name="height">An integer representing the height of the Rectangle</param>
        public Rectangle(int width, int height) : this()
        {
            this.width = width;
            this.height = height;
            //creationDate = DateTime.Now;
        }

        /// <summary>
        /// Calculate the area of the Rectangle
        /// </summary>
        /// <returns>The area of the Rectangle</returns>
        public double area()
        {
            return width * height;
        }

        /// <summary>
        /// Overload the ToString to output what we want about the Rectangle
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var diff = DateTime.Now - creationDate;
            string output = $"The rectangle was created on {creationDate.DayOfWeek} {diff.TotalSeconds} seconds ago & has a width of {width} and height of {height}" +
                            $"\n\tThe area of the rectangle is {area()}";

            return output;
        }
    }
}
