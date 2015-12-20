using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToeTacTic {

    /// <summary>
    /// Diese Klasse ist die Startklasse des Programms
    /// Am Anfang wird der Benutzer dazu aufgefordert zwei unterschiedliche Benutzernamen
    /// einzugeben. Das Ganze bestätigt man mit ENTER oder mit der Maus.
    /// </summary>
    public partial class StartForm : Form {
        public StartForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Überprüfung ob beide Spielernamen unterschiedlich sind. Falls alles Valide ist, wird das Spiel gestartet.
        /// </summary>
        private void ButtonStart_Click(object sender, EventArgs e) {
            // Wenn aus der IDE gestartet, dann automatisch Spielernamen eingeben
            if (System.Diagnostics.Debugger.IsAttached) {
                textBox1.Text = "Rudolf";
                textBox2.Text = "Peter";
            }

            if (textBox1.Text == "" || textBox2.Text == "") {
                MessageBox.Show("Bitte gebe beide Spielernamen ein");
                return;
            }

            if (textBox1.Text == textBox2.Text) {
                MessageBox.Show("Beide Spielernamen müssen sich unterscheiden");
                return;
            }

            Visible = false;

            TicTacToeForm gameWin = new TicTacToeForm(textBox1.Text, textBox2.Text);
            gameWin.ShowDialog();

            // Dieser Teil wird erst ausgeführt, wenn der TicTacToeForm Thread beendet wurde.
            Close();
            Dispose();
        }

        /// <summary>
        /// Darauf reagieren wenn Enter geklickt wird. Dann wird die Methode StartForm.ButtonStart_Click aufgerufen.
        /// </summary>
        private void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ButtonStart_Click(this, e);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("Über dieses Programm:\n*************************\nEs handelt sich hierbei um eine Tic Tac Toe Implementation, die im Rahmen eines Schulprojektes entstanden ist.\n\nBeschreibung:\n***************\nSchule: Georg-Simon-Ohm Berufskolleg\nKlasse: FIA41\nFach: Anwendungsentwicklung\nLehrer: Herr Folkmann\nTechnologien: C# .NET, WinForms, GDI+\n\n(c) 2015 by Marian Ebert, Jan Höck & Thomas Schumacher. Alle Rechte vorbehalten.", "About us", MessageBoxButtons.OK);
        }
    }
}
