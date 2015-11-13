using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToeTacTic
{
    class GameVerifierFactory
    {
        VerifierType verifierType;

        public GameVerifierFactory(VerifierType verifierType)
        {
            this.verifierType = verifierType;
        }

        public GameVerifier getVerifier(GameBoard board)
        {
            //return (this.verifierType == VerifierType.Classic) ? new GameVerifier(board) : new GameVerifier(board);
            return new GameVerifier(board);
        }
    }
}
