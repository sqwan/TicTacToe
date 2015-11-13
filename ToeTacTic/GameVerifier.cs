using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToeTacTic
{
    class GameVerifier
    {
        private GameBoardField[,] GameBoardArray;
        public GameVerifier(GameBoard board)
        {
            this.GameBoardArray = board.GameBoardArray;
        }
        public Boolean IsGameOver()
        {
            for (int columnAndRowNumber = 0; columnAndRowNumber < 3; columnAndRowNumber++)
            {
                if (isRowComplete(columnAndRowNumber) || isColumnComplete(columnAndRowNumber))
                {
                    return true;
                }
            }

            return isDiagonalComplete();
        }
        public Boolean isPat()
        {
            if (this.IsGameOver())
            {
                return false; 
            }

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (GameBoardArray[row, column].selectedByPlayer == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean IsMoveAllowed(Point atPosition)
        {
            int boardSize = GameBoardArray.GetLength(0);

            if (boardSize < atPosition.X || boardSize < atPosition.Y)
                return false;

            if (atPosition.X < 0 || atPosition.Y < 0)
                return false;

           return (GameBoardArray[atPosition.X, atPosition.Y].selectedByPlayer == null);
        }

        private Boolean isRowComplete(int rowNumber)
        {
            if (GameBoardArray[rowNumber, 0].selectedByPlayer == GameBoardArray[rowNumber, 1].selectedByPlayer && GameBoardArray[rowNumber, 1].selectedByPlayer == GameBoardArray[rowNumber, 2].selectedByPlayer && GameBoardArray[rowNumber, 0].selectedByPlayer != null)
                return true;
            return false;
        }

        private Boolean isColumnComplete(int columnNumber)
        {
            if (GameBoardArray[0, columnNumber] == GameBoardArray[1, columnNumber] && GameBoardArray[1, columnNumber] == GameBoardArray[2, columnNumber] && GameBoardArray[0, columnNumber] != null)
                return true;
            return false;
        }

        private Boolean isDiagonalComplete()
        {
            if (GameBoardArray[0, 0] == GameBoardArray[1, 1] && GameBoardArray[1, 1] == GameBoardArray[2, 2] && GameBoardArray[0, 0] != null)
                return true;
            if (GameBoardArray[0, 2] == GameBoardArray[1, 1] && GameBoardArray[1, 1] == GameBoardArray[2, 0] && GameBoardArray[0, 2] != null)
                return true;
            return false;
        }

        /*
#region Test
        public void TestVerifyMove()
        {
        }
        public void TestIsGameOver()
        {
            Player p1 = new Player("Spieler 1");
            Player p2 = new Player("Spieler 2");

            //is testing the if a row is completet by one player
            for (int row = 0; row < 3; row++)
            {
                GameBoard gb1 = new GameBoard();
                for (int column = 0; column < 3; column++)
                {
                    gb1.insertMoveInGameBoard(p1, new Point(row, column));
                }

                if (!this.IsGameOver(gb1))
                {
                    MessageBox.Show("Failed in row: " + row);
                    return;
                }
            }

            for (int column = 0; column < 3; column++)
            {
                GameBoard gb1 = new GameBoard();
                for (int row = 0; row < 3; row++)
                {
                    gb1.insertMoveInGameBoard(p1, new Point(row, column));
                }

                if (!this.IsGameOver(gb1))
                {
                    MessageBox.Show("Failed in column: " + column);
                    return;
                }
            }
        }
#endregion
        */
    }
}
