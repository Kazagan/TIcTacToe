using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Class
{
    class AI
    {

        public static bool CPU { get; set; }
        public static int Play { get; set; }
        public static int TakeTurn(PlayerTurn[] Board)
        {
            
            PlayerTurn[] allWinningMoves = { 
                //Rows
                Board[0], Board[1], Board[2],
                Board[3], Board[4], Board[5],
                Board[6], Board[7], Board[8],
                //Columns
                Board[0], Board[3], Board[6],
                Board[1], Board[4], Board[7],
                Board[2], Board[5], Board[8],
                //Diagnols
                Board[0], Board[4], Board[8],
                Board[2], Board[4], Board[6] };
            Random rnd = new Random();
            int random = rnd.Next(1, 10);
            if (random >= 4)
            {
                int rand = rnd.Next(0, 8);
                int play = 0;
                for (int i = 0; i < Board.Length; i++)
                {
                    if (Board[i] == PlayerTurn.None && i == rand)
                    {
                        play = rand ;
                    }
                }
                return play;
            }
            else
            {
                for (int j = 0; j < allWinningMoves.Length; j += 3)
                {
                    int play = 0;
                    if (allWinningMoves[j] != PlayerTurn.None)
                    {
                        if (allWinningMoves[j] == allWinningMoves[j+1])
                        {
                            play = j + 2;
                            return play;
                        }
                        else if (allWinningMoves[j] == allWinningMoves[j+2])
                        {
                            play = j + 1;
                            return play;
                        }                        
                    }
                }
            }            
        }
    }
}
