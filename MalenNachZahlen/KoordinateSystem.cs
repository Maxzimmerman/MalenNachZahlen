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
        private List<Point> _coloredPoints = new List<Point>();

        public List<Point> Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public List<Point> ColoredPoints
        {
            get { return _coloredPoints; }
            set { _coloredPoints = value; }
        }

        public void SetField()
        {
            for(int y = 9; y >= -9; y--)
            {
                for(int x = -9; x <= 9; x++)
                {
                    if (y == 0)
                    {
                        Point point1 = new Point(y, x, '-');
                        _field.Add(point1);
                    }
                    else if (x == 0)
                    {
                        Point point2 = new Point(y, x, '|');
                        _field.Add(point2);
                    }
                    else
                    {
                        Point point = new Point(y, x, '#');
                        _field.Add(point);   
                    }
                }
            }
        }

        public void UpdateField()
        {
            for (int i = 0; i < _field.Count; i++)
            {
                for (int j = 0; j < _coloredPoints.Count; j++)
                {
                    if (_field[i].Y == _coloredPoints[j].Y && _field[i].X == _coloredPoints[j].X)
                    {
                        _field[i].Color = "Red";
                    }
                }
            }
        }

        public void printField()
        {
            for (int i = 0; i < _field.Count; i++)
            {
                if(i % 19 == 0)
                {
                    Console.WriteLine();
                }

                if (_field[i].Color.ToLower() == "white")
                {
                    Console.Write($"{_field[i].Point_representer}");
                } 
                else if (_field[i].Color.ToLower() == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public List<Point> ReadCSV(string filePath)
        {
            List<Point> points = new List<Point>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] coordinates = line.Split(',');

                    if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int x) && int.TryParse(coordinates[1], out int y))
                    {
                        points.Add(new Point(x, y, 'R'));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }
            }

            this._coloredPoints = points;
            return points;
        }

        public KoordinateSystem() { }

        public KoordinateSystem(List<Point> field, List<Point> coloredPoints)
        {
            this._field = field;
            this._coloredPoints = coloredPoints;
        }
    }
}
