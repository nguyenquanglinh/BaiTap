using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ChatLib;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLib;
using ChatLib.MessageModel;
using System.IO;

namespace ChatForm
{
    public partial class MayKhach : Form
    {
        ClientChat client;
        public MayKhach()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            client = new ClientChat(2302);
            client.Processor.Add(new SendProcess(this));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.Send(new SendMessage(txtUserName.Text, txtReceive.Text, txtMessage.Text));
            ThemCauChat(txtMessage.Text);
        }






        #region
        class SendProcess : MessagerProcessorBase
        {
            MayKhach form;
            //1 hàm tạo
            public SendProcess(MayKhach form)
            {
                this.form = form;
            }
            //2 tên máy khách
            public override void Process(ChatLib.MessageModel.ConnectMessageSuccess message)
            {
                this.form.Text = message.NameSender;
            }
            //3 gửi tin nhắn thất bại
            public override void Process(ChatLib.MessageModel.ConnecMessageFaile message)
            {
                this.form.KhungChat.AppendText(message.Exception + "\n");
            }
            //5 nhận được file
            public override void Process(ChatLib.MessageModel.RecievedFile message)
            {
                this.form.KhungChat.AppendText("Recieve from " + message.NameSender + " file name:" + message.FileName);
                File.WriteAllBytes("d:/chat/" + message.FileName, message.ByteData);

            }
            //4 nhận được tin nhắn
            public override void Process(ChatLib.MessageModel.RecievedMessage message)
            {
                this.form.KhungChat.AppendText(string.Format("{0}: {1} \n", message.Form, message.Message));
            }


        }
        #endregion

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var file = File.ReadAllBytes(open.FileName);
                if (file.Length > 1024)
                {
                    var tepFile = ChuyenFileLon(file);
                    client.Send(new SendFileBig(txtUserName.Text, txtReceive.Text, Path.GetFileName(open.FileName), tepFile.Count));
                    for (int i = 0; i < tepFile.Count; i++)
                    {
                        client.Send(new SendFileBig(i.ToString(), tepFile[i]));
                    }
                }
                else
                {
                    client.Send(new SenFile(txtUserName.Text, File.ReadAllBytes(open.FileName), txtReceive.Text, Path.GetFileName(open.FileName)));
                    ThemCauChat("đã gửi file " + open.FileName);
                }
            }
        }

        private List<byte[]> ChuyenFileLon(byte[] file)
        {
            var result = new List<byte[]>();
            for (int i = 0; i < file.Length; i += 1024)
            {
                result.Add(LayFileDuLon(i, file));
            }
            return result;
        }

        private byte[] LayFileDuLon(int p1, byte[] file)
        {
            var data = new byte[1024];
            int x;
            for (int i = 0; i < 1024; i++)
            {
                if (i + p1 < file.Length)
                    data[i] = file[p1 + i];
                else break;
            }
            return data;
        }
        private void ThemCauChat(string cauChat)
        {
            this.KhungChat.AppendText(cauChat + "\n");
            txtMessage.Clear();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(txtUserName.Text);
        }
    }
}
