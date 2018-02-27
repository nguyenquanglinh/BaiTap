using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatlib
{
    public class MessagerProcessorBase : IMessageProcess
    {
        virtual public void Process(MessageModel.ConnectMessageRequest connectMessageRequest)
        {
        }

        virtual public void Process(MessageModel.ConnectMessageSuccess connectMessageSuccess)
        {
        }

        virtual public void Process(MessageModel.ConnecMessageFaile connecMessageFaile)
        {
        }

        virtual public void Process(MessageModel.SendMessage sendMessage)
        {
        }

        virtual public void Process(MessageModel.RecievedMessage recievedMessage)
        {
        }

        virtual public void Process(MessageModel.SendMessageFalse sendMessageFile)
        {
        }

        virtual public void Process(MessageModel.SenFile senFile)
        {
        }

        virtual public void Process(MessageModel.RecievedFile recievedFile)
        {
        }

        virtual public void Process(MessageModel.SendFileBig senFileBig)
        {
        }

        virtual public void Process(MessageModel.ReceiFileBig receiFileBig)
        {
        }

        virtual public void Process(MessageModel.SendLocationPlayerClick sendLocationPlayerClick)
        {
        }

        virtual public void Process(MessageModel.RecieveLoactionPlayerClick recieveLoactionPlayerClick)
        {
        }
    }
}
