using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic {
    public enum GameState {
        MoveNotAllowed,
        MoveAllowed,
        MoveDone,
        GameOver,
        Pat,
        None,
        Restart,
        GiveUp
    }
}
