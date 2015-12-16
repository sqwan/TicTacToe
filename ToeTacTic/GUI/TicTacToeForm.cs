using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeTacTic.Events;
using ToeTacTic.Objects;

namespace ToeTacTic {
    public partial class TicTacToeForm : Form {

        private GameController controller;

        private Player player1, player2;

        public TicTacToeForm(string playername1, string playername2) {
            InitializeComponent();

            player1 = new Player(playername1, GameSymbol.Circle);
            player2 = new Player(playername2, GameSymbol.Cross);
        }

        private void TicTacToeForm_Load(object sender, EventArgs e) {
            controller = new GameController(player1, player2);

            control.FieldClicked += controller.OnFieldClick;
            controller.TurnMade += control.OnTurnMade;

            controller.NotifyGameStateChanged += OnNotifyGameStateChanged;
            controller.FireNotifyGameStateEvent();

            // Knopf setzen, weil das im Designer nicht möglich ist diese Berechnungen durchzuführen + dataGrid
            Button.SetBounds(10, ((groupBox1.Height / 4) * 3) - 10, groupBox1.Width - 20, groupBox1.Height / 4);

            // Spielernamen in die Tabelle füllen
            dataGridView1.Rows.Insert(0, player1.Name, 0, 0, GameSymbolExtension.ToFriendlyString(player1.Symbol));
            dataGridView1.Rows.Insert(1, player2.Name, 0, 0, GameSymbolExtension.ToFriendlyString(player2.Symbol));
        }

        private void TicTacToeForm_Resize(object sender, EventArgs e) {
            int width = 10;
            int height = Height - 60;
            width = height;

            control.Width = ((int)width / 3) * 3 - 2;
            control.Height = ((int)height / 3) * 3 - 2;
            control.Invalidate();

            // Groupbox neu setzen
            Point controlPoint = control.Location;
            groupBox1.SetBounds((control.Width + 2 * controlPoint.X), controlPoint.Y, (Width - control.Width - 2 * controlPoint.X - 30), Height - 60);

            // Neustart / Aufgeben Knopf validieren
            Button.SetBounds(10, ((groupBox1.Height / 4) * 3) - 10, groupBox1.Width - 20, groupBox1.Height / 4);

            // DataGrid neu setzen

        }

        private void Button_Click(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (button.Text == "Aufgeben") {
                controller.GiveUp();
                button.Text = "Neustart";
            } else if (button.Text == "Neustart") {
                // Evtl Spielernamen neu eingeben amk
                controller.ResetGameBoard();
                button.Text = "Aufgeben";
            }
        }

        private void OnNotifyGameStateChanged(Object sender, GameStateEventArgs args) {
            label2.Text = args.CurrentPlayerName;

            if (args.GameStatus == GameState.GameOver || args.GameStatus == GameState.GiveUp || args.GameStatus == GameState.Pat) {
                label2.Text = "--";
                Button.Text = "Neustart";

                // Spieler Statistik aktualisieren
                dataGridView1.Rows[0].Cells[1].Value = player1.Score.Wins;
                dataGridView1.Rows[0].Cells[2].Value = player1.Score.Defeats;

                dataGridView1.Rows[1].Cells[1].Value = player2.Score.Wins;
                dataGridView1.Rows[1].Cells[2].Value = player2.Score.Defeats;
            }

            // Abfrage welcher GameStatus gemacht wurde
            switch (args.GameStatus) {
                case GameState.GameOver:
                    MessageBox.Show(args.CurrentPlayerName + " hat das Spiel gewonnen!");
                    break;

                case GameState.GiveUp:
                    MessageBox.Show(args.CurrentPlayerName + " hat aufgegeben! :(");
                    break;

                case GameState.Pat:
                    MessageBox.Show("Niemand hat gewonnen!");
                    break;
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && Button.Text == "Neustart") {
                Dispose();

                StartForm startForm = new StartForm();
                startForm.Show();
            }
        }
    }
}
