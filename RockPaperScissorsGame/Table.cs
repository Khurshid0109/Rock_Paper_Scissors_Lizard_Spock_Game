using System;
using System.Linq;
using ConsoleTables;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame
{
    /// <summary>
    /// For generating the table
    /// </summary>
    class Table
    {
        string[] Options;
        public Table(string[] options)
        {
            Options = options;
        }

        public void Print()
        {
            var headerItems = Options.Prepend("PC \\ User");
            var table = new ConsoleTable(headerItems.ToArray());

            var judge = new Judge(Options.Length);

            for (int i = 0; i < Options.Length; i++)
            {
                var currentRow = new string[Options.Length + 1];
                currentRow[0] = Options[i];
            
                for (int j = 0; j < Options.Length; j++)
                {
                    currentRow[j + 1] = Enum.GetName(typeof(Result), judge.Decide(i, j));
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}
