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
        public Boolean IsGameOver(GameBoard board)
        {
            for (int columnAndRowNumber = 0; columnAndRowNumber < 3; columnAndRowNumber++)
            {
                if (isRowComplete(columnAndRowNumber, board) || isColumnComplete(columnAndRowNumber, board))
                {
                    return true;
                }
            }

            return isDiagonalComplete(board);
        }
        public Boolean isPat(GameBoard board)
        {
            if (this.IsGameOver(board))
            {
                return false; 
            }

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (board.GameBoardArray[row, column] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean IsMoveAllowed(GameBoard board, Point atPosition)
        {
            int boardSize = board.GameBoardArray.GetLength(0);

            if (boardSize < atPosition.X || boardSize < atPosition.Y)
                return false;

            if (atPosition.X < 0 || atPosition.Y < 0)
                return false;

           return (board.GameBoardArray[atPosition.X, atPosition.Y] == null);
        }

        private Boolean isRowComplete(int rowNumber, GameBoard inGameBoard)
        {
            if (inGameBoard.GameBoardArray[rowNumber, 0] == inGameBoard.GameBoardArray[rowNumber, 1] && inGameBoard.GameBoardArray[rowNumber, 1] == inGameBoard.GameBoardArray[rowNumber, 2] && inGameBoard.GameBoardArray[rowNumber, 0] != null)
                return true;
            return false;
        }

        private Boolean isColumnComplete(int columnNumber, GameBoard inGameBoard)
        {
            if (inGameBoard.GameBoardArray[0, columnNumber] == inGameBoard.GameBoardArray[1, columnNumber] && inGameBoard.GameBoardArray[1, columnNumber] == inGameBoard.GameBoardArray[2, columnNumber] && inGameBoard.GameBoardArray[0, columnNumber] != null)
                return true;
            return false;
        }

        private Boolean isDiagonalComplete(GameBoard inGameBoard)
        {
            if (inGameBoard.GameBoardArray[0, 0] == inGameBoard.GameBoardArray[1, 1] && inGameBoard.GameBoardArray[1, 1] == inGameBoard.GameBoardArray[2, 2] && inGameBoard.GameBoardArray[0, 0] != null)
                return true;
            if (inGameBoard.GameBoardArray[0, 2] == inGameBoard.GameBoardArray[1, 1] && inGameBoard.GameBoardArray[1, 1] == inGameBoard.GameBoardArray[2, 0] && inGameBoard.GameBoardArray[0, 2] != null)
                return true;
            return false;
        }


#region Test
        public void TestVerifyMove()
        {
        }
        public void TestIsGameOver()
        {
            Player p1 = new Player();
            Player p2 = new Player();

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

    }
}
