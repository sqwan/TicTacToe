using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToeTacTic {
    public partial class GameBoardControl : UserControl {

        private int offset = 0;
        public int Column { get; private set; }
        public int Row { get; private set; }

        public GameBoardControl(int height, int width) {
            InitializeComponent();
            Height = height;
            Width = width;
        }

        public GameBoardControl() {
            //InitializeComponent();
        }

        private void GameBoardControl_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);

            int positionX = 0;
            int positionY = 0;
            int rectWidth = Width / 3;
            int rectHeight = Height / 3;

            for (int column = 0; column < 3; column++) {
                for (int row = 0; row < 3; row++) {
                    graphics.DrawRectangle(new Pen(Brushes.Black), positionX, positionY, rectWidth, rectHeight);

                    positionX += rectWidth;
                }
                positionY += rectHeight;
                positionX = 0;
            }
        }

        private void GameBoardControl_Click(object sender, EventArgs e) {
            int column = this.PointToClient(MousePosition).X;
            int row = this.PointToClient(MousePosition).Y;

            // Algorithmus ob man ein hurensohn ist
            column = column / (Width / 3);
            row = row / (Height/ 3);

            MessageBox.Show(row + " - " + column);
        }

    }
}
