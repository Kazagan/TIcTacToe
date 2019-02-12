using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Class
{
    enum PlayerTurn { None, Player1, Player2 };
    enum Winner { None, Player1, Player2, Draw }
    class Turn_Winner
    {
        public static PlayerTurn Turn { get; set; }
        public static Winner Winner { get; set; }
    }
}
