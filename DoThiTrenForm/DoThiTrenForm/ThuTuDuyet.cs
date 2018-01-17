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
    public partial class ThuTuDuyet : Form
    {
        public ThuTuDuyet()
        {
            InitializeComponent();
        }
        DoThi dt;
        public ThuTuDuyet(DoThi dt)
            : this()
        {
            this.dt = dt;
            CacDinhDuyet();
        }

        private void CacDinhDuyet()
        {
            foreach (var item in dt.tapDinh)
            {
                comboBox1.Items.Add(item.PointName);
            }
        }
        int dinh;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dinh = int.Parse(comboBox1.SelectedItem.ToString());
       
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            var dfs = new Dfs(dt);
           var hinh= dfs.ThuTuDuyetDinh(dinh);
           foreach (var dinhDuyet in hinh.tapDinh)
           {
               MessageBox.Show(dinhDuyet.PointName);
           }
        }
    }
}
