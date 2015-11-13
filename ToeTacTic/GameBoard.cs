using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ToeTacTic
{
    class GameBoard
    {
        public GameBoardField[,] GameBoardArray { get; private set; }
        private GameVerifier Verifier;

        public GameBoard(GameVerifierFactory verifierFactory)
        {
            this.Verifier = verifierFactory.getVerifier(this); ;
            this.GameBoardArray = new GameBoardField[3, 3];
        }
        public GameBoard(int rowsAndColums, GameVerifierFactory verifierFactory)
        {
            this.Verifier = verifierFactory.getVerifier(this);
            this.GameBoardArray = new GameBoardField[rowsAndColums,rowsAndColums];
        }

        public EnumTest insertMoveInGameBoard(Player player, Point position)
        {
            if (this.Verifier.IsMoveAllowed(position))
            {
                return EnumTest.MoveNotAllowed;
            }
            
            this.GameBoardArray[position.X, position.Y].selectedByPlayer = player;

            if (this.Verifier.IsGameOver())
            {
                return EnumTest.GameOver;
            }
            if (this.Verifier.isPat())
            {
                return EnumTest.Pat;
            }
            return EnumTest.None;
        }
    }
}