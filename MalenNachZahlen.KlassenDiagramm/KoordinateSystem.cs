using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MalenNachZahlen.KlassenDiagramm
{
    public class KoordinateSystem
    {
        private System.Collections.Generic.List<Point> _field;
        private int _coloredPoint;

        public System.Collections.Generic.List<Point> Field
        {
            get => default;
            set
            {
            }
        }

        public int ColoredPoints
        {
            get => default;
            set
            {
            }
        }

        public void SetFieldforRocket(int FieldSize)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldForSizeForOtherThanRocket(int FieldSize)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateField()
        {
            throw new System.NotImplementedException();
        }

        public void PrintField()
        {
            throw new System.NotImplementedException();
        }

        public void ReadCSV()
        {
            throw new System.NotImplementedException();
        }
    }
}