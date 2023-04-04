using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLGAME
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
            KeyDown += KeyDowns;
        }
        public void KeyDowns(object sender, KeyEventArgs e)
        {
            string buf_string = e.KeyCode.ToString();
            if (buf_string.Equals("Escape")) { this.Close(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
