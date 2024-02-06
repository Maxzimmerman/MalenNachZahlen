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

        public static void SetGame()
        {
            try
            {
                KoordinateSystem.ReadCSV($"H:\\c#repo\\MalenNachZahlen\\MalenNachZahlen\\dateien\\{Picture}.csv");
                KoordinateSystem.SetField(FieldSize);
                KoordinateSystem.UpdateField();
                KoordinateSystem.printField();
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
                        correctInput = true;
                        break;
                    case 2:
                        Picture = "bug";
                        FieldSize = 12;
                        correctInput = true;
                        break;
                    case 3:
                        Picture = "butterfly";
                        FieldSize = 11;
                        correctInput = true;
                        break;
                    case 4:
                        Picture = "bien";
                        FieldSize = 10;
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
