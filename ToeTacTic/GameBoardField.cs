using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic {

    /// <summary>
    /// Diese Klasse ist für ein Spielfeld bestimmt.
    /// </summary>
    class GameBoardField {

        /// <summary>
        /// Gibt Information darüber, wer auf dieses Spielfeld geklickt hat.
        /// </summary>
        public Player SelectedByPlayer {
            get;
            set;
        }
    }
}
