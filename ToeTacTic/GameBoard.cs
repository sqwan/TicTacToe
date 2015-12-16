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
        private GameVerifier verifier;

        public GameBoard(GameVerifierFactory verifierFactory, int rowsAndColums = 3) {
            this.GameBoardArray = new GameBoardField[rowsAndColums, rowsAndColums];
            this.verifier = verifierFactory.GetVerifier(this);

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

        public GameState InsertMoveInGameBoard(Player player, Point position) {
            if (!this.verifier.IsMoveAllowed(position)) {
                return GameState.MoveNotAllowed;
            }

            this.GameBoardArray[position.X, position.Y].SelectedByPlayer = player;

            if (this.verifier.IsGameOver()) {
                return GameState.GameOver;
            }
            if (this.verifier.IsPat()) {
                return GameState.Pat;
            }
            return GameState.None;
        }
    }
}