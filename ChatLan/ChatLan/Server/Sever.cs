using ChatLib;
using ChatLib.MessageModel;
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

namespace Server
{
    class ClientManager
    { 
        private static ClientManager instance = new ClientManager();
        public static ClientManager Instance { get { return instance; } }

        private ClientManager()
        {

        }

        List<MayKhach> dsMayKhach = new List<MayKhach>();

        public bool IsExist(string name)
        {
            return dsMayKhach.Any(x => x.TenMay == name);
        }

        public void Add(MayKhach client)
        {
            dsMayKhach.Add(client);
        }

        public void Remove(MayKhach client)
        {
            client.Dispose();
            dsMayKhach.Remove(client);
        }
    }

    public class MayChu
    {
        int Port = 2302;

        private ClientManager clientManager = ClientManager.Instance;

        public MayChu(int port)
        {
            this.Port = port;
        }

        public void Start()
        {

            Connect();
        }

        /// <summary>
        /// Start server và bắt đầu lắng nghe từ client
        /// </summary>
        void Connect()
        {
            var ip = new IPEndPoint(IPAddress.Any, Port);
            Socket Sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Sever.Bind(ip);
            Logging.Info("Server started");
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Sever.Listen(100);
                        var client = Sever.Accept();
                        var mayKhach = new MayKhach(client);
                        Logging.Info("Client connected");

                        Thread receive = new Thread(NhanTinVe);
                        receive.IsBackground = true;
                        receive.Start(mayKhach);
                    }
                }
                catch
                {
                    ip = new IPEndPoint(IPAddress.Any, Port);
                    Sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });

            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// Lấy dữ liệu từ máy khác
        /// </summary>
        /// <param name="obj"></param>
        void NhanTinVe(object obj)
        {
            var client = (MayKhach)obj;

            try
            {
                while (true)
                {
                    var data = client.Receive();
                    var message = ObjectConvert.Binnary2Object(data);
                    Logging.Debug("Recieved data from:" + client.TenMay);
                    var processor = new ServerMessageProcessor(clientManager, client);
                    message.Accept(processor);

                    foreach (var item in processor.Response)
                    {
                        SendToClient(client, item);
                    }
                }
            }
            catch
            {
                clientManager.Remove(client);
            }
        }

        private void SendToClient(MayKhach client, MessageBase message)
        {
            Logging.Debug("Send to:" + message.ToString());
            client.Send(ObjectConvert.Object2Binary(message));
        }

        //private void PhanLuongCauChat(string chuoi, MayKhach mayNhan)
        //{
        //    var tenMayKhach = LayTenMayKhachTrenServer(chuoi);
        //    if (mayNhan.TenMay == null)
        //    {
        //        if (KiemTraTenMayTrenServer(tenMayKhach))
        //        {
        //            dsMayKhach.Add(mayNhan);
        //            mayNhan.TenMay = tenMayKhach;
        //            mayNhan.SocKet.Send(XuLuTinDi("[]"));
        //        }
        //        else if (dsMayKhach.Count == 1)
        //            dsMayKhach[0].SocKet.Send(XuLuTinDi("[[]"));
        //        else
        //        {
        //            mayNhan.SocKet.Send(XuLuTinDi("[]]"));
        //            DongMayKhach(mayNhan);
        //        }
        //    }
        //    else if (KiemTraTenMayNhan(tenMayKhach))
        //    {
        //        var cauGui = LayCauChatDen(chuoi, tenMayKhach);
        //        var DsTenMayNhan = tenMayKhach.Remove(0, 1);
        //        DsTenMayNhan = DsTenMayNhan.Remove(DsTenMayNhan.Length - 1, 1);
        //        if (DsTenMayNhan == "/*")
        //        {
        //            ChuyenTin(cauGui, dsMayKhach, mayNhan.TenMay);
        //            return;
        //        }
        //        var ten = DsTenMayNhan.Split('&');
        //        var nhomChat = new List<MayKhach>();
        //        nhomChat.Add(mayNhan);
        //        foreach (var item in ten)
        //        {
        //            var tenMayGui = LayMayKhachTuongUng(item);
        //            if (tenMayGui != null)
        //                nhomChat.Add(tenMayGui);
        //            else
        //                mayNhan.SocKet.Send(XuLuTinDi("**/" + item));
        //        }
        //        ChuyenTin(cauGui, nhomChat, mayNhan.TenMay);
        //    }
        //    else
        //    {
        //        DongMayKhach(mayNhan);
        //        throw new Exception("lỗi");
        //    }
        //}

        //private bool KiemTraTenMayNhan(string chuoi)
        //{
        //    if (chuoi[0] == '@' && chuoi[chuoi.Length - 1] == '@')
        //        return true;
        //    return false;
        //}

        //string LayTenMayKhachTrenServer(string cauChat)
        //{
        //    var tpChat = cauChat.ToCharArray();
        //    var tenMay = "";
        //    for (int i = 1; i < tpChat.Length; i++)
        //    {
        //        if (tpChat[0] == '[' && tpChat[i] != ']')
        //            tenMay += tpChat[i];
        //        else break;
        //    }
        //    return tenMay;
        //}

        //string LayCauChatDen(string chuoi, string tenMay)
        //{
        //    if (tenMay.Length < 1)
        //        throw new Exception("lỗi");
        //    int chiSo = tenMay.Length + 2;
        //    var cauChat = "";
        //    for (int i = chiSo; i < chuoi.Length; i++)
        //    {
        //        cauChat += chuoi[i];
        //    }
        //    return cauChat;
        //}

        //MayKhach LayMayKhachTuongUng(string tenMay)
        //{
        //    foreach (var item in dsMayKhach)
        //    {
        //        if (item.TenMay == tenMay)
        //            return item;
        //    }
        //    return null;
        //}


        //private void ChuyenTin(string cauChat, List<MayKhach> dsMayChatChung, string tenMay)
        //{
        //    foreach (var may in dsMayChatChung.ToArray())
        //    {
        //        may.SocKet.Send(XuLuTinDi(tenMay + " : " + cauChat));
        //    }

        //}

    }
}
