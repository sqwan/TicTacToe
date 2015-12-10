using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToeTacTic {
    class GameController {

        private Player[] Player;
        private GameBoard Board;
        private int currentPlayer = 0;
        private GameState GameStatus = GameState.None;
        private List<TurnMadeEventArgs> turnMadeEventArgsList = new List<TurnMadeEventArgs>();

        public delegate void TurnMadeToDelegate(Object sender, List<TurnMadeEventArgs> eventArgsList);
        public event TurnMadeToDelegate TurnMade;

        public delegate void NotifyGameStateChangedDelegate(Object sender, GameStateEventArgs gameState);
        public event NotifyGameStateChangedDelegate NotifyGameStateChanged;

        public GameController(String nameOfPlayer1, String nameOfPlayer2, int boardSize = 3) {
            this.Player = new Player[2];
            this.Player[0] = new Player(nameOfPlayer1, GameSymbolType.Circle);
            this.Player[1] = new Player(nameOfPlayer2, GameSymbolType.Cross);

            this.Board = new GameBoard(new GameVerifierFactory(VerifierType.Classic), boardSize);

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
                CurrentPlayerName = this.Player[this.currentPlayer].Name,
                CurrentPlayerWins = this.Player[this.currentPlayer].Score.Wins + "",
                CurrentPlayerDefeats = this.Player[this.currentPlayer].Score.Defeats + "",
                CurrentPlayerPats = this.Player[this.currentPlayer].Score.Pats + "",
                GameStatus = this.GameStatus
            };
        }

        public void Turn(Player player, Point point) {
            if (this.GameStatus == GameState.GameOver || this.GameStatus == GameState.Pat) {
                //MessageBox.Show("Das Spiel ist um du spast!");
                return;
            }
            if (player != this.Player[this.currentPlayer]) {
                //MessageBox.Show("Chill mal. Du bist nicht dran!");
                return;
            }

            this.GameStatus = this.Board.insertMoveInGameBoard(player, point);

            if (this.GameStatus == GameState.MoveNotAllowed) {
                //MessageBox.Show("Hashtag DarfErDas?");
                return;
            }

            turnMadeEventArgsList.Add(new TurnMadeEventArgs() {
                Position = point,
                Symbol = this.Player[this.currentPlayer].Symbole,
                Color = Color.Red
            });
            TurnMade.Invoke(this, turnMadeEventArgsList);

            if (this.GameStatus == GameState.GameOver) {
                this.Player[this.currentPlayer].Score.Wins++;
                this.Player[1 - this.currentPlayer].Score.Defeats++;
                //MessageBox.Show("Gewonnen du Sohn deiner Mutter!");
                NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
                return;
            }

            if (this.GameStatus == GameState.Pat) {
                this.Player[this.currentPlayer].Score.Pats++;
                this.Player[1 - this.currentPlayer].Score.Pats++;
                //MessageBox.Show("Ihr Kacknoobs. Keiner hat gewonnen!");
                NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
                return;
            }
            this.currentPlayer = 1 - this.currentPlayer;
        }

        public void GiveUp() {
            this.GameStatus = GameState.GameOver;
            this.Player[this.currentPlayer].Score.Defeats++;
            this.Player[1 - this.currentPlayer].Score.Wins++;
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
            this.currentPlayer = 1 - this.currentPlayer;
        }

        public void ResetGameBoard() {
            Board.ClearGameBoardFieldArray();

            turnMadeEventArgsList = new List<TurnMadeEventArgs>();
            TurnMade.Invoke(this, turnMadeEventArgsList);

            this.GameStatus = GameState.None;
        }

        public void OnFieldClick(Object sender, Point point) {
            Turn(Player[currentPlayer], point);

            // Pikachu Donnerblitz
            NotifyGameStateChanged.Invoke(this, GetGameStatusAsEventArgs());
        }
    }
}
