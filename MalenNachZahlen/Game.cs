using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenNachZahlen
{
    public static class Game
    {
        private static string _picture;
        private static int _fieldSize;
        private static int _lineSize;

        public static string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public static int FieldSize
        {
            get { return _fieldSize; }
            set { _fieldSize = value; }
        }

        public static int LineSize
        {
            get { return _lineSize; }
            set { _lineSize = value; }
        }

        public static void SetGame()
        {
            try
            {
                KoordinateSystem.ReadCSV($"C:\\Users\\Max Zimmermann\\Source\\Repos\\Maxzimmerman\\MalenNachZahlen\\MalenNachZahlen\\dateien\\{Picture}.csv");
                if(FieldSize == 9)
                {
                    KoordinateSystem.SetFieldForRocket(FieldSize);
                }
                else
                {
                    KoordinateSystem.SetFieldForSizeForOtherThanRocket(FieldSize);
                }
                KoordinateSystem.UpdateField();
                KoordinateSystem.printField(LineSize);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ChooseImage()
        {
            while (true)
            {
                int input;
                bool correctInput = false;
                Console.WriteLine("Choose you image: ");
                Console.WriteLine("1. Rocket");
                Console.WriteLine("2. Bug");
                Console.WriteLine("3. Butterfly");
                Console.WriteLine("4. Bien");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Picture = "rocket";
                        FieldSize = 9;
                        LineSize = 19;
                        correctInput = true;
                        break;
                    case 2:
                        Picture = "bug";
                        FieldSize = 13;
                        LineSize = 14;
                        correctInput = true;
                        break;
                    case 3:
                        Picture = "butterfly";
                        FieldSize = 12;
                        LineSize = 13;
                        correctInput = true;
                        break;
                    case 4:
                        Picture = "bien";
                        FieldSize = 13;
                        LineSize = 14;
                        correctInput = true;
                        break;
                    default:
                        continue;
                }
                SetGame();
                if(correctInput)
                {
                    break;
                }
            }
        }
    }
}
