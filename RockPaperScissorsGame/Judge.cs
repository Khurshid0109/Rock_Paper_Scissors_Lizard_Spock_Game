using System;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame
{
    class Judge
    {
        int MovesCount;

        public Judge(int movesCount)
        {
            MovesCount = movesCount;
        }

        public Result Decide(int computer, int player)
        {
            int p = (int)Math.Floor(MovesCount / 2.0);  

            int result = Math.Sign((computer - player + p + MovesCount) % MovesCount - p);

            //if (computer == player)
            //{
            //    return Result.Draw;
            //}

            //if ((player > computer && player - computer <= MovesCount / 2) || (player < computer && computer - player > MovesCount / 2.0))
            //{
            //    return Result.Won;
            //}

            //return Result.Lost;

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
