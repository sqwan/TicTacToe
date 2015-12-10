using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToeTacTic {

    class GameVerifier {

        private GameBoardField[,] GameBoardArray;
        public GameVerifier(GameBoard board) {
            this.GameBoardArray = board.GameBoardArray;
        }

        public Boolean IsGameOver() {
            for (int columnAndRowNumber = 0; columnAndRowNumber < 3; columnAndRowNumber++) {
                if (isRowComplete(columnAndRowNumber) || isColumnComplete(columnAndRowNumber)) {
                    return true;
                }
            }

            return isDiagonalComplete();
        }

        public Boolean isPat() {
            if (this.IsGameOver()) {
                return false;
            }

            for (int row = 0; row < 3; row++) {
                for (int column = 0; column < 3; column++) {
                    if (GameBoardArray[row, column].selectedByPlayer == null) {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean IsMoveAllowed(Point atPosition) {
            int boardSize = GameBoardArray.GetLength(0);

            if (boardSize < atPosition.X || boardSize < atPosition.Y)
                return false;

            if (atPosition.X < 0 || atPosition.Y < 0)
                return false;

            return (GameBoardArray[atPosition.X, atPosition.Y].selectedByPlayer == null);
        }

        private Boolean isRowComplete(int rowNumber) {
            if (GameBoardArray[rowNumber, 0].selectedByPlayer == GameBoardArray[rowNumber, 1].selectedByPlayer && GameBoardArray[rowNumber, 1].selectedByPlayer == GameBoardArray[rowNumber, 2].selectedByPlayer && GameBoardArray[rowNumber, 0].selectedByPlayer != null)
                return true;
            return false;
        }

        private Boolean isColumnComplete(int columnNumber) {
            if (GameBoardArray[0, columnNumber].selectedByPlayer == GameBoardArray[1, columnNumber].selectedByPlayer && GameBoardArray[1, columnNumber].selectedByPlayer == GameBoardArray[2, columnNumber].selectedByPlayer && GameBoardArray[0, columnNumber].selectedByPlayer != null)
                return true;
            return false;
        }

        private Boolean isDiagonalComplete() {
            Boolean diagonalComplete = false;

            // Überprüfen, ob von oben Links bis unten Rechts die gleichen Symbole sind
            if (GameBoardArray[0, 0].selectedByPlayer != null) {
                diagonalComplete = true;

                for (int i = 0; i < 2; i++) {
                    if (GameBoardArray[i, i].selectedByPlayer != GameBoardArray[i + 1, i + 1].selectedByPlayer)
                        diagonalComplete = false;
                }
            }

            if (GameBoardArray[0, 2].selectedByPlayer != null && !diagonalComplete) {
                diagonalComplete = true;

                for (int i = 0; i < 2; i++) {
                    if (GameBoardArray[i, 2 - i].selectedByPlayer != GameBoardArray[i + 1, 2 - (i + 1)].selectedByPlayer)
                        diagonalComplete = false;
                }
            }
            return diagonalComplete;
        }
    }
}
