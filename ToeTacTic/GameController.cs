using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeTacTic.Events;

namespace ToeTacTic {

    /// <summary>
    /// Diese Klasse ist unabhänig von der GUI. Sie kennt die Spieler, den aktuellen Game Status.
    /// Zudem hat sie die Möglichkeit ein Spiel zu beenden und auf einen Spielzug zu reagieren.
    /// Sie kann das Spiel auch komplett zurücksetzen
    /// </summary>
    class GameController {

        private Player[] player;
        private GameBoard board;
        private GameState gameState = GameState.None;
        private int currentPlayer = 0;

        private List<TurnMadeEventArgs> turnMadeEventArgsList = new List<TurnMadeEventArgs>();

        public delegate void TurnMadeToDelegate(Object sender, List<TurnMadeEventArgs> eventArgsList);
        public event TurnMadeToDelegate TurnMade;

        public delegate void NotifyGameStateChangedDelegate(Object sender, GameStateEventArgs gameState);
        public event NotifyGameStateChangedDelegate NotifyGameStateChanged;

        public GameController(Player player1, Player player2, int boardSize = 3) {
            this.player = new Player[2] { player1, player2 };

            this.board = new GameBoard(new GameVerifierFactory(VerifierType.Classic), boardSize);

            Random random = new Random();
            this.currentPlayer = random.Next(0, 2);
        }

        public void FireNotifyGameStateEvent() {
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }

        /*
         * Diese Methode liefert den aktuellen GameStatus zurück 
         * 
         */
        public GameStateEventArgs GetGameStatusAsEventArgs() {
            return new GameStateEventArgs() {
                CurrentPlayerName = this.player[this.currentPlayer].Name,
                CurrentPlayerWins = this.player[this.currentPlayer].Score.Wins + "",
                CurrentPlayerDefeats = this.player[this.currentPlayer].Score.Defeats + "",
                CurrentPlayerPats = this.player[this.currentPlayer].Score.Pats + "",
                GameStatus = this.gameState
            };
        }

        /// <summary>
        /// Diese Methode handelt einen Zug von einem Spieler ab.
        /// Sie überprüft den aktuellen Spiel Status und fügt einen Zug auf das Spielfeld ein.
        /// </summary>
        /// <param name="player">Der aktuelle Spieler</param>
        /// <param name="point">Die Stelle wo der aktuelle Spieler einen Zug gemacht hat</param>
        public void Turn(Player player, Point point) {
            // Abfrage ob das Spiel bereits um ist bzw. ob ein Unentschieden erzielt wurde
            if (this.gameState == GameState.GameOver || this.gameState == GameState.Pat) {
                return;
            }

            // Überprüfen, ob der Zug von dem aktuellen Spieler gemacht wurde
            if (player != this.player[this.currentPlayer]) {
                return;
            }

            // Das Spielfeld darüber informieren, dass ein Zug gemacht wurde
            this.gameState = this.board.InsertMoveInGameBoard(player, point);

            if (this.gameState == GameState.MoveNotAllowed) {
                return;
            }

            // Die Interessenten darüber informieren, dass ein Zug gemacht wurde
            turnMadeEventArgsList.Add(new TurnMadeEventArgs() {
                Position = point,
                Symbol = this.player[this.currentPlayer].Symbol,
                Color = Color.Red
            });
            TurnMade.Invoke(this, turnMadeEventArgsList);

            // Wenn das Spiel vorbei ist, wird die Statistik hochgezählt
            if (this.gameState == GameState.GameOver) {
                this.player[this.currentPlayer].Score.Wins++;
                this.player[1 - this.currentPlayer].Score.Defeats++;
                return;
            }

            // Wenn ein Unentschieden erzielt wurde, dann die Statistik hochzähhlen
            if (this.gameState == GameState.Pat) {
                this.player[this.currentPlayer].Score.Pats++;
                this.player[1 - this.currentPlayer].Score.Pats++;
                return;
            }
            this.currentPlayer = 1 - this.currentPlayer;
        }

        /// <summary>
        /// Der aktuelle Spieler gibt das Spiel auf. Das Spielfeld wird dadurch nicht geleert.
        /// </summary>
        public void GiveUp() {
            this.gameState = GameState.GiveUp;
            this.player[this.currentPlayer].Score.Defeats++;
            this.player[1 - this.currentPlayer].Score.Wins++;
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }

        /// <summary>
        /// Das Spielfeld wird geleert. Die Statistiken bleiben weiterhin bestehen.
        /// </summary>
        public void ResetGameBoard() {
            this.gameState = GameState.Restart;

            board.ClearGameBoardFieldArray();

            turnMadeEventArgsList = new List<TurnMadeEventArgs>();
            TurnMade.Invoke(this, turnMadeEventArgsList);

            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }

        /// <summary>
        /// Diese Methode reagiert darauf, wenn ein Spieler eine Aktion gemacht hat.
        /// </summary>
        /// <param name="sender">Die Klasse, die diese Methode aufgerufen hat.</param>
        /// <param name="point">Der geklickte Point</param>
        public void OnFieldClick(Object sender, Point point) {
            Turn(player[currentPlayer], point);

            // Event feuern
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }
    }
}
