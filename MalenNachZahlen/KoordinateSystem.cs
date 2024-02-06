using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MalenNachZahlen
{
    public static class KoordinateSystem
    {
        private static List<Point> _field = new List<Point>();
        private static List<Point> _coloredPoints = new List<Point>();

        public static List<Point> Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public static List<Point> ColoredPoints
        {
            get { return _coloredPoints; }
            set { _coloredPoints = value; }
        }

        public static void SetFieldForRocket(int size)
        {
            for(int y = size; y >= -size; y--)
            {
                for(int x = -size; x <= size; x++)
                {
                    if (y == 0)
                    {
                        Point point1 = new Point(x, y, '-');
                        _field.Add(point1);
                    }
                    else if (x == 0)
                    {
                        Point point2 = new Point(x, y, '|');
                        _field.Add(point2);
                    }
                    else
                    {
                        Point point = new Point(x, y, '#');
                        _field.Add(point);   
                    }
                }
            }
        }

        public static void SetFieldForSizeForOtherThanRocket(int size)
        {
            for (int x = 0; x <= size; x++)
            {
                for (int y = 0; y <= size; y++)
                {
                    Point point = new Point(x, y);
                    _field.Add(point);
                }
            }
        }

        public static void UpdateField()
        {
            for (int j = 0; j < _coloredPoints.Count; j++)
            {
                for (int i = 0; i < _field.Count; i++)
                {
                    if (_field[i].Y == _coloredPoints[j].Y && _field[i].X == _coloredPoints[j].X)
                    {
                        _field[i].Color = _coloredPoints[j].Color;
                    }
                }
            }
        }

        public static void printField(int lineSize)
        {
            for (int i = 0; i < _field.Count; i++)
            {
                if(i % lineSize  == 0)
                {
                    Console.WriteLine();
                }
                else if (_field[i].Color.ToLower() == "rot")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[i].Color.ToLower() == "schwarz")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[i].Color.ToLower() == "blau")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[i].Color.ToLower() == "gelb")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[i].Color.ToLower() == "grün")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(_field[i].Color.ToLower() == "white")
                {
                    Console.Write($"{_field[i].Point_representer}");
                } 
                
            }
        }

        public static void ReadCSV(string filePath)
        {
            List<Point> points = new List<Point>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] coordinates = line.Split(',');

                    if(coordinates.Length >= 3 && int.TryParse(coordinates[1], out int x) && int.TryParse(coordinates[2], out int y))
                    {
                        points.Add(new Point(x, y, coordinates[0]));
                    }
                }
            }
            _coloredPoints = points;
        }
    }
}