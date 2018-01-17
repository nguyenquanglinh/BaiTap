using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoThiTrenForm
{
    public partial class Diem : UserControl, IDiem
    {
        public Diem()
        {
            InitializeComponent();
            this.Color = System.Drawing.Color.Red;
        }

        //static DoThi dT;
        //static DrawCanh draW;

        //public Diem(DoThi dt, DrawCanh draw)
        //    : this()
        //{
        //    dT = dt;
        //    draW = draw;
        //}

        Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; this.Invalidate(); }
        }

        public string PointName
        {
            get { return txtName.Text; }
            set
            {
                txtName.Text = value;
                if (string.IsNullOrEmpty(value))
                    txtName.Text = "";
            }
        }

        public Point Center
        {
            get
            {
                return new Point(Location.X + Width / 2, Location.Y + Height / 2);
            }
        }

        public bool Overlap(Diem other)
        {
            return other.Bounds.IntersectsWith(this.Bounds);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush sb = new SolidBrush(Color);
            Graphics g = this.CreateGraphics();
            g.FillEllipse(sb, 0, 0, 60, 60);
            g.Dispose();
            sb.Dispose();
        }
         

        private void Diem_Click(object sender, EventArgs e)
        {
            //var ht = sender as IDiem;
            //ht.Color = Color.Red;

            //if (lastedClick == null)
            //{
            //    lastedClick = ht;
            //    return;
            //}
            //if (ht.Equals(lastedClick))
            //{
            //    ht.Color = Color.Blue;
            //    lastedClick = null;
            //    return;
            //}
            //ht.Color = Color.Blue;
            //lastedClick.Color = Color.Blue;
            //canhMoi = new Canh(lastedClick, ht);
            //if (!dT.tapCanh.Contains(canhMoi))
            //{
            //    dT.ThemCanh(canhMoi);
            //    draW.Draw(canhMoi);
            //}
            //lastedClick = null;
        }

        private void Diem_DoubleClick(object sender, EventArgs e)
        {
            if (this.OnDoubleClick != null)
                this.OnDoubleClick(this, new DiemDoubleClickedArgs { Name = this.PointName });
   
        }

        public override string ToString()
        {
            return this.Center.X.ToString() + " " + this.Center.Y.ToString();
        }

        public event EventHandler<DiemDoubleClickedArgs> OnDoubleClick;
    }

    public class DiemDoubleClickedArgs : EventArgs
    {
        public string Name { get; set; }

    }
}
