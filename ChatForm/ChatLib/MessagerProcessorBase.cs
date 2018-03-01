using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class MessagerProcessorBase : IMessageProcess
    {
        virtual public void Process(MessageModel.ConnectMessageSuccess message) { }

        virtual public void Process(MessageModel.ConnecMessageFaile message) { }

        virtual public void Process(MessageModel.ConnectMessageRequest message) { }

        virtual public void Process(MessageModel.SendMessage message) { }

        virtual public void Process(MessageModel.RecievedMessage message) { }

        virtual public void Process(MessageModel.RecievedFile message) { }

        virtual public void Process(MessageModel.SendMessageFalse message) { }

        virtual public void Process(MessageModel.SenFile message) { }

        virtual public void Process(MessageModel.SendFileBig message) { }
        /// <summary>
        /// chưa làm được
        /// </summary>
        /// <param name="message"></param>
        virtual public void Process(MessageModel.ReceiFileBig message) { }



        virtual public void Process(MessageModel.SendLocationPlayerClick sendLocationPlayerClick)
        {
        }

        virtual public void Process(MessageModel.RecieveLoactionPlayerClick recieveLoactionPlayerClick)
        {
        }
    }
}
