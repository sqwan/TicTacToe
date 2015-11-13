using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToeTacTic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GameVerifier gv = new GameVerifier();
            //gv.TestIsGameOver();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(black, 2);

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    graphics.DrawRectangle(blackPen, 5 + row * 55, 5 + column * 55, 50, 50);
                }
            }
        }
    }
}
