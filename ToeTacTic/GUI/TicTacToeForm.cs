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

    /// <summary>
    /// Diese Klasse ist die GUI des Spiels
    /// </summary>
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

            // Abbonieren der Events
            control.FieldClicked += controller.OnFieldClick;
            controller.TurnMade += control.OnTurnMade;
            controller.NotifyGameStateChanged += OnNotifyGameStateChanged;

            // Am Anfang informieren, dass der Spiel Status geändert wurde.
            controller.FireNotifyGameStateEvent();

            // Knopf setzen, weil das im Designer nicht möglich ist diese Berechnungen durchzuführen + dataGrid
            button.SetBounds(10, ((groupBox1.Height / 4) * 3) - 10, groupBox1.Width - 20, groupBox1.Height / 4);

            // Spielernamen in die Tabelle füllen
            dataGridView1.Rows.Insert(0, player1.Name, 0, 0, GameSymbolExtension.ToFriendlyString(player1.Symbol));
            dataGridView1.Rows.Insert(1, player2.Name, 0, 0, GameSymbolExtension.ToFriendlyString(player2.Symbol));
        }

        private void TicTacToeForm_Resize(object sender, EventArgs e) {
            int height = Height - 60;
            int width = height; // Die Höhe und Breite sollen immer gleich groß sein

            control.Width = ((int)width / 3) * 3 - 2;
            control.Height = ((int)height / 3) * 3 - 2 - 20;
            control.Invalidate();

            // Groupbox neu setzen
            Point controlPoint = control.Location;
            groupBox1.SetBounds((control.Width + 2 * controlPoint.X), controlPoint.Y, 270, Height - 60 - 20);
            //groupBox1.SetBounds((control.Width + 2 * controlPoint.X), controlPoint.Y, (Width - control.Width - 2 * controlPoint.X - 30), Height - 60);

            // Neustart / Aufgeben Knopf validieren
            button.SetBounds(10, ((groupBox1.Height / 4) * 3) - 10, groupBox1.Width - 20, groupBox1.Height / 4);

            groupBox2.SetBounds((control.Width + groupBox1.Width + 3 * controlPoint.X), controlPoint.Y, (Width - 270 - control.Width - 3 * controlPoint.X - 30), Height - 60 - 20);
        }

        private void Button_Click(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (button.Text == "Aufgeben") {
                controller.GiveUp();
                button.Text = "Neustart";
                resetToolStripMenuItem.Text = "Neustart";
            } else if (button.Text == "Neustart") {
                controller.ResetGameBoard();
                button.Text = "Aufgeben";
                resetToolStripMenuItem.Text = "Aufgeben";
                logListBox.Items.Clear();
            }
        }

        private void OnNotifyGameStateChanged(Object sender, GameStateEventArgs args) {
            label2.Text = args.LastPlayerName;

            if (args.GameStatus == GameState.GameOver || args.GameStatus == GameState.GiveUp || args.GameStatus == GameState.Pat) {
                label2.Text = "--";
                button.Text = "Neustart";

                // Spieler Statistik aktualisieren
                dataGridView1.Rows[0].Cells[1].Value = player1.Score.Wins;
                dataGridView1.Rows[0].Cells[2].Value = player1.Score.Defeats;

                dataGridView1.Rows[1].Cells[1].Value = player2.Score.Wins;
                dataGridView1.Rows[1].Cells[2].Value = player2.Score.Defeats;
                dataGridView1.EndEdit();
            }

            // Spielzüge loggen
            if ((args.Position.X > -1 && args.Position.Y > -1))
            {
                // TODO: 'Dirty' Hack ersetzen (Event aus GameController.OnFieldClick nach GameController.Turn verschieben)
                string message = "Spieler '" + args.CurrentPlayerName + "' => ( " + (args.Position.Y + 1) + " | " + (args.Position.X + 1) + " )";
                if (!logListBox.Items.Contains(message))
                {
                    logListBox.Items.Add(message);
                }
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
            // Wenn aufgegeben wurde, ist es möglich mit einem Rechtsklick neue Spielernamen einzugeben. 
            if (e.Button == MouseButtons.Right && button.Text == "Neustart") {
                Dispose();

                StartForm startForm = new StartForm();
                startForm.Show();
            }
        }

        private void TicTacToeForm_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Möchten Sie die bestehende Sitzung wirklich beenden?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) {
                e.Cancel = true;
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resetToolStripMenuItem.Text == "Aufgeben")
            {
                controller.GiveUp();
                resetToolStripMenuItem.Text = "Neustart";
                button.Text = "Neustart";
            }
            else if (resetToolStripMenuItem.Text == "Neustart")
            {
                controller.ResetGameBoard();
                resetToolStripMenuItem.Text = "Aufgeben";
                button.Text = "Aufgeben";
                logListBox.Items.Clear();
            }
        }

        private void aboutInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Über dieses Programm:\n*************************\nEs handelt sich hierbei um eine Tic Tac Toe Implementation, die im Rahmen eines Schulprojektes entstanden ist.\n\nBeschreibung:\n***************\nSchule: Georg-Simon-Ohm Berufskolleg\nKlasse: FIA41\nFach: Anwendungsentwicklung\nLehrer: Herr Folkmann\nTechnologien: C# .NET, WinForms, GDI+\n\n(c) 2015 by Marian Ebert, Jan Höck & Thomas Schumacher. Alle Rechte vorbehalten.", "About us", MessageBoxButtons.OK);
        }
    }
}
