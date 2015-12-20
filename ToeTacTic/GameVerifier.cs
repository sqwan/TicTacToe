using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToeTacTic {

    /// <summary>
    /// Diese Klasse ist dazu fähig, jeden Zug zu überprüfen.
    /// </summary>
    class GameVerifier {

        private GameBoardField[,] gameBoardArray;

        public GameVerifier(GameBoard board) {
            this.gameBoardArray = board.GameBoardArray;
        }

        /// <summary>
        /// Überprüfung, ob das Spiel vorbei ist
        /// </summary>
        /// <returns></returns>
        public Boolean IsGameOver() {
            for (int columnAndRowNumber = 0; columnAndRowNumber < 3; columnAndRowNumber++) {
                if (IsRowComplete(columnAndRowNumber) || IsColumnComplete(columnAndRowNumber)) {
                    return true;
                }
            }

            return IsDiagonalComplete();
        }

        /// <summary>
        /// Überprüfung, ob ein Unentschieden erzielt wurde.
        /// </summary>
        /// <returns></returns>
        public Boolean IsPat() {
            if (this.IsGameOver()) {
                return false;
            }

            for (int row = 0; row < 3; row++) {
                for (int column = 0; column < 3; column++) {
                    if (gameBoardArray[row, column].SelectedByPlayer == null) {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Überprüfung, ob der Zug an dieser Stelle erlaubt ist. Beispiel: Dort ist bereits ein Zug gemacht wurden
        /// </summary>
        /// <param name="atPosition"></param>
        /// <returns></returns>
        public Boolean IsMoveAllowed(Point atPosition) {
            int boardSize = gameBoardArray.GetLength(0);

            if (boardSize < atPosition.X || boardSize < atPosition.Y)
                return false;

            if (atPosition.X < 0 || atPosition.Y < 0)
                return false;

            return (gameBoardArray[atPosition.X, atPosition.Y].SelectedByPlayer == null);
        }

        /// <summary>
        /// Überprüfung ob eine Reihe, mit einem Symbol vollständig ist
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        private Boolean IsRowComplete(int rowNumber) {
            if (gameBoardArray[rowNumber, 0].SelectedByPlayer == gameBoardArray[rowNumber, 1].SelectedByPlayer && gameBoardArray[rowNumber, 1].SelectedByPlayer == gameBoardArray[rowNumber, 2].SelectedByPlayer && gameBoardArray[rowNumber, 0].SelectedByPlayer != null)
                return true;
            return false;
        }

        /// <summary>
        /// Überprüfung ob eine Spalte, mit einem Symbol vollständig ist
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        private Boolean IsColumnComplete(int columnNumber) {
            if (gameBoardArray[0, columnNumber].SelectedByPlayer == gameBoardArray[1, columnNumber].SelectedByPlayer && gameBoardArray[1, columnNumber].SelectedByPlayer == gameBoardArray[2, columnNumber].SelectedByPlayer && gameBoardArray[0, columnNumber].SelectedByPlayer != null)
                return true;
            return false;
        }

        /// <summary>
        /// Überprüfung ob eine Diagonale, mit einem Symbol vollständig ist.
        /// </summary>
        /// <returns></returns>
        private Boolean IsDiagonalComplete() {
            Boolean diagonalComplete = false;

            // Überprüfen, ob von oben Links bis unten Rechts die gleichen Symbole sind
            if (gameBoardArray[0, 0].SelectedByPlayer != null) {
                diagonalComplete = true;

                for (int i = 0; i < 2; i++) {
                    if (gameBoardArray[i, i].SelectedByPlayer != gameBoardArray[i + 1, i + 1].SelectedByPlayer)
                        diagonalComplete = false;
                }
            }

            // Überprüfen ob von oben Rechts bis unten Links die gleichen Symbole sind
            if (gameBoardArray[0, 2].SelectedByPlayer != null && !diagonalComplete) {
                diagonalComplete = true;

                for (int i = 0; i < 2; i++) {
                    if (gameBoardArray[i, 2 - i].SelectedByPlayer != gameBoardArray[i + 1, 2 - (i + 1)].SelectedByPlayer)
                        diagonalComplete = false;
                }
            }
            return diagonalComplete;
        }
    }
}
