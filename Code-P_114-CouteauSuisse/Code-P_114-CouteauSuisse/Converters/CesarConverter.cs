using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_P_114_CouteauSuisse.Converters {
    internal class CesarConverter {
        // limit of letters in ascii table (includ)
        int asciiLowLimit = 65;
        int asciiHighLimit = 90;

        int whichGap = 0;
        bool itIsANumber = false;

        string userPhrase = "";
        bool phraseIsCorect = false;

        int[] cursorPosition = { 8, 4 };
        ConsoleKeyInfo keyPress;
        public CesarConverter() {

            Console.Clear();

            Console.WriteLine("\n\n\tMerci d'entrer le nombre de décalages positif que va subire le message.");
            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);

            Console.CursorVisible = true;
            itIsANumber = int.TryParse(Console.ReadLine(), out whichGap);
            while (!itIsANumber) {
                Console.WriteLine("\n\tMerci d'entrer un nombre.");
                cursorPosition[1] += 4;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
                itIsANumber = int.TryParse(Console.ReadLine(), out whichGap);
            }


            Console.Clear();
            cursorPosition[0] = 8;
            cursorPosition[1] = 4;
            Console.WriteLine("\n\n\tMerci d'entré un phrase sans accents ni caractères spéciaux.");
            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);

            userPhrase = Console.ReadLine();
            userPhrase = userPhrase.ToUpper();

            foreach (Char l in userPhrase) {
                // if the letter is isnt's a regular letter
                if (((int)l < asciiLowLimit || (int)l > asciiHighLimit) && (int)l != 32) {
                    // the phrase is not correcte
                    phraseIsCorect = false;
                    break;
                } else {
                    // the phrase is correcte
                    phraseIsCorect = true;
                }
            }

            while (userPhrase.Length < 1 || !phraseIsCorect) {
                Console.WriteLine("\n\tMerci d'entrer une phrase.");

                cursorPosition[1] += 4;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);

                userPhrase = Console.ReadLine();
                userPhrase = userPhrase.ToUpper();

                foreach (Char l in userPhrase) {
                    // if the letter is isnt's a regular letter
                    if (((int)l < asciiLowLimit || (int)l > asciiHighLimit) && (int)l != 32) {
                        // the phrase is not correcte
                        phraseIsCorect = false;
                        break;
                    } else {
                        // the phrase is correcte
                        phraseIsCorect = true;
                    }
                }
            }

            Console.CursorVisible = false;

            char[] userPhraseChars = userPhrase.ToCharArray();

            Console.WriteLine("\n\n\tVotre phrase en claire : " + userPhrase);
            Console.Write("\n\tVotre phrase codé : ");

            for (int i = 0; i < userPhraseChars.Length; i++) {
                if (userPhraseChars[i] == 32) {
                    Console.Write(" ");
                } else {
                    userPhraseChars[i] += (char)whichGap;
                    while (userPhraseChars[i] > asciiHighLimit) {
                        userPhraseChars[i] -= (char)asciiHighLimit;
                        userPhraseChars[i] += (char)(asciiLowLimit-1);
                    }
                    Console.Write(userPhraseChars[i]);
                }
            }

            Console.WriteLine("\n\n\tVotre décalage : " + whichGap);

            Console.CursorVisible = false;

            Console.WriteLine("\n\n\tVoulez vous reconvertir une phrase ?");
            Console.WriteLine("\n\tO = Oui | N = Non");

            keyPress = Console.ReadKey(true);

            switch (keyPress.Key) {
                case ConsoleKey.O:
                    // restart
                    Console.Clear();
                    CesarConverter cesarConverter = new CesarConverter();
                    break;

                case ConsoleKey.N:
                    // quit to lobby
                    Console.Clear();
                    break;
            }
        }
    }
}
