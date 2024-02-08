using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenNachZahlen
{
    public class Game
    {
        private string _picture;
        private int _fieldSize;
        private int _lineSize;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public int FieldSize
        {
            get { return _fieldSize; }
            set { _fieldSize = value; }
        }

        public int LineSize
        {
            get { return _lineSize; }
            set { _lineSize = value; }
        }

        public Game()
        {

        }

        public Game(string picture, int fieldSize, int lineSize)
        {
            this.Picture = picture;
            this.FieldSize = fieldSize;
            this.LineSize = lineSize;
        }

        public void SetGame()
        {
            try
            {
                KoordinateSystem system = new KoordinateSystem();
                system.ReadCSV($"C:\\Users\\Max Zimmermann\\Source\\Repos\\Maxzimmerman\\MalenNachZahlen\\MalenNachZahlen\\dateien\\{Picture}.csv");
                if (FieldSize == 9)
                {
                    system.SetFieldForRocket(FieldSize);
                }
                else
                {
                    system.SetFieldForSizeForOtherThanRocket(FieldSize);
                }
                system.UpdateField();
                system.printField(LineSize);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChooseImage()
        {
            while (true)
            {
                int input;
                bool correctInput = false;
                Console.WriteLine("Choose you image: ");
                Console.WriteLine("[1] Rocket");
                Console.WriteLine("[2] Bug");
                Console.WriteLine("[3] Butterfly");
                Console.WriteLine("[4] Bien");
                Console.WriteLine("[5] Escape");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Picture = "rocket";
                        FieldSize = 9;
                        LineSize = 19;
                        correctInput = true;
                        SetGame();
                        continue;
                    case 2:
                        Picture = "bug";
                        FieldSize = 13;
                        LineSize = 14;
                        correctInput = true;
                        SetGame();
                        continue;
                    case 3:
                        Picture = "butterfly";
                        FieldSize = 12;
                        LineSize = 13;
                        correctInput = true;
                        SetGame();
                        continue;
                    case 4:
                        Picture = "bien";
                        FieldSize = 11;
                        LineSize = 12;
                        correctInput = true;
                        SetGame();
                        continue;
                    case 5:
                        correctInput = true;
                        break;
                    default:
                        continue;
                }
                if (correctInput)
                {
                    break;
                }
            }
        }
    }
}
