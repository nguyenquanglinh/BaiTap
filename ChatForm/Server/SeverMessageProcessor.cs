using ChatLib;
using ChatLib.MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    class SeverMessageProcessor : MessagerProcessorBase
    {
        private MayKhach client;
        private ClientManager clientManager;
        public List<MessageBaser> ListReiceveMassager { get; set; }

        public SeverMessageProcessor(MayKhach client, ClientManager clientManage)
        {
            this.clientManager = clientManage;
            this.client = client;
            ListReiceveMassager = new List<MessageBaser>();
        }
        /// <summary>
        /// override obj messager base
        /// </summary>
        /// <param name="message"></param>
        public override void Process(ChatLib.MessageModel.SendMessage message)
        {
            var clientName = message.NameSender;
            var nguoiNhan = message.SendTo;
            if (nguoiNhan == "*")
            {
                foreach (var item in clientManager.GetAll())
                    this.ListReiceveMassager.Add(new RecievedMessage(item.TenMay, message.Message) { Form = message.NameSender, Client = item });
                return;
            }
            if (!clientManager.IsCounterName(message.NameSender))
            {
                this.ListReiceveMassager.Add(new SendMessageFalse(clientName, message.Message, "người nhận không tồn tại " + nguoiNhan));
            }
            else
            {
                this.ListReiceveMassager.Add(new RecievedMessage(clientName, message.Message) { Form = clientName, Client = clientManager.Get(nguoiNhan) });
            }
        }

        public override void Process(ConnectMessageRequest message)
        {
            var clientName = message.NameSender;
            if (clientManager.IsCounterName(clientName))
                this.ListReiceveMassager.Add(new ConnecMessageFaile(clientName) { Exception = "Name =counter name=true " });
            else
            {
                client.TenMay = message.NameSender;
                this.ListReiceveMassager.Add(new ConnectMessageSuccess(clientName));
                this.clientManager.Add(client);
            }
        }

        public override void Process(SenFile message)
        {
            var clientName = message.NameSender;
            var nguoiNhan = message.SendTo;

            if (nguoiNhan == "*")
            {
                foreach (var item in clientManager.GetAll())
                    this.ListReiceveMassager.Add(new RecievedFile(clientName, item.TenMay, message.FileName, message.ByteData) { Client = item });
                return;
            }

            if (!clientManager.IsCounterName(nguoiNhan))
            {
                //Nếu người gửi không tồn tại 
                this.ListReiceveMassager.Add(new SendMessageFalse(clientName, "không thể gửi file", "lỗi:không có người nhận"));
            }
            else
            {
                this.ListReiceveMassager.Add(new RecievedFile(clientName, nguoiNhan, message.FileName, message.ByteData) { Client = clientManager.Get(nguoiNhan) });
            }
        }
        /// <summary>
        /// chưa làm được
        /// </summary>
        /// <param name="message"></param>
        public override void Process(SendFileBig message)
        {
            var clientName = message.NameSender;
            var nguoiNhan = message.SendTo;
            if (nguoiNhan == "*")
            {
                foreach (var item in clientManager.GetAll())
                    this.ListReiceveMassager.Add(new ReceiFileBig(clientName, message.FileName, message.SendTo, message.DaTaBig) { Client = item });
                return;
            }
            if (!clientManager.IsCounterName(message.NameSender))
            {
                this.ListReiceveMassager.Add(new SendMessageFalse(clientName, "lỗi ", "người nhận không tồn tại " + nguoiNhan));
            }
            else
            {
                this.ListReiceveMassager.Add(new ReceiFileBig(clientName, message.FileName, message.SendTo, message.DaTaBig) { Client = clientManager.Get(nguoiNhan) });
            }
        }

    }

}

