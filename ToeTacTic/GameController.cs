using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeTacTic.Events;

namespace ToeTacTic {
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

        public void Turn(Player player, Point point) {
            if (this.gameState == GameState.GameOver || this.gameState == GameState.Pat) {
                //MessageBox.Show("Das Spiel ist um du spast!");
                return;
            }
            if (player != this.player[this.currentPlayer]) {
                //MessageBox.Show("Chill mal. Du bist nicht dran!");
                return;
            }

            this.gameState = this.board.InsertMoveInGameBoard(player, point);

            if (this.gameState == GameState.MoveNotAllowed) {
                //MessageBox.Show("Hashtag DarfErDas?");
                return;
            }

            turnMadeEventArgsList.Add(new TurnMadeEventArgs() {
                Position = point,
                Symbol = this.player[this.currentPlayer].Symbol,
                Color = Color.Red
            });
            TurnMade.Invoke(this, turnMadeEventArgsList);

            if (this.gameState == GameState.GameOver) {
                this.player[this.currentPlayer].Score.Wins++;
                this.player[1 - this.currentPlayer].Score.Defeats++;
                return;
            }

            if (this.gameState == GameState.Pat) {
                this.player[this.currentPlayer].Score.Pats++;
                this.player[1 - this.currentPlayer].Score.Pats++;
                return;
            }
            this.currentPlayer = 1 - this.currentPlayer;
        }

        public void GiveUp() {
            this.gameState = GameState.GiveUp;
            this.player[this.currentPlayer].Score.Defeats++;
            this.player[1 - this.currentPlayer].Score.Wins++;
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }

        public void ResetGameBoard() {
            this.gameState = GameState.Restart;

            board.ClearGameBoardFieldArray();

            turnMadeEventArgsList = new List<TurnMadeEventArgs>();
            TurnMade.Invoke(this, turnMadeEventArgsList);

            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }

        public void OnFieldClick(Object sender, Point point) {
            Turn(player[currentPlayer], point);

            // Pikachu Donnerblitz
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }
    }
}
