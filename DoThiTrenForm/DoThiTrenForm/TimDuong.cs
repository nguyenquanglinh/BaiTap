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
    public partial class TimDuong : Form
    {
        public TimDuong()
        {
            InitializeComponent();
        }
        DoThi dt;
        public TimDuong(DoThi dt)
            : this()
        {
            // TODO: Complete member initialization
            this.dt = dt;
            LayTenHinhTron();
        }
        private void LayTenHinhTron()
        {

            cbbBd.Items.Clear();
            cbbKt.Items.Clear();
            foreach (var item in dt.tapDinh)
            {
                cbbBd.Items.Add(item.PointName);
                cbbKt.Items.Add(item.PointName);
            }
        }

        int bd = 0, kt = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            var dfs = new Dfs(dt);
            if (bd == kt)
            {
                MessageBox.Show("chọn lại điểm bắt đầu và kết thúc");
                return;
            }
            var ss = dfs.TimDuongMin(bd, kt);
            var draw = new DrawCanh(this);

            var dtt = new DoThi(draw);
            foreach (IDiem dinh in ss.tapDinh)
            {
                var diem = new Diem(dtt, draw) { Location = new Point(dinh.Center.X, dinh.Center.Y), Color = Color.Blue, };
                this.Controls.Add(diem);
            }
            foreach (var canh in ss.tapCanh)
            {
                draw.Draw(canh);
            }
        }

        private void cbbBd_SelectedIndexChanged(object sender, EventArgs e)
        {
            bd = int.Parse(cbbBd.SelectedItem.ToString());
        }

        private void cbbKt_SelectedIndexChanged(object sender, EventArgs e)
        {
            kt = int.Parse(cbbKt.SelectedItem.ToString());
        }
    }
}
