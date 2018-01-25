namespace Sever
{
    partial class MayChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.KhungChat = new System.Windows.Forms.ListView();
            this.txtCauChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(181, 33);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // KhungChat
            // 
            this.KhungChat.Location = new System.Drawing.Point(3, 12);
            this.KhungChat.Name = "KhungChat";
            this.KhungChat.Size = new System.Drawing.Size(279, 219);
            this.KhungChat.TabIndex = 4;
            this.KhungChat.UseCompatibleStateImageBehavior = false;
            this.KhungChat.View = System.Windows.Forms.View.List;
            // 
            // txtCauChat
            // 
            this.txtCauChat.Location = new System.Drawing.Point(3, 229);
            this.txtCauChat.Name = "txtCauChat";
            this.txtCauChat.Size = new System.Drawing.Size(232, 20);
            this.txtCauChat.TabIndex = 5;
            // 
            // MayChu
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.KhungChat);
            this.Controls.Add(this.txtCauChat);
            this.Name = "MayChu";
            this.Text = "Máy chủ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MayChu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView KhungChat;
        private System.Windows.Forms.TextBox txtCauChat;
    }
}

