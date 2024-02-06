using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenNachZahlen
{
    public class Point
    {
        private int _x;
        private int _y;
        private string _color = "white";
        private char _point_representer = '#';

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public char Point_representer
        {
            get { return _point_representer; }
            set { _point_representer = value; }
        }

        public Point() { }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(int x, int y, string color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public Point(int x, int y, char pointRepresenter)
        {
            this.X = x;
            this.Y = y;
            this.Point_representer = pointRepresenter;
        }

        public Point(int x, int y, char pointRepresenter, string color)
        {
            this.X = x;
            this.Y = y;
            this.Point_representer = pointRepresenter;
            this.Color = color;
        }
    }
}
