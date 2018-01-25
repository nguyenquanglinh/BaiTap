using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace ChatWinForm
{
    public class MayChu
    {
        public MayChu()
        {
            cacMayKhach = new List<MayKhach>();
        }

        List<MayKhach> cacMayKhach;

        Stream stream;

        private void Connect()
        {
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(address, 9999);
                listener.Start();
                Socket socket = listener.AcceptSocket();
            }
            catch
            {
                throw new Exception("lỗi không thể kết nối");
            }
        }

        public string KetQuaDem()
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnGraphChanged;

        public void Send()
        {


        }
        void GuiChoMayKhac(TcpClient tcp)
        {

        }



    }
}
