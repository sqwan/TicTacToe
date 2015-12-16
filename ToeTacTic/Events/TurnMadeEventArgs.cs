using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToeTacTic.Objects;

namespace ToeTacTic.Events {
    public class TurnMadeEventArgs {
        public Point Position {get;set;}
        public Color Color {get;set;}
        public GameSymbol Symbol {get;set;}
    }
}
