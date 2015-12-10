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

        public delegate void FieldClickedDelegate(Object sender, Point point);
        public event FieldClickedDelegate FieldClicked;

        // Diese Liste wird immer im Event neu gesetzt und ist bloß ein Abbild der Liste aus dem GameController.cs
        private List<TurnMadeEventArgs> turnMadeEventArgsList = new List<TurnMadeEventArgs>();

        public int Column {
            get;
            private set;
        }
        public int Row {
            get;
            private set;
        }

        public GameBoardControl(int height, int width) {
            InitializeComponent();
            Height = height;
            Width = width;
        }

        public GameBoardControl() {
            InitializeComponent();
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
            paintSymboles();
        }

        private void GameBoardControl_Click(object sender, EventArgs e) {
            int column = this.PointToClient(MousePosition).X;
            int row = this.PointToClient(MousePosition).Y;

            // Algorithmus ob man ein hurensohn ist
            column = column / (Width / 3);
            row = row / (Height / 3);

            //MessageBox.Show(row + " - " + column);
            FieldClicked.Invoke(this, new Point(row, column));
        }

        public void paintSymboles() {
            Graphics graphics = this.CreateGraphics();
            foreach (TurnMadeEventArgs eventArgs in turnMadeEventArgsList) {
                int xPosition = ((Height / 3) * eventArgs.Position.X) + 5;
                int yPosition = ((Width / 3) * eventArgs.Position.Y) + 5;

                Pen pen = new Pen(Brushes.Black, 3);
                Rectangle rec = new Rectangle(new Point(yPosition, xPosition), new Size((Width / 3) - 10, (Height / 3) - 10));

                switch (eventArgs.Symbol) {
                    case GameSymbolType.Circle:
                        graphics.DrawEllipse(pen, rec);
                        break;

                    case GameSymbolType.Cross:
                        graphics.DrawRectangle(pen, rec);
                        break;
                }

            }
        }

        public void OnTurnMade(object sender, List<TurnMadeEventArgs> eventArgsList) {
            this.turnMadeEventArgsList = eventArgsList;
            if (turnMadeEventArgsList.Count == 0) {
                Invalidate();
            } else {
                paintSymboles();
            }
        }
    }
}
