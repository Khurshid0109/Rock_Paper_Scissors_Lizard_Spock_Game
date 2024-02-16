using System;
using System.Security.Cryptography;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // For checking the arguments
             if (!CheckArguments.CheckArgs(args))
                return;

            Console.WriteLine("Hello there.We will enjoy together! Lets start!\n");

            var sec = new Security();
            var a = new Table(args);                       
            var judge = new Judge(args.Length);

            bool gameFinished = false;  

            while (!gameFinished)
            {
                var key = sec.GenerateKey();
                var computerMove = RandomNumberGenerator.GetInt32(args.Length);
                var hmac = sec.GenerateHMAC(key, args[computerMove]);

                Console.WriteLine("HMAC: " + hmac);

                Console.WriteLine("Available Moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(i + 1 + " - " + args[i]);
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine("! - Score");
                Console.WriteLine("? - Help");

                Console.Write("Enter your move: ");
                var ans = Console.ReadLine();

                if (ans == "?")
                {
                    a.Print();
                    Console.WriteLine("");
                    continue;
                }
                else if (ans == "0")
                {
                    gameFinished = true;
                    OverallScore.DisplayScore();
                    OverallScore.ResetScore();
                    Console.WriteLine("Goodby.Have a nice day!");
                    continue;
                }
                else if(ans == "!")
                {
                    OverallScore.DisplayScore();
                    continue;
                }

                int playerMove = 0;

                if (!int.TryParse(ans, out playerMove) || playerMove <= 0 || playerMove > args.Length)
                {
                    Console.WriteLine("");
                    continue;
                }

                Console.WriteLine("Your move: " + args[playerMove - 1]);
                Console.WriteLine("Computer move: " + args[computerMove]);

                judge.MatchResult(computerMove, playerMove);

                Console.WriteLine("HMAC key: " + key +"\n");
             }
        }
    }
}
