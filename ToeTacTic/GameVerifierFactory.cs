using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToeTacTic {
    class GameVerifierFactory {
        private VerifierType verifierType;

        public GameVerifierFactory(VerifierType verifierType) {
            this.verifierType = verifierType;
        }

        public GameVerifier GetVerifier(GameBoard board) {
            //return (this.verifierType == VerifierType.Classic) ? new GameVerifier(board) : new GameVerifier(board);
            return new GameVerifier(board);
        }
    }
}
