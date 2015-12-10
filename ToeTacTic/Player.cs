using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic {
    class Player {
        public String Name {
            get;
            set;
        }
        public GameScore Score {
            get;
            set;
        }
        public GameSymbolType Symbole {
            get;
            set;
        }

        public Player(String name, GameSymbolType symbole) {
            this.Name = name;
            this.Symbole = symbole;
            this.Score = new GameScore();
        }
    }
}
