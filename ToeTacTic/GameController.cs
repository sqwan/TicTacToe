﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToeTacTic
{
    class GameController
    {
        private Player[] Player;
        private GameBoard Board;
        private GameVerifier Verifier;
        private int currentPlayer = 0;
        private Boolean isGameOver = false;

        public GameController(String nameOfPlayer1, String nameOfPlayer2, int boardSize)
        {
            this.Player = new Player[2];
            this.Player[0] = new Player(nameOfPlayer1);
            this.Player[1] = new Player(nameOfPlayer2);

            this.Board = new GameBoard(boardSize);

            this.Verifier = new GameVerifier();

            Random random = new Random();
            this.currentPlayer = random.Next(0, 2);
        }

        public void Turn(Player player, Point point)
        {
            if (isGameOver)
            {
                MessageBox.Show("Das Spiel ist um du spast!");
                return;
            }
            if (player != this.Player[this.currentPlayer])
            {
                MessageBox.Show("Chill mal. Du bist nicht dran!");
                return;
            }
            if(this.Verifier.IsMoveAllowed(this.Board, point))
            {
                MessageBox.Show("#Darf er dass?");
                return;
            }

            this.Board.insertMoveInGameBoard(player, point);

            if (this.Verifier.IsGameOver(this.Board))
            {
                this.isGameOver = true;
                this.Player[this.currentPlayer].Score.Wins++;
                this.Player[1-this.currentPlayer].Score.Defeats++;
                MessageBox.Show("Gewonnen!");
                return;
            }

            if (this.Verifier.isPat(this.Board))
            {
                this.isGameOver = true;
                this.Player[this.currentPlayer].Score.Pats++;
                this.Player[1 - this.currentPlayer].Score.Pats++;
                MessageBox.Show("Ihr Kacknoobs. Keiner hat gewonnen!");
                return;
            }
            this.currentPlayer = 1 - this.currentPlayer;
        }
    }
}
