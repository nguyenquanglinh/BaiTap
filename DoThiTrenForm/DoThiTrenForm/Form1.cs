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
    public partial class Form1 : Form
    {
        IDoThi doThi;
        CacFile doFile = new FileText();
        GrapDrawler drawler;
        public Form1()
        {
            InitializeComponent();
            doThi = new DoThi();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("không được chọn vào đây");
        }

        private bool OverLap(Diem diem)
        {
            foreach (var dinh in doThi.TapDinh)
                if (dinh.Overlap(diem))
                    return true;
            return false;
        }

        void VeDoThi()
        {
            this.panel.Controls.Clear();
            drawler = new GrapDrawler(this.panel);
            drawler.Draw(this.doThi);
            this.panel.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.panel.Controls.Clear();
                var fileName = Path.GetFileNameWithoutExtension(ofd.FileName);
                doThi = doFile.DocFile(fileName);
                doThi.OnGraphChanged += doThi_OnGraphChanged;
                VeDoThi();
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (drawler != null && doThi != null)
                drawler.UpdateEdge(doThi);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = Path.GetFileNameWithoutExtension(ofd.FileName);
                doFile.LuuFile(fileName, doThi);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            var diem = new Diem() { Location = new Point(e.Location.X, e.Location.Y), Color = Color.Blue, };
            if (!OverLap(diem))
            {
                doThi.ThemDinh(diem);
                this.panel.Controls.Add(diem);
                doThi.OnGraphChanged += doThi_OnGraphChanged;
            }
        }
        void doThi_OnGraphChanged(object sender, EventArgs e)
        {
            VeDoThi();
        }

    }
}
