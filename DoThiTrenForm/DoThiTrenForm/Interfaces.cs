using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{

    public interface IDoThi
    {
        List<ICanh> TapCanh { get; set; }

        void ThemCanh(Canh canh);
        void ThemDinh(IDiem diemDinh);
        void XoaMotDiem(IDiem diemClick);
    }

    public interface IDiem
    {
        Point Center { get; }
        Color Color { get; set; }
        bool Overlap(Diem other);
        string PointName { get; set; }
    }

    public interface ICanh
    {
        IDiem DiemCuoi { get; set; }
        IDiem DiemDau { get; set; }
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
