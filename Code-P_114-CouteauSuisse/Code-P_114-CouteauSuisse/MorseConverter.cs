namespace Code_P_114_CouteauSuisse {
    internal class MorseConverter {
        string[] morseArray = new string[]
            {
                ".-",   "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
                "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-",
                "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", "·----", "··---", "···--",
                "····-", "·····", "-····", "--···", "---··", "----·", "/"
            };

        char[] lettreArray = new char[]
        {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', ' '
        };

        int y = 0;
        string userPhrase;


        bool isKnowChar = true;
        bool aCharIsUnknow = false;

        ConsoleKeyInfo keyPress;
        public MorseConverter() {
            Console.Clear();

            Console.WriteLine("Merci d'enter une phrase sans accents et caratères spéciaux.");

            userPhrase = Console.ReadLine();
            while (userPhrase.Length < 1) {
                Console.WriteLine("Merci d'entrer une phrase.");
                userPhrase = Console.ReadLine();
            }

            Console.Clear();

            Console.CursorVisible = false;

            Console.WriteLine($"Votre phrase était " + '"' + userPhrase + '"' + "\n");
            Console.WriteLine("Votre phrase en morse donne : ");
            foreach (char lettrePhrase in userPhrase.ToUpper()) {
                isKnowChar = false;

                for (int i = 0; i < lettreArray.Length; i++) {
                    if (CompareChar(lettrePhrase, lettreArray[i])) {
                        Console.Write(morseArray[i] + " ");
                        isKnowChar = true;
                        break;
                    }
                }
                if (!isKnowChar)
                // si le char n'est pas présent dans la liste de lettre
                {
                    Console.Write("? ");
                    // signale qu'un caractère inconnue à été détecté
                    aCharIsUnknow = true;
                }
            }
            if (aCharIsUnknow) {
                Console.WriteLine("\nUn ou plusieurs caratères de sont pas pris en charge.\nLes caractères inconnues ont été remplacer par le symbole " + '"' + '?' + '"' + '.');
            }

            Console.WriteLine("\n\n\tVoulez vous reconvertir une phrase ?");
            Console.WriteLine("\n\tO = Oui | N = Non");

            keyPress = Console.ReadKey(true);

            switch (keyPress.Key) {
                case ConsoleKey.O:
                    // restart
                    Console.Clear();
                    MorseConverter morseConverter = new MorseConverter();
                    break;

                case ConsoleKey.N:
                    // quit to lobby
                    Console.Clear();
                    break;
            }
        }

        public static bool CompareChar(char firstLettre, char secondLettre) {
            if (firstLettre == secondLettre) {
                return true;
            } else {
                return false;
            }
        }
    }
}
