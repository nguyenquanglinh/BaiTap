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

namespace DoThiTrenForm
{
    public partial class LuuFile_DocFile : Form
    {
        public LuuFile_DocFile()
        {
            InitializeComponent();
        }
        string path = "D:\\BaiTap1\\TimDuongTrenForm\\Data\\";
        FileText fileText;
        public LuuFile_DocFile(DoThi dt, DrawCanh draw)
            : this()
        {
            fileText = new FileText(dt, draw); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tenThuMuc = Directory.GetFiles(path);
            if (tenThuMuc.Length == 0)
            {
                MessageBox.Show("chưa có file nào được lưu");
                return;
            }
            var tapTen = new List<string>();
            cbbFileDaLuu.Enabled = true;
            btnDoc.Enabled = true;
            foreach (string fileName in tenThuMuc)
            {
                string tenFile = "";
                tenFile = Path.GetFileName(fileName).Trim();
                tenFile = tenFile.Remove(tenFile.Length - 4, 4);
                cbbFileDaLuu.Items.Add(tenFile);
            }
        }

        string fileName;

        private void btnDoc_Click(object sender, EventArgs e)
        {
            if(fileName==null)
            {
                MessageBox.Show("chưa chọn file đọc");
                return;
            }

            fileText.DocFile(fileName);
            if (MessageBox.Show("bạn phải thoát ", "thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            fileText.LuuFile(txtDinh.Text);
            MessageBox.Show("hoàn thành");
        }

        private void cbbFileDaLuu_SelectedValueChanged(object sender, EventArgs e)
        {
            fileName = cbbFileDaLuu.SelectedItem.ToString();
        }
    }
}
