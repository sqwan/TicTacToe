using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic {
    public class GameStateEventArgs {
        public string CurrentPlayerName;
        public string CurrentPlayerWins;
        public string CurrentPlayerDefeats;
        public string CurrentPlayerPats;
        public GameState GameStatus;
    }
}
