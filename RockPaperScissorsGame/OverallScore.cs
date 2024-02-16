using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame
{
    public static class OverallScore
    {
        public static Dictionary<string, int> Score = new Dictionary<string, int> { { "Player",0},{"Computer",0 } };

        public static void UpdateScore(int x)
        {
            if (x == 0)
            {
                Score["Player"]++;
                Score["Computer"]++;
            }
            else
                Score[(x == -1) ? "Player" : "Computer"]++;
        }

        public static void DisplayScore()
        {
           Console.WriteLine("You: " + Score["Player"] + "  Computer: " + Score["Computer"]+"\n");
        }

        public static void ResetScore()
        {
            Score["Player"] = 0;
            Score["Computer"] = 0;
        }
    }
}
