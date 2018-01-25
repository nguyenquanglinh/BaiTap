using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatWinForm
{
    public class MayKhach : IKetNoi
    {
        Stream stream;

        public MayKhach()
        {
           
        }

        public string Name { get; set; }

        public void Connect()
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 9999);
                stream = client.GetStream();
            }
            catch
            {
                throw new Exception("lỗi không thể kết nối");
            }
        }

        public void Send(string cauChat)
        {
            DuLieuGuiDi(cauChat);
            NotifyChanged();
        }

        private byte[] DuLieuGuiDi(string cauChat)
        {
            var data = new byte[cauChat.Length];
            stream.Write(data, 0, cauChat.Length);
            return data;
        }

        byte[] cauChat { get; set; }

        private void Revice()
        {
            cauChat = new byte[1024];
            stream.Read(cauChat, 0, 1024);
            NotifyChanged();
        }

        public string KetQuaDem()
        {
            if (cauChat == null)
                Revice();
            var sss = Encoding.UTF8.GetString(cauChat);
            foreach (var item in sss)
            {
                
            }
            if (KiemTraKetQua(sss))
                return sss;
            return null;
        }

        private bool KiemTraKetQua(string sss)
        {
            if (sss[0] != '\0')
                return true;
            else if (sss[sss.Length] != '\0')
                return true;
            return false;
        }

        void NotifyChanged()
        {
            if (this.OnGraphChanged != null)
                OnGraphChanged(this, new EventArgs());
        }

        public event EventHandler OnGraphChanged;



    }
}
