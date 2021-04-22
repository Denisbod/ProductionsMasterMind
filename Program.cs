using System;
using System.Collections;
using System.Collections.Generic;


namespace ProductionsMasterMind
{
    [Flags]
    public enum ColorsList {DarkYellow, DarkGray, Blue, Green, Cyan, Red, Magenta, Yellow };
    // les 8 constantes de cette énumération sont écrites comme celles de ConsoleColor Enum.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenu au Mastermind, trouvez les 4 couleurs dans le bon ordre\n");
            char key = default;
            do
            {
                Console.WriteLine("\nSouhaitez vous quitter (touche 'q') ou bien (re)jouer (une autre touche...) ?");
                if (Console.ReadKey().KeyChar != 'q')
                {
                    bool win = false;
                    int attempt = 0; 
                    List<String> CoCo;

                    Mastermind Co;
                    Co = default;
                    Mastermind Jo;
                    Jo = default;

                    Co.ComputerColors(out CoCo);

                    do
                    {
                        List<String> JoJo;
                        int count = 0;
                        attempt++;

                        Jo.JoueurColors(out JoJo);

                        for (int i = 0; i < JoJo.Count; i++)
                        {
                            string color = JoJo[i];
                            Console.ForegroundColor = Enum.Parse<ConsoleColor>(color);
                            Console.WriteLine($"Case{i} = {color}.");
                        }
                        Console.WriteLine("\n");

                        for (int i = 0; i < JoJo.Count; i++)
                        {
                            string joColor = JoJo[i];
                            for (int j = 0; j < CoCo.Count; j++)
                            {
                                string coColor = CoCo[j];
                                if ((JoJo[i] == CoCo[j]) && (i == j))
                                {
                                    Console.ForegroundColor = Enum.Parse<ConsoleColor>(joColor);
                                    Console.WriteLine($"Case{i} = {joColor} est à la bonne place.");
                                    count++;
                                }
                                else if ((JoJo[i] == CoCo[j]) && (i != j))
                                {
                                    Console.ForegroundColor = Enum.Parse<ConsoleColor>(joColor);
                                    Console.WriteLine($"Case{i} = {joColor} n'est pas à la bonne place.");
                                }
                            }
                        }

                        if (count == 4)
                        {
                            Console.WriteLine($"\nFelicitations! Vous avez trouvé la bonne combinaison en {attempt} tentatives!");
                            win = true;
                        }
                        else
                        {
                            Console.WriteLine("\n\nAppuyez sur 'q' pour abandonner ou une autre touche pour poursuivre la partie et choisir une nouvelle combinaison!");
                            if (Console.ReadKey().KeyChar == 'q')
                            {
                                Console.WriteLine("\n\nLa solution était :");
                                for (int i = 0; i < CoCo.Count; i++)
                                {
                                    string color = CoCo[i];
                                    Console.ForegroundColor = Enum.Parse<ConsoleColor>(color);
                                    Console.WriteLine($"Case{i} = {color}.");
                                }
                                Console.WriteLine("\n");
                                win = true;
                            }
                        }
                    } while (!win);
                }
                else key = 'q';
            }
            while (key != 'q');
            Console.Write($"\n\nAurevoir !\n\n");
            

        }
    }
}
