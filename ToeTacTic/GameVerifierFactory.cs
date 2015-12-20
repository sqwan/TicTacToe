using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToeTacTic {

    /// <summary>
    /// Mit dieser Klasse bestimmt man den GameVerifier. Es ist also möglich andere Spielregeln für das Spiel festzulegen.
    /// </summary>
    class GameVerifierFactory {
        private VerifierType verifierType;

        public GameVerifierFactory(VerifierType verifierType) {
            this.verifierType = verifierType;
        }

        public GameVerifier GetVerifier(GameBoard board) {
            if (this.verifierType == VerifierType.Classic) {
                return new GameVerifier(board);
            }
            // Da wir derzeit nur einen Verifier haben, muss das so bleiben
            return new GameVerifier(board);
        }
    }
}
