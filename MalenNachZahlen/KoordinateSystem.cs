using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MalenNachZahlen
{
    public class KoordinateSystem
    {
        private string[,] _field = new string[19, 19];
        private List<Point> field = new List<Point>();

        public string[,] Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public void setField()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    _field[i, j] = $" ({i - 9}, {j - 9})";
                }
            }
        }

        public void SetField()
        {
            for(int y = 9; y >= -9; y--)
            {
                for(int x = -9; x <= 9; x++)
                {
                    Point point = new Point(y, x);
                    field.Add(point);
                }
            }

            for (int i = 0; i < field.Count; i++)
            {
                if(i % 19 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{field[i].Point_representer} {field[i].X} {field[i].Y}");
            }
        }

        public void printField()
        {
            for (int i = 1; i < _field.GetLength(0); i++)
            {
                for (int j = 1; j < _field.GetLength(1); j++)
                {
                    Console.Write(string.Format(_field[i, j]));
                }
                Console.WriteLine();
            }
        }

        public KoordinateSystem() { }

        public KoordinateSystem(string[,] field)
        {
            this._field = field;
        }
    }
}
