using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.MessageModel
{
    /// <summary>
    /// Đổi tượng message cho phần mềm chat,
    ///  Tất các gói tin đều sẽ được gửi theo đối tượng kế thừa từ đối tượng này 
    /// </summary>
    [Serializable]
    abstract public class MessageBase
    {

        /// <summary>
        /// Xử lý message bởi processor
        /// </summary>
        /// <param name="processor"></param>
        /// <returns></returns>
        public abstract void Accept(IMessageProcess processor);

        /// <summary>
        /// Tên người gửi
        /// </summary>
        public string Sender { get; set; }

        public MessageBase(string name)
        {
            this.Sender = name;
        }
    }

    /// <summary>
    /// Gói tin báo đã connect kèm theo tên
    /// </summary>
    [Serializable]
    public class ConnectMessageRequest : MessageBase
    {
        public ConnectMessageRequest(string name)
            : base(name)
        {

        }

        public override void Accept(IMessageProcess processor)
        {
            processor.Process(this);
        }


    }


    /// <summary>
    /// Gói tin báo connect kèm theo tên
    /// </summary>
    [Serializable]
    public class ConnectMessageSuccess : MessageBase
    {
        public ConnectMessageSuccess(string name)
            : base(name)
        {

        }
        public override void Accept(IMessageProcess processor)
        {
            processor.Process(this);
        }

    }


    /// <summary>
    /// Gói tin báo đã connect lỗi 
    /// </summary>
    [Serializable]
    public class ConnectMessageFailed : MessageBase
    {
        /// <summary>
        /// Chi tiết lỗi
        /// </summary>
        public string Reason { get; set; }

        public ConnectMessageFailed(string name)
            : base(name)
        {

        }
        public override void Accept(IMessageProcess processor)
        {
            processor.Process(this);
        }
    }



}
