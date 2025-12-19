using Code_P_114_CouteauSuisse.Converters;

namespace Code_P_114_CouteauSuisse {
    internal class Program {
        static void Main(string[] args) {
            ConsoleKeyInfo keyPress;
            do {
                Console.CursorVisible = false;

                Console.WriteLine("\n\n\t═══ Veuillez choisir un progamme ═══");
                Console.WriteLine("\n\n\t1. Convertir du texte en Morse.");
                Console.WriteLine("\n\t2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal).");
                Console.WriteLine("\n\t3. Convertir une phrase dans un code cesar donné.");
                Console.WriteLine("\n\n\tAppuyez sur Escape pour quitter le progamme.");

                keyPress = Console.ReadKey(true);
                switch (keyPress.Key) {
                    case ConsoleKey.D1:
                        MorseConverter morseConverter = new MorseConverter();
                        break;

                    case ConsoleKey.D2:
                        BaseConverter baseConverter = new BaseConverter();
                        break;

                    case ConsoleKey.D3:
                        CesarConverter cesarConverter = new CesarConverter();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}

