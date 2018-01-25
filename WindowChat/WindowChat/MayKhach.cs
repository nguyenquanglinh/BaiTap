using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowChat
{
    public partial class MayKhach : Form
    {
        public MayKhach()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        IPEndPoint ip;
        Socket client;
        const int Port = 2302;

        void MoKetNoi()
        {
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(ip);
            }
            catch
            {
                MessageBox.Show("không thể kết nối đến sever");
                return;
            }
            Thread listen = new Thread(NhanTinVe);
            listen.IsBackground = true;
            listen.Start();

        }

        void DongKetNoi()
        {
            client.Close();
        }

        void GuiTinDi()
        {
            if (txtCauChat.Text != null)
                client.Send(XuLyDuLieuDi(txtCauChat.Text));
            else MessageBox.Show("tin rong");
        }

        void NhanTinVe()
        {
            try
            {
                while (true)
                {
                    var data = new byte[1024];
                    client.Receive(data);
                    var cauChat = XuLyDuLieuDen(data);
                    ThemCauChat(cauChat);
                }
            }
            catch
            {
                client.Close();
            }
        }

        void ThemCauChat(string cauChat)
        {
            KhungChat.Items.Add(cauChat);
            txtCauChat.Clear();
        }

        byte[] XuLyDuLieuDi(object obj)
        {
            var stream = new MemoryStream();
            var formater = new BinaryFormatter();
            formater.Serialize(stream, obj);
            return stream.ToArray();
        }

        string XuLyDuLieuDen(byte[] data)
        {
            var stream = new MemoryStream(data);
            var formater = new BinaryFormatter();
            return (string)formater.Deserialize(stream);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DongKetNoi();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            GuiTinDi();
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            MoKetNoi();
            btnSend.Enabled = true;
        }
    }
}
