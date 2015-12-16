using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToeTacTic.Objects;

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
        public GameSymbol Symbol {
            get;
            set;
        }

        public Player(String name, GameSymbol symbole) {
            this.Name = name;
            this.Symbol = symbole;
            this.Score = new GameScore();
        }
    }
}
