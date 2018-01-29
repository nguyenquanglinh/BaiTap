using ChatLib;
using ChatLib.MessageModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formMain : Form
    {
        ChatClient client = new ChatClient(2302);

        public formMain()
        {
            InitializeComponent();
            //client.Processors.Add(new ClientMessageProcessor());
            client.Processors.Add(new GuiProcess(this));
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(txtName.Text);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.Send(new SendMessage(txtName.Text, this.txtTo.Text, txtInput.Text));
        }

        class GuiProcess : MessageProcessorBase
        {
            private formMain form;
            public GuiProcess(formMain form)
            {
                this.form = form;
            }
            public override void Process(ChatLib.MessageModel.ConnectMessageSuccess message)
            {
                this.form.Text = message.Sender;
            }

            public override void Process(ChatLib.MessageModel.ConnectMessageFailed message)
            {
                this.form.richTextBox1.AppendText(message.Reason + "\n");
            }

            public override void Process(RecievedMessage message)
            {
                this.form.richTextBox1.AppendText(string.Format("{0}: {1} \n", message.From, message.Message));
            }

            public override void Process(RecievedFile recievedFile)
            {
                this.form.richTextBox1.AppendText("Recieve from " + recievedFile.From + " file name:" + recievedFile.FileName);
                File.WriteAllBytes("d:/chat/" + recievedFile.FileName, recievedFile.ByteData);
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                client.Send(new SendFile(txtName.Text, this.txtTo.Text, File.ReadAllBytes(ofd.FileName), Path.GetFileName(ofd.FileName)));

            }
        } 
    }
}
