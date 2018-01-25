using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ChatWinForm
{
    public partial class Client : UserControl
    {
        public Client()
        {
            InitializeComponent();
        }
        MayKhach mayKhach;
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (txtChat.Text != null)
            {
                mayKhach.Send(txtChat.Text);
                ThemCauChat(txtChat.Text);
            }
        }

        private void ThemCauChat(string p)
        {
            KhungChat.Items.Add(p);
            txtChat.Clear();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            mayKhach = new MayKhach();
            mayKhach.Connect();
            mayKhach.OnGraphChanged += mayKhach_OnGraphChanged;
        }

        void mayKhach_OnGraphChanged(object sender, EventArgs e)
        {
            var ss = mayKhach.KetQuaDem();
            ThemCauChat(ss);

        }
    }
}
