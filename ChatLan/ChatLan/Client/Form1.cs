using ChatLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        ChatClient client = new ChatClient(2302);

        public Form1()
        {
            InitializeComponent();
            client.Processors.Add(new ClientMessageProcessor());
            client.Processors.Add(new GuiProcess(this));
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect("client1");
        }

        class GuiProcess : IMessageProcess
        {
            private Form1 form;
            public GuiProcess(Form1 form)
            {
                this.form = form;
            }
            public void Process(ChatLib.MessageModel.ConnectMessageSuccess message)
            {
                this.form.Text = message.Sender;
            }

            public void Process(ChatLib.MessageModel.ConnectMessageFailed message)
            {
                this.form.richTextBox1.AppendText(message.Reason + "\n");
            }

            public void Process(ChatLib.MessageModel.ConnectMessageRequest message)
            {
                throw new NotImplementedException();
            }
        }

    }
}
