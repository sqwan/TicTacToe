using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic {
    public enum GameState {
        MoveNotAllowed = 0,
        MoveAllowed = 1,
        MoveDone = 2,
        GameOver = 3,
        Pat = 4,
        None = 5,
        Restart = 6,
        GiveUp = 7
    }
}
