using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Class
{
    class FindWinner
    {
        public void GetWinner(PlayerTurn[] Board)
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
            for (int i = 0; i < allWinningMoves.Length; i += 3)
            {
                if (allWinningMoves[i] != PlayerTurn.None)
                {
                    if (allWinningMoves[i] == allWinningMoves[i + 1] && allWinningMoves[i] == allWinningMoves[i + 2])
                    {
                        if (allWinningMoves[i] == PlayerTurn.Player1)
                        {
                            Turn_Winner.Winner = Winner.Player1;
                            return;
                        }
                        else
                        {
                            Turn_Winner.Winner = Winner.Player2;
                            return;
                        }
                    }
                }
            }
            foreach (var p in Board)
            {
                if (p == PlayerTurn.None)
                {
                    Turn_Winner.Winner = Winner.None;
                    return;
                }
            }
            //Draw
            Turn_Winner.Winner = Winner.Draw;
        }
    }
}
