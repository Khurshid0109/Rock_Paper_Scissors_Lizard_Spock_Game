using System;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame
{
    class Judge
    {
        /// <summary>
        /// For deciding the result of the match
        /// </summary>
        int MovesCount;

        public Judge(int movesCount)
        {
            MovesCount = movesCount;
        }

        public Result Decide(int computer, int player)
        {
            int p = (int)Math.Floor(MovesCount / 2.0);  

            int result = Math.Sign((computer - player + p + MovesCount) % MovesCount - p);
            OverallScore.UpdateScore(result);

            if (result == -1)
                return Result.Won;

            return result == 1 ? Result.Lost : Result.Draw;
        }

        public void MatchResult(int computerMove,int playerMove)
        {
            switch (Decide(computerMove, playerMove - 1))
            {
                case Result.Won:
                    Console.WriteLine("You won!");
                    break;

                case Result.Lost:
                    Console.WriteLine("You lost!");
                    break;

                default:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }
}
