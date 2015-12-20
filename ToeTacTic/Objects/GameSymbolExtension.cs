using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeTacTic.Objects {
    public static class GameSymbolExtension {

        /// <summary>
        /// Diese Methode konveriert ein GameSymbol Enum zu einem benutzbaren Zeichen
        /// </summary>
        /// <param name="gameSymbole">Das Game Symbol</param>
        /// <returns></returns>
        public static String ToFriendlyString(GameSymbol gameSymbole) {
            switch (gameSymbole) {
                case GameSymbol.Circle:
                    return "o";

                case GameSymbol.Cross:
                    return "x";
            }
            return "";
        }

    }
}
