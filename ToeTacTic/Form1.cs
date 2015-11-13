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
        private GameBoardControl control;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            control = new GameBoardControl(100, 100);
            this.Controls.Add(control);
        }

        private void Form1_Resize(object sender, EventArgs e) {
            control.Width = Width/2;
            control.Height = Height/2;
            control.Invalidate();
        }
    }
}
