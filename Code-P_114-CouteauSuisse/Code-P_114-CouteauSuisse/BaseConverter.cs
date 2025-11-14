using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_P_114_CouteauSuisse
{
    internal class BaseConverter
    {
        int valueToConvert;
        bool isCorrectValue;
        int wichChoise;
        ConsoleKeyInfo keyPress;

                
        public BaseConverter() {

            Console.WriteLine("\n\n\t═══ Convertisseur de bases ═══");
            Console.WriteLine("\n\n\t1. Décimal > Binaire");
            Console.WriteLine("\n\t2. Binaire > Décimal");
            Console.WriteLine("\n\t3. Binaire > Octal");
            Console.WriteLine("\n\t4. Octal > Binaire");

            // choisir quel type de convertion
            do
            {
                keyPress = Console.ReadKey(true);
                switch (keyPress.Key)
                {
                    case ConsoleKey.D1:
                        wichChoise = 1;
                        break;

                    case ConsoleKey.D2:
                        wichChoise = 2;
                        break;

                    case ConsoleKey.D3:
                        wichChoise = 3;
                        break;

                    case ConsoleKey.D4:
                        wichChoise = 4;
                        break;
                }
            } while (wichChoise > 4 || wichChoise < 1);

            Console.Clear();

            // nombre à convertire
            Console.WriteLine("\n\tMerci d'entrer une valeur à convertir.");

            isCorrectValue = Int32.TryParse(Console.ReadLine(), out valueToConvert);

            while (!isCorrectValue)
            {
                Console.WriteLine("\n\tMerci d'entre une valeur correcte.");
                isCorrectValue = Int32.TryParse(Console.ReadLine(), out valueToConvert);
            }
            Console.CursorVisible = false;

            Console.Clear();

            switch (wichChoise)
            {
                case 1:
                    // décimale vers binaire
                    Console.WriteLine("\n\tDécimal > Binaire");
                    Console.WriteLine("\n\n\tVotre valeur en décimal : "+valueToConvert);
                    Console.WriteLine("\n\n\tVotre valeur en binaire : " + decimalToBinary(valueToConvert));
                    break;
                case 2:
                    // binaire vers décimal
                    Console.WriteLine("\n\tBinaire > Décimal");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Binaire.");

                    break;
                case 3:
                    // binaire vers octal
                    Console.WriteLine("\n\tBinaire > Octal");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Binaire.");

                    break;
                case 4:
                    // octale vers binaire
                    Console.WriteLine("\n\tOctal > Binaire");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Octal.");

                    break;
            }
            Console.WriteLine("\n\n\tVoulez vous reconvertir un nombre ?");
            Console.WriteLine("\n\tO = Oui | N = Non");
            keyPress = Console.ReadKey(true);
            switch (keyPress.Key)
            {
                case ConsoleKey.O:
                    MorseConverter morseConverter = new MorseConverter();
                    break;

                case ConsoleKey.N:
                    BaseConverter baseConverter = new BaseConverter();
                    break;
            }
            Console.ReadLine();

        }
        /// <summary>
        /// Convertie une valeur donnée en base décimal, vers une base binaire
        /// </summary>
        /// <param name="valueToConvert">Valeur à convertir</param>
        /// <returns>retourne la valeur convertie en binaire</returns>
        public string decimalToBinary(int valueToConvert)
        {
            List<int> binaryValueList = new List<int>();

            List<int> tempList = new List<int>();

            string returnValue = "";

            while (valueToConvert > 0)
            {
                int i = 0;

                binaryValueList.Add(valueToConvert % 2);
                valueToConvert = valueToConvert / 2;


                i++;
            }

            binaryValueList.Reverse();

            foreach (int binaryValue in binaryValueList)
            {
                returnValue = returnValue + binaryValue.ToString();
            }

            return returnValue;
        }
    }
}
