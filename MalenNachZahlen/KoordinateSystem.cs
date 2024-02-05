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
        private List<Point> _field = new List<Point>();

        public List<Point> Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public void SetField()
        {
            for(int y = 9; y >= -9; y--)
            {
                for(int x = -9; x <= 9; x++)
                {
                    Point point = new Point(y, x);
                    _field.Add(point);
                }
            }

            for (int i = 0; i < _field.Count; i++)
            {
                if(i % 19 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{_field[i].Point_representer} {_field[i].X} {_field[i].Y}");
            }
        }

        public void ReadCSv()
        {
            List<String> strings = new List<string>();
            List<Point> redpoints = new List<Point>();
            using(StreamReader reader = new StreamReader("H:\\c#repo\\MalenNachZahlen\\MalenNachZahlen\\dateien\\sw.csv"))
            {
                while(!reader.EndOfStream)
                {
                    strings.Add(reader.ReadLine());
                }
            }

            string x = "";
            string y = "";

            for(int i = 0; i < strings.Count; i ++)
            {
                for(int j = 0; j < strings[i].Length; j++)
                {
                    if (strings[i] == ",")
                    {
                        x = strings[i - 1];
                        y = strings[i + 1];
                    }
                }
            }

            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        public KoordinateSystem() { }

        public KoordinateSystem(List<Point> field)
        {
            this._field = field;
        }
    }
}
