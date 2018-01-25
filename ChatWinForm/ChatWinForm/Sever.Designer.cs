namespace ChatWinForm
{
    partial class Sever
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
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.KhungChat = new System.Windows.Forms.ListView();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnGui = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(23, 0);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(73, 23);
            this.btnKetNoi.TabIndex = 5;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            // 
            // KhungChat
            // 
            this.KhungChat.Location = new System.Drawing.Point(0, 33);
            this.KhungChat.Name = "KhungChat";
            this.KhungChat.Size = new System.Drawing.Size(410, 297);
            this.KhungChat.TabIndex = 4;
            this.KhungChat.UseCompatibleStateImageBehavior = false;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(-11, 336);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(321, 29);
            this.txtChat.TabIndex = 7;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(316, 339);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(79, 23);
            this.btnGui.TabIndex = 6;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            // 
            // Sever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.KhungChat);
            this.Name = "Sever";
            this.Size = new System.Drawing.Size(509, 390);
            this.Load += new System.EventHandler(this.Sever_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.ListView KhungChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnGui;

    }
}
