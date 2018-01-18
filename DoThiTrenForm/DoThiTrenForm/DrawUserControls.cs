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

    public class GrapDrawler : IGraphDrawler
    {
        public Panel f1;
        public GrapDrawler(Panel f1)
        {
            this.f1 = f1;
        }

        void Draw(ICanh canh)
        {
            var dDau = canh.DiemDau;
            var dCuoi = canh.DiemCuoi;

            using (Graphics g = f1.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(canh.Color, 2))
                    g.DrawLine(p, dDau.Center, dCuoi.Center);
            }
        }

        public void Draw(IDoThi doThi)
        {
            foreach (var item in doThi.TapDinh)
                this.f1.Controls.Add(item as Diem);
            UpdateEdge(doThi);
        }

        public void UpdateEdge(IDoThi doThi)
        {
            foreach (var item in doThi.TapCanh)
                Draw(item);
           
        }
    }
}
