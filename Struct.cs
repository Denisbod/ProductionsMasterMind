using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProductionsMasterMind
{
    public struct Mastermind
    {

        //public ColorsList Color;
        
        #region ComputerColors
        // Cette méthode gère la sélection de 4 couleurs aléatoires parmis les 8 de l'énumération.
        // Elle utilise une Arrayliste que l'on ampute des numéros déjà sortis pour simuler un dé.
        // La seconde liste permet de stocker la couleur correspondant au numéro dans l'énumération.
        public void ComputerColors(out List<string> Coco)
        {
            
            List<String> RandomColors = new List<string>();
            Random dice = new Random();
            ArrayList tab = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7 };
            int i = 0;
            do
            {
                int chiffre = dice.Next(tab.Count);

                foreach (var c in Enum.GetNames(typeof(ColorsList)))
                {
                    if ((int)tab[chiffre] == (int)Enum.Parse<ColorsList>(c))
                    {
                        RandomColors.Add(c);
                    }
                }
                tab.Remove(tab[chiffre]);
                i++;

            } while (i < 4);
            Coco = RandomColors;
        }
        #endregion

        #region JoueurColors
        // Cette méthode gère la sélection de 4 couleurs par le joueur.
        // Elle exploite 2 listes.
        // (Copie de l'énumération),la première, présentant les couleurs disponibles, est amputée des choix du joueur.
        // La seconde emmagasine les choix du joueur et leur ordre.
        public void JoueurColors(out List<string> JoJo)
        {
            List<String> ListedColors = new List<string>();
            List<String> ChoiceColors = new List<string>();;
            bool b = false;
            string choice;
            foreach (string color in Enum.GetNames(typeof(ColorsList)))
            {
                Console.WriteLine($"{color}");
                ListedColors.Add(color);
            }
            int i = 0;
            do
            {
                do
                {
                Console.Clear();
                    foreach (string color in ListedColors)
                    {
                        Console.WriteLine($"{color}");
                    }
                    Console.WriteLine();
                    foreach (string color in ChoiceColors)
                    {
                        int j = 0;
                        Console.ForegroundColor = Enum.Parse<ConsoleColor>(color);
                        Console.WriteLine($"Case{i} = {color}.");
                        j++;
                    }
                    Console.Write($"\nChoix de couleur pour la case {i}, Ecrivez l'une de celles-ci en toute lettres (! Majuscule) : ");
                
                    choice = Console.ReadLine().ToString();
                    b = ListedColors.Contains(choice);
                    if (b) ChoiceColors.Add(choice);
                }
                while (!b);
                i++;
                ListedColors.Remove(choice);
            } while (i<4);
            Console.Clear();
            JoJo = ChoiceColors;
        }
        #endregion

    }
}
