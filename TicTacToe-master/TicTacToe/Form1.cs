using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Class;

namespace TicTacToe
{ 

    public partial class Form : System.Windows.Forms.Form
    {
        
        PlayerTurn turn;
        Winner winner;
        int player1wins = 0; int player2wins = 0;
        void OnNewGame()
        {
            PictureBox[] board = { p0, p1, p2, p3, p4, p5, p6, p7, p8 };
            foreach (PictureBox p in board)
            {
                p.Image = null;
            }
            turn = PlayerTurn.Player1;
            winner = Winner.None;            
        }
        FindWinner findWinner = new FindWinner();
        Winner GetWinner()
        {
            PlayerTurn[] Board = BoardStatus();
            findWinner.GetWinner(Board);
            winner = Turn_Winner.Winner;
            return winner;
        }

        void ShowTurn()
        {
            string status = "";
            string msg = "";
            
            switch (winner)
            {
                case Winner.None:
                    
                    if (turn == PlayerTurn.Player1)
                    { status = "Turn: Player1"; }
                    else { status = "Turn: Player2"; }
                    break;
                case Winner.Player1:
                    msg = status = "Player 1 Wins!";
                    player1wins++;
                    Player1Wins.Text = $"{player1wins}";
                    
                    break;
                case Winner.Player2:
                    msg = status = "Player 2 Wins!";
                    player2wins++;
                    Player2Wins.Text = $"{player2wins}";
                    break;
                case Winner.Draw:
                    msg = status = "Draw!";
                        break;
            }
            LabelStatus.Text = status;
            if (msg != "")
            {
                MessageBox.Show(msg, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public Form()
        {
            InitializeComponent();
            AI.CPU = false;
        }

        private void PictureBox0_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p.Image != null)
            {
                return;
            }
            if (turn == PlayerTurn.None)
            {
                return;
            }
            if (turn == PlayerTurn.Player1)
            { p.Image = player1.Image; }

            else { p.Image = player2.Image; }
            //Check for Winner
            winner = GetWinner();
            if (winner == Winner.None)
            {
                //Change Turns
                turn = (PlayerTurn.Player1 == turn) ? PlayerTurn.Player2 : PlayerTurn.Player1;
                if (AI.CPU == false)
                {
                    return;
                }
                else
                {
                    AI.TakeTurn(BoardStatus());
                    int play = AI.Play;
                    PictureBox[] pictureBoxes = { p0, p1, p2, p3, p4, p5, p6, p7, p8 };
                    for (int i = 0; i < pictureBoxes.Length; i++)
                    {
                        if (play == i)
                        {
                            pictureBoxes[i].Image = player2.Image;
                        }
                    }
                }
            }
            else
            {
                turn = PlayerTurn.None;
            }
            ShowTurn();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to start a new game?", "NewGame", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OnNewGame();
            }
        }
        private PlayerTurn[] BoardStatus()
        {
            int i = 0;
            PictureBox[] pictureBoxes = { p0, p1, p2, p3, p4, p5, p6, p7, p8 };
            PlayerTurn[] Board = new PlayerTurn[9];
            foreach (PictureBox p in pictureBoxes)
            {
                if (p.Image == player1.Image)
                {
                    Board[i] = PlayerTurn.Player1;
                }
                else if (p.Image == player2.Image)
                {
                    Board[i] = PlayerTurn.Player2;
                }
                else
                {
                    Board[i] = PlayerTurn.None;
                }
                i++;
            }
            return Board;
        }

        private void Computer_CheckedChanged(object sender, EventArgs e)
        {
            AI.CPU = true;
        }
    }
}
