﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatlib
{
    public interface IMessageProcess
    {
        //yêu cầu kết nối đên server thành công
        void Process(MessageModel.ConnectMessageRequest connectMessageRequest);

        //kết nối thành công tới server
        void Process(MessageModel.ConnectMessageSuccess connectMessageSuccess);

        //gửi tin nhắn lỗi
        void Process(MessageModel.ConnecMessageFaile connecMessageFaile);

        //gửi tin nhắn
        void Process(MessageModel.SendMessage sendMessage);

        //nhận tin nhắn
        void Process(MessageModel.RecievedMessage recievedMessage);

        //gửi tin nhắn lỗi
        void Process(MessageModel.SendMessageFalse sendMessageFile);

        //gửi tin nhắn
        void Process(MessageModel.SenFile senFile);

        //nhận tin nhắn
        void Process(MessageModel.RecievedFile recievedFile);
        #region
        /// <summary>
        /// chưa làm được 
        /// </summary>
        /// <param name="senFileBig"></param>
        void Process(MessageModel.SendFileBig senFileBig);

        void Process(MessageModel.ReceiFileBig receiFileBig);
        #endregion
        void Process(MessageModel.SendLocationPlayerClick sendLocationPlayerClick);

        void Process(MessageModel.RecieveLoactionPlayerClick recieveLoactionPlayerClick);

    }
}