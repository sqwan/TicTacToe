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
            if (board.GameBoardArray[0, 0] == board.GameBoardArray[1, 0] && board.GameBoardArray[1, 0] == board.GameBoardArray[2, 0])
                return true;

            return false;
        }

        public Boolean VerifyMove(GameBoard board, Point atPosition)
        {
            return false;
        }

        private Boolean CheckRow(int row)
        {
            return false;
        }

        private Boolean CheckColumn(int column)
        {
            return false;
        }

        private Boolean CheckDiagonalen()
        {
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

            for (int j = 0; j < 3; j++)
            {
                GameBoard gb1 = new GameBoard();
                for (int i = 0; i < 3; i++)
                {
                    gb1.insertMoveInGameBoard(p1, new Point(i, j));
                }

                if (!this.IsGameOver(gb1))
                {
                    MessageBox.Show("Failed at: " + j);
                    return;
                }
            }
        }
#endregion

    }
}
