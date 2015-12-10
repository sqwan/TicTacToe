using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ToeTacTic {
    class GameBoard {

        public GameBoardField[,] GameBoardArray {
            get;
            private set;
        }
        private GameVerifier Verifier;

        public GameBoard(GameVerifierFactory verifierFactory, int rowsAndColums = 3) {
            this.GameBoardArray = new GameBoardField[rowsAndColums, rowsAndColums];
            this.Verifier = verifierFactory.getVerifier(this);

            // Array  befüllen
            ClearGameBoardFieldArray();
        }

        public void ClearGameBoardFieldArray() {
            for (int i = 0; i < GameBoardArray.GetLength(0); i++) {
                for (int j = 0; j < GameBoardArray.GetLength(1); j++) {
                    this.GameBoardArray[i, j] = new GameBoardField();
                }
            }   
        }

        public GameState insertMoveInGameBoard(Player player, Point position) {
            if (!this.Verifier.IsMoveAllowed(position)) {
                return GameState.MoveNotAllowed;
            }

            this.GameBoardArray[position.X, position.Y].selectedByPlayer = player;

            if (this.Verifier.IsGameOver()) {
                return GameState.GameOver;
            }
            if (this.Verifier.isPat()) {
                return GameState.Pat;
            }
            return GameState.None;
        }
    }
}