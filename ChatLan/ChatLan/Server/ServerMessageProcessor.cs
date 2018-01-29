using ChatLib;
using ChatLib.MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMessageProcessor : IMessageProcess
    {
        private ClientManager clientManager;
        private MayKhach client;

        public ServerMessageProcessor(ClientManager manager, MayKhach client)
        {
            this.clientManager = manager;
            this.client = client;
            Response = new List<MessageBase>();
        }

        public List<MessageBase> Response { get; set; }

        public void Process(ChatLib.MessageModel.ConnectMessageSuccess message)
        {
            throw new NotImplementedException();
        }

        public void Process(ChatLib.MessageModel.ConnectMessageFailed message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Server xử lý gói tin ConnectMessageRequest
        /// </summary>
        /// <param name="message"></param>
        public void Process(ChatLib.MessageModel.ConnectMessageRequest message)
        {
            var clientName = message.Sender;
            if (clientManager.IsExist(clientName))
            {
                //Nếu đã tồn tại client có tên này 
                this.Response.Add(new ConnectMessageFailed(clientName) { Reason = "Name already exists on server" });

            }
            else
            {

                client.TenMay = message.Sender;
                this.Response.Add(new ConnectMessageSuccess(clientName));
                this.clientManager.Add(client);
            }
        }
    }
}
