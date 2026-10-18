using System;
using System.Collections.Generic;


namespace виселица
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var Game = new Game();
            Game.start();

            while (true)
            {
                Game.Gallows();
                Game.goodLetter();
                Game.CheckLetter();

                if (Game.isVin())
                {
                    Console.WriteLine("ПОБЕДА");
                    break;
                }
                if (Game.isLoose())
                {
                    Game.Gallows();
                    Console.WriteLine("ЛУЗЕР");
                    break;
                }
            }
            Console.ReadKey();
        }
    }

    internal class Game
    {
        private string[] words = { "дерево", "радуга", "поляна", "компьютер", "программист", "мороженое" };
        Random rnd = new Random();
       private string secret;
       private List<char> unswer = new List<char>();
        private int errors = 0; 

        public void start()
        {
            int index = rnd.Next(words.Length);
            secret = words[index];
        }

        public void CheckLetter()
        {
            while (true)
            {
                Console.Write("\nВведите букву: ");
                string check = Console.ReadLine();

                if (string.IsNullOrEmpty(check))
                {
                    Console.WriteLine("Поле не должно быть пустым!");
                    continue;
                }

                if (check.Length != 1)
                {
                    Console.WriteLine("Вы ввели больше 1 символа");
                    continue;
                }

                char letter = char.ToLower(check[0]);

                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("Введенный символ - не буква! ;)");
                    continue;
                }

                if (letter < 'а' || letter > 'я')
                {
                    Console.WriteLine("Буквы должны быть русскими! =)");
                    continue;
                }

                if (secret.IndexOf(letter) >= 0)
                {
                    unswer.Add(letter);
                }
                else errors++;
                break;
            }
        }

        public void goodLetter()
        {
            foreach(char letter in secret)
            {
                if (unswer.Contains(letter))
                {
                    Console.Write(" " + letter);
                }
                else
                {
                    Console.Write(" _");
                }
            }
            Console.WriteLine();
        }

        public bool isVin()
        {
            foreach (char letter in secret)
            {
               if (!unswer.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public bool isLoose()
        {
                if (errors >= 6)
                {
                    return true;
                }
          return false;
        }

        public void Gallows()
        {
            Console.Clear();
            Console.WriteLine($"В слове {secret.Length} букв \n");

                Console.WriteLine("    +----+");
                Console.WriteLine("    |    |");
                Console.WriteLine("    +    |");

            if (errors >= 1)
                Console.WriteLine("    O    |");
            else
                Console.WriteLine("         |");

            if (errors >= 4)
                Console.WriteLine(@"   /|\   |");
            else if (errors == 3)
                Console.WriteLine(@"   /|    |");
            else if (errors == 2)
                Console.WriteLine(@"    |    |");
            else
                Console.WriteLine(@"         |");

            if (errors == 5)
                Console.WriteLine(@"   /     |");
            else if (errors == 6)
                Console.WriteLine(@"   / \   |");
            else
                Console.WriteLine("         |");


                Console.WriteLine("         |");
                Console.WriteLine("  +--------+ ");
                Console.WriteLine(@" /          \");
                Console.WriteLine("+------------+");
            Console.WriteLine();
        }
    }
}
