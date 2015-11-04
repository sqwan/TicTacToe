using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic
{
    class Player
    {
        public String Name { get; set; }
        public GameScore Score { get; set; }

        public Player(String name)
        {
            this.Name = name; 
        }
    }
}
