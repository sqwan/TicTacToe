using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ToeTacTic
{
    class GameBoard
    {
        public Player[,] GameBoardArray { get; private set; }

        public GameBoard()
        {
            this.GameBoardArray = new Player[3, 3];
        }
        public GameBoard(int rowsAndColums)
        {
            this.GameBoardArray = new Player[rowsAndColums,rowsAndColums];
        }

        public void insertMoveInGameBoard(Player player, Point position)
        {
            this.GameBoardArray[position.X, position.Y] = player;
        }
    }
}