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
    public partial class StartForm : Form {
        public StartForm() {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
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

        private void StartForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ButtonStart_Click(this, e);
            }
        }
    }
}
