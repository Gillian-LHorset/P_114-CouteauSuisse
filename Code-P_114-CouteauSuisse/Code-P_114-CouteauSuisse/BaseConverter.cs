namespace Code_P_114_CouteauSuisse {
    internal class BaseConverter {
        int valueToConvert;
        bool isCorrectValue;
        int whichChoise;
        ConsoleKeyInfo keyPress;


        public BaseConverter() {

            Console.WriteLine("\n\n\t═══ Convertisseur de bases ═══");
            Console.WriteLine("\n\n\t1. Décimal > Binaire");
            Console.WriteLine("\n\t2. Binaire > Décimal");
            Console.WriteLine("\n\t3. Binaire > Octal");
            Console.WriteLine("\n\t4. Octal > Binaire");
            Console.WriteLine("\n\n\tAppuyez sur Escape pour revenir à la liste de choix");

            // choisir quel type de convertion
            do {
                keyPress = Console.ReadKey(true);
                switch (keyPress.Key) {
                    case ConsoleKey.D1:
                        whichChoise = 1;
                        break;

                    case ConsoleKey.D2:
                        whichChoise = 2;
                        break;

                    case ConsoleKey.D3:
                        whichChoise = 3;
                        break;

                    case ConsoleKey.D4:
                        whichChoise = 4;
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                }
            } while (whichChoise > 4 || whichChoise < 1);

            Console.CursorVisible = false;

            Console.Clear();

            switch (whichChoise) {
                case 1:
                    // décimale vers binaire
                    Console.WriteLine("\n\tDécimal > Binaire");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Décimal.");
                    Console.WriteLine("\n\n\tVotre valeur en binaire : " + IntBaseConverter(ConvertAnyToDecimal(10), 2));
                    break;
                case 2:
                    // binaire vers décimal
                    Console.WriteLine("\n\tBinaire > Décimal");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Binaire.");
                    Console.WriteLine("\n\n\tVotre valeur en decimal : " + ConvertAnyToDecimal(2));
                    break;
                case 3:
                    // binaire vers octal
                    Console.WriteLine("\n\tBinaire > Octal");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Binaire.");
                    // convert a binary value to decimal then decimal to octal
                    Console.WriteLine("\n\n\tVotre valeur en octal : " + IntBaseConverter(ConvertAnyToDecimal(2), 8));
                    break;
                case 4:
                    // octale vers binaire
                    Console.WriteLine("\n\tOctal > Binaire");
                    Console.WriteLine("\n\n\tVeuillez entrer un nombre Octal.");
                    // convert a octal value to decimal then decimal to binary
                    Console.WriteLine("\n\n\tVotre valeur en binaire : " + IntBaseConverter(Convert.ToInt32(ConvertAnyToDecimal(8)), 2));
                    break;
            }

            Console.CursorVisible = false;

            Console.WriteLine("\n\n\tVoulez vous reconvertir un nombre ?");
            Console.WriteLine("\n\tO = Oui | N = Non");

            keyPress = Console.ReadKey(true);

            switch (keyPress.Key) {
                case ConsoleKey.O:
                    // restart
                    Console.Clear();
                    BaseConverter baseConverter = new BaseConverter();
                    break;

                case ConsoleKey.N:
                    // quit to lobby
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// request to enter a number and convert him to int
        /// </summary> 
        /// <param name="isOctal">Is the value entered octal</param>
        /// <returns>Int value enter by the user</returns>
        public int ConvertValueToInt(bool isOctal) {
            Console.CursorVisible = true;
            int[] cursorPosition = { 8, 8 };

            // nombre à convertir
            Console.WriteLine("\n\tMerci d'entrer une valeur à convertir.");

            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            isCorrectValue = Int32.TryParse(Console.ReadLine(), out valueToConvert);
            if (isOctal) {
                foreach (Char c in Convert.ToString(valueToConvert)) {
                    if (c == '8' || c == '9') {
                        isCorrectValue = false;
                        break;
                    }
                }
            }

            while (!isCorrectValue) {
                Console.WriteLine("\n\tMerci d'entre une valeur correcte.");

                cursorPosition[1] += 4;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);

                isCorrectValue = Int32.TryParse(Console.ReadLine(), out valueToConvert);
                if (isOctal) {
                    foreach (Char c in Convert.ToString(valueToConvert)) {
                        if (c == '8' || c == '9') {
                            isCorrectValue = false;
                            break;
                        }
                    }
                }
            }
            Console.Clear();
            Console.CursorVisible = false;
            return valueToConvert;
        }

        /// <summary>
        /// request to enter a number and convert him to binary
        /// </summary>
        /// <returns>Binary value enter by the user</returns>
        public string CheckIsValueBinary() {
            Console.CursorVisible = true;
            int[] cursorPosition = { 8, 8 };

            string binaryValueToCheck;

            // nombre binaire à convertir
            Console.WriteLine("\n\tMerci d'entrer une valeur binaire à convertir.");
            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            binaryValueToCheck = Console.ReadLine();

            foreach (Char c in binaryValueToCheck) {
                if (c != '0' && c != '1') {
                    isCorrectValue = false;
                    break;
                } else {
                    isCorrectValue = true;
                }
            }

            while (!isCorrectValue) {
                Console.WriteLine("\n\tMerci d'entre une valeur composé uniquement de 0 et de 1.");

                cursorPosition[1] += 4;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
                binaryValueToCheck = Console.ReadLine();

                foreach (char c in binaryValueToCheck) {
                    if (c != '0' && c != '1') {
                        isCorrectValue = false;
                        break;
                    } else {
                        isCorrectValue = true;
                    }
                }
            }
            Console.Clear();
            return binaryValueToCheck;
        }

        /// <summary>
        /// Convert any base to decimal
        /// </summary>
        /// <param name="baseFromConvert">in which base is the enter number</param>
        /// <returns>the decimal value</returns>
        public int ConvertAnyToDecimal(int baseFromConvert) {
            string ValueToConvert;
            double finalValue = 0;

            if (baseFromConvert == 2) {
                ValueToConvert = CheckIsValueBinary();
            } else {
                ValueToConvert = Convert.ToString(ConvertValueToInt(true));
            }

            int[] valueArray = new int[ValueToConvert.ToCharArray().Length + 1];
            int y = 0;

            for (int i = ValueToConvert.ToCharArray().Length - 1; i > -1; i--) {
                valueArray[i] = ValueToConvert.ToCharArray()[y] - 48;
                y++;
            }

            for (int i = 0; i < valueArray.Length; i++) {
                finalValue += valueArray[i] * Math.Pow(baseFromConvert, i);
            }

            return Convert.ToInt32(finalValue);
        }

        /// <summary> 
        /// Can convert any base in any, exept for binary in entrance
        /// </summary>
        /// <param name="valueToConvert">the value who need to be convert</param>
        /// <param name="baseToConvert">defin in which base you want to convert</param>
        /// <returns></returns>
        public string IntBaseConverter(int valueToConvert, int baseToConvert) {
            List<int> valueList = new List<int>();

            string returnValue = "";

            while (valueToConvert > 0) {
                valueList.Add(valueToConvert % baseToConvert);
                valueToConvert = valueToConvert / baseToConvert;
            }

            valueList.Reverse();

            foreach (int value in valueList) {
                returnValue = returnValue + value.ToString();
            }

            return returnValue;
        }

    }
}
