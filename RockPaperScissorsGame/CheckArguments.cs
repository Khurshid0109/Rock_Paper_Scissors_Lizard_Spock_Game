using System;
using System.Linq;

namespace RockPaperScissorsGame
{
    public  class CheckArguments
    {
        public static bool CheckArgs(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Invalid number of options: please pass at least 3 options or more!\n");
                return false;
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Invalid number of options: please pass odd number of moves!\n");
                return false;
            }

            if (args.Length != args.Select(arg => arg.ToLower()).Distinct().Count())
            {
                Console.WriteLine("Options should be distinct. Please make sure there are no identical options.\n");
                return false;
            }

            return true;
        }
    }
}
