using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoThiTrenForm
{
    public partial class Form1 : Form
    {
        DoThi doThi;
        public Form1()
        {
            InitializeComponent();
            draw = new DrawCanh(this);
            doThi = new DoThi(draw);
            Diem diem = new Diem(doThi, draw);

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            var diem = new Diem(doThi, draw) { Location = new Point(e.Location.X, e.Location.Y), Color = Color.Blue, };
            if (OverLap(diem))
            {
                doThi.ThemDinh(diem);
                this.Controls.Add(diem);
            }

        }
        bool OverLap(Diem diem)
        {
            foreach (var dinh in doThi.tapDinh)
            {
                if (dinh.Overlap(diem))
                    return false;
            }
            return true;
        }


        private void btnTimDuong_Click(object sender, EventArgs e)
        {
            var f2 = new TimDuong(doThi);
            f2.Show();
        }
        IThuatToan dfs;
        DrawCanh draw;
        private void cbbThuatToan_SelectedValueChanged(object sender, EventArgs e)
        {
            string thuatToan = cbbThuatToan.SelectedItem.ToString();
            if (thuatToan == "bfs")
            {
                MessageBox.Show("chưa làm bfs");
                return;

            }
            else
            {
                dfs = new Dfs(doThi);
            }

        }

        private void btnToMau_Click(object sender, EventArgs e)
        {
            if (doThi.tapDinh.Count == 0)
            {
                MessageBox.Show("chưa có gì để tô màu");
                return;
            }

            if (dfs == null)
            {
                MessageBox.Show("bạn chưa chọn kiểu duyệt");
                return;
            }
            var soDothi = dfs.DemDoThi();
            if (soDothi.Count == 0)
            {
                MessageBox.Show("không có đồ thị liên thông");
            }
            foreach (var hinh in soDothi)
            {
                draw.DrawHinh(hinh);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f2 = new LuuFile_DocFile(doThi, draw);

            f2.Show();
        }

        private void btnThuTuDuyet_Click(object sender, EventArgs e)
        {
            var f2 = new ThuTuDuyet(doThi);
            f2.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);
            }
        }


    }
}
