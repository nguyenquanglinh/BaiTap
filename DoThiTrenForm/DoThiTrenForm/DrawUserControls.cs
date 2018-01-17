using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace DoThiTrenForm
{
    interface DrawUserControls
    {
        void Draw(Canh canh);
    }
    public class DrawCanh : DrawUserControls
    {
        //f1 from1
        public Form f1;
        public DrawCanh(Form f1)
        {
            this.f1 = f1;
        }
        public void Draw(Canh canh)
        {

            var dDau = canh.DiemDau;
            var dCuoi = canh.DiemCuoi;
            var color = dCuoi.Color;
            using (Graphics g = f1.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(color, 2))
                {
                    g.DrawLine(p, dDau.Center, dCuoi.Center);
                }
            }
        }

        public void DrawHinh(Hinh hinh)
        {
            foreach (var canh in hinh.tapCanh)
            {
                Draw(canh);
            }
        }

        //public void

    }
}
