using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToeTacTic {
    public class TurnMadeEventArgs {
        public Point Position {get;set;}
        public Color Color {get;set;}
        public GameSymbolType Symbol {get;set;}
    }
}
