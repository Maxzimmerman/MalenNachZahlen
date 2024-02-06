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

        public static void SetField(int size)
        {
            // adjust for different sizes
            for(int y = size; y >= -size; y--)
            {
                for(int x = -size; x <= size; x++)
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

        public static void UpdateField()
        {
            // adjust color
            for (int j = 0; j < _coloredPoints.Count; j++)
            {
                for (int i = 0; i < _field.Count; i++)
                {
                    if (_field[i].Y == _coloredPoints[j].Y && _field[i].X == _coloredPoints[j].X)
                    {
                        _field[i].Color = "Red";
                    }
                }
            }
        }

        public static void printField()
        {
            for (int i = 0; i < _field.Count; i++)
            {
                // adjust for different sizes
                if(i % 19 == 0)
                {
                    Console.WriteLine();
                }
                else if (_field[i].Color.ToLower() == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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

            _coloredPoints = points;
        }

        public static async void MovingImage()
        {
            for (int i = 0; i < _field.Count; i++)
            {
                // adjust for different sizes
                if (i % 19 == 0)
                {
                    Console.WriteLine();
                }
                else if (_field[i].Color.ToLower() == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_field[i].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else if (_field[i].Color.ToLower() == "white")
                {
                    Console.Write($"{_field[i].Point_representer}");
                }

            }

            var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                for (int i = 0; i < _field.Count; i++)
                {
                    
                }
            }
        }
    }
}