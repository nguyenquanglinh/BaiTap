namespace ChatWinForm
{
    partial class Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KhungChat = new System.Windows.Forms.ListView();
            this.btnGui = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KhungChat
            // 
            this.KhungChat.Location = new System.Drawing.Point(0, 36);
            this.KhungChat.Name = "KhungChat";
            this.KhungChat.Size = new System.Drawing.Size(417, 297);
            this.KhungChat.TabIndex = 0;
            this.KhungChat.UseCompatibleStateImageBehavior = false;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(327, 339);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(79, 23);
            this.btnGui.TabIndex = 1;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(0, 336);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(321, 29);
            this.txtChat.TabIndex = 2;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(29, 3);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(73, 23);
            this.btnKetNoi.TabIndex = 3;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.KhungChat);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(440, 371);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView KhungChat;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnKetNoi;
    }
}
