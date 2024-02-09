using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void SetFieldForRocket(int Fieldsize)
        {
            for(int y_koordinate = Fieldsize; y_koordinate >= -Fieldsize; y_koordinate--)
            {
                for(int x_koordiante = -Fieldsize; x_koordiante <= Fieldsize; x_koordiante++)
                {
                    if (y_koordinate == 0)
                    {
                        Point point1 = new Point(x_koordiante, y_koordinate, '-');
                        _field.Add(point1);
                    }
                    else if (x_koordiante == 0)
                    {
                        Point point2 = new Point(x_koordiante, y_koordinate, '|');
                        _field.Add(point2);
                    }
                    else
                    {
                        Point point = new Point(x_koordiante, y_koordinate, '#');
                        _field.Add(point);   
                    }
                }
            }
        }

        public void SetFieldForSizeForOtherThanRocket(int Fieldsize)
        {
            for (int x_koordiante = 0; x_koordiante <= Fieldsize; x_koordiante++)
            {
                for (int y_koordinate = 0; y_koordinate <= Fieldsize; y_koordinate++)
                {
                    Point point = new Point(x_koordiante, y_koordinate);
                    _field.Add(point);
                }
            }
        }

        public void UpdateField()
        {
            for (int coloredPointIndex = 0; coloredPointIndex < _coloredPoints.Count; coloredPointIndex++)
            {
                for (int fieldPointIndex = 0; fieldPointIndex < _field.Count; fieldPointIndex++)
                {
                    if (_field[fieldPointIndex].Y == _coloredPoints[coloredPointIndex].Y && _field[fieldPointIndex].X == _coloredPoints[coloredPointIndex].X)
                    {
                        _field[fieldPointIndex].Color = _coloredPoints[coloredPointIndex].Color;
                    }
                }
            }
        }

        public void printField(int lineSize)
        {
            for (int pointIndex = 0; pointIndex < _field.Count; pointIndex++)
            {
                if(pointIndex % lineSize  == 0)
                {
                    Console.WriteLine();
                }
                else if (_field[pointIndex].Color.ToLower() == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_field[pointIndex].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[pointIndex].Color.ToLower() == "black")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{_field[pointIndex].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[pointIndex].Color.ToLower() == "blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{_field[pointIndex].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[pointIndex].Color.ToLower() == "yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{_field[pointIndex].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (_field[pointIndex].Color.ToLower() == "green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{_field[pointIndex].Point_representer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(_field[pointIndex].Color.ToLower() == "white")
                {
                    Console.Write($"{_field[pointIndex].Point_representer}");
                } 
                
            }
        }

        public void ReadCSV(string filePath)
        {
            List<Point> points = new List<Point>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] coordinates = line.Split(',');

                        if (coordinates.Length >= 3 && int.TryParse(coordinates[1], out int x) && int.TryParse(coordinates[2], out int y))
                        {
                            points.Add(new Point(x, y, coordinates[0]));
                        }
                    }
                }
                this.ColoredPoints = points;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}