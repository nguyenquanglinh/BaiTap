using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayKhach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10000; i++)
            {
                KhungChat.AppendText(i.ToString() + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhungChat.AppendText(textBox1.Text + "\n");
        }
    }
}
