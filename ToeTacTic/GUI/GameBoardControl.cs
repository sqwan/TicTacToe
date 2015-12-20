using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeTacTic.Objects;
using ToeTacTic.Events;

namespace ToeTacTic {

    /// <summary>
    /// Dieses Benutzersteuerelement stellt die GUI des Spielfeldes dar
    /// </summary>
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

            // Durch das Spielfeld gehen und die Linien zeichnen
            for (int column = 0; column < 3; column++) {
                for (int row = 0; row < 3; row++) {
                    graphics.DrawRectangle(new Pen(Brushes.Black), positionX, positionY, rectWidth, rectHeight);

                    positionX += rectWidth;
                }
                positionY += rectHeight;
                positionX = 0;
            }
            // Bereits gesetzte Symbole zeichnen
            PaintSymboles();
        }

        private void GameBoardControl_Click(object sender, EventArgs e) {
            int column = this.PointToClient(MousePosition).X;
            int row = this.PointToClient(MousePosition).Y;

            // Der Punkt im Spielfeld wo man geklickt hat. Ein wert 0 - 2 ist möglich
            column = column / (Width / 3);
            row = row / (Height / 3);

            // Event feuern, dass man geklickt hat
            FieldClicked.Invoke(this, new Point(row, column));
        }

        /// <summary>
        /// Alle bereits gesetzten Symbole auf dem Spielfeld malen
        /// </summary>
        public void PaintSymboles() {
            Graphics graphics = this.CreateGraphics();
            foreach (TurnMadeEventArgs eventArgs in turnMadeEventArgsList) {
                int xPosition = ((Height / 3) * eventArgs.Position.X) + 5;
                int yPosition = ((Width / 3) * eventArgs.Position.Y) + 5;

                int heightAField = Height / 3;
                int widthAField = Width / 3;

                Pen pen = new Pen(Brushes.Black, 3);
                Rectangle rec = new Rectangle(new Point(yPosition, xPosition), new Size(widthAField - 10, heightAField - 10));

                switch (eventArgs.Symbol) {
                    case GameSymbol.Circle:
                        graphics.DrawEllipse(pen, rec);
                        break;

                    case GameSymbol.Cross:
                        graphics.DrawLine(pen, new Point(yPosition, xPosition + widthAField - 10), new Point(yPosition + heightAField - 10, xPosition));
                        graphics.DrawLine(pen, new Point(yPosition + 5, xPosition + 5), new Point(yPosition + (widthAField - 10), xPosition + (widthAField - 10)));
                        break;
                }

            }
        }

        public void OnTurnMade(object sender, List<TurnMadeEventArgs> eventArgsList) {
            this.turnMadeEventArgsList = eventArgsList;
            if (turnMadeEventArgsList.Count == 0) {
                Invalidate();
            } else {
                PaintSymboles();
            }
        }

        private void GameBoardControl_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case '1':
                    FieldClicked.Invoke(this, new Point(2, 0));
                    break;
                case '2':
                    FieldClicked.Invoke(this, new Point(2, 1));
                    break;
                case '3':
                    FieldClicked.Invoke(this, new Point(2, 2));
                    break;
                case '4':
                    FieldClicked.Invoke(this, new Point(1, 0));
                    break;
                case '5':
                    FieldClicked.Invoke(this, new Point(1, 1));
                    break;
                case '6':
                    FieldClicked.Invoke(this, new Point(1, 2));
                    break;
                case '7':
                    FieldClicked.Invoke(this, new Point(0, 0));
                    break;
                case '8':
                    FieldClicked.Invoke(this, new Point(0, 1));
                    break;
                case '9':
                    FieldClicked.Invoke(this, new Point(0, 2));
                    break;
            }
        }
    }
}
