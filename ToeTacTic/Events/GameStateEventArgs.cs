using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic.Events {
    public class GameStateEventArgs {
        public Point Position { get; set; }
        public string CurrentPlayerName { get; set; }
        public string LastPlayerName { get; set; }
        public string CurrentPlayerWins { get; set; }
        public string CurrentPlayerDefeats { get; set; }
        public string CurrentPlayerPats { get; set; }
        public GameState GameStatus { get; set; }
    }
}
